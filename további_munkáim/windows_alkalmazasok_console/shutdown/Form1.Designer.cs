namespace shutdown
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
            this.Shutdown_btn = new System.Windows.Forms.Button();
            this.Restart_btn = new System.Windows.Forms.Button();
            this.LogOFF_btn = new System.Windows.Forms.Button();
            this.Lock_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Shutdown_btn
            // 
            this.Shutdown_btn.Location = new System.Drawing.Point(110, 64);
            this.Shutdown_btn.Name = "Shutdown_btn";
            this.Shutdown_btn.Size = new System.Drawing.Size(150, 50);
            this.Shutdown_btn.TabIndex = 0;
            this.Shutdown_btn.Text = "Shutdown";
            this.Shutdown_btn.UseVisualStyleBackColor = true;
            this.Shutdown_btn.Click += new System.EventHandler(this.Shutdown_btn_Click);
            // 
            // Restart_btn
            // 
            this.Restart_btn.Location = new System.Drawing.Point(110, 156);
            this.Restart_btn.Name = "Restart_btn";
            this.Restart_btn.Size = new System.Drawing.Size(150, 50);
            this.Restart_btn.TabIndex = 1;
            this.Restart_btn.Text = "Restrart";
            this.Restart_btn.UseVisualStyleBackColor = true;
            this.Restart_btn.Click += new System.EventHandler(this.Restart_btn_Click);
            // 
            // LogOFF_btn
            // 
            this.LogOFF_btn.Location = new System.Drawing.Point(110, 343);
            this.LogOFF_btn.Name = "LogOFF_btn";
            this.LogOFF_btn.Size = new System.Drawing.Size(150, 50);
            this.LogOFF_btn.TabIndex = 3;
            this.LogOFF_btn.Text = "LogOFF_btn";
            this.LogOFF_btn.UseVisualStyleBackColor = true;
            this.LogOFF_btn.Click += new System.EventHandler(this.LogOFF_btn_Click);
            // 
            // Lock_btn
            // 
            this.Lock_btn.Location = new System.Drawing.Point(110, 251);
            this.Lock_btn.Name = "Lock_btn";
            this.Lock_btn.Size = new System.Drawing.Size(150, 50);
            this.Lock_btn.TabIndex = 2;
            this.Lock_btn.Text = "Lock_btn";
            this.Lock_btn.UseVisualStyleBackColor = true;
            this.Lock_btn.Click += new System.EventHandler(this.Lock_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 453);
            this.Controls.Add(this.LogOFF_btn);
            this.Controls.Add(this.Lock_btn);
            this.Controls.Add(this.Restart_btn);
            this.Controls.Add(this.Shutdown_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Shutdown_btn;
        private System.Windows.Forms.Button Restart_btn;
        private System.Windows.Forms.Button LogOFF_btn;
        private System.Windows.Forms.Button Lock_btn;
    }
}

