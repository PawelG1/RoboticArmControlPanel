using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace espControl1
{
    //klasa autoMode udostepnia metody do programowania automatycznej pracy robota t.j.iteracji po zadanych punktach
    internal class AutoMode 
    {
        private List<Point> pointsList = new List<Point>(); // inicjializacja pustej listy ktora bedzie przechowywac punkty do ktorych robot ma dotrzec

        class Point
        {
            private int _idx;
            private int _baseServoPos; // pozycja serva w danym punkcie
            private int _j1ServoPos; // Pozycja serwa J1 w danym punkcie
            private int _j2ServoPos; // Pozycja serwa J2 w danym punkcie
            private int _gripperServoPos; // kat serwa chwytaka w danym punkcie

            public int getIdx
            {
                get { return _idx; }
            }
            public int baseServoPos
            {
                get { return _baseServoPos; }
            }
            public int j1ServoPos
            {
                get { return _j1ServoPos; }
            }
            public int j2ServoPos
            {
                get { return _j2ServoPos; }
            }
            public int gripperServoPos
            {
                get { return _gripperServoPos; }
            }


            public Point(int i, int baseP, int j1P, int j2P, int gripP) // konstruktor zapisujacy katy obrotu kazdego z serw w punkcie
            {
                this._idx = i;
                this._baseServoPos = baseP;
                this._j1ServoPos = j1P;
                this._j2ServoPos = j2P;
                this._gripperServoPos = gripP;
            }
        }

        public void addPoint(int baseP, int j1P, int j2P, int gripP)
        {
            int idx = pointsList.Count;
            pointsList.Add(new Point(idx, baseP, j1P, j2P, gripP));
        }

        public void removePoint(int idx)
        {
            pointsList.RemoveAll(p => p.getIdx == idx);
        }

        public int getLastIdx()
        {
            return pointsList.Count-1;
        }

        public async Task LoopWork(RobotControl robotArm) //metoda asynchroniczna by nie blokowac glownego watku, sterująca pracą robota t.j. iteruje po punktach
        {
            try
            {
                foreach (Point point in pointsList) // dla kazdego punktu w liscie
                {
                    robotArm.baseServo.move(point.baseServoPos); // ustawienie serva na pozycji podanej w punkcie
                    robotArm.j1Servo.move(point.j1ServoPos);
                    robotArm.j2Servo.move(point.j2ServoPos);
                    robotArm.gripperServo.move(point.gripperServoPos);
                    await Task.Delay(3000); //odczekanie by robot byl wstanie osiagnac zadana pozycje
                }

            }catch (Exception ex)
            {
                Console.WriteLine($"wystapil blad w pracy automatycznej{ex.ToString()}");
            }
          
           

            
        }

    }
}
