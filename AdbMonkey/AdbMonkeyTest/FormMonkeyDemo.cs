using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vrocky.AdbMonkey;

namespace Vrocky.AdbMonkeyTest
{
    public partial class FormMonkeyDemo : Form
    {

        Monkey monkey;
        Boolean IsDown = false;


        public FormMonkeyDemo()
        {
            InitializeComponent();
        }

        private void FormMonkeyDemo_Load(object sender, EventArgs e)
        {
            var devices = AdbClient.Instance.GetDevices();
        }
        List<DeviceData> devices;
        private void button1_Click(object sender, EventArgs e)
        {
            var devices = AdbClient.Instance.GetDevices();
            this.devices = devices;
            comboBox1.DataSource = devices;
       
        }
   

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedDevice != null)
            {
                IsDown = false;
                monkey.Up();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedDevice != null)
            {
                IsDown = true;
                monkey.Down((UInt32)e.X, (UInt32)e.Y);
            }
        }
   
    
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(selectedDevice != null)
            if (IsDown)
            {
                monkey.SetXY((UInt32)e.X, (UInt32)e.Y);
            }
        }

        DeviceData selectedDevice;
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                selectedDevice = devices[comboBox1.SelectedIndex];
                setMonkey();
                pictureBox1.Enabled = true;
            }
            else
            {
                selectedDevice = null;
                pictureBox1.Enabled = false;
            }
        }

        public void setMonkey()
        {
            //INPUT EVENT CAN BE GET BY PRACTICALLY EXECUTING getevent COMMAND AND ACTUALLY TOUCHING THE DEVICE
            monkey = new Monkey(selectedDevice, new InputEvent(0));
        }
    }
}
