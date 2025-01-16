using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espControl1
{
    public class RobotControl : SerialComm //klasa robot control dziedziczy z klasy SerialComm,
                                           //ocpowiedzialnej za komunikacje za posrednictwem portu szer. z uC esp32

    {
        private bool isRunning; // Flaga do kontrolowania wątku

        //numery pinow GPIO do ktoeych podpiete sa servomechanizmy
        const int baseServoPin = 23; //numer pinu GPIO esp32 do ktorego powinien byc podpiete servo odp. za obrot podstawy
        const int j1ServoPin = 22; // servo1  przeguba
        const int j2ServoPin = 21; // servo 2 przeguba
        const int gripperServoPin = 19; // servo 3 chwytaka

        //domyslne pozycje serv
        const int baseServoDefPos = 0; //domyslna/startowa pozycja serva
        const int j1ServoDefPos = 70;
        const int j2ServoDefPos = 95;
        const int gripperServoDefPos = 0;

        //obiekty klasy Serwo do zarzadzania poszczegolymi servami
        public Servo baseServo; //obiekt klasy servo utowrzony do zarzadzania serwem do obrotu podstawy
        public Servo j1Servo;
        public Servo j2Servo;
        public Servo gripperServo;

        public RobotControl(string port) : base(port) { // wywolanie konstruktora klasy nadrzędnej i przekazanie do niego portu
            baseServo = new Servo(this, baseServoPin, baseServoDefPos); //  inicjalizacja obiektu Servo odpowiadajace za servo obrotu podstawy,
                                                                        //  przekazanie pinu serwa oraz pozycji domyslnej
            j1Servo = new Servo(this, j1ServoPin, j1ServoDefPos);
            j2Servo = new Servo(this, j2ServoPin, j2ServoDefPos);
            gripperServo = new Servo(this, gripperServoPin, gripperServoDefPos);
        }

        public RobotControl(ComboBox cbox, RichTextBox rtb) : base(rtb)
        { 
            baseServo = new Servo(this, baseServoPin, baseServoDefPos);
            j1Servo = new Servo(this, j1ServoPin, j1ServoDefPos);
            j2Servo = new Servo(this, j2ServoPin, j2ServoDefPos);
            gripperServo = new Servo(this, gripperServoPin, gripperServoDefPos);
        }

        
        public void resetRobot() // wyresetowanie pozycji serwomechanizmow do pozycji wyjsciowej (bezpoeczniej)
        {
            baseServo.reset(); // reset pozycji serva obracajacego podstawa
            j1Servo.reset();
            j2Servo.reset();
            gripperServo.reset();
        }

        public Thread readingSensorsThread()
        {
            isRunning = true; // flaga ze watek dziala
            Thread thread = new Thread(new ThreadStart(readingSensors));
            thread.IsBackground = true; // zamkniecie watka wraz z prgramem
            return thread;
        }

        private void readingSensors() //metoda monitorujaca stan sensorow
        {
            while (isRunning)
            {
                if (proximity_sensor) //gdy wykryty wysoki stan sensora
                {
                    Console.WriteLine("Proximity sensor detected! Resetting robot...");
                    resetRobot(); //resetowanie pozycji robota do stanu wyjsciowego
                }
                Thread.Sleep(100); 
            }
        }

        public void StopReadingSensors()// Zatrzymanie wątku nasluchujacego komunikatow o sensorach
        {
            isRunning = false;  //ustawienie flagi o zatrzymaniu dzialania watku
        }


    }
}
