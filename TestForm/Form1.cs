using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        string m_splitter = "'\\'";
        string m_fName = string.Empty;
        string[] m_split = null;
        byte[] m_clientData = null;
        enum DataPacketType { TEXT = 1, IMAGE };
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            char[] delimeter = m_splitter.ToCharArray();

            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.ShowDialog();

            //textBox1.Text = openFileDialog1.FileName;
         

            //m_split = textBox1.Text.Split(delimeter);
            //int limit = m_split.Length;

            //m_fName = m_split[limit - 1].ToString();

            //if (textBox1.Text != null)
            //    btnSend.Enabled = true;


        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //byte[] textData = Encoding.UTF8.GetBytes(textBox2.Text);
            byte[] fileType = BitConverter.GetBytes((int)DataPacketType.TEXT);
            // TEXT(4 byte) + 데이타 길이
            //m_clientData = new byte[fileType.Length + textData.Length];

            fileType.CopyTo(m_clientData, 0);
            //textData.CopyTo(m_clientData, 4);

            IPHostEntry ip =Dns.GetHostByName("devcork.toktok.sk.com");

            clientSocket.Connect(IPAddress.Parse("192.168.0.11"), 8888);
            clientSocket.Send(m_clientData);
            clientSocket.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
