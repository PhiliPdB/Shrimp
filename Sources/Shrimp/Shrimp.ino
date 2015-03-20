//
//     FILE: Shrimp.ino
//   AUTHOR: Philip de Bruin
//  VERSION: 0.1
//  PURPOSE: For school assesment
//
//

// Include temperature and humidity sensor library
#include <dht11.h>
// Include libraries for database
#include <EEPROM.h>
#include <DB.h>

#define TABLE 1

// Pins
const int ledPin = 13;
const int dhc11Pin = 8;

// Variables
dht11 DHT11;
DB db;
int travelTime = 0; // Total travel time in s
int logInterval = 0; // Hoe vaak willen we loggen?
struct MyRec {
  int humidity;
  double temperature;
} myrec;

void setup() {
  // Initialize pins
  pinMode(ledPin, OUTPUT);
  
  DHT11.attach(dhc11Pin);
  Serial.begin(9600);
  
  db.create(TABLE, sizeof(myrec));
  db.open(TABLE);
}

void loop() {
  // put your main code here, to run repeatedly:
  int chk = DHT11.read();
//  switch (chk) {
//    case 0: Serial.println("OK"); break;
//    case -1: Serial.println("Checksum error"); break;
//    case -2: Serial.println("Time out error"); break;
//    default: Serial.println("Unknown error"); break;
//  }
  
//  Serial.print("Humidity (%): ");
//  Serial.println((int)DHT11.humidity, DEC);
  myrec.humidity = (int) DHT11.humidity;
  
//  Serial.print("Temperature (°C): ");
//  Serial.println((double)DHT11.temperature, DEC);
  myrec.temperature = (double) DHT11.temperature;
  
  db.append(DB_REC myrec);
  selectAll();
  delay(2000);
}

void selectAll() {
  if (db.nRecs()) Serial.println("-----");
  for (int i = 1; i <= db.nRecs(); i++)
  {
    db.read(i, DB_REC myrec);
    Serial.print("Recnum: "); Serial.println(i); 
    Serial.print("Humidity: "); Serial.println(myrec.humidity);
    Serial.print("Temperature: "); Serial.println(myrec.temperature);
    Serial.println("-----");  
  } 
}
