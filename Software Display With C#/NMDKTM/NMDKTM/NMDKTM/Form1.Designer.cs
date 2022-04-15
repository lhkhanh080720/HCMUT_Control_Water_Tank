namespace NMDKTM
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.SetPoint = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.Send_SP = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.PbMode = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Connect);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication Setup";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(97, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // Connect
            // 
            this.Connect.BackColor = System.Drawing.Color.Lime;
            this.Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect.Location = new System.Drawing.Point(36, 46);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(154, 23);
            this.Connect.TabIndex = 2;
            this.Connect.Text = "CONNECT";
            this.Connect.UseVisualStyleBackColor = false;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // SetPoint
            // 
            this.SetPoint.Location = new System.Drawing.Point(6, 30);
            this.SetPoint.Name = "SetPoint";
            this.SetPoint.Size = new System.Drawing.Size(100, 20);
            this.SetPoint.TabIndex = 3;
            this.SetPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 93);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(539, 367);
            this.zedGraphControl1.TabIndex = 3;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // Send_SP
            // 
            this.Send_SP.BackColor = System.Drawing.Color.Blue;
            this.Send_SP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Send_SP.Location = new System.Drawing.Point(119, 28);
            this.Send_SP.Name = "Send_SP";
            this.Send_SP.Size = new System.Drawing.Size(75, 23);
            this.Send_SP.TabIndex = 5;
            this.Send_SP.Text = "SEND";
            this.Send_SP.UseVisualStyleBackColor = false;
            this.Send_SP.Click += new System.EventHandler(this.SendSP);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SetPoint);
            this.groupBox3.Controls.Add(this.Send_SP);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(257, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 78);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SetPoint";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.PbMode);
            this.groupBox5.Location = new System.Drawing.Point(463, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(88, 78);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Mode";
            // 
            // PbMode
            // 
            this.PbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PbMode.Location = new System.Drawing.Point(6, 28);
            this.PbMode.Name = "PbMode";
            this.PbMode.Size = new System.Drawing.Size(75, 30);
            this.PbMode.TabIndex = 0;
            this.PbMode.Text = "COMPACT";
            this.PbMode.UseVisualStyleBackColor = true;
            this.PbMode.Click += new System.EventHandler(this.PbMode_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(558, 472);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_main);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.TextBox SetPoint;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBox1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button Send_SP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button PbMode;
        private System.Windows.Forms.Timer timer1;
    }
}

