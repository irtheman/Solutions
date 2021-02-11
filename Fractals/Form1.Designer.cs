
namespace Fractals
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep = new System.Windows.Forms.ToolStripSeparator();
            this.mnuScale1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale6 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFullScale = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFractal = new System.Windows.Forms.ToolStripComboBox();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.mnuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuStrip
            // 
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuView,
            this.mnuOptions,
            this.mnuFractal});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(278, 27);
            this.mnuStrip.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSaveAs});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 23);
            this.mnuFile.Text = "&File";
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(123, 22);
            this.mnuSaveAs.Text = "&Save As...";
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuScale1,
                this.mnuScale2,
                this.mnuScale3,
                this.mnuScale4,
                this.mnuScale5,
                this.mnuScale6,
                this.mnuFullScale,
                this.mnuSep,
                this.mnuUndo,
                this.mnuSep,
                this.mnuRefresh});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 23);
            this.mnuView.Text = "&View";
            // 
            // mnuScale1
            // 
            this.mnuScale1.Name = "mnuScale1";
            this.mnuScale1.Size = new System.Drawing.Size(113, 22);
            this.mnuScale1.Text = "Scale 0.25x";
            this.mnuScale1.Tag = 0.25;
            this.mnuScale1.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale2
            // 
            this.mnuScale2.Name = "mnuScale2";
            this.mnuScale2.Size = new System.Drawing.Size(113, 22);
            this.mnuScale2.Text = "Scale 0.5x";
            this.mnuScale2.Tag = 0.5;
            this.mnuScale2.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale3
            // 
            this.mnuScale3.Name = "mnuScale3";
            this.mnuScale3.Size = new System.Drawing.Size(113, 22);
            this.mnuScale3.Text = "Scale 0.75x";
            this.mnuScale3.Tag = 0.75;
            this.mnuScale3.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale4
            // 
            this.mnuScale4.Name = "mnuScale4";
            this.mnuScale4.Size = new System.Drawing.Size(113, 22);
            this.mnuScale4.Text = "Scale 2x";
            this.mnuScale4.Tag = 2.0;
            this.mnuScale4.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale5
            // 
            this.mnuScale5.Name = "mnuScale5";
            this.mnuScale5.Size = new System.Drawing.Size(113, 22);
            this.mnuScale5.Text = "Scale 4x";
            this.mnuScale5.Tag = 4.0;
            this.mnuScale5.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale6
            // 
            this.mnuScale6.Name = "mnuScale6";
            this.mnuScale6.Size = new System.Drawing.Size(113, 22);
            this.mnuScale6.Text = "Scale 8x";
            this.mnuScale6.Tag = 8.0;
            this.mnuScale6.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuFullScale
            // 
            this.mnuFullScale.Name = "mnuFullScale";
            this.mnuFullScale.Size = new System.Drawing.Size(113, 22);
            this.mnuFullScale.Text = "&Full Scale";
            this.mnuFullScale.Click += new System.EventHandler(this.mnuFullScale_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(113, 22);
            this.mnuRefresh.Text = "&Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuUndo
            // 
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.Size = new System.Drawing.Size(113, 22);
            this.mnuUndo.Text = "&Undo";
            this.mnuUndo.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z;
            this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(61, 23);
            this.mnuOptions.Text = "&Options";
            // 
            // mnuFractal
            // 
            this.mnuFractal.Items.AddRange(new object[] {
            "Mandelbrot",
            "Burning Ship",
            "Julia 1",
            "Julia 2",
            "Julia 3",
            "Julia 4"});
            this.mnuFractal.Name = "mnuFractal";
            this.mnuFractal.Size = new System.Drawing.Size(121, 23);
            this.mnuFractal.Text = "Fractal";
            this.mnuFractal.SelectedIndexChanged += new System.EventHandler(this.mnuFractal_SelectedIndexChanged);
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.BackColor = System.Drawing.Color.Black;
            this.Canvas.Location = new System.Drawing.Point(0, 28);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(278, 225);
            this.Canvas.TabIndex = 1;
            this.Canvas.TabStop = false;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 254);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.mnuStrip);
            this.MainMenuStrip = this.mnuStrip;
            this.Name = "Form1";
            this.Text = "Fractals";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1;
        private System.Windows.Forms.ToolStripMenuItem mnuScale2;
        private System.Windows.Forms.ToolStripMenuItem mnuScale3;
        private System.Windows.Forms.ToolStripMenuItem mnuScale4;
        private System.Windows.Forms.ToolStripMenuItem mnuScale5;
        private System.Windows.Forms.ToolStripMenuItem mnuScale6;
        private System.Windows.Forms.ToolStripMenuItem mnuFullScale;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripComboBox mnuFractal;
        private System.Windows.Forms.ToolStripSeparator mnuSep;
        private System.Windows.Forms.PictureBox Canvas;
    }
}

