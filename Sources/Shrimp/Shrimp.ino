//
//     FILE: Shrimp.ino
//   AUTHOR: Philip de Bruin
//  VERSION: 1.1
//  PURPOSE: For school assesment
//

#include "Arduino.h"

// Include temperature sensor library
#include <OneWire.h>
#include <DallasTemperature.h>
// Include libraries for database
#include <EEPROM.h>
#include <String.h>

// Pins
const int TemperatureSensorPin = 8;

// Variables to use for the interval
unsigned long previousMillis = 0;
unsigned long previousLogMillis = 0;
unsigned long logDelay = 0;                       // Log delay in milliseconds
int logInterval = 0;                             // Log interval in milliseconds

// Variables
OneWire ds(TemperatureSensorPin);
DallasTemperature sensors(&ds);

long travelTime; // Total travel time in s
boolean travelTimeSet = false;
int maxLogs = 503;
String msg;
boolean logData = false;
char buffer[25];

double avgTemp;

int addr = 18;

void EEPROMWritelong(int address, long value) {
      //Decomposition from a long to 4 bytes by using bitshift.
      //One = Most significant -> Four = Least significant byte
      byte four = (value & 0xFF);
      byte three = ((value >> 8) & 0xFF);
      byte two = ((value >> 16) & 0xFF);
      byte one = ((value >> 24) & 0xFF);

      //Write the 4 bytes into the eeprom memory.
      EEPROM.write(address, four);
      EEPROM.write(address + 1, three);
      EEPROM.write(address + 2, two);
      EEPROM.write(address + 3, one);
}

long EEPROMReadlong(long address) {
      //Read the 4 bytes from the eeprom memory.
      long four = EEPROM.read(address);
      long three = EEPROM.read(address + 1);
      long two = EEPROM.read(address + 2);
      long one = EEPROM.read(address + 3);

      //Return the recomposed long by using bitshift.
      return ((four << 0) & 0xFF) + ((three << 8) & 0xFFFF) + ((two << 16) & 0xFFFFFF) + ((one << 24) & 0xFFFFFFFF);
}

//This function will write a 2 byte integer to the eeprom at the specified address and address + 1
void EEPROMWriteInt(int address, int value) {
     byte lowByte = ((value >> 0) & 0xFF);
     byte highByte = ((value >> 8) & 0xFF);

     EEPROM.write(address, lowByte);
     EEPROM.write(address + 1, highByte);
}

//This function will read a 2 byte integer from the eeprom at the specified address and address + 1
unsigned int EEPROMReadInt(int address) {
     byte lowByte = EEPROM.read(address);
     byte highByte = EEPROM.read(address + 1);

     return ((lowByte << 0) & 0xFF) + ((highByte << 8) & 0xFF00);
}

void scanSensors(void) {
  byte i;
  byte present = 0;
  byte data[12];
  byte addr[8];
  while (ds.search(addr)) {
    Serial.print("R=");
    for( i = 0; i < 8; i++) {
      Serial.print(addr[i], HEX);
      Serial.print(" ");
    }
  
    if ( OneWire::crc8( addr, 7) != addr[7]) {
        Serial.print("CRC is not valid!\n");
        return;
    }
    
    if ( addr[0] == 0x10) {
        Serial.print("Device is a DS18S20 family device.\n");
    } else {
        Serial.print("Device is unknown!\n");
        Serial.print("Device ID: ");
        Serial.print(addr[0],HEX);
        Serial.println();
        return;
      }
    
    // The DallasTemperature library can do all this work for you!
    ds.reset();
    ds.select(addr);
    ds.write(0x44,1);         // start conversion, with parasite power on at the end
    delay(1000);     // maybe 750ms is enough, maybe not
    // we might do a ds.depower() here, but the reset will take care of it.
    present = ds.reset();
    ds.select(addr);    
    ds.write(0xBE);         // Read Scratchpad
    Serial.print("P=");
    Serial.print(present,HEX);
    Serial.print("  ");
    for ( i = 0; i < 9; i++) {           // we need 9 bytes
      data[i] = ds.read();
      Serial.print(data[i], HEX);
      Serial.print(" ");
    }
    Serial.print(" CRC=");
    Serial.print( OneWire::crc8( data, 8), HEX);
    Serial.println();
  }
  Serial.print("No more addresses.\n");
  ds.reset_search();
  delay(250);
}

