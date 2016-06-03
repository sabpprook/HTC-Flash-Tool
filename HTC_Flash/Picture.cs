using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTC_Flash
{
    public partial class Picture : Form
    {
        public string deviceSN { get; set; }
        public string deviceMode { get; set; }
        ProcessStartInfo psi = new ProcessStartInfo();
        string binDict = Path.GetTempPath() + "\\bin\\";

        public Picture()
        {
            InitializeComponent();
            psi.FileName = binDict + "adb.exe";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
        }

        private void Picture_FormClosing(object sender, FormClosingEventArgs e)
        {
            getfbTimer.Enabled = false;
            Hide();
            e.Cancel = true;
        }

        private void updateDevice_Tick(object sender, EventArgs e)
        {
            label1.Text = "SN: " + deviceSN;
            label2.Text = "Mode: " + deviceMode;
            if (!string.IsNullOrEmpty(deviceSN) && !string.IsNullOrEmpty(deviceMode) && (deviceMode.Equals("adb") || deviceMode.Equals("recovery")))
            {
                button1.Enabled = true;
                checkBox1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                pictureBox1.Image = null;
            }
        }

        private void deviceInit()
        {
            pushfb2png();
            chmodfb2png();
        }

        void pushfb2png()
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.Arguments = "-s " + deviceSN + " push " + binDict + "fb2png /data/local/tmp/fb2png";
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        void chmodfb2png()
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.Arguments = "-s " + deviceSN + " shell chmod 755 /data/local/tmp/fb2png";
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        void getfbpng()
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.Arguments = "-s " + deviceSN + " shell /data/local/tmp/fb2png /data/local/tmp/fb.png";
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        void getfbpng2()
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.Arguments = "-s " + deviceSN + " shell \"screencap -p /data/local/tmp/fb.png\"";
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        void pullfbpng()
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.Arguments = "-s " + deviceSN + " pull /data/local/tmp/fb.png";
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        private void getfbTimer_Tick(object sender, EventArgs e)
        {
            if (!getfbWorker.IsBusy)
                getfbWorker.RunWorkerAsync();
            GC.Collect();
        }

        private void getfbWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (deviceMode.Equals("adb"))
                getfbpng2();
            else if (deviceMode.Equals("recovery"))
                getfbpng();
            else
                e.Cancel = true;
        }

        private void getfbWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pullfbpng();
                Stream fs = File.OpenRead(@"fb.png");
                pictureBox1.Image = Image.FromStream(fs);
                fs.Close();
                File.Delete(@"fb.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!getfbWorker.IsBusy)
                getfbWorker.RunWorkerAsync();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                getfbTimer.Enabled = true;
            else
                getfbTimer.Enabled = false;
        }
    }
}
