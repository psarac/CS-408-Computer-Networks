/*CS408 project
 * Doruk Benli-29182 Pelinsu Saraç - 28820
 * this is the client part of the project
 */

using Microsoft.VisualBasic.Logging;
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace cs408_project_client
{
    public partial class Form1 : Form
    {

        bool terminating = false; // flag to check if the client form is closing
        bool connected = false; // flag to check if the client is connected to the server
        Socket clientSocket; // socket that the client will use to connect to the server
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            // for the form to be closed without crashing
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNConnect_Click(object sender, EventArgs e)
        {
            // Client socket is initialized to be a TCP socket
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = IPtextBox.Text; // IP address of the server
            string Username = UsernametextBox.Text; // username of the client
            int portNum; // port that the server listens

            // if both IP address and port are provided
            if (Int32.TryParse(PorttextBox.Text, out portNum)&& IP != "")
            {
                try
                {
                    // try connecting to the server 
                    clientSocket.Connect(IP, portNum);

                    //send name to server if username field is not empty 
                    if (Username.Trim() != "" && Username.Length <= 64)
                    {
                        // send username via the connection
                        Byte[] buffer = Encoding.Default.GetBytes(Username);
                        clientSocket.Send(buffer);

                        // receive the message from server regarding the uniqueness of the name
                        Byte[] singleTimeReceiveBuffer = new Byte[256];
                        clientSocket.Receive(singleTimeReceiveBuffer);
                        string incomingStatus = Encoding.Default.GetString(singleTimeReceiveBuffer);
                        incomingStatus = incomingStatus.Substring(0, incomingStatus.IndexOf('\0'));

                        // if the username is not unique
                        if (incomingStatus == "Username not unique! \n")
                        {
                            // send acknowledgment to the server for it to close the related socket
                            string ack = "error message received";
                            Byte[] Errorbuffer = Encoding.Default.GetBytes(ack);
                            clientSocket.Send(Errorbuffer);

                            // inform the user about the existing name
                            StatusTextBox.AppendText(incomingStatus);
                            // close the socket as the server will also be closing the related socket 
                            clientSocket.Close();
                        }
                        else // username is unique
                        {
                            // inform the user about successful connection
                            StatusTextBox.AppendText(incomingStatus);

                            // enable the messaging utilities 
                            BTNConnect.Enabled = false;
                            BTNIF100sub.Enabled = true;
                            BTNSPS101sub.Enabled = true;
                            connected = true;

                            //start the receive thread
                            Thread receiveThread = new Thread(Receive);
                            receiveThread.Start();
                        }
                    }
                    else // no name provided by the server
                    {
                        //log error message and close socket for the next try 
                        StatusTextBox.AppendText("You should provide a username \n");
                        clientSocket.Close();
                    }
                }
                catch // in case connection cannot be established with the server
                {
                    // inform the user about server
                    StatusTextBox.AppendText("Could not connect to the server!\n");
                }
            }
            else // at least one field from IP address or port is empty
            {
                if(IP == "") // warn user about the IP address
                {
                    StatusTextBox.AppendText("Check the IP\n");
                }
                else
                {
                    // warn user about the port number
                    StatusTextBox.AppendText("Check the port\n");
                }
            }
        }

        private void Receive()
        {
            while (connected) // as long as the client is connected, it must receive what is coming form server
            {
                try
                {
                    // receive the encoded message from server
                    Byte[] buffer = new Byte[256];
                    clientSocket.Receive(buffer);

                    // decode the message into string 
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf('\0'));

                    // messages from server come in the form: <channel_name>@<username>:<message>
                    string channelName = incomingMessage.Substring(0, incomingMessage.IndexOf('@'));
                    string messageToPrint = incomingMessage.Substring(incomingMessage.IndexOf('@') + 1);


                    /* Important note:
                     * If a message arriving to a particular client,
                     * it is because server is sending it according to the client's subscription status
                     * block below is just in case if the client is subscribed to both channels
                     */

                    // if message is coming from IF100
                    if (channelName == "IF100")
                    {
                        // append to IF100 text box
                        IF100Chat.AppendText(messageToPrint);
                    }
                    else
                    {
                        // else, append to SPS101 text box 
                        SPS101Chat.AppendText(messageToPrint);
                    }

                }
                catch
                {
                    if (!terminating) // meaning that the error is due to the server
                    {
                        //inform the user about server disconnection
                        StatusTextBox.AppendText("The server has disconnected\n");

                        // revert the GUI back to the initial state
                        BTNConnect.Enabled = true;
                        BTNIF100sub.Enabled = false;
                        BTNSPS101sub.Enabled = false;
                        BTNIF100unsub.Enabled = false;
                        BTNSPS101unsub.Enabled = false;
                        BTN_IF100_send.Enabled = false;
                        BTN_SPS101_send.Enabled = false;
                        BTNIF100sub.BackColor = SystemColors.Control;
                        BTNIF100sub.UseVisualStyleBackColor = true;
                        BTNIF100sub.Text = "Subscribe";
                        BTNSPS101sub.BackColor = SystemColors.Control;
                        BTNSPS101sub.UseVisualStyleBackColor = true;
                        BTNSPS101sub.Text = "Subscribe";
                    }

                    // in any case, close the client socket for reconnection
                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        private void BTNIF100sub_Click(object sender, EventArgs e)
        {
            //send channel name to server along with sub message and make send button enabled, unsub enable, sub disable
            try
            {
                string message = "IF100@sub";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                BTNIF100sub.Enabled = false;
                BTNIF100unsub.Enabled = true;
                BTN_IF100_send.Enabled = true;
                IF100_text_box.Enabled = true;
                BTNIF100sub.BackColor = Color.Green;
                BTNIF100sub.Text = "Subscribed";
            }
            catch // in case server is disconnected during this process
            {
                StatusTextBox.AppendText("The server has disconnected\n");
                BTNConnect.Enabled = true;
                BTNIF100sub.Enabled = false;
                BTNSPS101sub.Enabled = false;
                BTN_IF100_send.Enabled = false;
                BTN_SPS101_send.Enabled = false;
                clientSocket.Close();
                connected = false;
            }


        }

        private void BTNSPS101sub_Click(object sender, EventArgs e)
        {
            //send channel name to server along with sub message and make send button enabled, unsub enable, sub disable
            try
            {
                string message = "SPS101@sub";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                BTNSPS101sub.Enabled = false;
                BTNSPS101unsub.Enabled = true;
                BTN_SPS101_send.Enabled = true;
                SPS101_text_box.Enabled = true;
                BTNSPS101sub.BackColor = Color.Green;
                BTNSPS101sub.Text = "Subscribed";
            }
            catch // in case server is disconnected during this process
            {
                StatusTextBox.AppendText("The server has disconnected\n");
                BTNConnect.Enabled = true;
                BTNIF100sub.Enabled = false;
                BTNSPS101sub.Enabled = false;
                BTN_IF100_send.Enabled = false;
                BTN_SPS101_send.Enabled = false;
                clientSocket.Close();
                connected = false;
            }
            
            
        }

        private void BTNIF100unsub_Click(object sender, EventArgs e)
        {
            //send channel name to server along with unsub message and make send button disabled, unsub disable, sub enable
            try
            {
                string message = "IF100@unsub";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                BTNIF100sub.Enabled = true;
                BTNIF100unsub.Enabled = false;
                BTN_IF100_send.Enabled = false;
                IF100_text_box.Enabled = false;
                BTNIF100sub.BackColor = SystemColors.Control;
                BTNIF100sub.UseVisualStyleBackColor = true;
                BTNIF100sub.Text = "Subscribe";
            }
            catch // in case server is disconnected during this process
            {
                StatusTextBox.AppendText("The server has disconnected\n");
                BTNConnect.Enabled = true;
                BTNIF100sub.Enabled = false;
                BTNSPS101sub.Enabled = false;
                BTN_IF100_send.Enabled = false;
                BTN_SPS101_send.Enabled = false;
                clientSocket.Close();
                connected = false;
            }
            
            
        }

        private void BTNSPS101unsub_Click(object sender, EventArgs e)
        {
            //send channel name to server along with unsub message and make send button disabled, unsub disable, sub enable
            try
            {
                string message = "SPS101@unsub";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                BTNSPS101sub.Enabled = true;
                BTNSPS101unsub.Enabled = false;
                BTN_SPS101_send.Enabled = false;
                SPS101_text_box.Enabled = false;
                BTNSPS101sub.BackColor = SystemColors.Control;
                BTNSPS101sub.UseVisualStyleBackColor = true;
                BTNSPS101sub.Text = "Subscribe";
            }
            catch // in case server is disconnected during this process
            {
                StatusTextBox.AppendText("The server has disconnected\n");
                BTNConnect.Enabled = true;
                BTNIF100sub.Enabled = false;
                BTNSPS101sub.Enabled = false;
                BTN_IF100_send.Enabled = false;
                BTN_SPS101_send.Enabled = false;
                clientSocket.Close();
                connected = false;
            }
            
            
        }

        private void BTN_IF100_send_Click(object sender, EventArgs e)
        {
            try
            {
                // form the message for server to read with channel name
                string text = IF100_text_box.Text;
                string message = $"IF100@{text}";

                // send the message
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                IF100_text_box.Clear();
            }
            catch // in case server is disconnected during this process
            {
                StatusTextBox.AppendText("The server has disconnected\n");
                BTNConnect.Enabled = true;
                BTNIF100sub.Enabled = false;
                BTNSPS101sub.Enabled = false;
                BTN_IF100_send.Enabled = false;
                BTN_SPS101_send.Enabled = false;
                clientSocket.Close();
                connected = false;
            }
            
        }

        private void BTN_SPS101_send_Click(object sender, EventArgs e)
        {
            try
            {
                // form the message for server to read with channel name
                string text = SPS101_text_box.Text;
                string message = $"SPS101@{text}";

                // send the message
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                SPS101_text_box.Clear();
            }
            catch // in case server is disconnected during this process
            {
                StatusTextBox.AppendText("The server has disconnected\n");
                BTNConnect.Enabled = true;
                BTNIF100sub.Enabled = false;
                BTNSPS101sub.Enabled = false;
                BTN_IF100_send.Enabled = false;
                BTN_SPS101_send.Enabled = false;
                clientSocket.Close();
                connected = false;
            }
            
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // connection is closing and the form is termination
            //  flags are set accordingly for threads to terminate
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }
    }
}