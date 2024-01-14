using Microsoft.VisualBasic.Logging;
using System.Net.Sockets;
using System.Text;

namespace psarac_Sarac_Pelinsu
{
    public partial class Form1 : Form
    {
        Socket clientSocket;
        string name;
        string email;
        string message;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string IP = textBox_ip.Text;
            int portNum;

            if (Int32.TryParse(textBox_port.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    log.AppendText("Connection established...\n");

                    name = textBox_name.Text;
                    email = textBox_email.Text;
                    message = email + " " + name;

                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                    log.AppendText("Message sent:" + message + "\n");

                    Thread receiveTokenThread = new Thread(ReceiveToken);
                    receiveTokenThread.Start();

                }
                catch
                {
                    log.AppendText("Problem occurred while connecting...\n");
                }
            }
            else
            {
                log.AppendText("Problem occurred due to port number...\n");
            }

        }

        private void ReceiveToken()
        {
            try
            {
                Byte[] buffer = new Byte[4]; 
                clientSocket.Receive(buffer);

                string token = Encoding.Default.GetString(buffer);
                //token = token.Substring(0, token.IndexOf("\0"));

                log.AppendText("Server: " + token + "\n");

                string re_name = textBox_name.Text;
                int sum = 0;

                //log.AppendText("Server: " + token.Length + "\n");

                for (int i = 0; i < email.Length; i++) 
                {
                    char digit = token[i % token.Length];
                    int digit_int = digit - '0';
                    int shifted_ascii_value = email[i] + digit_int;
                    sum += shifted_ascii_value;
                }

                string sum_str = sum.ToString();
                string msg_to_be_sent = sum_str + " " + re_name;
                Byte[] buffer_to_send = Encoding.Default.GetBytes(msg_to_be_sent);
                clientSocket.Send(buffer_to_send);
                log.AppendText("Message sent: " + msg_to_be_sent + "\n");

                Thread receiveLastThread = new Thread(ReceiveLast);
                receiveLastThread.Start();

            }
            catch
            {
                log.AppendText("Could not receive token or sent the message!\n");
                clientSocket.Close();
            }
        }

        private void ReceiveLast()
        {
            try
            {
                Byte[] buffer = new Byte[64]; 
                clientSocket.Receive(buffer);

                string incomingMessage = Encoding.Default.GetString(buffer);
                //incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                log.AppendText("Server: " + incomingMessage + "\n");

                clientSocket.Close();

            }
            catch
            {
                log.AppendText("Could not receive token or sent the message!\n");
                clientSocket.Close();
            }
        }
    }
}