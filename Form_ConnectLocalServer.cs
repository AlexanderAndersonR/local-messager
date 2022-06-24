using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace local_messager
{
    public partial class Form_ConnectLocalServer: Form
    {
        tcp.server Server { get; set; }
        public Form_ConnectLocalServer()
        {
            //Server = server;
            InitializeComponent();
            
        }
    }
}
