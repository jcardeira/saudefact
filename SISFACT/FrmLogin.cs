namespace SISFACT
{
    using STYLE;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    public class FrmLogin : Form
    {
        private Button button1;
        private Button button2;
        private IContainer components = null;
        private SqlConnection con = null;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        public string[] per = null;
        private EFEECT style = new EFEECT();
        private TextBox textBox1;
        private TextBox textBox2;
        public string user = null;
        public int userID = 0;

        public FrmLogin()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = Convert.ToBase64String(Encoding.ASCII.GetBytes(Security.Encrypt("ADMIN", "CARDEX")));
            this.con = new SqlConnection(Security.GetCnn());
            try
            {
                this.con.Open();
                SqlCommand cmd = this.con.CreateCommand();
                cmd.CommandTimeout = 0x98967f;
                this.per = Data.GetPermissions(ref cmd, ref this.userID, this.textBox1.Text, Convert.ToBase64String(Encoding.ASCII.GetBytes(Security.Encrypt(this.textBox2.Text, "CARDEX"))));
                this.user = this.textBox1.Text;
            }
            catch (Exception exception)
            {
                new FrmMsg(1, "ERRO", exception.Message).ShowDialog();
                throw exception;
            }
            finally
            {
                if ((this.con != null) && (this.con.State == ConnectionState.Open))
                {
                    this.con.Close();
                }
            }
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

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }

        public static string Getgama()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry hostByName = Dns.GetHostByName(hostName);
            switch (hostName)
            {
                case "Antonio-NLS":
                    return "Antonio-NLS";

                case "MEDINFOT-471C1F":
                    return "MEDINFOT-471C1F";
            }
            IPAddress[] addressList = hostByName.AddressList;
            for (int i = 0; i < addressList.Length; i++)
            {
                if (addressList[i].ToString().StartsWith("192."))
                {
                    return addressList[i].ToString();
                }
            }
            return "";
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmLogin));
            
            this.label1 = new Label();
            this.label2 = new Label();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.groupBox1 = new GroupBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 0x10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(50, 13);
            this.label1.TabIndex = 0x18;
            this.label1.Text = "Utilizador";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 0x2f);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x35, 13);
            this.label2.TabIndex = 0x19;
            this.label2.Text = "Password";
            this.textBox1.BackColor = Color.White;
            this.textBox1.ForeColor = Color.SteelBlue;
            this.textBox1.Location = new Point(0x48, 0x10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(140, 20);
            this.textBox1.TabIndex = 0x1a;
            this.textBox2.BackColor = Color.White;
            this.textBox2.ForeColor = Color.SteelBlue;
            this.textBox2.Location = new Point(0x48, 0x2f);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new Size(140, 20);
            this.textBox2.TabIndex = 0x1b;
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.Location = new Point(70, 90);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0x1c;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.FlatAppearance.BorderColor = Color.White;
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.Location = new Point(0x97, 90);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 0x1d;
            this.button2.Text = "CANCELAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.groupBox1.BackColor = Color.White;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.ForeColor = Color.SteelBlue;
            this.groupBox1.Location = new Point(3, 0x1b);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(280, 120);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            base.AcceptButton = this.button1;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x11f, 0x98);
            base.Controls.Add(this.groupBox1);
            this.ForeColor = Color.White;
//            base.FormBorderStyle = FormBorderStyle.Fixed3D;
//            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "FrmLogin";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login -" + FrmMain.GetRunningVersion(); ;
            base.Load += new EventHandler(this.FrmLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}

