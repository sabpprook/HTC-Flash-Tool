namespace HTC_Flash
{
    partial class Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_MID = new System.Windows.Forms.TextBox();
            this.txt_CID = new System.Windows.Forms.TextBox();
            this.txt_IMEI = new System.Windows.Forms.TextBox();
            this.txt_Product = new System.Windows.Forms.TextBox();
            this.txt_Version = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.commandText = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_R_Reboot = new System.Windows.Forms.Button();
            this.btn_R_RUU = new System.Windows.Forms.Button();
            this.btn_R_recovery = new System.Windows.Forms.Button();
            this.btn_R_Download = new System.Windows.Forms.Button();
            this.btn_R_bootloader = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_U_Flash = new System.Windows.Forms.Button();
            this.btn_U_GetToken = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_F_Zip = new System.Windows.Forms.Button();
            this.btn_F_System = new System.Windows.Forms.Button();
            this.btn_F_Recovery = new System.Windows.Forms.Button();
            this.btn_F_Boot = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listDeviceWorker = new System.ComponentModel.BackgroundWorker();
            this.listDeviceTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeight = 20;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(214, 114);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "SN";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Mode";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_MID);
            this.groupBox1.Controls.Add(this.txt_CID);
            this.groupBox1.Controls.Add(this.txt_IMEI);
            this.groupBox1.Controls.Add(this.txt_Product);
            this.groupBox1.Controls.Add(this.txt_Version);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 215);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device Info";
            // 
            // txt_MID
            // 
            this.txt_MID.Location = new System.Drawing.Point(64, 27);
            this.txt_MID.Name = "txt_MID";
            this.txt_MID.ReadOnly = true;
            this.txt_MID.Size = new System.Drawing.Size(135, 22);
            this.txt_MID.TabIndex = 9;
            this.txt_MID.TabStop = false;
            // 
            // txt_CID
            // 
            this.txt_CID.Location = new System.Drawing.Point(64, 65);
            this.txt_CID.Name = "txt_CID";
            this.txt_CID.ReadOnly = true;
            this.txt_CID.Size = new System.Drawing.Size(135, 22);
            this.txt_CID.TabIndex = 8;
            this.txt_CID.TabStop = false;
            // 
            // txt_IMEI
            // 
            this.txt_IMEI.Location = new System.Drawing.Point(64, 103);
            this.txt_IMEI.Name = "txt_IMEI";
            this.txt_IMEI.ReadOnly = true;
            this.txt_IMEI.Size = new System.Drawing.Size(135, 22);
            this.txt_IMEI.TabIndex = 7;
            this.txt_IMEI.TabStop = false;
            // 
            // txt_Product
            // 
            this.txt_Product.Location = new System.Drawing.Point(64, 141);
            this.txt_Product.Name = "txt_Product";
            this.txt_Product.ReadOnly = true;
            this.txt_Product.Size = new System.Drawing.Size(135, 22);
            this.txt_Product.TabIndex = 6;
            this.txt_Product.TabStop = false;
            // 
            // txt_Version
            // 
            this.txt_Version.Location = new System.Drawing.Point(64, 179);
            this.txt_Version.Name = "txt_Version";
            this.txt_Version.ReadOnly = true;
            this.txt_Version.Size = new System.Drawing.Size(135, 22);
            this.txt_Version.TabIndex = 5;
            this.txt_Version.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Version:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Product:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "IMEI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "CID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MID:";
            // 
            // commandText
            // 
            this.commandText.AllowDrop = true;
            this.commandText.Location = new System.Drawing.Point(12, 367);
            this.commandText.Name = "commandText";
            this.commandText.Size = new System.Drawing.Size(496, 22);
            this.commandText.TabIndex = 2;
            this.commandText.TabStop = false;
            this.commandText.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.commandText.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            this.commandText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commandText_KeyPress);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(522, 372);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(61, 12);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "HTC Driver";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(597, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.TabStop = false;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_R_Reboot);
            this.groupBox2.Controls.Add(this.btn_R_RUU);
            this.groupBox2.Controls.Add(this.btn_R_recovery);
            this.groupBox2.Controls.Add(this.btn_R_Download);
            this.groupBox2.Controls.Add(this.btn_R_bootloader);
            this.groupBox2.Location = new System.Drawing.Point(244, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 59);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reboot";
            // 
            // btn_R_Reboot
            // 
            this.btn_R_Reboot.Enabled = false;
            this.btn_R_Reboot.Location = new System.Drawing.Point(339, 21);
            this.btn_R_Reboot.Name = "btn_R_Reboot";
            this.btn_R_Reboot.Size = new System.Drawing.Size(75, 23);
            this.btn_R_Reboot.TabIndex = 4;
            this.btn_R_Reboot.TabStop = false;
            this.btn_R_Reboot.Text = "Reboot";
            this.btn_R_Reboot.UseVisualStyleBackColor = true;
            this.btn_R_Reboot.Click += new System.EventHandler(this.btn_R_Reboot_Click);
            // 
            // btn_R_RUU
            // 
            this.btn_R_RUU.Enabled = false;
            this.btn_R_RUU.Location = new System.Drawing.Point(258, 21);
            this.btn_R_RUU.Name = "btn_R_RUU";
            this.btn_R_RUU.Size = new System.Drawing.Size(75, 23);
            this.btn_R_RUU.TabIndex = 3;
            this.btn_R_RUU.TabStop = false;
            this.btn_R_RUU.Text = "RUU";
            this.btn_R_RUU.UseVisualStyleBackColor = true;
            this.btn_R_RUU.Click += new System.EventHandler(this.btn_R_RUU_Click);
            // 
            // btn_R_recovery
            // 
            this.btn_R_recovery.Enabled = false;
            this.btn_R_recovery.Location = new System.Drawing.Point(177, 21);
            this.btn_R_recovery.Name = "btn_R_recovery";
            this.btn_R_recovery.Size = new System.Drawing.Size(75, 23);
            this.btn_R_recovery.TabIndex = 2;
            this.btn_R_recovery.TabStop = false;
            this.btn_R_recovery.Text = "Recovery";
            this.btn_R_recovery.UseVisualStyleBackColor = true;
            this.btn_R_recovery.Click += new System.EventHandler(this.btn_R_recovery_Click);
            // 
            // btn_R_Download
            // 
            this.btn_R_Download.Enabled = false;
            this.btn_R_Download.Location = new System.Drawing.Point(96, 21);
            this.btn_R_Download.Name = "btn_R_Download";
            this.btn_R_Download.Size = new System.Drawing.Size(75, 23);
            this.btn_R_Download.TabIndex = 1;
            this.btn_R_Download.TabStop = false;
            this.btn_R_Download.Text = "Download";
            this.btn_R_Download.UseVisualStyleBackColor = true;
            this.btn_R_Download.Click += new System.EventHandler(this.btn_R_Download_Click);
            // 
            // btn_R_bootloader
            // 
            this.btn_R_bootloader.Enabled = false;
            this.btn_R_bootloader.Location = new System.Drawing.Point(15, 21);
            this.btn_R_bootloader.Name = "btn_R_bootloader";
            this.btn_R_bootloader.Size = new System.Drawing.Size(75, 23);
            this.btn_R_bootloader.TabIndex = 0;
            this.btn_R_bootloader.TabStop = false;
            this.btn_R_bootloader.Text = "Bootloader";
            this.btn_R_bootloader.UseVisualStyleBackColor = true;
            this.btn_R_bootloader.Click += new System.EventHandler(this.btn_R_bootloader_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_U_Flash);
            this.groupBox3.Controls.Add(this.btn_U_GetToken);
            this.groupBox3.Location = new System.Drawing.Point(244, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(104, 90);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Unlock";
            // 
            // btn_U_Flash
            // 
            this.btn_U_Flash.Enabled = false;
            this.btn_U_Flash.Location = new System.Drawing.Point(15, 53);
            this.btn_U_Flash.Name = "btn_U_Flash";
            this.btn_U_Flash.Size = new System.Drawing.Size(75, 23);
            this.btn_U_Flash.TabIndex = 2;
            this.btn_U_Flash.TabStop = false;
            this.btn_U_Flash.Text = "Flash";
            this.btn_U_Flash.UseVisualStyleBackColor = true;
            this.btn_U_Flash.Click += new System.EventHandler(this.btn_U_Flash_Click);
            // 
            // btn_U_GetToken
            // 
            this.btn_U_GetToken.Enabled = false;
            this.btn_U_GetToken.Location = new System.Drawing.Point(15, 21);
            this.btn_U_GetToken.Name = "btn_U_GetToken";
            this.btn_U_GetToken.Size = new System.Drawing.Size(75, 23);
            this.btn_U_GetToken.TabIndex = 1;
            this.btn_U_GetToken.TabStop = false;
            this.btn_U_GetToken.Text = "Get Token";
            this.btn_U_GetToken.UseVisualStyleBackColor = true;
            this.btn_U_GetToken.Click += new System.EventHandler(this.btn_U_GetToken_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_F_Zip);
            this.groupBox4.Controls.Add(this.btn_F_System);
            this.groupBox4.Controls.Add(this.btn_F_Recovery);
            this.groupBox4.Controls.Add(this.btn_F_Boot);
            this.groupBox4.Location = new System.Drawing.Point(244, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(104, 174);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Flash";
            // 
            // btn_F_Zip
            // 
            this.btn_F_Zip.Enabled = false;
            this.btn_F_Zip.Location = new System.Drawing.Point(15, 134);
            this.btn_F_Zip.Name = "btn_F_Zip";
            this.btn_F_Zip.Size = new System.Drawing.Size(75, 23);
            this.btn_F_Zip.TabIndex = 4;
            this.btn_F_Zip.TabStop = false;
            this.btn_F_Zip.Text = "Zip";
            this.btn_F_Zip.UseVisualStyleBackColor = true;
            this.btn_F_Zip.Click += new System.EventHandler(this.btn_F_Zip_Click);
            // 
            // btn_F_System
            // 
            this.btn_F_System.Enabled = false;
            this.btn_F_System.Location = new System.Drawing.Point(15, 97);
            this.btn_F_System.Name = "btn_F_System";
            this.btn_F_System.Size = new System.Drawing.Size(75, 23);
            this.btn_F_System.TabIndex = 3;
            this.btn_F_System.TabStop = false;
            this.btn_F_System.Text = "System";
            this.btn_F_System.UseVisualStyleBackColor = true;
            this.btn_F_System.Click += new System.EventHandler(this.btn_F_System_Click);
            // 
            // btn_F_Recovery
            // 
            this.btn_F_Recovery.Enabled = false;
            this.btn_F_Recovery.Location = new System.Drawing.Point(15, 60);
            this.btn_F_Recovery.Name = "btn_F_Recovery";
            this.btn_F_Recovery.Size = new System.Drawing.Size(75, 23);
            this.btn_F_Recovery.TabIndex = 2;
            this.btn_F_Recovery.TabStop = false;
            this.btn_F_Recovery.Text = "Recovery";
            this.btn_F_Recovery.UseVisualStyleBackColor = true;
            this.btn_F_Recovery.Click += new System.EventHandler(this.btn_F_Recovery_Click);
            // 
            // btn_F_Boot
            // 
            this.btn_F_Boot.Enabled = false;
            this.btn_F_Boot.Location = new System.Drawing.Point(15, 23);
            this.btn_F_Boot.Name = "btn_F_Boot";
            this.btn_F_Boot.Size = new System.Drawing.Size(75, 23);
            this.btn_F_Boot.TabIndex = 1;
            this.btn_F_Boot.TabStop = false;
            this.btn_F_Boot.Text = "Boot";
            this.btn_F_Boot.UseVisualStyleBackColor = true;
            this.btn_F_Boot.Click += new System.EventHandler(this.btn_F_Boot_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2.ForeColor = System.Drawing.Color.Lime;
            this.textBox2.Location = new System.Drawing.Point(366, 85);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(306, 273);
            this.textBox2.TabIndex = 8;
            // 
            // listDeviceWorker
            // 
            this.listDeviceWorker.WorkerSupportsCancellation = true;
            this.listDeviceWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.listDeviceWorker_DoWork);
            this.listDeviceWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.listDeviceWorker_RunWorkerCompleted);
            // 
            // listDeviceTimer
            // 
            this.listDeviceTimer.Enabled = true;
            this.listDeviceTimer.Interval = 1000;
            this.listDeviceTimer.Tick += new System.EventHandler(this.listDeviceTimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 401);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.commandText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTC Flash Tool 2.1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox commandText;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MID;
        private System.Windows.Forms.TextBox txt_CID;
        private System.Windows.Forms.TextBox txt_IMEI;
        private System.Windows.Forms.TextBox txt_Product;
        private System.Windows.Forms.TextBox txt_Version;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_R_Reboot;
        private System.Windows.Forms.Button btn_R_RUU;
        private System.Windows.Forms.Button btn_R_recovery;
        private System.Windows.Forms.Button btn_R_Download;
        private System.Windows.Forms.Button btn_R_bootloader;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_U_Flash;
        private System.Windows.Forms.Button btn_U_GetToken;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_F_Zip;
        private System.Windows.Forms.Button btn_F_System;
        private System.Windows.Forms.Button btn_F_Recovery;
        private System.Windows.Forms.Button btn_F_Boot;
        public System.Windows.Forms.TextBox textBox2;
        private System.ComponentModel.BackgroundWorker listDeviceWorker;
        private System.Windows.Forms.Timer listDeviceTimer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

