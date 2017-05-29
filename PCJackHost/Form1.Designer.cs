namespace PCJackHost
{
    partial class PCHost
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
            this.IPLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(106, 79);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(58, 13);
            this.IPLabel.TabIndex = 0;
            this.IPLabel.Text = "Press Start";
            this.IPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IPLabel.SizeChanged += new System.EventHandler(this.IPLabel_SizeChanged);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(71, 220);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(134, 37);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ver 0.2";
            // 
            // PCHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 292);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.IPLabel);
            this.Name = "PCHost";
            this.Text = "PCHost";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Close);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label2;
    }
}