void setup() {
    if (EEPROMReadInt(0)) logInterval = (int) EEPROMReadInt(0);
    if (EEPROM.read(2)) logData = (boolean) EEPROM.read(2);
    if (EEPROMReadlong(3)) previousLogMillis = (long) EEPROMReadlong(3);
    if (EEPROM.read(7)) travelTimeSet = (boolean) EEPROM.read(7);
    if (EEPROMReadlong(8)) logDelay = (int) EEPROMReadInt(8);
    if (EEPROMReadlong(12)) travelTime = (long) EEPROMReadlong(10);
    if (EEPROMReadInt(16)) addr = (int) EEPROMReadInt(16);
    
    if (logInterval <= 1000) logData = false;
    
    Serial.begin(9600);
    
    sensors.begin();
    scanSensors();
}

void loop() {
    // put your main code here, to run repeatedly:
    while (Serial.available()) {
        boolean msgComplete = false;
        char recieved = Serial.read();
        if (recieved != '\n') msg += recieved;       
        else msgComplete = true;

        if (msgComplete) {
            if (msg == "viewData") readData();
            else if (msg == "stopLogging") {
                Serial.println("Stopping with logging data");
                logData = false;
            } else if (msg == "setTravelTime") setTravelTime();
            else if (msg == "viewAvgTemp") {
                calcAvgTemp();
                Serial.print("avgTemp: "); Serial.println(avgTemp);
            } else if (msg == "clearData") clearData();
            else if (msg == "viewTemp") Temp();
            else if (msg == "addr") Serial.println(addr);
            
            msg = "";
            msgComplete = false;
        }
    }
  
    unsigned long currentMillis = millis();
  
    if (currentMillis - previousMillis >= logInterval * 1000 && logData && addr < 1024) {
        previousMillis = currentMillis;
      
        readTempSensor();
    }
    
    if (travelTimeSet && currentMillis - previousLogMillis >= logDelay) {
        setLogInterval();
    }
}

void readData() {
    Serial.println("-----");
    for (int i = 18; i < addr; i+=2) {
        double x = (EEPROMReadInt(i) / 100);
        Serial.print("Temperature: ");
        Serial.print(x, 2);
        Serial.println("°C");
    } 
}

void clearData() {
    for ( int i = 0 ; i < 1024 ; i++ ) EEPROM.write(i, 0);
    logData = false;
    addr = 18;
    EEPROMWriteInt(16, addr);
    Serial.println("Data succesfully cleared");
}

void setTravelTime() {
    Serial.println("set travel time in sec");
    while (Serial.available() == 0) { }
    travelTime = Serial.parseInt();
    
    while (Serial.available() == 0) { }
    logDelay = (long) Serial.parseInt();
    previousLogMillis = millis();
    travelTimeSet = true;
    Serial.print("Shrimp starts logging over ");
    Serial.print(logDelay);Serial.println(" milliseconds");
    
    EEPROMWritelong(3, previousLogMillis);
    EEPROM.write(7,travelTimeSet);
    EEPROMWritelong(8,logDelay);
    EEPROMWritelong(12, travelTime);
}

void setLogInterval() {
    logInterval = travelTime / maxLogs;
    logData = true;
    EEPROMWriteInt(0,logInterval);
    EEPROM.write(2,logData);
}

void readTempSensor() {
    sensors.requestTemperatures();
    double temp = sensors.getTempCByIndex(0);
    EEPROMWriteInt(addr, (int) (temp * 100));
    
    addr += 2;
    
    EEPROMWriteInt(16, addr);
}

void calcAvgTemp() {
    double totalTemp = 0;
    int cases = 0;
    for (int i = 18; i < addr; i+=2) {
        totalTemp += ((double) EEPROMReadInt(i) / 100);
        cases++;
    }
    avgTemp = totalTemp / cases;
}

void Temp() {
    Serial.println("Start");
    for (int i = 18; i < addr; i+=2)
        Serial.println(((double) EEPROMReadInt(i) / 100), 2);
    Serial.println("End");
}
