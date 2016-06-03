using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Diagnostics;

namespace HTC_Flash
{
    public partial class Main : Form
    {
        Tools HFT = new Tools();
        Picture picBox = new Picture();
        About about = new About();
        ManagementObjectSearcher WMI_Searcher = new ManagementObjectSearcher("SELECT Description FROM Win32_PnPEntity WHERE Description = 'My HTC'");
        ManagementObjectCollection WMI_Devices;
        int deviceCount = 0;
        string deviceSN, deviceMode;
        string binDict = Path.GetTempPath() + "\\bin\\";
        string tmpDict = Path.GetTempPath();        

        public Main()
        {
            InitializeComponent();
            HFT.textBox = textBox2;
            HFT.binDict = binDict;
            releaseData();
        }

        private void releaseData()
        {
            Directory.CreateDirectory(binDict);
            string[] data = { "adb.exe", "AdbWinApi.dll", "fastboot.exe", "mfastboot.exe", "fb2png" };
            Assembly asm = Assembly.GetExecutingAssembly();
            foreach (var str in data)
            {
                if (!File.Exists(binDict + str))
                {
                    using (FileStream fs = File.Create(binDict + str))
                    {
                        using (Stream compressStream = asm.GetManifestResourceStream("HTC_Flash.tools." + str))
                        {
                            using (DeflateStream deflateStream = new DeflateStream(compressStream, CompressionMode.Decompress))
                            {
                                deflateStream.CopyTo(fs);
                                fs.Close();
                            }
                            compressStream.Close();
                        }
                    }
                }
            }
        }

        private void listDeviceTimer_Tick(object sender, EventArgs e)
        {
            if (!listDeviceWorker.IsBusy)
                listDeviceWorker.RunWorkerAsync();
            GC.Collect();
        }

        private void listDeviceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (WMI_Devices = WMI_Searcher.Get())
                deviceCount = WMI_Devices.Count;
            if (deviceCount != dataGridView1.Rows.Count)
            {
                HFT.getDevices();
                e.Result = "refreash";
            }
            if (deviceCount == 0 && deviceCount < dataGridView1.Rows.Count)
                e.Result = "clean";
        }

