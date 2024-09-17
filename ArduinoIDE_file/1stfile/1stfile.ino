
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
  
  int value=analogRead(A2);
  value=map(value,0,100,0,10);
  String unity= Serial.readString();

  if (unity=="2"){
    digitalWrite(5,1);
  } else if (unity=="1"){
    digitalWrite(6,1);
  } else{
    digitalWrite(5,0);
    digitalWrite(6,0);
  }

  if (digitalRead(7)==LOW){
    
    

    /* if (tcs.begin()) {

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
    delay(60);  // takes 50ms to read
    tcs.getRGB(&red, &green, &blue);
    tcs.setInterrupt(true);  // turn off LED
  
    //Serial.print("R:\t"); Serial.print(int(red));
    //Serial.print("\tG:\t"); Serial.print(int(green));
    //Serial.print("\tB:\t"); Serial.print(int(blue));

    if(red>green and red>blue){
      Serial.print("Red");
    } else if (green>red and green>blue){
      Serial.print("Green");
    } else if (blue>red and blue>green){
      Serial.print("Blue");
    }
    Serial.print("\n");
  
    analogWrite(redpin, gammatable[(int)red]);
    analogWrite(greenpin, gammatable[(int)green]);
    analogWrite(bluepin, gammatable[(int)blue]); */

    Serial.println("Button 3 pressed");

  }else if (digitalRead(8)==LOW){
    Serial.println("Button 1 pressed");


  }else if (digitalRead(9)==LOW){
    Serial.println("Button 2 pressed");


  } else if (digitalRead(8)==LOW and digitalRead(9)==LOW){

    if (value>60){
      Serial.println("Hot");
    } else if(value<60 and value>40){
      Serial.println("Medium");
    } else if(value<40){
      Serial.println("Cold");
    }
  }

  

}
