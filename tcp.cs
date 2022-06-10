using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace local_messager
{
    public class tcp
    {
        public class client
        {
            private TcpClient tcpClient = new TcpClient();
            public string server { get; set; }
            public int port { get; set; }
            public bool con_status { get; set; }
            public string code { get; set; }
            public void connect()
            {
                try
                {
                    tcpClient.Connect(server, port);
                    con_status = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка при подключении к серверу\r\n" + e, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    con_status = false;
                }
            }
            public string read()
            {
                try
                {
                    if (con_status)
                    {
                        NetworkStream stream = tcpClient.GetStream();
                        StringBuilder response = new StringBuilder();
                        byte[] data = new byte[256];
                        do
                        {
                            int bytes = stream.Read(data, 0, data.Length);
                            if (code == "UTF8")
                            {
                                response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                            }
                            else if (code == "ASCII")
                            {
                                response.Append(Encoding.ASCII.GetString(data, 0, bytes));
                            }
                            else if (code == "Unicode")
                            {
                                response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                            }
                            else if (code == "UTF7")
                            {
                                response.Append(Encoding.UTF7.GetString(data, 0, bytes));
                            }
                        }
                        while (stream.DataAvailable);
                        return response.ToString();
                    }
                    else
                    {
                        con_status = false;
                        return "port closed";
                    }
                }
                catch (Exception e)
                {
                    con_status = false;
                    MessageBox.Show("Ошибка при подключении к серверу\r\n" + e, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    return "port error";
                }
            }
            public void close()
            {
                if (tcpClient != null)
                {
                    if (con_status)
                    {
                        tcpClient.Close();

                    }
                }
            }
            public void Disconnect()
            {
                if (tcpClient.Connected)
                {
                    try
                    {
                        con_status = false;
                        tcpClient.Close();

                    }
                    catch (Exception)
                    {
                        con_status = false;
                    }

                }
            }
            public void Send(string message)
            {
                try
                {
                    if (con_status)
                    {
                        NetworkStream stream = tcpClient.GetStream();
                        byte[] data = new byte[message.Length];
                        if (code == "UTF8")
                        {
                            data = Encoding.UTF8.GetBytes(message);
                        }
                        else if (code == "ASCII")
                        {
                            data = Encoding.ASCII.GetBytes(message);
                        }
                        else if (code == "Unicode")
                        {
                            data = Encoding.Unicode.GetBytes(message);
                        }
                        else if (code == "UTF7")
                        {
                            data = Encoding.UTF7.GetBytes(message);
                        }
                        stream.Write(data, 0, data.Length);
                    }
                    else
                    {
                        con_status = false;
                        MessageBox.Show("Порт закрыт", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
                catch (Exception e)
                {
                    con_status = false;
                    MessageBox.Show("Ошибка при подключении к серверу\r\n" + e, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
        public class server
        {
            public TcpListener tcpListener;
            public string ipAdress { get; set; }
            public int port { get; set; }
            private bool work_flag = false;
            public void start()
            {
                start_logic();
            }
            public void start(string _ipAdress, int _port)
            {
                ipAdress = _ipAdress;
                port = _port;
                start_logic();
            }
            private void start_logic()
            {
                work_flag = true;
                try
                {
                    tcpListener = new TcpListener(System.Net.IPAddress.Parse(ipAdress), port);
                    tcpListener.Start();
                    while (true)
                    {
                        logic();
                    }
                }
                catch (Exception e)
                {
                    work_flag = false;
                    MessageBox.Show(e.Message);
                }
            }
            public void stop()
            {
                try
                {
                    tcpListener.Stop();
                    work_flag = false;
                }
                catch (Exception e)
                {
                    work_flag = false;
                    MessageBox.Show(e.Message);
                }
            }
            public virtual void logic()
            {

            }
        }
    }

}
