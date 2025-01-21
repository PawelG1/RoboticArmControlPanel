using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Net.Http;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace espControl1
{
    public partial class Form1 : Form
    {
        public SerialPort serialPort;
        RobotControl robotArm; 

        public Form1()
        {
            InitializeComponent();
            // Inicjalizacja portu szeregowego
            try
            {
                robotArm = new RobotControl(ports_combo, received_rtb); // inicjalizacja obiektu typu RobotControl do komunikacji
                                                                        // z mikrokontrolerem esp32 za pomoca polaczenia szeregowego
                                                                        //nie obsluzone jeszcze przyciski wiec zostaja wylaczone
            }catch (Exception ex)
            {
                MessageBox.Show($"Serial port initialization failed: {ex.Message}");
            }


            Cartesian_bt.Enabled = false;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //wyslanie polecenia wpisanego w pole txt do uC Esp32 
            string command = sendMessage_tb.Text;
            try
            {
                robotArm.sendCommand(command); // wyslanie polecenia API esp32 
                sendMessage_tb.Text = ""; //wyczyszczenie pola do wpisywania polecen
            }catch(Exception ex2)
            {
                MessageBox.Show($"Send command failed: {ex2.Message}");
            }

        }

        private void connect_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if(ports_combo.Items.Count > 0)//jesli wykryto jakiekowliek porty
                {
                    string selectedPort = ports_combo.SelectedItem.ToString(); // pobranie wybranego portu z 
                    robotArm.connect(selectedPort); // otwarcie polaczenia z wybranym portem
                }
                else
                {
                    MessageBox.Show("No available ports to connect");
                }
            }catch (Exception ex)
            {
                MessageBox.Show($"Unable to connect: {ex}");
            }
           
        }

        private void disconnect_bt_Click(object sender, EventArgs e)
        {
            try
            {
                robotArm.Close();//zamkniecie polaczenia z esp32
                ports_combo.Items.Clear();// wyczyszczenie listy combo box
            }
            catch(Exception ex3)
            {
                MessageBox.Show($"disconnecting failed: {ex3.Message}\n");
            }
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(robotArm.isConnected == true)
            {
                try
                {
                    FormJointControl formJC = new FormJointControl(this, robotArm); //utworzenie formularza do sterowania przegubami, 
                    Hide();
                    formJC.Show();
                }catch(Exception eee)
                {
                    MessageBox.Show(eee.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Nie polaczono z ESP23");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                robotArm.Close();
                Application.Exit(); //zamkniecie wszytskich formularzy
            }catch(Exception ex3)
            {
                MessageBox.Show($"Failed on closing: {ex3.Message}");
            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
           

        }

        private void refresh_bt_Click(object sender, EventArgs e)
        {
            try
            {
                ports_combo.Items.Clear();// wyczyszczenie listy combo box
                String[] ports = robotArm.listPorts();
                ports_combo.Items.AddRange(ports);// dodanie portow do ComboBox
                if (ports_combo.Items.Count > 0) // jesli wykryto jakiekolwiek porty
                {
                    ports_combo.SelectedIndex = 0; //wybranie domyslnie pierwszego dostepnego portu
                }
            }catch(Exception ee)
            {
                MessageBox.Show($"cannot refresh:{ee.Message}");
            }
            
        }

        private void teach_bt_Click(object sender, EventArgs e)
        {
            if (robotArm.isConnected == true)
            {
                try
                {
                    FormTeachMode formTM = new FormTeachMode(this, robotArm); //utworzenie formularza do sterowania przegubami, 
                    Hide();
                    formTM.Show();
                }catch(Exception eee)
                {
                    MessageBox.Show($"cannot enter teach mode: {eee.Message}");
                }
                
            }
            else
            {
                MessageBox.Show("Nie polaczono z ESP23");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
