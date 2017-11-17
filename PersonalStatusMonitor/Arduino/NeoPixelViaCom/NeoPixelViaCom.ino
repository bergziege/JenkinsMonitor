#include <Adafruit_NeoPixel.h>
#define PIN 7

int PIXEL_COUNT = 12;
int PIXEL_ROTATION = 0;
int BOTTOM_PIXEL = 7;
int INPUT_PIN_1 = 3;
int INPUT_PIN_2 = 4;
int INPUT_PIN_3 = 5;
int INPUT_PIN_4 = 6;

int rotation_offset = 0;
int new_rotation_offset =0;
int val_1 = 0;
int val_2 = 0;
int val_3 = 0;
int val_4 = 0;
uint32_t colorBottom = 0;
uint32_t colorLeft = 0;
uint32_t colorTop = 0;
uint32_t colorRight = 0;
bool hasNewColor = false;

// Später durch die Setuproutine vom PC
int BRIGHTNESS = 100;

// Byte 00000001
// - Pixel Index
// - Pixel R
// - Pixel G
// - Pixel B

// Parameter 1 = number of pixels in strip
// Parameter 2 = Arduino pin number (most are valid)
// Parameter 3 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)
Adafruit_NeoPixel strip = Adafruit_NeoPixel(PIXEL_COUNT, PIN, NEO_GRB + NEO_KHZ800);

byte incomingByte = 0;

void setup(){
  Serial.begin(9600);

  colorBottom = strip.Color(255,0,0);
  colorRight = strip.Color(0,255,0);
  colorTop = strip.Color(0,0,255);
  colorLeft = strip.Color(255,255,255);

  pinMode(INPUT_PIN_1, INPUT);
  pinMode(INPUT_PIN_2, INPUT);
  pinMode(INPUT_PIN_3, INPUT);
  pinMode(INPUT_PIN_4, INPUT);

  strip.begin();

  // alle Pixel für 2 Sekunden voll weiß
  ShowColorOnAll(255,255,255);
  delay(2000);

  // alle Pixel aus
  ShowColorOnAll(0,0,0);
}

void loop(){

  val_1 = digitalRead(INPUT_PIN_1);
  val_2 = digitalRead(INPUT_PIN_2);
  val_3 = digitalRead(INPUT_PIN_3);
  val_4 = digitalRead(INPUT_PIN_4);

  if (val_1 == 1){
    new_rotation_offset = 1;
    BRIGHTNESS = 30;
  }
  else if(val_2 == 1){
    new_rotation_offset = 2;    
    BRIGHTNESS = 80;
  }
  else if(val_3 == 1){
    new_rotation_offset = 3;  
    BRIGHTNESS = 150;  
  }
  else if(val_4 == 1){
    new_rotation_offset = 4;    
    BRIGHTNESS = 255;
  }

  // TODO: Durch Setupbyte vom PC setzen und anwenden
  strip.setBrightness(BRIGHTNESS);

  if(new_rotation_offset != rotation_offset || hasNewColor){
    rotation_offset = new_rotation_offset;
    Serial.write(rotation_offset);

    SetBottom();
    SetLeft();
    SetTop();
    SetRight();

    strip.show();
    hasNewColor = false;
  }

  if (Serial.available() > 0){
    incomingByte = Serial.read();
    if (incomingByte == B00000001){

      while (Serial.available() == 0){
      }
      int r = Serial.parseInt();
      while (Serial.available() == 0){
      }
      int g = Serial.parseInt();
      while (Serial.available() == 0){
      }
      int b = Serial.parseInt();

      colorBottom = strip.Color(r,g,b);
      hasNewColor = true;
    }
    else if (incomingByte == B00000010){

      while (Serial.available() == 0){
      }
      int r = Serial.parseInt();
      while (Serial.available() == 0){
      }
      int g = Serial.parseInt();
      while (Serial.available() == 0){
      }
      int b = Serial.parseInt();

      colorLeft = strip.Color(r,g,b);
      hasNewColor = true;
    }
    else if (incomingByte == B00000011){

      while (Serial.available() == 0){
      }
      int r = Serial.parseInt();
      while (Serial.available() == 0){
      }
      int g = Serial.parseInt();
      while (Serial.available() == 0){
      }
      int b = Serial.parseInt();

      colorTop = strip.Color(r,g,b);
      hasNewColor = true;
    }
    else if (incomingByte == B00000100){

      while (Serial.available() == 0){
      }
      int r = Serial.parseInt();
      while (Serial.available() == 0){
      }
      int g = Serial.parseInt();
      while (Serial.available() == 0){
      }
      int b = Serial.parseInt();

      colorRight = strip.Color(r,g,b);
      hasNewColor = true;
    }
    incomingByte = 0;
  }

}


void ShowColorOnAll(int r, int g, int b){
  for (int i = 0; i < PIXEL_COUNT; i++){
    strip.setPixelColor(i, strip.Color(r,g,b));  
  }

  strip.show(); 
}

void SetBottom(){
  // abhängig von der Rotation des Wahlschalters jeweils die unterste LED einschalten
  int bottom = GetBottomIndex();
  int bottomCC1 = GetIndex(bottom,-1);
  int bottomCW1 = GetIndex(bottom,1);
  strip.setPixelColor(bottom, colorBottom);  
  strip.setPixelColor(bottomCC1, colorBottom);  
  strip.setPixelColor(bottomCW1, colorBottom);  
}

int GetIndex(int bottomIndex, int offset){
  int result = bottomIndex + offset;
  if(result < 0){
    result = result + PIXEL_COUNT;
  }
  else if(result >= PIXEL_COUNT){
    result = result - PIXEL_COUNT;
  }
  return result;
}

void SetLeft(){
  int left1 = GetIndex(GetBottomIndex(),8);
  int left2 = GetIndex(left1,1);
  int left3 = GetIndex(left2,1);
  strip.setPixelColor(left1, colorLeft);  
  strip.setPixelColor(left2, colorLeft);  
  strip.setPixelColor(left3, colorLeft);
}

void SetTop(){
  int top1 = GetIndex(GetBottomIndex(),5);
  int top2 = GetIndex(top1,1);
  int top3 = GetIndex(top2,1);
  strip.setPixelColor(top1, colorTop);  
  strip.setPixelColor(top2, colorTop);  
  strip.setPixelColor(top3, colorTop);
}

void SetRight(){
  int right1 = GetIndex(GetBottomIndex(),2);
  int right2 = GetIndex(right1,1);
  int right3 = GetIndex(right2,1);
  strip.setPixelColor(right1, colorRight);  
  strip.setPixelColor(right2, colorRight);  
  strip.setPixelColor(right3, colorRight);
}

int GetBottomIndex(){
  int index = BOTTOM_PIXEL + rotation_offset;
  if(index >= PIXEL_COUNT){
    index = index - PIXEL_COUNT;
  }
  else if (index < 0){
    index = index + PIXEL_COUNT;
  }
  return index;
}













