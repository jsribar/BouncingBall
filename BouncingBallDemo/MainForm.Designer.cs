namespace BouncingBallDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.playground1 = new Vsite.Pood.BouncingBallDemo.Playground();
            this.SuspendLayout();
            // 
            // playground1
            // 
            this.playground1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.playground1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playground1.BackgroundImage")));
            this.playground1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playground1.Location = new System.Drawing.Point(0, 0);
            this.playground1.Name = "playground1";
            this.playground1.Size = new System.Drawing.Size(331, 261);
            this.playground1.TabIndex = 0;
            this.playground1.Text = "playground1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(331, 261);
            this.Controls.Add(this.playground1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Bouncy";
            this.ResumeLayout(false);

		}

        #endregion

        private Vsite.Pood.BouncingBallDemo.Playground playground1;
    }
}

