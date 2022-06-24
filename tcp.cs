using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace local_messager
{
    public class tcp
    {
        public class client
        {
            private TcpClient tcpClient = new TcpClient();
            public string ipAdress { get; set; }
            public int port { get; set; }
            public bool con_status { get; set; }
            public string code { get; set; }
            public bool connect()
            {
                try
                {
                    tcpClient.Connect(ipAdress, port);
                    con_status = true;
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка при подключении к серверу\r\n" + e, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    con_status = false;
                    return false;
                }
            }
            public bool connect(string _ipAdress, int _port)
            {
                ipAdress = _ipAdress;
                port=_port;
                return connect();
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
            public string GetHostName()
            {
                return Dns.GetHostName(); 
            }
            public string GetIPAdress()
            {
                return Dns.GetHostEntry(GetHostName()).AddressList[1].ToString();
            }
            public bool start()
            {
                work_flag = true;
                try
                {
                    if (String.IsNullOrEmpty(ipAdress))
                    {
                        tcpListener = new TcpListener(IPAddress.Any, port);
                    }
                    else
                    {
                        tcpListener = new TcpListener(IPAddress.Parse(ipAdress.Trim()), port);
                    }
                    tcpListener.Start();
                    return true;
                    //string name = Dns.GetHostName();
                    //string IP = Dns.GetHostByName(name).AddressList[0].ToString();
                    //var ip = Dns.GetHostEntry(name).AddressList[1];
                    //MessageBox.Show(name + ip);

                    //while (true)
                    //{
                    //    logic();
                    //}
                }
                catch (Exception e)
                {
                    work_flag = false;
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
            public bool start(string _ipAdress, int _port)
            {
                ipAdress = _ipAdress;
                port = _port;
                return start();
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
            public string message()
            {
                return "";
            }
        }
    }

}
