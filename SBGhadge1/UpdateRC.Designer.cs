﻿namespace SBGhadge1
{
    partial class UpdateRC
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
            this.btnexport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(33, 34);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(93, 46);
            this.btnexport.TabIndex = 0;
            this.btnexport.Text = "Export Rc To Excel";
            this.btnexport.UseVisualStyleBackColor = true;
            // 
            // UpdateRC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.btnexport);
            this.Name = "UpdateRC";
            this.Text = "UpdateRC";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnexport;
    }
}