        private void listDeviceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((string)e.Result == "clean")
            {
                dataGridView1.Rows.Clear();
                HFT.Devices.Clear();
                picBox.deviceSN = deviceSN = null;
                picBox.deviceMode = deviceMode = null;
                updateButton();
                txt_CID.Clear();
                txt_MID.Clear();
                txt_IMEI.Clear();
                txt_Product.Clear();
                txt_Version.Clear();
            }
            if ((string)e.Result == "refreash")
            {
                if (deviceCount == HFT.Devices.Count)
                {
                    dataGridView1.Rows.Clear();
                    foreach (Tools.Device item in HFT.Devices)
                        dataGridView1.Rows.Add(item.SN, item.Mode);
                }
                if (HFT.Devices.Count != 0)
                {
                    deviceSN = HFT.Devices[0].SN;
                    deviceMode = HFT.Devices[0].Mode;
                    updateDeviceInfo();
                }
            }
        }

        private void updateDeviceInfo()
        {
            picBox.deviceSN = deviceSN;
            picBox.deviceMode = deviceMode;
            updateButton();
            string[] info = HFT.getDeviceInfo(deviceSN, deviceMode);
            txt_CID.Text = info[0];
            txt_MID.Text = info[1];
            txt_IMEI.Text = info[2];
            txt_Product.Text = info[3];
            txt_Version.Text = info[4];
        }

        private void updateButton()
        {
            btn_R_bootloader.Enabled = false;
            btn_R_Download.Enabled = false;
            btn_R_recovery.Enabled = false;
            btn_R_RUU.Enabled = false;
            btn_R_Reboot.Enabled = false;
            btn_U_GetToken.Enabled = false;
            btn_U_Flash.Enabled = false;
            btn_F_Boot.Enabled = false;
            btn_F_Recovery.Enabled = false;
            btn_F_System.Enabled = false;
            btn_F_Zip.Enabled = false;
            if (HFT.adbMode.Contains(deviceMode))
            {
                if (deviceMode != "sideload")
                {
                    btn_R_bootloader.Enabled = true;
                    btn_R_Download.Enabled = true;
                    btn_R_recovery.Enabled = true;
                    btn_R_RUU.Enabled = true;
                    btn_R_Reboot.Enabled = true;
                }
                else
                    btn_F_Zip.Enabled = true;
            }
            else if (HFT.fastbootMode.Contains(deviceMode))
            {
                btn_R_bootloader.Enabled = true;
                btn_R_Download.Enabled = true;
                btn_R_RUU.Enabled = true;
                btn_R_Reboot.Enabled = true;
                btn_F_Boot.Enabled = true;
                btn_F_Recovery.Enabled = true;
                btn_F_System.Enabled = true;
                if (deviceMode != "ruu")
                {
                    btn_U_GetToken.Enabled = true;
                    btn_U_Flash.Enabled = true;
                }
                else
                {
                    btn_F_Zip.Enabled = true;
                    btn_F_Boot.Enabled = false;
                    btn_F_Recovery.Enabled = false;
                    btn_F_System.Enabled = false;
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            picBox.deviceSN = deviceSN = dataGridView1.CurrentRow.Cells[0].Value as string;
            picBox.deviceMode = deviceMode = dataGridView1.CurrentRow.Cells[1].Value as string;
            updateDeviceInfo();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            picBox.Show();
        }

        private void btn_R_bootloader_Click(object sender, EventArgs e)
        {
            textBox2.AppendText("[HFT]: Reboot to Bootloader mode...\r\n");
            if (HFT.adbMode.Contains(deviceMode))
                HFT.RunADB("-s " + deviceSN + " reboot bootloader");
            else if (HFT.fastbootMode.Contains(deviceMode))
                HFT.RunFastboot("-s " + deviceSN + " reboot-bootloader");
        }

        private void btn_R_Download_Click(object sender, EventArgs e)
        {
            textBox2.AppendText("[HFT]: Reboot to Download mode...\r\n");
            if (HFT.adbMode.Contains(deviceMode))
                HFT.RunADB("-s " + deviceSN + " reboot download");
            else if (HFT.fastbootMode.Contains(deviceMode))
                HFT.RunFastboot("-s " + deviceSN + " oem reboot-download");
        }

        private void btn_R_recovery_Click(object sender, EventArgs e)
        {
            textBox2.AppendText("[HFT]: Reboot to Recovery mode...\r\n");
            if (HFT.adbMode.Contains(deviceMode))
                HFT.RunADB("-s " + deviceSN + " reboot recovery");
            else if (HFT.fastbootMode.Contains(deviceMode))
                HFT.RunFastboot("-s " + deviceSN + " oem reboot-recovery");
        }

        private void btn_R_RUU_Click(object sender, EventArgs e)
        {
            textBox2.AppendText("[HFT]: Reboot to RUU mode...\r\n");
            if (HFT.adbMode.Contains(deviceMode))
                HFT.RunADB("-s " + deviceSN + " reboot oem-78");
            else if (HFT.fastbootMode.Contains(deviceMode))
                HFT.RunFastboot("-s " + deviceSN + " oem rebootRUU");
        }

        private void btn_R_Reboot_Click(object sender, EventArgs e)
        {
            textBox2.AppendText("[HFT]: Reboot...\r\n");
            if (HFT.adbMode.Contains(deviceMode))
                HFT.RunADB("-s " + deviceSN + " reboot");
            else if (HFT.fastbootMode.Contains(deviceMode))
                HFT.RunFastboot("-s " + deviceSN + " reboot");
        }

        private void btn_U_GetToken_Click(object sender, EventArgs e)
        {
            if (HFT.fastbootMode.Contains(deviceMode))
            {
                StreamReader sr = HFT.RunFastboot2("-s " + deviceSN + " oem get_identifier_token");
                string tmp, token = "";
                Clipboard.Clear();
                while (!sr.EndOfStream)
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
                        while (!tmp.Contains("Identifier Token End"))
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
                    textBox2.Text = token + "\r\n";
                }
            }
        }

        private void btn_U_Flash_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Unlock Token|*.bin|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.AppendText("[HFT]: Flash Unlock Code...\r\n");
                Thread th = new Thread(() => HFT.RunFastboot3("-s " + deviceSN + " flash unlocktoken " + openFileDialog1.FileName));
                th.Start();
            }
        }

        private void btn_F_Boot_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Raw Image|*.img|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.AppendText("[HFT]: Flashing Boot Image...\r\n");
                Thread th = new Thread(() => HFT.RunFastboot3("-s " + deviceSN + " flash boot " + openFileDialog1.FileName));
                th.Start();
            }
        }

        private void btn_F_Recovery_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Raw Image|*.img|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.AppendText("[HFT]: Flashing Recovery Image...\r\n");
                Thread th = new Thread(() => HFT.RunFastboot3("-s " + deviceSN + " flash recovery " + openFileDialog1.FileName));
                th.Start();
            }
        }

        private void btn_F_System_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Raw Image|*.img|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Thread th;
                textBox2.AppendText("[HFT]: Flashing System Image...\r\n");
                if (deviceMode.Equals("download"))
                    th = new Thread(() => HFT.RunFastboot3("-s " + deviceSN + " flash system " + openFileDialog1.FileName));
                else
                    th = new Thread(() => HFT.RunmFastboot("-s " + deviceSN + " -S 512M flash system " + openFileDialog1.FileName));
                th.Start();
            }
        }

        private void btn_F_Zip_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Zip files|*.zip|All files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.AppendText("[HFT]: Flashing Zip...\r\n");
                if (deviceMode.Equals("ruu") || deviceMode.Equals("sideload"))
                {
                    if (deviceMode.Equals("ruu"))
                    {
                        Thread th = new Thread(() => HFT.RunFastboot3("-s " + deviceSN + " flash zip " + openFileDialog1.FileName));
                        th.Start();
                    }
                    else
                    {
                        Thread th = new Thread(() => HFT.RunADB2("-s " + deviceSN + " sideload " + openFileDialog1.FileName));
                        th.Start();
                    }
                }
                else
                {
                    MessageBox.Show("Reboot to RUU mode first");
                }
            }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            commandText.Text += "\"" + ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString() + "\" ";
            commandText.SelectionStart = commandText.Text.Length;
        }

        private void commandText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string command = commandText.Text;
                textBox2.AppendText("[HFT]: " + command + "\r\n");
                if (command.Contains("fastboot"))
                {
                    command = command.Replace("fastboot ", "");
                    command = "-s " + deviceSN + " " + command;
                    HFT.RunFastboot3(command);
                }
                else if (command.Contains("adb"))
                {
                    command = command.Replace("adb ", "");
                    command = "-s " + deviceSN + " " + command;
                    HFT.RunADB2(command);
                }
                commandText.Clear();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Encoding.ASCII.GetString(Convert.FromBase64String("aHR0cHM6Ly9kcml2ZS5nb29nbGUuY29tL29wZW4/aWQ9MEI5X3pTeVMzZElScGExVnpRazB5TlVkWGQyTQ==")));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            about.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            picBox.Hide();
            listDeviceTimer.Stop();
            listDeviceWorker.CancelAsync();
            Process p = new Process();
            p.StartInfo.FileName = "TASKKILL";
            p.StartInfo.Arguments = "/IM adb.exe /F";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            Thread.Sleep(2000);
            Directory.Delete(binDict, true);
            string[] tmp = Directory.GetDirectories(tmpDict, "tmp*");
            if (tmp.Length != 0)
                foreach (string str in tmp) Directory.Delete(str, true);
        }
    }
}
