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
            this.playground1 = new Vsite.Pood.BouncingBallDemo.Playground();
            this.SuspendLayout();
            // 
            // playground1
            // 
            this.playground1.BackColor = System.Drawing.SystemColors.Window;
            this.playground1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playground1.Location = new System.Drawing.Point(0, 0);
            this.playground1.Name = "playground1";
            this.playground1.Size = new System.Drawing.Size(284, 261);
            this.playground1.TabIndex = 0;
            this.playground1.Text = "playground1";
            this.playground1.Click += new System.EventHandler(this.playground1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.playground1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

		}

        #endregion

        private Vsite.Pood.BouncingBallDemo.Playground playground1;
    }
}

