#include <dht11.h>

// Pins
const int ledPin = 13;
const int dhc11Pin = 8;


// Variables
dht11 DHT11;
int travelTime = 0; // Total travel time in s
int logInterval = 0; // Hoe vaak willen we loggen?

void setup() {
  // Initialize pins
  pinMode(ledPin, OUTPUT);
  
  DHT11.attach(dhc11Pin);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  int chk = DHT11.read();
  switch (chk)
  {
    case 0: Serial.println("OK"); break;
    case -1: Serial.println("Checksum error"); break;
    case -2: Serial.println("Time out error"); break;
    default: Serial.println("Unknown error"); break;
  }
  
  Serial.print("Humidity (%): ");
  Serial.println((int)DHT11.humidity, DEC);
  
  Serial.print("Temperature (°C): ");
  Serial.println((float)DHT11.temperature, DEC);
  
  delay(2000);
}
