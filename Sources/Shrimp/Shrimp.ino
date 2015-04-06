//
//     FILE: Shrimp.ino
//   AUTHOR: Philip de Bruin
//  VERSION: 0.1
//  PURPOSE: For school assesment
//
//

#include "Arduino.h"

// Include temperature and humidity sensor library
#include <dht11.h>
// Include libraries for database
#include <EEPROM.h>
#include <String.h>

// Pins
//const int ledPin = 13;
const int dht11Pin = 8;

// Variables to use for the interval
unsigned long previousMillis = 0;
unsigned long previousLogMillis = 0;
unsigned long logDelay = 0;                       // Log delay in milliseconds
int logInterval = 0;                             // Log interval in milliseconds

// Variables
dht11 DHT11;
long travelTime; // Total travel time in s
boolean travelTimeSet = false;
int maxLogs = 503;
String msg;
boolean logData = false;

int avgHumidity;
int avgTemp;

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

void setup() {
    if (EEPROMReadInt(0)) logInterval = (int) EEPROMReadInt(0);
    if (EEPROM.read(2)) logData = (boolean) EEPROM.read(2);
    if (EEPROMReadlong(3)) previousLogMillis = (long) EEPROMReadlong(3);
    if (EEPROM.read(7)) travelTimeSet = (boolean) EEPROM.read(7);
    if (EEPROMReadlong(8)) logDelay = (int) EEPROMReadInt(8);
    if (EEPROMReadlong(12)) travelTime = (long) EEPROMReadlong(10);
    if (EEPROMReadInt(16)) addr = (int) EEPROMReadInt(14);
    
    if (logInterval <= 1000) logData = false;
    
    DHT11.attach(dht11Pin);
    Serial.begin(9600);
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
            else if (msg == "viewAvgHumidity") {
                calcAvgHumidity();
                Serial.print("avgHumi: ");Serial.println(avgHumidity);
            } else if (msg == "viewAvgTemp") {
                calcAvgTemp();
                Serial.print("avgTemp: ");Serial.println(avgTemp);
            } else if (msg == "clearData") clearData();
            else if (msg == "viewTemp") Temp();
            else if (msg == "viewHumi") Humi();
            else if (msg == "addr") Serial.println(addr);
            
            msg = "";
            msgComplete = false;
        }
    }
  
    unsigned long currentMillis = millis();
  
    if (currentMillis - previousMillis >= logInterval * 1000 && logData && addr % 2 == 0 && addr < 1024) {
        previousMillis = currentMillis;
      
        readDHT11();
    }
    
    if (travelTimeSet && currentMillis - previousLogMillis >= logDelay) {
        setLogInterval();
    }
}

void readData() {
    int y = 1;
    Serial.println("-----");
    for (int i = 18; i < addr; i++) {
        int x = (int) EEPROM.read(i);
        if (i % 2 == 0) {
            Serial.print("Recnum: "); Serial.println(y);
            Serial.print("Humidity: "); Serial.println(x);
            y++;
        } else if (i % 2 != 0) {
            Serial.print("Temperature: "); Serial.println(x);
            Serial.println("-----");
        } 
    } 
}

void clearData() {
    for ( int i = 0 ; i < 1024 ; i++ ) EEPROM.write(i, 0);
    addr = 18;
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

void readDHT11() {
    int chk = DHT11.read();
//    switch (chk) {
//        case 0: Serial.println("OK"); break;
//        case -1: Serial.println("Checksum error"); break;
//        case -2: Serial.println("Time out error"); break;
//        default: Serial.println("Unknown error"); break;
//     }
    
//      Serial.print("Humidity (%): ");
//      Serial.println((int) DHT11.humidity, DEC);
    EEPROM.write(addr, (int) DHT11.humidity);
    addr++;
//      Serial.print("Temperature (°C): ");
//      Serial.println((double) DHT11.temperature, DEC);
    EEPROM.write(addr, (int) DHT11.temperature);
    addr++;
    
    EEPROMWriteInt(16, addr);
}

void calcAvgHumidity() {
    int totalHumidity = 0;
    int cases = 0;
    for (int i = 18; i < addr; i++) {
        if (i % 2 == 0) {
            totalHumidity += (int) EEPROM.read(i);
            cases++;
        }
    }
    avgHumidity = totalHumidity / cases;
}

void calcAvgTemp() {
    int totalTemp = 0;
    int cases = 0;
    for (int i = 18; i < addr; i++) {
        if (i % 2 != 0) {
            totalTemp += (int) EEPROM.read(i);
            cases++;
        }
    }
    avgTemp = totalTemp / cases;
}

void Humi() {
    Serial.println("Start");
    for (int i = 18; i < addr; i++)
        if (i % 2 == 0) Serial.println(EEPROM.read(i), DEC);
    Serial.println("End");
}

void Temp() {
    Serial.println("Start");
    for (int i = 18; i < addr; i++)
        if (i % 2 != 0) Serial.println(EEPROM.read(i), DEC);
    Serial.println("End");
}
