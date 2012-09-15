namespace SISFACT
{
    using STYLE;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class FrmPwdReset : Form
    {
        private Button button1;
        private Button button2;
        private IContainer components = null;
        private SqlConnection con = null;
        private GroupBox Dados;
        private int ID = 0;
        private Label label1;
        private Label label2;
        private Label label3;
        private string NAME = "";
        private EFEECT style = new EFEECT();
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;

        public FrmPwdReset(int Id, string Name)
        {
            this.InitializeComponent();
            this.ID = Id;
            this.NAME = Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text != this.textBox3.Text)
            {
                new FrmMsg(1, "ERRO", "Valida\x00e7\x00e3o de password incorrecta").ShowDialog();
            }
            else if (this.textBox2.Text.Trim().Length == 0)
            {
                new FrmMsg(1, "ERRO", "Password n\x00e3o pode ser vazia").ShowDialog();
            }
            else
            {
                this.con = new SqlConnection(Security.GetCnn());
                SqlTransaction transaction = null;
                try
                {
                    this.con.Open();
                    SqlCommand cmd = this.con.CreateCommand();
                    transaction = this.con.BeginTransaction();
                    cmd.Transaction = transaction;
                    if (!Data.TestUser(ref cmd, this.textBox1.Text))
                    {
                        transaction.Rollback();
                        new FrmMsg(1, "ERRO", "N\x00e3o \x00e9 possivel alterar este utilizador").ShowDialog();
                        return;
                    }
                    Data.ResetPWD(ref cmd, this.ID, Convert.ToBase64String(Encoding.ASCII.GetBytes(Security.Encrypt(this.textBox2.Text, "CARDEX"))));
                    transaction.Commit();
                    new FrmMsg(1, "AVISO", "Password alterada").ShowDialog();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    new FrmMsg(1, "ERRO", exception.Message).ShowDialog();
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

        private void FrmPwdReset_Load(object sender, EventArgs e)
        {
            this.style.Attach(this, EFEECT.Buttons.CLOSE, true);
            this.textBox1.Text = this.NAME;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmPwdReset));
            this.Dados = new GroupBox();
            this.button2 = new Button();
            this.button1 = new Button();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.label2 = new Label();
            this.label3 = new Label();
            this.textBox2 = new TextBox();
            this.textBox3 = new TextBox();
            this.Dados.SuspendLayout();
            base.SuspendLayout();
            this.Dados.BackColor = Color.White;
            this.Dados.Controls.Add(this.button2);
            this.Dados.Controls.Add(this.button1);
            this.Dados.Controls.Add(this.label1);
            this.Dados.Controls.Add(this.textBox1);
            this.Dados.Controls.Add(this.label2);
            this.Dados.Controls.Add(this.label3);
            this.Dados.Controls.Add(this.textBox2);
            this.Dados.Controls.Add(this.textBox3);
            this.Dados.ForeColor = Color.SteelBlue;
            this.Dados.Location = new Point(1, 0x1b);
            this.Dados.Name = "Dados";
            this.Dados.Size = new Size(0x183, 0xb6);
            this.Dados.TabIndex = 0;
            this.Dados.TabStop = false;
            this.Dados.Text = "Dados";
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.ForeColor = Color.SteelBlue;
            this.button2.Location = new Point(0xd4, 0x8a);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 0x29;
            this.button2.Text = "CANCELAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.Location = new Point(0x83, 0x8a);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 40;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x5f, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x21, 13);
            this.label1.TabIndex = 0x27;
            this.label1.Text = "Login";
            this.textBox1.BackColor = Color.White;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = Color.SteelBlue;
            this.textBox1.Location = new Point(0x86, 0x1b);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(0x79, 20);
            this.textBox1.TabIndex = 0x26;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x2e, 0x35);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x52, 13);
            this.label2.TabIndex = 0x22;
            this.label2.Text = "Nova Password";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x13, 0x4c);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x6d, 13);
            this.label3.TabIndex = 0x23;
            this.label3.Text = "Verifica\x00e7\x00e3o Password";
            this.textBox2.BackColor = Color.White;
            this.textBox2.ForeColor = Color.SteelBlue;
            this.textBox2.Location = new Point(0x86, 0x35);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new Size(0x79, 20);
            this.textBox2.TabIndex = 0x24;
            this.textBox3.BackColor = Color.White;
            this.textBox3.ForeColor = Color.SteelBlue;
            this.textBox3.Location = new Point(0x86, 0x4f);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new Size(0x79, 20);
            this.textBox3.TabIndex = 0x25;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(400, 0xdd);
            base.Controls.Add(this.Dados);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FrmPwdReset";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Alterar - Password";
            base.Load += new EventHandler(this.FrmPwdReset_Load);
            this.Dados.ResumeLayout(false);
            this.Dados.PerformLayout();
            base.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.style.Paint();
            base.OnPaint(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (this.style.WndProc(ref m))
            {
                base.WndProc(ref m);
            }
        }
    }
}

