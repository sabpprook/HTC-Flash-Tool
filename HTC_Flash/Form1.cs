using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HTC_Flash
{
    public partial class Form1 : Form
    {
        List<string> Devices = new List<string>();
        string DeviceSN = "", DeviceMode = "";
        ProcessStartInfo psi = new ProcessStartInfo();
        string binDict = Application.StartupPath + "\\bin\\";
        string tmpDict = Path.GetTempPath();

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.WorkingDirectory = binDict;
            psi.Verb = "runas";
            releaseData();
            updateTimer.Start();
        }

        private void releaseData()
        {
            Directory.CreateDirectory(binDict);

            string[] data = { "adb.exe", "AdbWinApi.dll", "fastboot.exe", "mfastboot.exe" };
            Assembly asm = Assembly.GetExecutingAssembly();

            foreach (var str in data)
            {
                if (!File.Exists(str))
                {
                    using (FileStream fs = new FileStream(binDict + str, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        asm.GetManifestResourceStream("HTC_Flash.Resources." + str).CopyTo(fs);
                        fs.Close();
                    }
                }
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (!updateDevices.IsBusy)
                updateDevices.RunWorkerAsync();
        }

        private void updateDevices_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = getAdbDevices().Concat(getFastbootDevices()).ToList();
        }

        private void updateDevices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool flag = false;
            List<string> tmp = e.Result as List<string>;
            if (tmp.Count.Equals(Devices.Count))
            {
                for (int i=0; i< tmp.Count; i++)
                {
                    if (!tmp[i].Equals(Devices[i]))
                        flag = true;
                }
            }
            else
            {
                flag = true;
            }
            if (flag)
            {
                Devices = tmp;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < Devices.Count; i += 2)
                    dataGridView1.Rows.Add(new Object[] { Devices[i], Devices[i + 1] });

                if (!(dataGridView1.Rows.Count == 0))
                {
                    DeviceSN = dataGridView1.CurrentRow.Cells[0].Value as string;
                    DeviceMode = dataGridView1.CurrentRow.Cells[1].Value as string;
                    updateDeviceInfo(DeviceSN, DeviceMode);
                }
                else
                {
                    DeviceSN = "";
                    DeviceMode = "";
                    updateDeviceInfo(DeviceSN, DeviceMode);
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DeviceSN = dataGridView1.CurrentRow.Cells[0].Value as string;
            DeviceMode = dataGridView1.CurrentRow.Cells[1].Value as string;
            updateDeviceInfo(DeviceSN, DeviceMode);
        }

        private void updateDeviceInfo(string SN, string mode)
        {
            string tmp, product="", imei="", version="", mid="", cid="";
            if (mode.Equals("fastboot") || mode.Equals("download") || mode.Equals("ruu"))
            {
                StreamReader sr = fastboot("-s " + SN + " getvar all");
                while (!sr.EndOfStream)
                {
                    tmp = sr.ReadLine().Replace("(bootloader) ", "");
                    if (tmp.Contains("product:"))
                        product = tmp.Replace("product: ", "");
                    if (tmp.Contains("imei:"))
                        imei = tmp.Replace("imei: ", "");
                    if (tmp.Contains("version-main:"))
                        version = tmp.Replace("version-main: ", "");
                    if (tmp.Contains("mid:"))
                        mid = tmp.Replace("mid: ", "");
                    if (tmp.Contains("cid:"))
                        cid = tmp.Replace("cid: ", "");
                    if (tmp.Contains("modelid:"))
                        mid = tmp.Replace("modelid: ", "");
                    if (tmp.Contains("cidnum:"))
                        cid = tmp.Replace("cidnum: ", "");
                    if (tmp.Contains("boot-mode:"))
                    {
                        DeviceMode = tmp.Replace("boot-mode: ", "").ToLower();
                        dataGridView1.CurrentRow.Cells[1].Value = DeviceMode;
                    }
                }
            }
            else if (mode.Equals("adb") || mode.Equals("recovery"))
            {
                StreamReader sr = adb("-s " + SN + " shell getprop");
                while (!sr.EndOfStream)
                {
                    tmp = sr.ReadLine();
                    if (tmp.Contains("[ro.build.product]:"))
                        product = tmp.Replace("[ro.build.product]: ", "").Replace("[", "").Replace("]", "");
                    if (tmp.Contains("[ro.product.device]:"))
                        product = tmp.Replace("[ro.product.device]: ", "").Replace("[", "").Replace("]", "");
                    if (tmp.Contains("[ro.product.version]:"))
                        version = tmp.Replace("[ro.product.version]: ", "").Replace("[", "").Replace("]", "");
                    if (tmp.Contains("[ro.mid]:"))
                        mid = tmp.Replace("[ro.mid]: ", "").Replace("[", "").Replace("]", "");
                    if (tmp.Contains("[ro.cid]:"))
                        cid = tmp.Replace("[ro.cid]: ", "").Replace("[", "").Replace("]", "");
                    if (tmp.Contains("[ro.boot.mid]:"))
                        mid = tmp.Replace("[ro.boot.mid]: ", "").Replace("[", "").Replace("]", "");
                    if (tmp.Contains("[ro.boot.cid]:"))
                        cid = tmp.Replace("[ro.boot.cid]: ", "").Replace("[", "").Replace("]", "");
                }
            }
            ProductText.Text = product;
            IMEIText.Text = imei;
            VersionText.Text = version;
            MIDText.Text = mid;
            CIDText.Text = cid;
            updateButtons();
        }

        private void updateButtons()
        {
            btn_bootloader.Enabled = false;
            btn_download.Enabled = false;
            btn_reboot.Enabled = false;
            btn_recovery.Enabled = false;
            btn_ruu.Enabled = false;
            btn_FlashBoot.Enabled = false;
            btn_FlashRecovery.Enabled = false;
            btn_FlashSystem.Enabled = false;
            btn_FlashZip.Enabled = false;
            btn_getToken.Enabled = false;
            btn_flashToken.Enabled = false;

            if (DeviceMode.Equals("fastboot") || DeviceMode.Equals("download") || DeviceMode.Equals("ruu") || DeviceMode.Equals("adb") || DeviceMode.Equals("recovery"))
            {
                btn_bootloader.Enabled = true;
                btn_download.Enabled = true;
                btn_reboot.Enabled = true;
                btn_ruu.Enabled = true;
            }
            if (DeviceMode.Equals("adb") || DeviceMode.Equals("recovery"))
            {
                btn_recovery.Enabled = true;
            }
            else if (DeviceMode.Equals("fastboot") || DeviceMode.Equals("download"))
            {

                btn_getToken.Enabled = true;
                btn_flashToken.Enabled = true;
                btn_FlashBoot.Enabled = true;
                btn_FlashRecovery.Enabled = true;
                btn_FlashSystem.Enabled = true;
            }
            else if (DeviceMode.Equals("ruu") || DeviceMode.Equals("sideload"))
            {
                btn_FlashZip.Enabled = true;
            }
        }

        private void btn_bootloader_Click(object sender, EventArgs e)
        {
            if (DeviceMode.Equals("fastboot") || DeviceMode.Equals("download") || DeviceMode.Equals("ruu"))
                fastboot("-s " + DeviceSN + " reboot-bootloader");
            else if (DeviceMode.Equals("adb") || DeviceMode.Equals("recovery"))
                adb("-s " + DeviceSN + " reboot bootloader");
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            if (DeviceMode.Equals("fastboot") || DeviceMode.Equals("download") || DeviceMode.Equals("ruu"))
                fastboot("-s " + DeviceSN + " oem reboot-download");
            else if (DeviceMode.Equals("adb") || DeviceMode.Equals("recovery"))
                adb("-s " + DeviceSN + " reboot download");
        }

        private void btn_recovery_Click(object sender, EventArgs e)
        {
            if (DeviceMode.Equals("adb") || DeviceMode.Equals("recovery"))
                adb("-s " + DeviceSN + " reboot recovery");
        }

        private void btn_ruu_Click(object sender, EventArgs e)
        {
            if (DeviceMode.Equals("fastboot") || DeviceMode.Equals("download") || DeviceMode.Equals("ruu"))
                fastboot("-s " + DeviceSN + " oem rebootRUU");
            else if (DeviceMode.Equals("adb") || DeviceMode.Equals("recovery"))
                adb("-s " + DeviceSN + " reboot oem-78");
        }

        private void btn_reboot_Click(object sender, EventArgs e)
        {
            if (DeviceMode.Equals("fastboot") || DeviceMode.Equals("download") || DeviceMode.Equals("ruu"))
                fastboot("-s " + DeviceSN + " reboot");
            else if (DeviceMode.Equals("adb") || DeviceMode.Equals("recovery"))
                adb("-s " + DeviceSN + " reboot");
        }

        private void btn_getToken_Click(object sender, EventArgs e)
        {
            if (DeviceMode.Equals("fastboot") || DeviceMode.Equals("download"))
            {
                StreamReader sr = fastboot("-s " + DeviceSN + " oem get_identifier_token");
                string tmp, token="";
                Clipboard.Clear();
                while(!sr.EndOfStream)
                {
                    tmp = sr.ReadLine().Replace("(bootloader) ", "");
                    if (tmp.Contains("disable unlock"))
                    {
                        MessageBox.Show(this, "裝置不允許解鎖，請先允許oem解鎖");
                        break;
                    }
                    if (tmp.Contains("Identifier Token Start"))
                    {
                        token = token + tmp + "\r\n";
                        while(!tmp.Contains("Identifier Token End"))
                        {
                            tmp = sr.ReadLine().Replace("(bootloader) ", "");
                            if (!String.IsNullOrEmpty(tmp))
                                token = token + tmp + "\r\n";
                        }
                    }
                }
                if (!String.IsNullOrEmpty(token))
                {
                    Clipboard.SetText(token, TextDataFormat.Text);
                    textBox1.Text = token;
                }
            }
        }

        private void btn_flashToken_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Unlock Token|*.bin|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ResetText();
                Thread th = new Thread(() => fastboot2("-s " + DeviceSN + " flash unlocktoken " + openFileDialog1.FileName));
                th.Start();
            }
        }

        private void btn_FlashBoot_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Raw Image|*.img|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ResetText();
                Thread th = new Thread(() => fastboot2("-s " + DeviceSN + " flash boot " + openFileDialog1.FileName));
                th.Start();
            }
        }

        private void btn_FlashRecovery_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Raw Image|*.img|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ResetText();
                Thread th = new Thread(() => fastboot2("-s " + DeviceSN + " flash recovery " + openFileDialog1.FileName));
                th.Start();
            }
        }

        private void btn_FlashSystem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Raw Image|*.img|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ResetText();
                if (DeviceMode.Equals("download"))
                {
                    Thread th = new Thread(() => fastboot2("-s " + DeviceSN + " flash system " + openFileDialog1.FileName));
                    th.Start();
                }
                else
                {
                    Thread th = new Thread(() => mfastboot("-s " + DeviceSN + " -S 512M flash system " + openFileDialog1.FileName));
                    th.Start();
                }
            }
        }

        private void btn_FlashZip_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Zip files|*.zip|All files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ResetText();
                if (DeviceMode.Equals("ruu") || DeviceMode.Equals("sideload"))
                {
                    if (DeviceMode.Equals("ruu"))
                    {
                        Thread th = new Thread(() => fastboot2("-s " + DeviceSN + " flash zip " + openFileDialog1.FileName));
                        th.Start();
                    }
                    else
                    {
                        Thread th = new Thread(() => adb2("-s " + DeviceSN + " sideload " + openFileDialog1.FileName));
                        th.Start();
                    }
                }
                else
                {
                    MessageBox.Show("Reboot to RUU mode first");
                }
            }
        }

        public List<string> getAdbDevices()
        {
            List<string> devices = new List<string>();
            string tmp;
            StreamReader sr = adb("devices");
            while (!sr.EndOfStream)
            {
                tmp = sr.ReadLine();
                if (tmp.Contains("\tdevice"))
                {
                    devices.Add(tmp.Replace("\tdevice", ""));
                    devices.Add("adb");
                }
                else if (tmp.Contains("\trecovery"))
                {
                    devices.Add(tmp.Replace("\trecovery", ""));
                    devices.Add("recovery");
                }
                else if (tmp.Contains("\tsideload"))
                {
                    devices.Add(tmp.Replace("\tsideload", ""));
                    devices.Add("sideload");
                }
            }
            return devices;
        }
        public StreamReader adb(string parameters)
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "adb.exe";
            p.StartInfo.Arguments = parameters;
            p.Start();
            StreamReader sr = p.StandardOutput;
            p.Close();
            return sr;
        }

        public void adb2(string parameters)
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "adb.exe";
            p.StartInfo.Arguments = parameters;
            p.OutputDataReceived += OutputDataReceived;
            p.ErrorDataReceived += ErrorDataReceived;
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
        }

        public List<string> getFastbootDevices()
        {
            List<string> devices = new List<string>();
            string tmp;
            StreamReader sr = fastboot("devices");
            while (!sr.EndOfStream)
            {
                tmp = sr.ReadLine();
                if (tmp.Contains("\tfastboot"))
                {
                    devices.Add(tmp.Replace("\tfastboot", ""));
                    devices.Add("fastboot");
                }
            }
            return devices;
        }

        public StreamReader fastboot(string parameters)
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "mfastboot.exe";
            p.StartInfo.Arguments = parameters;
            p.Start();
            StreamReader sr;
            if (p.StandardError.EndOfStream)
                sr = p.StandardOutput;
            else
                sr = p.StandardError;
            p.Close();
            return sr;
        }

        public void fastboot2(string parameters)
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "fastboot.exe";
            p.StartInfo.Arguments = parameters;
            p.ErrorDataReceived += ErrorDataReceived;
            p.Start();
            p.BeginErrorReadLine();
        }

        public void mfastboot(string parameters)
        {
            Process p = new Process();
            p.StartInfo.FileName = binDict + "mfastboot.exe";
            p.StartInfo.Arguments = parameters;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.Verb = "runas";
            p.StartInfo.WorkingDirectory = binDict;
            p.Start();
        }

        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
                UpdateText(e.Data);
        }

        private void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data) && !e.Data.Contains("htc_fastboot"))
                UpdateText(e.Data);
        }

        private void UpdateText(string text)
        {
            Action act = () =>
                {
                    if (string.IsNullOrEmpty(text) == false)
                    {
                        textBox1.AppendText(text + "\r\n");
                        textBox1.SelectionStart = textBox1.Text.Length;
                        textBox1.ScrollToCaret();
                    }
                };
            BeginInvoke(act);
        }

        private void commandText_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void commandText_DragDrop(object sender, DragEventArgs e)
        {
            commandText.Text += "\"" + ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString() + "\" ";
            commandText.SelectionStart = commandText.Text.Length;
        }

        private void commandText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string command = commandText.Text;
                if (command.Contains("fastboot"))
                {
                    command = command.Replace("fastboot ", "");
                    command = "-s " + DeviceSN + " " + command;
                    fastboot2(command);
                }
                else if (command.Contains("adb"))
                {
                    command = command.Replace("adb ", "");
                    command = "-s " + DeviceSN + " " + command;
                    adb2(command);
                }
                commandText.Clear();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://drive.google.com/open?id=0B9_zSyS3dIRpa1VzQk0yNUdXd2M");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/profile.php?id=100005653172695");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateDevices.CancelAsync();
            updateTimer.Stop();
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = "TASKKILL";
            p.StartInfo.Arguments = "/IM adb.exe /F";
            p.Start();
            Thread.Sleep(1000);
            Directory.Delete(binDict, true);
            string[] tmp = Directory.GetDirectories(tmpDict, "tmp*");
            if (tmp.Length != 0)
                foreach (string str in tmp) Directory.Delete(str, true);
        }
    }
}
