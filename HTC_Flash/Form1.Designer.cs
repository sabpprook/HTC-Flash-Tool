namespace HTC_Flash
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VersionText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ProductText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IMEIText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CIDText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MIDText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateDevices = new System.ComponentModel.BackgroundWorker();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_reboot = new System.Windows.Forms.Button();
            this.btn_ruu = new System.Windows.Forms.Button();
            this.btn_recovery = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_bootloader = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_FlashSystem = new System.Windows.Forms.Button();
            this.btn_FlashZip = new System.Windows.Forms.Button();
            this.btn_FlashRecovery = new System.Windows.Forms.Button();
            this.btn_FlashBoot = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_flashToken = new System.Windows.Forms.Button();
            this.btn_getToken = new System.Windows.Forms.Button();
            this.commandText = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.Height = 18;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(203, 99);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
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
            this.Column2.HeaderText = "Mode";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VersionText);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ProductText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.IMEIText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CIDText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.MIDText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 214);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device Info";
            // 
            // VersionText
            // 
            this.VersionText.Location = new System.Drawing.Point(59, 173);
            this.VersionText.Name = "VersionText";
            this.VersionText.ReadOnly = true;
            this.VersionText.Size = new System.Drawing.Size(135, 22);
            this.VersionText.TabIndex = 9;
            this.VersionText.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Version";
            // 
            // ProductText
            // 
            this.ProductText.Location = new System.Drawing.Point(59, 134);
            this.ProductText.Name = "ProductText";
            this.ProductText.ReadOnly = true;
            this.ProductText.Size = new System.Drawing.Size(135, 22);
            this.ProductText.TabIndex = 7;
            this.ProductText.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Product";
            // 
            // IMEIText
            // 
            this.IMEIText.Location = new System.Drawing.Point(59, 95);
            this.IMEIText.Name = "IMEIText";
            this.IMEIText.ReadOnly = true;
            this.IMEIText.Size = new System.Drawing.Size(135, 22);
            this.IMEIText.TabIndex = 5;
            this.IMEIText.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "IMEI";
            // 
            // CIDText
            // 
            this.CIDText.Location = new System.Drawing.Point(59, 58);
            this.CIDText.Name = "CIDText";
            this.CIDText.ReadOnly = true;
            this.CIDText.Size = new System.Drawing.Size(135, 22);
            this.CIDText.TabIndex = 3;
            this.CIDText.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "CID";
            // 
            // MIDText
            // 
            this.MIDText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MIDText.Location = new System.Drawing.Point(59, 21);
            this.MIDText.Name = "MIDText";
            this.MIDText.ReadOnly = true;
            this.MIDText.Size = new System.Drawing.Size(135, 22);
            this.MIDText.TabIndex = 1;
            this.MIDText.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MID";
            // 
            // updateDevices
            // 
            this.updateDevices.WorkerSupportsCancellation = true;
            this.updateDevices.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateDevices_DoWork);
            this.updateDevices.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateDevices_RunWorkerCompleted);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_reboot);
            this.groupBox2.Controls.Add(this.btn_ruu);
            this.groupBox2.Controls.Add(this.btn_recovery);
            this.groupBox2.Controls.Add(this.btn_download);
            this.groupBox2.Controls.Add(this.btn_bootloader);
            this.groupBox2.Location = new System.Drawing.Point(234, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 57);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reboot";
            // 
            // btn_reboot
            // 
            this.btn_reboot.Enabled = false;
            this.btn_reboot.Location = new System.Drawing.Point(339, 21);
            this.btn_reboot.Name = "btn_reboot";
            this.btn_reboot.Size = new System.Drawing.Size(75, 23);
            this.btn_reboot.TabIndex = 7;
            this.btn_reboot.TabStop = false;
            this.btn_reboot.Text = "Reboot";
            this.btn_reboot.UseVisualStyleBackColor = true;
            this.btn_reboot.Click += new System.EventHandler(this.btn_reboot_Click);
            // 
            // btn_ruu
            // 
            this.btn_ruu.Enabled = false;
            this.btn_ruu.Location = new System.Drawing.Point(258, 21);
            this.btn_ruu.Name = "btn_ruu";
            this.btn_ruu.Size = new System.Drawing.Size(75, 23);
            this.btn_ruu.TabIndex = 6;
            this.btn_ruu.TabStop = false;
            this.btn_ruu.Text = "RUU";
            this.btn_ruu.UseVisualStyleBackColor = true;
            this.btn_ruu.Click += new System.EventHandler(this.btn_ruu_Click);
            // 
            // btn_recovery
            // 
            this.btn_recovery.Enabled = false;
            this.btn_recovery.Location = new System.Drawing.Point(177, 21);
            this.btn_recovery.Name = "btn_recovery";
            this.btn_recovery.Size = new System.Drawing.Size(75, 23);
            this.btn_recovery.TabIndex = 5;
            this.btn_recovery.TabStop = false;
            this.btn_recovery.Text = "Recovery";
            this.btn_recovery.UseVisualStyleBackColor = true;
            this.btn_recovery.Click += new System.EventHandler(this.btn_recovery_Click);
            // 
            // btn_download
            // 
            this.btn_download.Enabled = false;
            this.btn_download.Location = new System.Drawing.Point(96, 21);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 23);
            this.btn_download.TabIndex = 4;
            this.btn_download.TabStop = false;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // btn_bootloader
            // 
            this.btn_bootloader.Enabled = false;
            this.btn_bootloader.Location = new System.Drawing.Point(15, 21);
            this.btn_bootloader.Name = "btn_bootloader";
            this.btn_bootloader.Size = new System.Drawing.Size(75, 23);
            this.btn_bootloader.TabIndex = 3;
            this.btn_bootloader.TabStop = false;
            this.btn_bootloader.Text = "Bootloader";
            this.btn_bootloader.UseVisualStyleBackColor = true;
            this.btn_bootloader.Click += new System.EventHandler(this.btn_bootloader_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_FlashSystem);
            this.groupBox3.Controls.Add(this.btn_FlashZip);
            this.groupBox3.Controls.Add(this.btn_FlashRecovery);
            this.groupBox3.Controls.Add(this.btn_FlashBoot);
            this.groupBox3.Location = new System.Drawing.Point(234, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(99, 177);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Flash";
            // 
            // btn_FlashSystem
            // 
            this.btn_FlashSystem.Enabled = false;
            this.btn_FlashSystem.Location = new System.Drawing.Point(13, 101);
            this.btn_FlashSystem.Name = "btn_FlashSystem";
            this.btn_FlashSystem.Size = new System.Drawing.Size(75, 23);
            this.btn_FlashSystem.TabIndex = 3;
            this.btn_FlashSystem.TabStop = false;
            this.btn_FlashSystem.Text = "System";
            this.btn_FlashSystem.UseVisualStyleBackColor = true;
            this.btn_FlashSystem.Click += new System.EventHandler(this.btn_FlashSystem_Click);
            // 
            // btn_FlashZip
            // 
            this.btn_FlashZip.Enabled = false;
            this.btn_FlashZip.Location = new System.Drawing.Point(13, 139);
            this.btn_FlashZip.Name = "btn_FlashZip";
            this.btn_FlashZip.Size = new System.Drawing.Size(75, 23);
            this.btn_FlashZip.TabIndex = 2;
            this.btn_FlashZip.TabStop = false;
            this.btn_FlashZip.Text = "Zip";
            this.btn_FlashZip.UseVisualStyleBackColor = true;
            this.btn_FlashZip.Click += new System.EventHandler(this.btn_FlashZip_Click);
            // 
            // btn_FlashRecovery
            // 
            this.btn_FlashRecovery.Enabled = false;
            this.btn_FlashRecovery.Location = new System.Drawing.Point(13, 62);
            this.btn_FlashRecovery.Name = "btn_FlashRecovery";
            this.btn_FlashRecovery.Size = new System.Drawing.Size(75, 23);
            this.btn_FlashRecovery.TabIndex = 1;
            this.btn_FlashRecovery.TabStop = false;
            this.btn_FlashRecovery.Text = "Recovery";
            this.btn_FlashRecovery.UseVisualStyleBackColor = true;
            this.btn_FlashRecovery.Click += new System.EventHandler(this.btn_FlashRecovery_Click);
            // 
            // btn_FlashBoot
            // 
            this.btn_FlashBoot.Enabled = false;
            this.btn_FlashBoot.Location = new System.Drawing.Point(13, 24);
            this.btn_FlashBoot.Name = "btn_FlashBoot";
            this.btn_FlashBoot.Size = new System.Drawing.Size(75, 23);
            this.btn_FlashBoot.TabIndex = 0;
            this.btn_FlashBoot.TabStop = false;
            this.btn_FlashBoot.Text = "Boot";
            this.btn_FlashBoot.UseVisualStyleBackColor = true;
            this.btn_FlashBoot.Click += new System.EventHandler(this.btn_FlashBoot_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(578, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Author";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(501, 363);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(61, 12);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "HTC Driver";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_flashToken);
            this.groupBox4.Controls.Add(this.btn_getToken);
            this.groupBox4.Location = new System.Drawing.Point(234, 75);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(99, 85);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Unlock Token";
            // 
            // btn_flashToken
            // 
            this.btn_flashToken.Enabled = false;
            this.btn_flashToken.Location = new System.Drawing.Point(14, 50);
            this.btn_flashToken.Name = "btn_flashToken";
            this.btn_flashToken.Size = new System.Drawing.Size(75, 23);
            this.btn_flashToken.TabIndex = 2;
            this.btn_flashToken.TabStop = false;
            this.btn_flashToken.Text = "Flash";
            this.btn_flashToken.UseVisualStyleBackColor = true;
            this.btn_flashToken.Click += new System.EventHandler(this.btn_flashToken_Click);
            // 
            // btn_getToken
            // 
            this.btn_getToken.Enabled = false;
            this.btn_getToken.Location = new System.Drawing.Point(14, 21);
            this.btn_getToken.Name = "btn_getToken";
            this.btn_getToken.Size = new System.Drawing.Size(75, 23);
            this.btn_getToken.TabIndex = 1;
            this.btn_getToken.TabStop = false;
            this.btn_getToken.Text = "Get";
            this.btn_getToken.UseVisualStyleBackColor = true;
            this.btn_getToken.Click += new System.EventHandler(this.btn_getToken_Click);
            // 
            // commandText
            // 
            this.commandText.AllowDrop = true;
            this.commandText.Location = new System.Drawing.Point(12, 356);
            this.commandText.Name = "commandText";
            this.commandText.Size = new System.Drawing.Size(472, 22);
            this.commandText.TabIndex = 8;
            this.commandText.TabStop = false;
            this.commandText.DragDrop += new System.Windows.Forms.DragEventHandler(this.commandText_DragDrop);
            this.commandText.DragEnter += new System.Windows.Forms.DragEventHandler(this.commandText_DragEnter);
            this.commandText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commandText_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Font = new System.Drawing.Font("細明體", 10F);
            this.textBox1.ForeColor = System.Drawing.Color.Lime;
            this.textBox1.Location = new System.Drawing.Point(351, 75);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(311, 268);
            this.textBox1.TabIndex = 9;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(674, 391);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.commandText);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTC Flash Tool v2.0.5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.TextBox MIDText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox VersionText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ProductText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IMEIText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CIDText;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker updateDevices;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_ruu;
        private System.Windows.Forms.Button btn_recovery;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_bootloader;
        private System.Windows.Forms.Button btn_reboot;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_FlashZip;
        private System.Windows.Forms.Button btn_FlashRecovery;
        private System.Windows.Forms.Button btn_FlashBoot;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btn_FlashSystem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_flashToken;
        private System.Windows.Forms.Button btn_getToken;
        private System.Windows.Forms.TextBox commandText;
        private System.Windows.Forms.TextBox textBox1;
    }
}

