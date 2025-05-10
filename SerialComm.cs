using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;


namespace espControl1
{
    public class SerialComm
    {
        private SerialPort serialPort; // obiekt klasy SerialPort
        //private string receivedMessage; 
        private RichTextBox receivingTb;
        private bool _isConnected = false; // stan czy udalo sie polaczyc z esp

        // Do synchronizacji odpowiedzi:
        private readonly object _lock = new object();
        private string _syncResponse;
        private readonly AutoResetEvent _responseEvent = new AutoResetEvent(false);
        private string _expectedPinToken;

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

        private StringBuilder _recvBuf = new StringBuilder();

        // w klasie SerialComm:
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // 1) pobierz wszystkie aktualnie dostępne znaki
                string chunk = serialPort.ReadExisting();

                lock (_recvBuf)
                {
                    _recvBuf.Append(chunk);
                    string all = _recvBuf.ToString();
                    int idx;

                    // 2) rozbijamy po '\n'
                    while ((idx = all.IndexOf('\n')) >= 0)
                    {
                        string line = all.Substring(0, idx).Trim('\r', '\n');
                        all = all.Substring(idx + 1);

                        // 3) zawsze doklejaj do UI
                        receivingTb.Invoke((Action)(() =>
                            receivingTb.AppendText(line + Environment.NewLine)
                        ));
                        Console.WriteLine(line);

                        // 4) jeżeli czekamy na GET S{pin} – poszukaj regexem w tej linii
                        if (_expectedPinToken != null)
                        {
                            string pattern = $@"S{_expectedPinToken}\s+(-?\d+)deg";
                            var m = System.Text.RegularExpressions.Regex.Match(line, pattern);
                            if (m.Success)
                            {
                                // odtwórz kanoniczną formę i powiadom wątek
                                string resp = $"S{_expectedPinToken} {m.Groups[1].Value}deg";
                                lock (_lock)
                                {
                                    _syncResponse = resp;
                                    _responseEvent.Set();
                                }
                            }
                        }

                        // 5) czujnik proximity
                        if (line == "S36 HIGH") _proximity_sensor = true;
                        else if (line == "S36 LOW") _proximity_sensor = false;
                    }

                    // 6) zostaw niekompletny ogon
                    _recvBuf.Clear();
                    _recvBuf.Append(all);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas odbierania danych: {ex.Message}");
            }
        }







        /// <summary>
        /// Wysyła komendę i czeka na jedną linię odpowiedzi lub aż minie timeout.
        /// </summary>
        /// <summary>
        /// Wysyła komendę i blokuje bezpośrednio na ReadLine() dopóki nie dostanie linii z "S{pin} ...deg"
        /// </summary>
        public string SendCommandAndWait(string command, int timeoutMs = 2000)
        {
            if (!serialPort.IsOpen)
                throw new InvalidOperationException("Port nie jest otwarty.");

            // 1) Wyrzuć wszystkie zalegające bajty (echo SAFE, echa move itp.)
            serialPort.DiscardInBuffer();

            // 2) Ustaw timeout na ReadLine
            serialPort.ReadTimeout = timeoutMs;

            // 3) Wyślij GET-a (np. "GET S23")
            serialPort.WriteLine(command);

            // 4) Oblicz deadline
            var deadline = DateTime.UtcNow.AddMilliseconds(timeoutMs);
            // 5) Token pinu, np. "S23"
            string pinToken = command.Substring(4).Trim();

            while (DateTime.UtcNow < deadline)
            {
                string line;
                try
                {
                    // to zablokuje do momentu otrzymania '\n' lub timeoutu
                    line = serialPort.ReadLine().Trim();
                }
                catch (TimeoutException)
                {
                    break;
                }

                // 6) Filtrujemy tylko tę jedną linijkę, która kończy się "deg"
                //    i zawiera dokładnie nasz pinToken ("S23").
                if (line.StartsWith(pinToken, StringComparison.Ordinal) &&
                    line.EndsWith("deg", StringComparison.Ordinal))
                {
                    return line;
                }
                // inne linie (SAFE-logi, Servo-logi) ignorujemy i czytamy dalej
            }

            throw new TimeoutException(
                $"Brak odpowiedzi „{pinToken} …deg” w ciągu {timeoutMs} ms.");
        }











    }
}
