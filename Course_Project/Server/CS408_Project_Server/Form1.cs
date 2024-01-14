/*CS408 project
 * Doruk Benli-29182 Pelinsu Saraç - 28820
 * this is the server part of the project
 */
using Microsoft.VisualBasic.Logging;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CS408_Project_Server
{
    public partial class Form1 : Form
    {
        //we are opening a new socket with a tcp connection
        //then we open 3 list that follows the connected but not subscribed users, or subscribed users.
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        List<Socket> IF100Sockets = new List<Socket>();
        List<Socket> SPS101Sockets = new List<Socket>();

        //variables for controlling the flow of the program.
        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            //The base form class, which has some options on threading and initializes components.
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ListenButton_Click(object sender, EventArgs e)
        {
            //Action on button "Listen", there is a port as an integer, to be taken as an input that we will listen.
            int serverPort;

            //check if there is a text on portTextBox
            if (Int32.TryParse(portTextBox.Text, out serverPort))
            {
                //create a new endpoint object, that listens on the corresponding port.
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen();
                //set listening state to true, also disable button for preventing collusion on same port.
                listening = true;
                ListenButton.Enabled = false;
                //start a new thread and pass the accept function
                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();
                //update  the monitor and inform user on the status of the server
                monitor.AppendText("Started listening on port: " + serverPort + "\n");
                portTextBox.Enabled = false;
                ListenButton.Enabled = false;

            }
            else
            {
                //if port text box is empty, it will append this following error message.
                monitor.AppendText("Please check the port number! \n");
            }

        }

        private void Accept()
        {
            //function that threads execute.
            while (listening)
            {
                //continue if we listen on the port, otherwise we do not have to exectue following
                try
                {
                    //open a new client socket, and also create a variable that checks if there are multiple names or not
                    Socket newClient = serverSocket.Accept();
                    bool isMultiple = false; // for a specific client, we check if it's name is multiple.
                    try
                    {
                        //create a buffer that will receive a message from client, since client sends its name first to be checked.
                        Byte[] buffer = new Byte[64];
                        newClient.Receive(buffer);

                        //string manipulation to extract the client name.
                        string newClientName = Encoding.Default.GetString(buffer);
                        newClientName = newClientName.Substring(0, newClientName.IndexOf('\0'));

                        //this loop checks if multiple names exists that are currently connected, this is case insensitive.
                        foreach (ListViewItem clientName in currentlyConnectedListView.Items)
                        {
                            if (clientName.Text.ToLower() == newClientName.ToLower())
                            {
                                //update the monitor and inform the GUI about the server's state.
                                monitor.AppendText("A new client tried to connect with an existing name. \n");
                                isMultiple = true;
                                //do not need to loop in foreach
                                break;
                            }
                        }

                        if (isMultiple)
                        {
                            // inform client about multiple name
                            string msg = "Username not unique! \n";
                            Byte[] sendBuffer = Encoding.Default.GetBytes(msg);
                            newClient.Send(sendBuffer); //informs client about the issue
                            //receive an acknowledgement from cleint side, that they are informed about this issue.
                            Byte[] receiveBuffer = new Byte[64];
                            newClient.Receive(receiveBuffer);
                            newClient.Close();
                        }
                        else
                        {
                            //successfull connection, add a new client, imform server GUI about the event by appending the monitor
                            clientSockets.Add(newClient);
                            currentlyConnectedListView.Items.Add(newClientName);
                            monitor.AppendText(newClientName + " has joined. \n");
                            //sends message to client
                            string msg = "Connected to the server \n";
                            Byte[] sendBuffer = Encoding.Default.GetBytes(msg);
                            newClient.Send(sendBuffer);

                            // Receive Thread start for the new client 
                            Thread receiveThread = new Thread(() => Receive(newClient, newClientName));
                            receiveThread.Start();
                        }

                    }
                    catch
                    {
                        //if there is a failure on sending name, this will trigger and handle the issue.
                        if (!terminating)
                        {
                            monitor.AppendText("New client could not send name. \n");
                        }
                        newClient.Close();
                    }
                }
                catch
                {
                    if (terminating)
                    {
                        //if we are terminating, we append that we are not listening.
                        monitor.AppendText("Server stopped listening \n");
                        listening = false;
                        // Client must understand that server is down and show appropriate message 
                    }
                    else
                    {
                        monitor.AppendText("Error occured while accepting a client.\n");
                    }
                }
            }
        }

        private void Receive(Socket thisClient, string clientName)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                // If a client send a message through a channel we can assume they are subscribed already, since send buttom will not be active
                try
                {
                    //create a new buffer for the message
                    Byte[] buffer = new Byte[256];
                    thisClient.Receive(buffer);
                    //string manipulation for extracting message.
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf('\0'));
                    //extracting the main message and channel body.
                    string channelName = incomingMessage.Substring(0, incomingMessage.IndexOf('@'));
                    string mainMessage = incomingMessage.Substring(incomingMessage.IndexOf('@') + 1);

                    // 1- subscribe to a channel

                    // message: "<channel_name>@sub"

                    if (mainMessage == "sub")
                    {
                        if (channelName == "IF100")
                        {
                            IF100Sockets.Add(thisClient);
                            IF100ListView.Items.Add(clientName);
                        }
                        else
                        {
                            SPS101Sockets.Add(thisClient);
                            SPS101ListView.Items.Add(clientName);
                        }

                        monitor.AppendText($"{clientName} has subscribed to {channelName}.\n");
                    }
                    // 2- Unsubscribe 

                    // message: <channel_name>@unsub
                    else if (mainMessage == "unsub")
                    {
                        //if we are unsubbing, remove from if100
                        if (channelName == "IF100")
                        {
                            IF100Sockets.Remove(thisClient);

                            foreach (ListViewItem item in IF100ListView.Items)
                            {
                                if (item.Text == clientName)
                                {
                                    IF100ListView.Items.Remove(item);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            //if we are unsubbing and not if100 remvoe from sps
                            SPS101Sockets.Remove(thisClient);

                            foreach (ListViewItem item in SPS101ListView.Items)
                            {
                                if (item.Text == clientName)
                                {
                                    SPS101ListView.Items.Remove(item);
                                    break;
                                }
                            }
                        }

                        monitor.AppendText($"{clientName} has unsubscribed from {channelName}. \n");
                    }
                    // 3- receive a message for a channel and send it to all others

                    // message: "<channel_name>@<message>
                    else
                    {
                        //server takes the messages and multicasts to all users, so server broadcasts.
                        string messageToPost = $"{channelName}@{clientName}: {mainMessage} \n"; 
                        Byte[] bufferMulticast = Encoding.Default.GetBytes(messageToPost);
                        if (channelName == "IF100")
                        {
                            //informs all cleints that are subbed to IF100
                            foreach (Socket client in IF100Sockets)
                            {
                                try
                                {
                                    client.Send(bufferMulticast);
                                }
                                catch
                                {
                                    monitor.AppendText("Problem occured while sending message to IF100 channel, check the connection.\n");
                                    terminating = true;
                                    portTextBox.Enabled = true;
                                    ListenButton.Enabled = true;
                                    serverSocket.Close();
                                }

                            }
                        }

                        else
                        {
                            //or informs all cleints that are subbed to sps101, if channel name is not if100
                            foreach (Socket client in SPS101Sockets)
                            {
                                try
                                {
                                    client.Send(bufferMulticast);
                                }
                                catch
                                {
                                    monitor.AppendText("Problem occured while sending message to SPS101 channel, check the connection.\n");
                                    terminating = true;
                                    portTextBox.Enabled = true;
                                    ListenButton.Enabled = true;
                                    serverSocket.Close();
                                }

                            }
                        }
                        //we also append it to monitor.
                        monitor.AppendText($"{clientName}@{channelName}: {mainMessage} \n");
                    }
                }
                catch
                {
                    //if client disconnects and server is not terminating
                    if (!terminating)
                    {
                        monitor.AppendText(clientName + " has disconnected\n");
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    //upper code removes client form socket, then we also remove client from socket lists by searching them in all lists.

                    foreach (ListViewItem item in currentlyConnectedListView.Items)
                    {
                        if (item.Text == clientName)
                        {
                            currentlyConnectedListView.Items.Remove(item);
                            break;
                        }
                    }

                    IF100Sockets.Remove(thisClient);
                    foreach (ListViewItem item in IF100ListView.Items)
                    {
                        if (item.Text == clientName)
                        {
                            IF100ListView.Items.Remove(item);
                            break;
                        }
                    }

                    SPS101Sockets.Remove(thisClient);
                    foreach (ListViewItem item in SPS101ListView.Items)
                    {
                        if (item.Text == clientName)
                        {
                            SPS101ListView.Items.Remove(item);
                            break;
                        }
                    }
                    connected = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }
    }
}