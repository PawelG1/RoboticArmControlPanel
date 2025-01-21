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
        private int _defaultPos = 0; // startowa/ wyjsciowa pozycja serva
        private int _servoPin;   //pin do ktorego podpiete jest servo
        int actualPos; //aktualna pozycja serva

        public Servo(RobotControl robot, int pin, int dPos)
        {
            robotArm = robot;// przypisanie referencji do obiektu RobotControl
            _servoPin = pin; // przypisanie pinu do servomechanizmu
            _defaultPos = dPos; // przypisanie pozycji startowej
        }

        //gettery dla defaultPos, ktore jest private by ograniczyc nieporzadane zmienianie tych wart z poziomu innych klas
        public int defaultPos
        {
            get { return _defaultPos; }
        }

        public void move(int desiredPos) //obrot serva na podana pozycje
        {
            robotArm.sendCommand($"P{_servoPin} {desiredPos}deg"); //wyslanie polecenia z numerem pinu oraz docelowa pozycja
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
