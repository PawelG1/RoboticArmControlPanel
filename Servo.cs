using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espControl1
{
    public class Servo
    {
        RobotControl robotArm; // obiekt klasy robotControl, zarzadzajacy robotem
        int defaultPos = 0; // startowa/ wyjsciowa pozycja serva
        int servoPin;   //pin do ktorego podpiete jest servo
        int actualPos; //aktualna pozycja serva

        public Servo(RobotControl robot, int pin, int dPos)
        {
            robotArm = robot;// przypisanie referencji do obiektu RobotControl
            servoPin = pin; // przypisanie pinu do servomechanizmu
            defaultPos = dPos; // przypisanie pozycji startowej
        }


        public void move(int desiredPos) //obrot serva na podana pozycje
        {
            robotArm.sendCommand($"P{servoPin} {desiredPos}deg"); //wyslanie polecenia z numerem pinu oraz docelowa pozycja
            updateServoPos(desiredPos); //nadpisanie info. o aktualnej poz. serwa
        }

        private void updateServoPos(int position)//nadpisuje aktualna pozycje serva
        {
            this.actualPos = position;
        }

        public void reset()
        {
            move(defaultPos); // obrot serva na pozycje domyslna
        }

        
    }
}
