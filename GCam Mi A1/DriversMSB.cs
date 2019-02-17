using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace GCam_Mi_A1
{
    public partial class DriversMSB : Form
    {
        public DriversMSB()
        {
            InitializeComponent();
        }

        int TogMove;
        int MValX;
        int MValY;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var procesoDrivers = Process.Start(Path.Combine(Application.StartupPath, "Files/drivers/adb-setup-1.4.3.exe"));
                procesoDrivers.WaitForExit();
            }
            catch (Exception)
            {
                MessageBox.Show("Archivo no encontrado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var procesoDrivers = Process.Start(Path.Combine(Application.StartupPath, "Files/drivers/adb-setup-1.3.exe"));
                procesoDrivers.WaitForExit();
            }
            catch (Exception)
            {
                MessageBox.Show("Archivo no encontrado");
            }
        }
    }
}
