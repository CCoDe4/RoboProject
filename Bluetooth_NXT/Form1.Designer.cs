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
            this.responseBox = new System.Windows.Forms.TextBox();
            this.btnPing = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLeftMotor = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // responseBox
            // 
            this.responseBox.Location = new System.Drawing.Point(182, 14);
            this.responseBox.Name = "responseBox";
            this.responseBox.Size = new System.Drawing.Size(100, 20);
            this.responseBox.TabIndex = 0;
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(87, 12);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(75, 23);
            this.btnPing.TabIndex = 1;
            this.btnPing.Text = "Ping";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 52);
            this.button1.TabIndex = 3;
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
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 261);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnLeftMotor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPing);
            this.Controls.Add(this.responseBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox responseBox;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLeftMotor;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
    }
}

