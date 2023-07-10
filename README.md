# INTRODUCE
Fixed water level control according to the preset speed.
Use C# to display as well as control.
***
# HARDWARE 
#### List of main devices
- **Arduino**: controls H-bridge and transmits signals to C# applications via UART.
- **L298 V3**: control the water pump motor.
- **Ultrasonic sensor HY-SFR05**: reads and returns the height of the water level.
- **USB UART**: transmit and receive signals between Arduino and C# application.
#### Connection && Result
![example](Images/pic1.png)
![example](Images/pic2.png)![example](Images/pic3.png)
***
# SOFTWARE
**Ultrasonic sensor processing algorithm**: 
- The time from when the sensor transmits the sound wave to when it is received is the time that the ECHO pin is HIGH. To calculate the distance to the obstacle, just take the speed of sound in the air (340m/s) times the time then / 2 (because the distance here is the total distance from the sensor to the obstacle and from the obstacle about sensors).
**GUI**: 
- Use the PID controller to control the water level of the SetPoint.
![example](Images/pic4.png)

**Code**: 
- [link code Arduino][1]
- [link code C#][2]
***
# REPORT
[link report][3]

[1]: <https://github.com/lhkhanh080720/HCMUT_Control_Water_Tank/blob/main/NMDKTM_CODE_MAIN/NMDKTM_CODE_MAIN.ino>
[2]: <https://github.com/lhkhanh080720/HCMUT_Control_Water_Tank/tree/main/Software%20Display%20With%20C%23/NMDKTM/NMDKTM/Control%20by%20PID/Release>
[3]: <https://github.com/lhkhanh080720/HCMUT_Control_Water_Tank/blob/main/Report/Bao%20cao%20nhom%203.pdf>

