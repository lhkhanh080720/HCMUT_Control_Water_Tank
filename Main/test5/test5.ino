#include <LiquidCrystal_I2C.h>
#include <LiquidCrystal.h>
#include <PID_v1.h>

const int trig = 8; //Khai báo chân trig nối với chân số 8 là hằng số
const int echo = 7; //Khai báo chân echo nối với chân số 7 là hằng số
const int in3 = 5;
const int in4 = 4;
const int enb = 3;
int i;
unsigned long thoigian; //Thời gian là kiểu số nguyên
int khoangcach; //Khoảng cách là kiểu số nguyên

#include <Wire.h> 
#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27,16,2); //LCD 16x02, địa chỉ I2C là 0X27

double Setpoint ; // will be the desired value
double Input; // photo sensor
double Output ; //LED
//PID parameters
const double Kp=2, Ki=8, Kd=0; // lần 1: 2,10

double E,E1,E2;
double a,b,g,kp,ki,kd,LastOutput;
long last = 0;
const int T = 100;

//create PID instance 
//PID myPID(&Input, &Output, &Setpoint, Kp, Ki, Kd, DIRECT);

void setup() 
{
  Serial. begin (9600);
  pinMode(trig, OUTPUT); //Chân trig xuất tín hiệu
  pinMode(echo, INPUT); //Chân echo nhận tín hiệu
  pinMode (in3, OUTPUT);
  pinMode (in4, OUTPUT);
  pinMode (enb, OUTPUT);
  lcd.init(); //Khởi động LCD
  lcd.backlight(); //Bật đèn nền
  lcd.setCursor(0,0); //Cột 1, hàng 0 
  lcd.print("--DO MUC NUOC---"); 

  Setpoint = 5;
//  //Turn the PID on
//  myPID.SetMode(AUTOMATIC);
//  //Adjust PID values
//  myPID.SetTunings(Kp, Ki, Kd);

  E = 0; E1 = 0; E2 = 0;
  LastOutput = 0;
  last = millis();
}

void loop() 
{
  digitalWrite(trig,0); //Tắt chân trig
  delayMicroseconds(2); 
  digitalWrite(trig,1); //bật chân trig để phát xung
  delayMicroseconds(10); //Xung có độ rộng là 10 microsecond
  digitalWrite(trig,0);  //Chân echo sẽ nhận xung phản xạ lại //Và đo độ rộng xung cao ở chân echo
  thoigian = pulseIn (echo, HIGH);//Tính khoảng cách đến vật thể (Đơn vị đo là cm)//Tốc độ của âm thanh trong không khí là 340 m/s, tương đương 29,412 microSeconds/cm, //Do thời gian được tính từ lúc phát tín hiệu tới khi sóng âm phản xạ lại,//vì vậy phải chia cho 2
  khoangcach = int(thoigian / 2 / 29.412); 
              /*--------------------------------control PID2--------------------------------------------------------*/
if(millis()-last >= 100)
{
  last = millis();
  Output = PID_continue(Output, Setpoint,12 - khoangcach);
  analogWrite(enb,Output);
  digitalWrite (in3, LOW); 
  digitalWrite (in4, HIGH);
}
       /*---------------------------------------------------------------------------------------------------*/
//  Input = 12 - khoangcach;  // photo senor is set on analog pin 5
//  //PID calculation
//  myPID.Compute();
//  //Write the output as calculated by the PID function
//  analogWrite(enb,Output); //LED is set to digital 3 this is a pwm pin.
//digitalWrite (in3, LOW); 
//     digitalWrite (in4, HIGH);
  /*---------------------------------------------------------------------------------------------------*/  
//Send data by serial for plotting 

  Serial.print(Input);
  Serial.print(" ");
  Serial.print(Setpoint); 
  Serial.println(" ");
//  Serial.println(Setpoint);
//  Serial.println("==========================================");
//  delay(100);


  //In trên LCD
  lcd.setCursor(0,1);
  lcd.print(Input);
  
  if (Input < 10)
  {
    lcd.setCursor(1,1);
    lcd.print("   ");
  }
  
  if (Input >= 10 && Input < 100)
  {
    lcd.setCursor(2,1);
    lcd.print("  ");
  }

  else
  {
    lcd.setCursor(3,1);
    lcd.print(" ");
  }
  lcd.setCursor(4,1);
  lcd.print("  Cm  "); 
  delay(250);   
}

int PID_continue(int Output, int Setpoint, int khoangcach)
{
  float OutPid = 0;
  E = abs(Setpoint) - abs(khoangcach);
  OutPid = (Kp*E) + (Kd*(E-E1));
  E1=E;
  return constrain(Output + int(OutPid),75,250);
}
