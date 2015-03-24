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
#include <DB.h>
#include <String.h>

#define TABLE 1

// Pins
const int ledPin = 13;
const int dht11Pin = 8;

// Variables to use for the interval
unsigned long previousMillis = 0;
long logInterval = 2000;

// Variables
dht11 DHT11;
DB db;
int travelTime; // Total travel time in s
int maxLogs = 255;
String msg;
boolean logData = true;

struct MyRec {
  int humidity;
  double temperature;
} myrec;

int avgHumidity;
int avgTemp;

void setup() {
  // Initialize pins
  pinMode(ledPin, OUTPUT);
  
  if (logInterval == 0) logData = false;
  
  DHT11.attach(dht11Pin);
  Serial.begin(9600);
  
  db.create(TABLE, sizeof(myrec));
  db.open(TABLE);
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
            
            msg = "";
            msgComplete = false;
        }
    }
    //if (Serial.available() == 0) msg = "";
  
    unsigned long currentMillis = millis();
  
    if(currentMillis - previousMillis >= logInterval && logData) {
        previousMillis = currentMillis;
      
        readDHT11();
    }
}

void readData() {
  if (db.nRecs()) Serial.println("-----");
  for (int i = 1; i <= db.nRecs(); i++) {
    db.read(i, DB_REC myrec);
    Serial.print("Recnum: "); Serial.println(i); 
    Serial.print("Humidity: "); Serial.println(myrec.humidity);
    Serial.print("Temperature: "); Serial.println(myrec.temperature);
    Serial.println("-----");  
  } 
}

void clearData() {
    for (int i = 0; i <= db.nRecs(); i++) {
        db.deleteRec(i);
    }
}

void setTravelTime() {
    Serial.println("set travel time in sec");
    while (Serial.available() == 0) { }
    
    int input = Serial.parseInt();
    travelTime = input;
    setLogInterval();
}

void setLogInterval() {
    logInterval = (travelTime * 1000) / maxLogs;
    logData = true;
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
      myrec.temperature = (double) DHT11.temperature;
    
      db.append(DB_REC myrec);
}

void calcAvgHumidity() {
    int totalHumidity = 0;
    int cases = 0;
    if (db.nRecs()) {
        for (int i = 1; i <= db.nRecs(); i++) {
            db.read(i, DB_REC myrec);
            totalHumidity += myrec.humidity;
            cases++;
        }
        avgHumidity = totalHumidity / cases;
    }
}

void calcAvgTemp() {
    int totalTemp = 0;
    int cases = 0;
    if (db.nRecs()) {
        for (int i = 1; i <= db.nRecs(); i++) {
            db.read(i, DB_REC myrec);
            totalTemp += myrec.temperature;
            cases++;
        }
        avgTemp = totalTemp / cases;
    }
}
