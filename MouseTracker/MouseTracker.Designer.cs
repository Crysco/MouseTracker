namespace MouseKeyboardActivityMonitor.MouseTracker
{
    partial class MouseTracker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                m_MouseHookManager.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.lMonSize = new System.Windows.Forms.Label();
            this.tbMonSize = new System.Windows.Forms.TextBox();
            this.errMon = new System.Windows.Forms.Label();
            this.lMonRes = new System.Windows.Forms.Label();
            this.cbMonRes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lErrMonSize = new System.Windows.Forms.Label();
            this.lErrMonRes = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(11, 101);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(100, 50);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(119, 101);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(100, 50);
            this.bStop.TabIndex = 2;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(225, 101);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(100, 50);
            this.bClear.TabIndex = 3;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // lMonSize
            // 
            this.lMonSize.AutoSize = true;
            this.lMonSize.Location = new System.Drawing.Point(13, 13);
            this.lMonSize.Name = "lMonSize";
            this.lMonSize.Size = new System.Drawing.Size(68, 13);
            this.lMonSize.TabIndex = 5;
            this.lMonSize.Text = "Monitor Size:";
            // 
            // tbMonSize
            // 
            this.tbMonSize.Location = new System.Drawing.Point(84, 10);
            this.tbMonSize.Name = "tbMonSize";
            this.tbMonSize.Size = new System.Drawing.Size(100, 20);
            this.tbMonSize.TabIndex = 0;
            // 
            // errMon
            // 
            this.errMon.Location = new System.Drawing.Point(0, 0);
            this.errMon.Name = "errMon";
            this.errMon.Size = new System.Drawing.Size(100, 23);
            this.errMon.TabIndex = 0;
            // 
            // lMonRes
            // 
            this.lMonRes.AutoSize = true;
            this.lMonRes.Location = new System.Drawing.Point(13, 44);
            this.lMonRes.Name = "lMonRes";
            this.lMonRes.Size = new System.Drawing.Size(97, 13);
            this.lMonRes.TabIndex = 7;
            this.lMonRes.Text = "Screen Resolution:";
            // 
            // cbMonRes
            // 
            this.cbMonRes.FormattingEnabled = true;
            this.cbMonRes.Items.AddRange(new object[] {
            "2560 x 1440",
            "1920 x 1200",
            "1920 x 1080",
            "1680 x 1050",
            "1600 x 1200",
            "1600 x 900 ",
            "1440 x 900 ",
            "1366 x 768 ",
            "1360 x 768 ",
            "1280 x 1024",
            "1280 x 800 ",
            "1280 x 720 ",
            "1024 x 768 ",
            " 800 x 600 ",
            " 640 x 480 "});
            this.cbMonRes.Location = new System.Drawing.Point(117, 41);
            this.cbMonRes.Name = "cbMonRes";
            this.cbMonRes.Size = new System.Drawing.Size(121, 21);
            this.cbMonRes.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // lErrMonSize
            // 
            this.lErrMonSize.AutoSize = true;
            this.lErrMonSize.Location = new System.Drawing.Point(190, 13);
            this.lErrMonSize.Name = "lErrMonSize";
            this.lErrMonSize.Size = new System.Drawing.Size(0, 13);
            this.lErrMonSize.TabIndex = 9;
            // 
            // lErrMonRes
            // 
            this.lErrMonRes.AutoSize = true;
            this.lErrMonRes.Location = new System.Drawing.Point(245, 44);
            this.lErrMonRes.Name = "lErrMonRes";
            this.lErrMonRes.Size = new System.Drawing.Size(0, 13);
            this.lErrMonRes.TabIndex = 10;
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(13, 73);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(58, 13);
            this.lTime.TabIndex = 11;
            this.lTime.Text = "0:00:00:00";
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MouseTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(337, 163);
            this.Controls.Add(this.lTime);
            this.Controls.Add(this.lErrMonRes);
            this.Controls.Add(this.lErrMonSize);
            this.Controls.Add(this.cbMonRes);
            this.Controls.Add(this.lMonRes);
            this.Controls.Add(this.tbMonSize);
            this.Controls.Add(this.lMonSize);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Name = "MouseTracker";
            this.Text = "MouseTracker";
            this.Load += new System.EventHandler(this.MouseTracker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Label lMonSize;
        private System.Windows.Forms.TextBox tbMonSize;
        private System.Windows.Forms.Label errMon;
        private System.Windows.Forms.Label lMonRes;
        private System.Windows.Forms.ComboBox cbMonRes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lErrMonSize;
        private System.Windows.Forms.Label lErrMonRes;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Timer timer;

    }
}