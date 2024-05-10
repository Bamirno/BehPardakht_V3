using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new BehPardakhtConnector.TCPClient("192.168.1.102", 6062);
            var response = client.Payment(10000);
            richTextBox1.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }
    }
}
