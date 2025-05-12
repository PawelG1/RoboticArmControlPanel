using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espControl1
{
    public partial class FormTeachMode : Form
    {
        RobotControl robotArm; // referencja do obiektu klasy robotArm, obiekt tej klasy "zarzadza" peryfieriami robota
        private Form mainForm; //uchwyt fo formularza glownego
        private Thread sensingTh; // watek w ktorym obslugiwane sa sygnaly z sensorwo
        private AutoMode autoMode; // w klasie autoMode dostepne sa metody do programowania automatycznej pracy robota t.j. iteracji po zadanych punktach
        private CancellationTokenSource cts; // Token source for stopping the AutoMode task

        private int baseRotation; // atrybut przechowujacy kat obrotu 1 podstawy robota
        private int j1Rotation;
        private int j2Rotation;
        private int gripper;


        public FormTeachMode(Form form1, RobotControl rArm)
        {
            mainForm = form1; //przypisanie formularza glownego menu do mainForm by umozliwic ponowne otwarcie menu
            InitializeComponent();
            grip_trb.SetRange(0, 110); // ustawienie zakresu wartosci dla trackbara odpowiadajacego za chwytak
            baseRot_trb.SetRange(0, 180);
            j1Rot_trb.SetRange(0, 180);
            j2Rot_trb.SetRange(0, 180);
            robotArm = rArm; // przypisanie przekazanaego obiektu RobotControl
            robotArm.resetRobot();// wyresetowanie przegubow robota
            sensingTh = robotArm.readingSensorsThread(); // przypisanie watku do nasluchu komunikatow o stanie sensora
            sensingTh.Start(); // uruchomienie watku do nasluchu
            autoMode = new AutoMode();

            //przypisanie wartosci startowych poszczegolnych serv do trackbarow
            Thread.Sleep(500);
            baseRotation = robotArm.baseServo.GetServoPos();
            baseRot_trb.Value = baseRotation;
            j1Rotation = robotArm.j1Servo.GetServoPos();
            j1Rot_trb.Value = j1Rotation;
            j2Rotation = robotArm.j2Servo.GetServoPos();
            j2Rot_trb.Value = j2Rotation;

            gripper = robotArm.gripperServo.GetServoPos();
            grip_trb.Value = gripper;
            //przypisanie tych wartosci do labels obok track barow
            baseRot_tb.Text = baseRot_trb.Value.ToString();
            j1Rot_tb.Text = j1Rot_trb.Value.ToString();
            j2Rot_tb.Text = j2Rot_trb.Value.ToString();
            grip_tb.Text = grip_trb.Value.ToString();
            
        }

        private void baseRot_trb_Scroll(object sender, EventArgs e)
        {
            baseRotation = baseRot_trb.Value; // pobranie wartosci z trackBara
            baseRot_tb.Text = baseRotation.ToString(); // konwersja na string
            robotArm.baseServo.move(baseRotation); // wydanie polecenia do obrocenia podstawy na kat obrotu baseRot..
        }

        private void j1Rot_trb_Scroll(object sender, EventArgs e)
        {
            j1Rotation = j1Rot_trb.Value;
            j1Rot_tb.Text = j1Rotation.ToString();
            robotArm.j1Servo.move(j1Rotation);
        }

        private void j2Rot_trb_Scroll(object sender, EventArgs e)
        {
            j2Rotation = j2Rot_trb.Value;
            j2Rot_tb.Text = j2Rotation.ToString();
            robotArm.j2Servo.move(j2Rotation);
        }

        private void grip_trb_Scroll(object sender, EventArgs e)
        {
            gripper = grip_trb.Value;
            grip_tb.Text = gripper.ToString();
            robotArm.gripperServo.move(gripper);

        }

        private void FormTeachMode_FormClosing(object sender, FormClosingEventArgs e)
        {
            robotArm.StopReadingSensors(); 
            if (sensingTh != null && sensingTh.IsAlive)
            {
                sensingTh.Join(); // Czekanie na zakończenie wątku odp. za nasluch komunikatow o sensorach
            }
        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            mainForm.Show();//ponowne otwarcie menu
            Close(); // zamknięcie formularza
        }

        private void addPos_bt_Click(object sender, EventArgs e)
        {

            autoMode.addPoint(baseRotation, j1Rotation, j2Rotation, gripper); //dodanie punktu do interpolacji do listy punktow w obiekcie autoMode
            ListViewItem point = new ListViewItem(autoMode.getLastIdx().ToString());
            point.SubItems.Add($"base: {baseRotation}, joint1: {j1Rotation}, joint2: {j2Rotation}");// dodanie punktu do listy punktow w gui
            //point_lv.Items.Add($"base: {baseRotation}, joint1: {j1Rotation}, joint2: {j2Rotation}"); // dodanie punktu do listy punktow w gui (ListView)
            points_lv.Items.Add(point);
        }

        private async void autoMode_bt_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel(); // Cancel any existing task if running
                cts.Dispose();
            }

            cts = new CancellationTokenSource(); // Create a new token source
            try
            {
                await autoMode.LoopWork(robotArm, cts.Token); // Pass the token to the LoopWork method
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Praca automatyczna została zatrzymana.");
            }
            finally
            {
                cts.Dispose();
                cts = null;
            }
        }

        private void points_lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void baseRot_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void visuMovement_bt_Click(object sender, EventArgs e)
        {

            Visualization visuForm = new Visualization(j1Rotation, j2Rotation); //utowrzenie okna do wizualizacji pracy ramienia
            visuForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void rmPointBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in points_lv.Items)
            {
                if (item.Selected)
                {
                    item.Remove();
                    autoMode.removePoint(int.Parse(item.Text));
                }
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel(); // Signal cancellation
                Console.WriteLine("Praca automatyczna zatrzymana przez użytkownika.");
            }
        }

        private async void OneIterBtn_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel(); // Cancel any existing task if running
                cts.Dispose();
            }

            cts = new CancellationTokenSource(); // Create a new token source
            try
            {
                await autoMode.OneIteration(robotArm, cts.Token); // Pass the token to the LoopWork method
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Praca automatyczna została zatrzymana.");
            }
            finally
            {
                cts.Dispose();
                cts = null;
            }
        }
    }
}
