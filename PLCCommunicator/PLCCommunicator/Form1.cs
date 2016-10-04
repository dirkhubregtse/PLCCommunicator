using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using System.Net;

namespace PLCCommunicator
{
    public partial class Form1 : Form
    {
        public string address;
        public Form1()
        {
            InitializeComponent();
        }

        private void IP_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void Set_IP_Click(object sender, EventArgs e)
        {
            //Checken of de input een geldig IP-address is
            IPAddress ipAddress;
            if (IPAddress.TryParse(IP_address.Text, out ipAddress))
            {
                address = IP_address.Text;
            }
            else
            {
                address = "No valid IP!";
            }
            
            label2.Text = address;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            using (var plc = new Plc(CpuType.S71200, address, 0, 1))
            {
                plc.Open();
                plc.Write("DB1.DBW8.0", 1);
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            using (var plc = new Plc(CpuType.S71200, address, 0, 1))
            {
                plc.Open();
                plc.Write("DB1.DBW8.0", 0);
            }
        }

        private void IP_address_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                Set_IP_Click(this, new EventArgs());
            }
        }

        private void Output1_on_Click(object sender, EventArgs e)
        {
            using (var plc = new Plc(CpuType.S71200, address, 0, 1))
            {
                plc.Open();
                plc.Write("DB1.DBW48.0", 1);
            }
        }

        private void Output_off_Click(object sender, EventArgs e)
        {
            using (var plc = new Plc(CpuType.S71200, address, 0, 1))
            {
                plc.Open();
                plc.Write("DB1.DBW48.0", 0);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
