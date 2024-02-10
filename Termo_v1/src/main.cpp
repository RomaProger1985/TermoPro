#include <Arduino.h>
#include "max6675.h"
#include <PWM.h>
#include <PID_v1.h>

#define PIN_OUTPUT 3

//Define Variables we'll be connecting to
double Setpoint, Input, Output;

//Specify the links and initial tuning parameters
PID myPID(&Input, &Output, &Setpoint,5,0.02,7500, DIRECT);
//end PID

int thermoDO_Bt = 4;
int thermoCS_Bt = 5;
int thermoCLK_Bt = 6;

int32_t frequency = 35; //frequency (in Hz)

unsigned long timeBottom;

MAX6675 thermocouple_bottom(thermoCLK_Bt, thermoCS_Bt, thermoDO_Bt);

void setup() 
{
 //инициализируем все таймеры, кроме 0, чтобы сохранить время работы функций
  InitTimersSafe(); 
  SetPinFrequencySafe(PIN_OUTPUT, frequency);
  Serial.begin(9600);
  pinMode(PIN_OUTPUT, OUTPUT); // MOSFET output PIN
  //initialize the variables we're linked to
  Input = thermocouple_bottom.readCelsius();//читаем температуру с дачика
  Setpoint = 100;
  //turn the PID on
  myPID.SetMode(AUTOMATIC);
}

void loop()
{
  //чтение температуры
  if (millis()-timeBottom > 220) 
  {
    timeBottom = millis();
    Input = thermocouple_bottom.readCelsius();//читаем температуру с дачика
    myPID.Compute();
    Serial.println((int)Input);// выводим температуру в порт
    // (вход, установка, п, и, д, период в секундах, мин.выход, макс. выход)
    pwmWrite(PIN_OUTPUT,Output);
  } 
}