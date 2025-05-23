﻿using System;
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
    public partial class FormJointControl : Form
    {
        RobotControl robotArm;
        private Form mainForm; //uchwyt fo formularza glownego
        private Thread sensingTh; // watek w ktorym obslugiwane sa sygnaly z sensorwo

        public FormJointControl(Form form1, RobotControl rArm)
        {
            mainForm = form1; //przypisanie formularza glownego menu do mainForm by umozliwic ponowne otwarcie menu
            InitializeComponent();
            grip_trb.SetRange(0, 110); // ustawienie zakresu wartosci dla trackbara odpowiadajacego za chwytak
            baseRot_trb.SetRange(0, 180);
            j1Rot_trb.SetRange(0, 180);
            j2Rot_trb.SetRange(0, 180);
            robotArm = rArm; // przypisanie przekazanaego obiektu RobotControl
            sensingTh = robotArm.readingSensorsThread();
            sensingTh.Start();
            robotArm.resetRobot();// wyresetowanie przegubow robota
            //przypisanie wartosci startowych poszczegolnych serv do trackbarow
            Thread.Sleep(500);
            baseRot_trb.Value = robotArm.baseServo.GetServoPos();
            j1Rot_trb.Value = robotArm.j1Servo.GetServoPos();
            j2Rot_trb.Value = robotArm.j2Servo.GetServoPos();
            grip_trb.Value = robotArm.gripperServo.GetServoPos();
            //przypisanie tych watosci tez do label obok trackbar
            baseRot_tb.Text = baseRot_trb.Value.ToString();
            j1Rot_tb.Text = j1Rot_trb.Value.ToString();
            j2Rot_tb.Text = j2Rot_trb.Value.ToString();
            grp_tb.Text = grip_trb.Value.ToString();

        }

        private void RotBase_trb_Scroll(object sender, EventArgs e)
        {
            int baseRotation = baseRot_trb.Value;
            baseRot_tb.Text = baseRotation.ToString();
            robotArm.baseServo.move(baseRotation);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            mainForm.Show();//ponowne otwarcie menu
            Close(); // zamknięcie formularza
        }

        private void j1Rot_trb_Scroll(object sender, EventArgs e)
        {
            int j1Rotation = j1Rot_trb.Value; //pobranie wartosci dot. obrotu z trackbar
            j1Rot_tb.Text = j1Rotation.ToString(); // konwersja na string
            robotArm.j1Servo.move(j1Rotation); // obrot serwa 1 przeguba na zadana w trackbarze pozycje
        }

        private void j2Rot_trb_Scroll(object sender, EventArgs e)
        {
            int j2Rotation = j2Rot_trb.Value;
            j2Rot_tb.Text = j2Rotation.ToString();
            robotArm.j2Servo.move(j2Rotation);
        }

        private void grip_trb_Scroll(object sender, EventArgs e)
        {
            int gripper = grip_trb.Value;
            grp_tb.Text = gripper.ToString();
            robotArm.gripperServo.move(gripper);
        }

        private void FormJointControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            robotArm.StopReadingSensors(); // zatrzymanie watku do nasluchu kom. o sensorach 
            if (sensingTh != null && sensingTh.IsAlive)
            {
                sensingTh.Join(); // Czekanie na zakończenie wątku
            }
        }

        private void baseRot_tb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
