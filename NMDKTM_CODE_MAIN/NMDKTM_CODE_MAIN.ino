#include <LiquidCrystal_I2C.h>
#include <LiquidCrystal.h>
#include <Wire.h> 
LiquidCrystal_I2C lcd(0x27,16,2); //LCD 16x02, địa chỉ I2C là 0X27
const int trig = 8; //Khai báo chân trig nối với chân số 8 là hằng số
const int echo = 7; //Khai báo chân echo nối với chân số 7 là hằng số
const int in3 = 5;
const int in4 = 4;
const int enb = 3;
int i;
int Status = 0;
unsigned long thoigian; //Thời gian là kiểu số nguyên
double khoangcach; //Khoảng cách là kiểu số nguyên
double Setpoint ; 
double Input; 
double Output; 
double OutVal;
long E,E1,E2;
double a,b,g,LastOutput,ki,kp,kd;
double alpha = 0;
double beta = 0;
double gamma = 0;
long last = 0;
long timer = 0;
const int T = 25;
int x = 0;

void setup() 
{
  Serial. begin (115200);
  pinMode(trig, OUTPUT); //Chân trig xuất tín hiệu
  pinMode(echo, INPUT); //Chân echo nhận tín hiệu
  pinMode (in3, OUTPUT);
  pinMode (in4, OUTPUT);
  pinMode (enb, OUTPUT);

  Setpoint = 0;

  E = 0; E1 = 0; E2 = 0;
  LastOutput = 0;
  last = millis();
  timer = millis();
  
}

void loop() 
{
  receiveData();
  while(Status == 1)
  {
  receiveData();
  digitalWrite(trig,0); //Tắt chân trig
  delayMicroseconds(2); 
  digitalWrite(trig,1); //bật chân trig để phát xung
  delayMicroseconds(10); //Xung có độ rộng là 10 microsecond
  digitalWrite(trig,0);  //Chân echo sẽ nhận xung phản xạ lại //Và đo độ rộng xung cao ở chân echo
  thoigian = pulseIn (echo, HIGH);//Tính khoảng cách đến vật thể (Đơn vị đo là cm)//Tốc độ của âm thanh trong không khí là 340 m/s, tương đương 29,412 microSeconds/cm, //Do thời gian được tính từ lúc phát tín hiệu tới khi sóng âm phản xạ lại,//vì vậy phải chia cho 2
  khoangcach = thoigian / 2 / 29.412; 
              /*--------------------------------control PID--------------------------------------------------------*/
  if(millis()-last >= T)
  {
  last = millis();
  double x = 20 - khoangcach;
  if(x < 0) x = 0; 
  updateKiKpKd(x);
  PIDControl();//ap tu 0v-12v
  digitalWrite (in3, LOW); 
  digitalWrite (in4, HIGH);
  }
  if(millis()-timer >= 100)
  {
    timer = millis();
    Serial.print(20 - khoangcach); 
  }  
  delay(10);
  } 
}

void receiveData(void)
{
  if(Serial.available())
  {
    String DataFromCSharp = Serial.readString();
    if(DataFromCSharp == "ON")          Status = 1;   
    else if (DataFromCSharp == "OFF")   Status = 0; 
    else                                Setpoint = DataFromCSharp.toInt();
  }
}

double hlt(double x, double L, double C1, double C2, double R)
{
  if(x < L)         return 0;
  else if(x < C1)   return (x-L)/(C1-L);
  else if (x < C2)  return 1;
  else if (x < R)   return (R-x)/(R-C2);
  else              return 0;
}

void updateKiKpKd(double num)
{
  double Kp[6]={0},Ki[6]={0},Kd[6]={0};
  double anlpha_dk[6] ={0};
  double h = num;
  if(h < 0) h = 0;
  if(h >= 0 && h <= 3.5)
  {
    anlpha_dk[0] = hlt(h,0,0,2,3.5);
    Kp[0] = 0.42;
    Ki[0] = 0.04;
    Kd[0] = 0;
  }
  if(h >= 2 && h <= 6)
  {
    anlpha_dk[1] = hlt(h,2,3.5,4,6);
    Kp[1] = 0.39;
    Ki[1] = 0.037;
    Kd[1] = 0;
  }
  if(h >= 4 && h <= 9)
  {
    anlpha_dk[2] = hlt(h,4,6,8,9);
    Kp[2] = 0.36;
    Ki[2] = 0.033;                                 
    Kd[2] = 0;
  }
  if(h >= 8 && h <= 12)
  {
    anlpha_dk[3] = hlt(h,8,9,11,12);
    Kp[3] = 0.32;
    Ki[3] = 0.03;
    Kd[3] = 0;
  }
  if(h >= 11 && h <= 16)
  {
    anlpha_dk[4] = hlt(h,11,12,15,16);
    Kp[4] = 0.31;
    Ki[4] = 0.027;
    Kd[4] = 0;
  }
  if(h >= 15 && h <= 18)
  {
    anlpha_dk[5] = hlt(h,15,16,18,18);
    Kp[5] = 0.28;
    Ki[5] = 0.026;
    Kd[5] = 0;
  }
  //15,17 oke 
  for(int i = 0; i < 6; i++)
  {
    if(anlpha_dk[i] != 0)
    {
      kp += anlpha_dk[i]*Kp[i];
      ki += anlpha_dk[i]*Ki[i];
      kd += anlpha_dk[i]*Kd[i];
    }
  }
}

void PIDControl(void)
{
  if(20-khoangcach < 0) E = Setpoint;
  else  E = Setpoint - (20 - khoangcach);
  alpha = 2*T*0.001*kp + ki*T*0.001*T*0.001 + 2*kd;
  beta = T*0.001*T*0.001*ki - 4*kd - 2*T*0.001*kp;
  gamma = 2*kd;
  Output = (alpha*E + beta*E1 + gamma*E2 + 2*T*0.001*LastOutput)/(2*T*0.001);
  LastOutput = Output;
  E2 = E1;
  E1 = E;
  if(Output >= 250)
  {
    Output = 250;
  }
   else if(Output < 0)
  {
    Output = 0;
  }
  if(Output > 0)  analogWrite (enb, Output);
  else            analogWrite (enb, 0);    
}
