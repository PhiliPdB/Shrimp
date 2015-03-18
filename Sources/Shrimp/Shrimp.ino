// Pins
const int ledPin = 13;
const int buttonPin = 2;
const int thermometerPin = A0;

// Variables
int travelTime = 0; // Total travel time in s
int logInterval = 0; // Hoe vaak willen we loggen?
int temperature = 0;

void setup() {
  // Initialize pins
  pinMode(ledPin, OUTPUT);
  
  Serial.begin(9600);
  digitalWrite(ledPin, LOW);
}

void loop() {
  // put your main code here, to run repeatedly:
  temperature = analogRead(thermometerPin);
  Serial.println(temperature, DEC);
  delay(1);
  
  
}
