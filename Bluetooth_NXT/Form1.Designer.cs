namespace Bluetooth_NXT
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
            this.portName = new System.Windows.Forms.TextBox();
            this.btnPing = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLeftMotor = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblPortName = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // portName
            // 
            this.portName.Location = new System.Drawing.Point(76, 12);
            this.portName.Name = "portName";
            this.portName.Size = new System.Drawing.Size(70, 20);
            this.portName.TabIndex = 1;
            this.portName.Text = "COM3";
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(309, 41);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(97, 46);
            this.btnPing.TabIndex = 1;
            this.btnPing.TabStop = false;
            this.btnPing.Text = "Beep";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 52);
            this.button1.TabIndex = 3;
            this.button1.TabStop = false;
            this.button1.Text = "Right";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnRightMotor_Click);
            // 
            // btnLeftMotor
            // 
            this.btnLeftMotor.Location = new System.Drawing.Point(16, 139);
            this.btnLeftMotor.Name = "btnLeftMotor";
            this.btnLeftMotor.Size = new System.Drawing.Size(72, 52);
            this.btnLeftMotor.TabIndex = 4;
            this.btnLeftMotor.TabStop = false;
            this.btnLeftMotor.Text = "Left";
            this.btnLeftMotor.UseVisualStyleBackColor = true;
            this.btnLeftMotor.Click += new System.EventHandler(this.btnLeftMotor_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStop.Location = new System.Drawing.Point(412, 41);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(206, 150);
            this.btnStop.TabIndex = 5;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "STOP MOTORS";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(94, 81);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(72, 52);
            this.btnUp.TabIndex = 6;
            this.btnUp.TabStop = false;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(94, 139);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(72, 52);
            this.btnDown.TabIndex = 7;
            this.btnDown.TabStop = false;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(152, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 20);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.TabStop = false;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblPortName
            // 
            this.lblPortName.AutoSize = true;
            this.lblPortName.Location = new System.Drawing.Point(14, 15);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(56, 13);
            this.lblPortName.TabIndex = 9;
            this.lblPortName.Text = "COM Port:";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.Red;
            this.lblConnectionStatus.Location = new System.Drawing.Point(12, 35);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(73, 13);
            this.lblConnectionStatus.TabIndex = 10;
            this.lblConnectionStatus.Text = "Disconnected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 240);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.lblPortName);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnLeftMotor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPing);
            this.Controls.Add(this.portName);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "RoboProject";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox portName;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLeftMotor;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblPortName;
        private System.Windows.Forms.Label lblConnectionStatus;
    }
}

