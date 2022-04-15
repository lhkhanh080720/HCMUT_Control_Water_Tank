int led = 13;
String inputString = "";
boolean stringComplete = false;
void setup() {
  Serial.begin(9600);
  pinMode(led, OUTPUT);
}

void loop() {
 if(stringComplete == true){
  digitalWrite(led, HIGH);
if(inputString.length() > 0) 
  digitalWrite(led, HIGH);
  inputString = "";
  stringComplete = false;
  
 }
 
}

void serialEvent(){
  while(Serial.available()){
    char inChar = (char)Serial.read();
    inputString = inputString + inChar;
    if(inChar == '\n'){
      stringComplete = true;
    }
  }
}
