namespace SISFACT
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmMsg : Form
    {
        private Button button1;
        private Button button2;
        private IContainer components;
        private GroupBox groupBox1;
        private Label label1;

        public FrmMsg(int buttons, string Caption, string text)
        {
            this.components = null;
            this.InitializeComponent();
            if (buttons == 1)
            {
                this.button2.Visible = false;
            }
            this.Text = Caption;
            this.label1.Text = text;
        }

        public FrmMsg(int buttons, string Caption, string text, int width, int height)
        {
            this.components = null;
            this.InitializeComponent();
            if (buttons == 1)
            {
                this.button2.Visible = false;
            }
            base.Width = width;
            base.Height = height;
            this.Text = Caption;
            this.label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmMsg_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmMsg));
            this.button2 = new Button();
            this.button1 = new Button();
            this.label1 = new Label();
            this.groupBox1 = new GroupBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.Location = new Point(0xb8, 0x69);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 0x1f;
            this.button2.Text = "CANCELAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.Location = new Point(0x67, 0x69);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 30;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0, 13);
            this.label1.TabIndex = 0x20;
            this.groupBox1.BackColor = Color.White;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.ForeColor = Color.SteelBlue;
            this.groupBox1.Location = new Point(2, 0x1a);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x16a, 0x86);
            this.groupBox1.TabIndex = 0x21;
            this.groupBox1.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x16f, 0xa6);
            base.Controls.Add(this.groupBox1);
            this.ForeColor = SystemColors.ActiveCaptionText;
            base.Name = "FrmMsg";
            base.StartPosition = FormStartPosition.CenterScreen;
            base.Load += new EventHandler(this.FrmMsg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}

