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
using System.Threading;
using System.Globalization;

namespace GCam_Mi_A1
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void GCamBT_Click(object sender, EventArgs e)
        {
            

        }

        private void driversBT_Click(object sender, EventArgs e)
        {

        }


        Process p = new Process();

        private void encuentraMovil()
        {
            //cmd
            cmd();
            //encuentra móvil
            p.StartInfo.Arguments = "/c adb kill-server";
            p.Start();
            p.WaitForExit();

            p.StartInfo.Arguments = "/c adb wait-for-device devices";
            p.Start();
            Form mensaje = new ADBMSB();
            mensaje.Show();
            p.WaitForExit();
            mensaje.Close();
        }

        private void cmd()
        {
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
        }

        private void fastBoot()
        {
            p.StartInfo.Arguments = "/c adb reboot bootloader";
            p.Start();
            p.WaitForExit();
        }

        private void twrp()
        {
            p.StartInfo.Arguments = @"/c fastboot boot " + "\"" + Path.Combine(Application.StartupPath, @"Files\adb\twrp.img") + "\"";
            p.Start();
            p.WaitForExit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //CMD
            cmd();

            //encuentra movil
            encuentraMovil();

            //Instala app
            estadoLabel.Text = Resource1.GCam_install;
            p.StartInfo.Arguments = "/c adb install " + "\"" + Path.Combine(Application.StartupPath, @"Files\app\GoogleCamera.apk") + "\"";
            p.Start();
            p.WaitForExit();

            //entra en fastboot
            estadoLabel.Text = Resource1.Main_pro_bootdes ;
            fastBoot();

            //desbloqueo
            p.StartInfo.Arguments = "/c fastboot oem unlock";
            p.Start();
            p.WaitForExit();

            //bootea en twrp
            estadoLabel.Text = Resource1.twrp;
            twrp();
            estadoLabel.Text = Resource1.twrp;

            //esperar

            System.Threading.Thread.Sleep(30000);
            estadoLabel.Text = Resource1.twrp;

            //HAL3
            p.StartInfo.Arguments = "/c adb shell setprop persist.camera.HAL3.enabled 1";
            p.Start();
            p.WaitForExit();

            //EIS
            p.StartInfo.Arguments = "/c adb shell setprop persist.camera.eis.enable 1";
            p.Start();
            p.WaitForExit();

            //sonido
            p.StartInfo.Arguments = "/c adb shell setprop ro.qc.sdk.audio.fluencetype fluencepro";
            p.Start();
            p.WaitForExit();

            p.StartInfo.Arguments = "/c adb reboot-bootloader";
            p.Start();
            p.WaitForExit();

            //bloqueo
            estadoLabel.Text =  Resource1.Main_pro_bootblo;
            p.StartInfo.Arguments = "/c fastboot oem lock";
            p.Start();
            p.WaitForExit();

            estadoLabel.Text = Resource1.reiniciar;
            p.StartInfo.Arguments = "/c fastboot reboot";
            p.Start();
            p.WaitForExit();

            estadoLabel.Text = Resource1.finalizado;
            //mensaje camara
            MessageBox.Show(Resource1.Main_pro_precam);
            Process.Start(Path.Combine(Application.StartupPath, "Files/photos/camara.jpg"));

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
             Form mensajeDrivers = new DriversMSB();
             mensajeDrivers.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=JGTRVHM65657L");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }


        int TogMove;
        int MValX;
        int MValY;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

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

        private void label3_Click(object sender, EventArgs e)
        {
            Process.Start(Resource1.post);
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //CMD
            cmd();

            //encuentra movil
            encuentraMovil();

            //entra en fastboot
            estadoLabel.Text = Resource1.Main_pro_bootdes;
            fastBoot();

            //desbloqueo
            p.StartInfo.Arguments = "/c fastboot oem unlock";
            p.Start();
            p.WaitForExit();

            //bootea en twrp
            estadoLabel.Text = Resource1.twrp;
            twrp();
            estadoLabel.Text = Resource1.twrp;

            //esperar

            System.Threading.Thread.Sleep(30000);
            estadoLabel.Text = Resource1.twrp;

            //HAL3
            p.StartInfo.Arguments = "/c adb shell setprop persist.camera.HAL3.enabled 0";
            p.Start();
            p.WaitForExit();

            //EIS
            p.StartInfo.Arguments = "/c adb shell setprop persist.camera.eis.enable 0";
            p.Start();
            p.WaitForExit();

            //sonido
            p.StartInfo.Arguments = "/c adb shell setprop ro.qc.sdk.audio.fluencetype none";
            p.Start();
            p.WaitForExit();

            p.StartInfo.Arguments = "/c adb reboot-bootloader";
            p.Start();
            p.WaitForExit();

            //bloqueo
            estadoLabel.Text = Resource1.Main_pro_bootblo;
            p.StartInfo.Arguments = "/c fastboot oem lock";
            p.Start();
            p.WaitForExit();

            estadoLabel.Text = Resource1.reiniciar;
            p.StartInfo.Arguments = "/c fastboot reboot";
            p.Start();
            p.WaitForExit();

            estadoLabel.Text = Resource1.finalizado;
        }
    }
}
