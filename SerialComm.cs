using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace espControl1
{
    public class SerialComm
    {
        private SerialPort serialPort; // obiekt klasy SerialPort
        //private string receivedMessage; 
        private RichTextBox receivingTb;
        private bool _isConnected = false; // stan czy udalo sie polaczyc z esp

        //variables to store received sensors data
        private bool _proximity_sensor = false;// Flaga określająca stan czujnika zblizeniowego indukcujnego

        public bool proximity_sensor
        {
            get { return _proximity_sensor; }
        }

        public bool isConnected //getter dla wartosci is connected
        {
            get
            { return _isConnected; }
        }

        public SerialComm(RichTextBox recBox)
        {
            receivingTb = recBox;
            // inicjalizacja portu szeregowego
            serialPort = new SerialPort
            {
                BaudRate = 115200,  // ustawienia szybkosci transmisji
                DataBits = 8,       // liczba bitów danych
                StopBits = StopBits.One,  // bity stopu
                Parity = Parity.None,     // parzystosc
                Handshake = Handshake.None // brak sterowania przepływem
            };

            serialPort.DataReceived += SerialPort_DataReceived; // obsługa zdarzenia odbioru danych t.j. przypisanie metody do obslugi zdarzenia dataReceived za pomoca operatora +=, 

        }

        public SerialComm(string port)
        {
            // inicjalizacja portu szeregowego
            serialPort = new SerialPort
            {
                BaudRate = 115200,  // ustawienia szybkosci transmisji
                DataBits = 8,       // liczba bitów danych
                StopBits = StopBits.One,  // bity stopu
                Parity = Parity.None,     // parzystosc
                Handshake = Handshake.None // brak sterowania przepływem
            };

            serialPort.DataReceived += SerialPort_DataReceived; // obsługa zdarzenia odbioru danych t.j. przypisanie metody do obslugi zdarzenia dataReceived za pomoca operatora +=, 

        }


        public void sendCommand(string command)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.WriteLine(command); // wysyłanie komendy do ESP32
                }
                else
                {
                    MessageBox.Show("Port nie jest otwarty.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wysyłania: {ex.Message}");
            }
        }

        public string[] listPorts()
        {
            string[] ports = Array.Empty<string>(); //pusta tablica typu string 
            try
            {               
                ports = SerialPort.GetPortNames();// pobranie dostepnych portow szeregowych i zapis do tablicy
                if (ports.Length > 0)
                {
                    MessageBox.Show("Porty załadowane pomyślnie.");
                    return ports;
                }
                else
                {
                    MessageBox.Show("Brak dostępnych portów COM.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas pobierania portów: {ex.Message}");
            }
            return ports;
        }

        public void Close()
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close(); // zamkniecie poloczenia z portem szeregowym
                    _isConnected = false; // nadpisanie flagi ze rozlaczono
                    MessageBox.Show("Rozłączono z ESP32!");
                }
                else
                {
                    MessageBox.Show("Port już jest zamknięty.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas rozłączania: {ex.Message}");
            }
        }

        public void connect(string selectedPort)
        {
            try
            {
                if (!serialPort.IsOpen) // jesli port nie jest juz otwarty
                {
                    serialPort.PortName = selectedPort; // ustawienie podanego portu
                    serialPort.Open(); //otwarcie polaczenia z portem szeregowym
                    _isConnected = true; //nadpisanie flagi ze otwarto polaczenioe
                    MessageBox.Show("Połączono z ESP32!");
                }
                else
                {
                    MessageBox.Show("Port jest już otwarty.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas łączenia: {ex.Message}");
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // sdczyt pełnej linii
                string receivedMessage = serialPort.ReadLine().Trim();
                //
                receivingTb.Invoke(new Action(() => { receivingTb.Text += receivedMessage+ "\n"; }));
                //koniecze jest wykorzystanie invoke poniewaz kontrolki formularza dzialaja w innym watku i przy probie przypisania ich w tym watku wystepuje blad
                //invoke powoduje ze metoda wywolana w nim wykona sie w watku w ktorym utworzona zostala kontrolka receivingTb
                //jako argument do metody Invoke przekazany zostala nowa akcja w ktorej przekazujemy funkcje anonimowa zwracajaca wlasnie przypisanie odberanej
                //wiadomosci do pola txt
                //przez uzycie invoke przypisanie tekstu wystapilo w watku w ktorym utworzona zostala kontrolka

                Console.WriteLine(receivedMessage);
                if(receivedMessage == "S36 HIGH") //sprawdzenie czy otrzymano komunikat o stanie wysokim sensora
                {
                    _proximity_sensor = true;
                }else if(receivedMessage == "S36 LOW")
                {
                    _proximity_sensor = false;
                }

            }
            catch (TimeoutException)
            {
                MessageBox.Show("Timeout");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas odbierania danych: {ex.Message}");
            }
        }


    }
}
