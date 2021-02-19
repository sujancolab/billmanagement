namespace SBGhadgev1
{
    partial class PointCanvas
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
            this.classificationBW = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.adaboostBW = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // classificationBW
            // 
            this.classificationBW.WorkerSupportsCancellation = true;
            this.classificationBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 40;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // adaboostBW
            // 
            this.adaboostBW.WorkerSupportsCancellation = true;
            // 
            // PointCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "PointCanvas";
            this.Size = new System.Drawing.Size(344, 141);
            this.Load += new System.EventHandler(this.PointCanvas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker classificationBW;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer animationTimer;
        private System.ComponentModel.BackgroundWorker adaboostBW;
    }
}