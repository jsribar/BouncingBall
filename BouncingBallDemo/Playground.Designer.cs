﻿namespace Vsite.Pood.BouncingBallDemo
{
    partial class Playground
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 10;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // Playground
            // 
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Click += new System.EventHandler(this.Playground_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Playground_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Playground_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerRefresh;
    }
}
