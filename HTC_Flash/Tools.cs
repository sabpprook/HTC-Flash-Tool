using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTC_Flash
{
    class Tools
    {
        private ProcessStartInfo psi = new ProcessStartInfo();
        public List<Device> Devices = new List<Device>();
        public string[] adbMode = { "adb", "recovery", "sideload" };
        public string[] fastbootMode = { "bootloader", "download", "ruu" };
        public TextBox textBox;
        public string binDict;

        public Tools()
        {
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.Verb = "runas";
            psi.WorkingDirectory = binDict;
        }

        public void getDevices()
        {
            Devices.Clear();
            adbDevices();
            fastbootDevices();
        }

        public void RunADB(string parameter)
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "adb.exe";
            p.StartInfo.Arguments = parameter;
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        public void RunADB2(string parameter)
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "adb.exe";
            p.StartInfo.Arguments = parameter;
            p.OutputDataReceived += adbMessage;
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
            p.Close();
            UpdateText("[HFT]: Finish...\r\n\r\n");
        }

        

        public void RunFastboot(string parameter)
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "fastboot.exe";
            p.StartInfo.Arguments = parameter;
            p.Start();
            p.WaitForExit();
            p.Close();
            UpdateText("[HFT]: Finish...\r\n");
        }

        public void RunmFastboot(string parameter)
        {
            Process p = new Process();
            p.StartInfo.FileName = binDict + "mfastboot.exe";
            p.StartInfo.Arguments = parameter;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.Verb = "runas";
            p.StartInfo.WorkingDirectory = binDict;
            p.Start();
            p.WaitForExit();
            p.Close();
            UpdateText("[HFT]: Finish...\r\n");
        }

        public StreamReader RunFastboot2(string parameter)
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "fastboot.exe";
            p.StartInfo.Arguments = parameter;
            p.Start();
            p.WaitForExit();
            var stream = p.StandardError;
            p.Close();
            return stream;
        }

        public void RunFastboot3(string parameter)
        {
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "fastboot.exe";
            p.StartInfo.Arguments = parameter;
            p.ErrorDataReceived += fastbootMessage;
            p.Start();
            p.BeginErrorReadLine();
            p.WaitForExit();
            p.Close();
            UpdateText("[HFT]: Finish...\r\n");
        }

        void adbMessage(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data) && !e.Data.Contains("htc_fastboot"))
                UpdateText(e.Data);
        }

        private void fastbootMessage(object sender, DataReceivedEventArgs e)
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
                        textBox.AppendText(text + "\r\n");
                        textBox.SelectionStart = textBox.Text.Length;
                        textBox.ScrollToCaret();
                    }
                };
            textBox.BeginInvoke(act);
        }

        private void adbDevices()
        {
            string tmp;
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "adb.exe";
            p.StartInfo.Arguments = "devices";
            p.Start();
            p.WaitForExit();
            while (!p.StandardOutput.EndOfStream)
            {
                tmp = p.StandardOutput.ReadLine();
                if (tmp.Contains('\t') && !tmp.Contains("emulator"))
                    Devices.Add(new Device(tmp.Split('\t')[0], tmp.Split('\t')[1].Replace("device", "adb")));
            }
            p.Close();
        }

        private void fastbootDevices()
        {
            string tmp;
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "fastboot.exe";
            p.StartInfo.Arguments = "devices";
            p.Start();
            p.WaitForExit();
            while (!p.StandardError.EndOfStream)
            {
                tmp = p.StandardError.ReadLine();
                if (tmp.Contains('\t'))
                    Devices.Add(new Device(tmp.Split('\t')[0], fastbootDeviceMode(tmp.Split('\t')[0])));
            }
            p.Close();
        }

        private string fastbootDeviceMode(string SN)
        {
            string tmp, mode = "";
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.FileName = binDict + "fastboot.exe";
            p.StartInfo.Arguments = "-s " + SN + " getvar boot-mode";
            p.Start();
            while (!p.StandardError.EndOfStream)
            {
                tmp = p.StandardError.ReadLine();
                if (tmp.Contains("boot-mode:"))
                    mode = tmp.Replace("boot-mode: ", "").ToLower();
            }
            p.Close();
            if (!string.IsNullOrEmpty(mode))
            {
                if (mode.Contains("ruu"))
                    mode = "ruu";
                return mode;
            }
            else
                return "bootloader";
        }

        public string[] getDeviceInfo(string SN, string Mode)
        {
            string tmp, cid = "", mid = "", imei = "", product = "", version = "";
            Process p = new Process();
            p.StartInfo = psi;
            if (adbMode.Contains(Mode))
            {
                p.StartInfo.FileName = binDict + "adb.exe";
                p.StartInfo.Arguments = "-s " + SN + " shell getprop";
                p.Start();
                while (!p.StandardOutput.EndOfStream)
                {
                    tmp = p.StandardOutput.ReadLine();
                    if (tmp.Contains("ro.cid") || tmp.Contains("ro.boot.cid"))
                        cid = tmp.Replace("[ro.cid]: ", "").Replace("[ro.boot.cid]: ", "").Replace("[", "").Replace("]", "");
                    else if (tmp.Contains("ro.mid") || tmp.Contains("ro.boot.mid"))
                        mid = tmp.Replace("[ro.mid]: ", "").Replace("[ro.boot.mid]: ", "").Replace("[", "").Replace("]", "");
                    else if (tmp.Contains("ro.product.device"))
                        product = tmp.Replace("[ro.product.device]: ", "").Replace("[", "").Replace("]", "");
                    else if (tmp.Contains("ro.aa.romver"))
                        version = tmp.Replace("[ro.aa.romver]: ", "").Replace("[", "").Replace("]", "");
                }
                p.Close();
            }
            else
            {
                p.StartInfo.FileName = binDict + "fastboot.exe";
                p.StartInfo.Arguments = "-s " + SN + " getvar all";
                p.Start();
                p.WaitForExit();
                while (!p.StandardError.EndOfStream)
                {
                    tmp = p.StandardError.ReadLine().Replace("(bootloader) ", "");
                    if (tmp.Contains("cid") || tmp.Contains("cidnum"))
                        cid = tmp.Replace("cid: ", "").Replace("cidnum: ", "");
                    else if (tmp.Contains("mid") || tmp.Contains("modelid"))
                        mid = tmp.Replace("mid: ", "").Replace("modelid: ", "");
                    else if (tmp.Contains("imei"))
                        imei = tmp.Replace("imei: ", "");
                    else if (tmp.Contains("product"))
                        product = tmp.Replace("product: ", "");
                    else if (tmp.Contains("version-main"))
                        version = tmp.Replace("version-main: ", "");
                }
                p.Close();
            }
            return new string[] { cid, mid, imei, product, version };
        }

        public class Device
        {
            public Device(string _SN, string _Mode)
            {
                SN = _SN;
                Mode = _Mode;
            }
            public string SN { get; set; }
            public string Mode { get; set; }
        }
    }
}
