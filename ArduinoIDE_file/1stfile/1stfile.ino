
#include "Adafruit_TCS34725.h"
#define redpin 3
#define greenpin 10
#define bluepin 11
#define commonAnode true
byte gammatable[256];
Adafruit_TCS34725 tcs = Adafruit_TCS34725(TCS34725_INTEGRATIONTIME_50MS, TCS34725_GAIN_4X);

 
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(7,INPUT_PULLUP);//Button closest to the lights
  pinMode(A2,INPUT_PULLUP);//Rotating button
  pinMode(9,INPUT_PULLUP);//Middle button
  pinMode(8,INPUT_PULLUP);//Button fartest from the lights
  pinMode(6,OUTPUT);//Red light
  pinMode(5,OUTPUT);//Green light

  pinMode(redpin, OUTPUT);
  pinMode(greenpin, OUTPUT);
  pinMode(bluepin, OUTPUT);
 
}

void loop() {
  // put your main code here, to run repeatedly:

  if (digitalRead(7)==LOW){
    Serial.println("Button 3 pressed");
    Serial.flush();
    if (tcs.begin()) {

    } else {
      Serial.println("No TCS34725 found ... check your connections");
      while (1); 
    }
      
    for (int i = 0; i < 256; i++) {
      float x = i;
      x /= 255;
      x = pow(x, 2.5);
      x *= 255;
      if (commonAnode) {
        gammatable[i] = 255 - x;
      } else {
        gammatable[i] = x;
      }

    }

    float red, green, blue;
    tcs.setInterrupt(false);  // turn on LED
    
    tcs.getRGB(&red, &green, &blue);
    tcs.setInterrupt(true);  // turn off LED
    
    //Serial.print("R:\t"); Serial.print(int(red));
    //Serial.print("\tG:\t"); Serial.print(int(green));
    //Serial.print("\tB:\t"); Serial.print(int(blue));

    if(red>green and red>blue){
      Serial.println("Red");
    } else if (green>red and green>blue){
      Serial.println("Green");
    } else if (blue>red and blue>green){
      Serial.println("Blue");
    }
    
    analogWrite(redpin, gammatable[(int)red]);
    analogWrite(greenpin, gammatable[(int)green]);
    analogWrite(bluepin, gammatable[(int)blue]);

  }else if (digitalRead(8)==LOW){
    Serial.println("Button 1 pressed");


  }else if (digitalRead(9)==LOW){
    Serial.println("Button 2 pressed");


  } else if (digitalRead(8)==LOW and digitalRead(9)==LOW){
    Serial.println("Both buttons pressed");
  }
  
  String unity= Serial.readString();
  
  if (unity=="win"){
    digitalWrite(5,1);
  } else if (unity=="lose"){
    digitalWrite(6,1);
  } else{
    digitalWrite(5,0);
    digitalWrite(6,0);
  } 

  int value=analogRead(A2);
  value=map(value,0,1023,0,100);
    if (value==100){
      Serial.println(100);
    } else if(value<100 and value>90){
      Serial.println(90);
    } else if(value<90 and value>80){
      Serial.println(80);
    } else if(value<80 and value>70){
      Serial.println(70);
    } else if(value<70 and value>60){
      Serial.println(60);
    } else if(value<60 and value>50){
      Serial.println(50);
    } else if(value<50 and value>40){
      Serial.println(40);
    } else if(value<40 and value>30){
      Serial.println(30);
    } else if(value<30 and value>20){
      Serial.println(20);
    } else if(value<20 and value>10){
      Serial.println(10);
    } else if(value<10 and value>0){
      Serial.println(01);
    } else if(value==0){
      Serial.println(0);
    }

}
