#include <Servo.h>

// Defines Tirg and Echo pins of the Ultrasonic Sensor
int trigPin = 10;
int echoPin = 13;
int servoPin = 9;
int MAX_ANGLE = 100;

Servo myservo; // Creates a servo object for controlling the servo motor

// Variables for the duration and the distance
float range;
int pos;
String tmpstr;
int curstate;


void setup() {
  pinMode(trigPin, OUTPUT); // Sets the trigPin as an Output
  pinMode(echoPin, INPUT); // Sets the echoPin as an Input
  Serial.begin(9600);
  myservo.attach(servoPin); // Defines on which pin is the servo motor attached
  curstate = 1;
  pos = myservo.read();  
}

float myrange_delay(){
    //send 10us pulse to the sensor trig
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  
   //Mesur the reponse from the sensor echo
  float mydelay = pulseIn(echoPin, HIGH);
  return mydelay;
}

void setAndMeasur(){
  myservo.write(pos);
  delay(15);

  //calculate distance
  //calculate signal duration
  float duration = myrange_delay();

  float soundspeedcm = 0.0334;

  range = (duration / 2) * soundspeedcm;

  if (range > 2.0 && range < 200.0){
    tmpstr = String(pos) + " " + String(range);
    Serial.println(tmpstr);
    delay(15);
    }
  
}

void loop(){
 if (curstate == 1){
    pos++;
    setAndMeasur();
    if (pos>=MAX_ANGLE){
      curstate = 2;
    }
 }
 else if (curstate==2)
 {
  //Move backward servo
  pos--;
  setAndMeasur();

  if (pos<=0){
    curstate = 1;
    }
  }
} 
 
