using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espControl1
{
    public partial class Visualization : Form
    {
        Pen uniPen = new Pen(new SolidBrush(Color.Gray), 5);//inicjalizacja pedzla by wszystkie elementy schematu byly rysowane tym samym
        const int screenWidth = 720;
        const int screenHeight = 520;
        private int j1Pos;
        private int j2Pos;

        public Visualization(int j1pos, int j2pos)
        {
            this.j1Pos = j1pos;
            this.j2Pos = j2pos;
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.visuPainter);
            this.Size = new Size(screenWidth, screenHeight);

        }

        private void Visualization_Load(object sender, EventArgs e)
        {

        }

        private void visuPainter(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Pixel; // ustalamy jednostki osi

            const int jLength = 100;

            int j1Angle = j1Pos;
            int j2Angle = j2Pos;

            const int baseX = screenWidth/2; //wspolrzedne podstawy robota
            const int baseY = screenHeight-100;
            int j1X = baseX; //wspolrzedne poczatka 1 przeguba
            int j1Y = baseY - 60;

            g.Clear(Color.White);
            RobotBaseShape(g, baseX, baseY);

            //transformacja dla narsowania  przegubu pod katemn
            g.TranslateTransform(j1X, j1Y); // srodek obrotu na podstawie robota
            //g.RotateTransform(j1Angle); //obracamy ukl wspolrzednycho kat obrotu

            joint1Shape(g, 0, 0);//rysowanie 1 przeguba

            g.TranslateTransform(0, -jLength); //przesuwanie ukl wsp na koniec 1 przeguba
            g.RotateTransform(j1Angle);        //obrot
            joint1Shape(g, 0, 0);//rys 2 przeguba

            

            g.TranslateTransform(0, -jLength); 
            g.RotateTransform(j2Angle);        
            gripperShape(g, 0, 0);

            g.ResetTransform();//reset transformacji

        }


        private void joint1Shape(Graphics g, int x, int y)
        {

            const int jLength = 100;
            const int width = 20;
            g.DrawLine(uniPen, x, y, x, y - jLength+(width/2));
            g.DrawEllipse(uniPen, x-(width/2), y-jLength-(width/2), width, width);
        }

        private void gripperShape(Graphics g, int x, int y)
        {
            const int jLength = 100;
            const int width = 20;
            g.DrawLine(uniPen, x, y, x, y - jLength);
            Point[] shape = new Point[]
            {
                new Point(x-width,y-jLength),
                new Point(x+width,y-jLength),
            };
            g.DrawPolygon(uniPen, shape);
        }


        private void RobotBaseShape(Graphics g, int x, int y)
        {
            const int baseLength = 50;
            const int width = 20;
            const int spacer = 10;

            g.DrawLine(uniPen, x, y+50, x, y+200 );
            Point[] traingleP = new Point[]
            {
                new Point(x-width,y),
                new Point(x+width,y),
                new Point(x,y+baseLength),
                new Point(x-width,y),
            };
            g.DrawPolygon(uniPen, traingleP);

            Point[] traingleP2 = new Point[]
            {
                new Point(x-width,y-spacer),
                new Point(x+width,y-spacer),
                new Point(x,y-baseLength-spacer),
                new Point(x-width,y-spacer),
            };
            g.DrawPolygon(uniPen, traingleP2);

        }
    }
}
