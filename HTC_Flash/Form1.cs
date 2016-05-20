﻿using System;
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

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            releaseData();
            updateTimer.Start();
        }

        private void releaseData()
        {
            string[] data = { "adb.exe", "AdbWinApi.dll", "fastboot.exe", "mfastboot.exe" };
            Assembly asm = Assembly.GetExecutingAssembly();

            foreach (var str in data)
            {
                if (!File.Exists(str))
                {
                    using (FileStream fs = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        asm.GetManifestResourceStream("HTC_Flash.Resources." + str).CopyTo(fs);
                    }
                }
            }
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

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (!updateDevices.IsBusy)
                updateDevices.RunWorkerAsync();
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

        private void btn_FlashBoot_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Raw Image|*.img|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ResetText();
                Thread th = new Thread(() => fastboot2("-s " + DeviceSN + " flash boot " + openFileDialog1.FileName));
                th.Start();
            }
        }

        private void btn_FlashRecovery_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Raw Image|*.img|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ResetText();
                Thread th = new Thread(() => fastboot2("-s " + DeviceSN + " flash recovery " + openFileDialog1.FileName));
                th.Start();
            }
        }

        private void btn_FlashSystem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Raw Image|*.img|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ResetText();
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
                richTextBox1.ResetText();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://drive.google.com/open?id=0B9_zSyS3dIRpa1VzQk0yNUdXd2M");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/profile.php?id=100005653172695");
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
            p.StartInfo.FileName = "fastboot.exe";
            p.StartInfo.Arguments = parameters;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WorkingDirectory = Application.StartupPath;
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
            p.StartInfo.FileName = "fastboot.exe";
            p.StartInfo.Arguments = parameters;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WorkingDirectory = Application.StartupPath;
            //p.OutputDataReceived += OutputDataReceived;
            p.ErrorDataReceived += ErrorDataReceived;
            p.Start();
            //p.BeginOutputReadLine();
            p.BeginErrorReadLine();

        }

        public void mfastboot(string parameters)
        {
            Process p = new Process();
            p.StartInfo.FileName = "mfastboot.exe";
            p.StartInfo.Arguments = parameters;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WorkingDirectory = Application.StartupPath;
            p.Start();
            p.OutputDataReceived += OutputDataReceived;
            p.ErrorDataReceived += ErrorDataReceived;
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
        }

        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!(e.Data == null))
                UpdateText(e.Data);
        }

        private void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!(e.Data == null))
                UpdateText(e.Data);
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
            p.StartInfo.FileName = "adb.exe";
            p.StartInfo.Arguments = parameters;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WorkingDirectory = Application.StartupPath;
            p.Start();
            StreamReader sr = p.StandardOutput;
            p.Close();
            return sr;
        }

        public void adb2(string parameters)
        {
            Process p = new Process();
            p.StartInfo.FileName = "adb.exe";
            p.StartInfo.Arguments = parameters;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WorkingDirectory = Application.StartupPath;
            p.OutputDataReceived += OutputDataReceived;
            p.Start();
            p.BeginOutputReadLine();
        }

        delegate void UpdateTextCallback(string text);

        private void UpdateText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                UpdateTextCallback d = new UpdateTextCallback(UpdateText);
                Invoke(d, new object[] { text });
            }
            else
            {
                richTextBox1.AppendText(text + "\n");
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            adb("kill-server");
            Thread.Sleep(200);
            File.Delete("adb.exe");
            File.Delete("AdbWinApi.dll");
            File.Delete("fastboot.exe");
            File.Delete("mfastboot.exe");
        }
    }
}