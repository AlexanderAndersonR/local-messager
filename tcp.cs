using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace local_messager
{
    public class tcp
    {
        public class client
        {
            private TcpClient tcpClient = new TcpClient();
            public bool debugging;
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
                    if (debugging) MessageBox.Show("Ошибка при подключении к серверу\r\n" + e, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    con_status = false;
                    return false;
                }
            }
            public bool connect(string _ipAdress, int _port)
            {
                ipAdress = _ipAdress;
                port = _port;
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
                    if (debugging) MessageBox.Show("Ошибка при подключении к серверу\r\n" + e, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    return "port error";
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
                    catch (Exception e)
                    {
                        con_status = false;
                        if (debugging) MessageBox.Show(e.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

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
                    if (debugging) MessageBox.Show("Ошибка при подключении к серверу\r\n" + e, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
        public class server
        {
            public List<TcpClient> clients = new List<TcpClient>();
            public TcpListener tcpListener;
            public bool debugging_message;
            public bool thow_exeption;
            public string ipAdress { get; set; }
            public int port { get; set; }
            public string code { get; set; }
            public bool work_flag = false;
            public string GetHostName()
            {
                return Dns.GetHostName();
            }
            public string GetIPAdress()
            {
                //change
                // ip version 
                //return Dns.GetHostEntry(GetHostName()).AddressList[1].ToString();
                IPAddress[] loc_ip = Dns.GetHostAddresses(Dns.GetHostName());
                //StringBuilder builder = new StringBuilder();
                //loc_ip[loc_ip.Length]
                //foreach (var item in loc_ip)
                //{
                //    builder.Append(item.ToString());
                //}
                //return builder.ToString();

                return loc_ip[loc_ip.Length - 1].ToString();
            }
            public bool start()
            {
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
                    work_flag = true;
                    return true;
                }
                catch (Exception e)
                {
                    work_flag = false;
                    if (debugging_message) MessageBox.Show(e.Message);
                    if (thow_exeption) throw;
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
                    foreach (var item in clients)
                    {
                        item.Close();
                    }
                    tcpListener.Stop();
                    clients.Clear();
                    work_flag = false;
                }
                catch (Exception e)
                {
                    work_flag = false;
                    if (debugging_message) MessageBox.Show(e.Message);
                    if (thow_exeption) throw;
                }
            }
            public string read(TcpClient tcpClient)
            {
                try
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
                    stream.Close();
                    return response.ToString();
                }
                catch (Exception e)
                {
                    work_flag = false;
                    if (debugging_message) MessageBox.Show(e.Message);
                    if (thow_exeption) throw;
                    return "port error";
                }
            }
            public void Send(string message)
            {
                try
                {
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
                    foreach (TcpClient item in clients)
                    {
                        NetworkStream stream = item.GetStream();
                        stream.Write(data, 0, data.Length);
                    }
                }
                catch (Exception e)
                {
                    if (debugging_message) MessageBox.Show(e.Message);
                    if (thow_exeption) throw;
                }
            }
        }
    }
}

