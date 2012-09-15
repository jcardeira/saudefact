namespace SISFACT
{
    using SISFACT.Properties;
    using System;
    using System.ComponentModel;
    using System.Deployment.Application;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    internal class AboutBox1 : Form
    {
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;

        public AboutBox1()
        {
            this.InitializeComponent();
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                this.label2.Text = "Vers\x00e3o: " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            this.label4.Text = "BD: " + Data.GetVersaoBD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            MessageBox.Show(directoryName);
            DirectoryInfo info = new DirectoryInfo(directoryName.Replace(@"file:\", "") + @"\rpt\");
            MessageBox.Show(info.FullName);
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
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Location = new Point(0x218, 0x11b);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x5e, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto: SISFACT";
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.Location = new Point(0x218, 0x131);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x4f, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vers\x00e3o: 1.1.1.1";
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.Transparent;
            this.label3.Location = new Point(0x218, 0x153);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Companhia: NLS";
            this.label4.AutoSize = true;
            this.label4.BackColor = Color.Transparent;
            this.label4.Location = new Point(0x218, 0x141);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x3d, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "BD: 1.1.1.1";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.BackgroundImage = SISFACT.Properties.Resources.image002;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            base.ClientSize = new Size(0x2a5, 0x176);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "AboutBox1";
            base.Padding = new Padding(9);
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Acerca de ...";
            base.Load += new EventHandler(this.AboutBox1_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
    }
}

