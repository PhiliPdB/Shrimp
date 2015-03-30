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
#include <EDB.h>
#include <String.h>

#define TABLE_SIZE 1024
#define RECORDS_TO_CREATE 252

// Pins
const int ledPin = 13;
const int dht11Pin = 8;

// Variables to use for the interval
unsigned long previousMillis = 0;
unsigned long logDelay;                           // Log delay in milliseconds
long logInterval = 0;                            // Log interval in milliseconds

// Variables
dht11 DHT11;
EDB db(&writer, &reader);
long travelTime; // Total travel time in s
int maxLogs = 252;
String msg;
boolean logData = false;

struct MyRec {
  int humidity;
  int temperature;
} myrec;

int avgHumidity;
int avgTemp;

int addr = 0;

// The read and write handlers for using the EEPROM Library
void writer(unsigned long address, byte data) {
    EEPROM.write(address, data);
}

byte reader(unsigned long address) {
    return EEPROM.read(address);
}

void setup() {
    if (EEPROM.read(0)) logInterval = (long) EEPROM.read(0);
    if (EEPROM.read(1)) logData = (boolean) EEPROM.read(1);
    
    // Initialize pins
    pinMode(ledPin, OUTPUT);
  
    if (logInterval == 0) logData = false;
    
    DHT11.attach(dht11Pin);
    Serial.begin(9600);
    
    if (db.count()) db.open(db.count());
    else db.create(3, TABLE_SIZE, sizeof(myrec));
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
                Serial.println(avgHumidity);
            } else if (msg == "viewAvgTemp") {
                calcAvgTemp();
                Serial.println(avgTemp);
            } else if (msg == "clearData") clearData();
            else if (msg == "viewTemp") Temp();
            else if (msg == "viewHumi") Humi();
            
            msg = "";
            msgComplete = false;
        }
    }
  
    unsigned long currentMillis = millis();
  
    if(currentMillis - previousMillis >= logInterval * 1000 && logData) {
        previousMillis = currentMillis;
      
        readDHT11();
    }
}

void readData() {
  if (db.count()) Serial.println("-----");
  for (int i = 1; i <= db.count(); i++) {
    db.readRec(i, EDB_REC myrec);
    Serial.print("Recnum: "); Serial.println(i); 
    Serial.print("Humidity: "); Serial.println(myrec.humidity);
    Serial.print("Temperature: "); Serial.println(myrec.temperature);
    Serial.println("-----");  
  } 
}

void clearData() {
    db.clear();
}

void setTravelTime() {
    Serial.println("set travel time in sec");
    while (Serial.available() == 0) { }
    
    travelTime = Serial.parseInt();
    setLogInterval();
}

void setLogInterval() {
    logInterval = travelTime / maxLogs;
    logData = true;
    EEPROM.write(0,logInterval);
    EEPROM.write(1,logData);
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
      myrec.humidity = (int) DHT11.humidity;
    
//      Serial.print("Temperature (°C): ");
//      Serial.println((double) DHT11.temperature, DEC);
      myrec.temperature = (int) DHT11.temperature;
    
      if (db.count() <= 253) db.appendRec(EDB_REC myrec);
}

void calcAvgHumidity() {
    int totalHumidity = 0;
    int cases = 0;
    if (db.count()) {
        for (int i = 1; i <= db.count(); i++) {
            db.readRec(i, EDB_REC myrec);
            totalHumidity += myrec.humidity;
            cases++;
        }
        avgHumidity = totalHumidity / cases;
    }
}

void calcAvgTemp() {
    int totalTemp = 0;
    int cases = 0;
    if (db.count()) {
        for (int i = 1; i <= db.count(); i++) {
            db.readRec(i, EDB_REC myrec);
            totalTemp += myrec.temperature;
            cases++;
        }
        avgTemp = totalTemp / cases;
    }
}

void Humi() {
    if (db.count()) {
        Serial.println("Start");
        for (int i = 1; i <= db.count(); i++) {
            db.readRec(i, EDB_REC myrec);
            Serial.println(myrec.humidity);
        }
        Serial.println("End");
    }
}

void Temp() {
    if (db.count()) {
        Serial.println("Start");
        for (int i = 1; i <= db.count(); i++) {
            db.readRec(i, EDB_REC myrec);
            Serial.println(myrec.temperature);
        }
        Serial.println("End");
    }
}
