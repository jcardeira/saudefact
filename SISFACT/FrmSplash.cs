namespace SISFACT
{
    using SISFACT.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmSplash : Form
    {
        private IContainer components = null;
        private PictureBox pictureBox1;
        private Timer timer1;

        public FrmSplash()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmSplash));
            this.timer1 = new Timer(this.components);
            this.pictureBox1 = new PictureBox();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.timer1.Enabled = true;
            this.timer1.Interval = 0x5dc;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.pictureBox1.Dock = DockStyle.Fill;
            this.pictureBox1.Image = Resources.Logovital;
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x1ee, 0x10f);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1ee, 0x10f);
            base.Controls.Add(this.pictureBox1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FrmSplash";
            base.StartPosition = FormStartPosition.CenterScreen;
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

