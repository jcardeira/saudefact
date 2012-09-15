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

    public class FrmNewUser : Form
    {
        private Button button3;
        private Button button4;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private IContainer components = null;
        private SqlConnection con = null;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private EFEECT style = new EFEECT();
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;

        public FrmNewUser()
        {
            this.InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().Length == 0)
            {
                new FrmMsg(1, "AVISO", "Login obrigat\x00f3rio").ShowDialog();
            }
            else if (this.textBox2.Text != this.textBox3.Text)
            {
                new FrmMsg(1, "AVISO", "Valida\x00e7\x00e3o de password incorrecta").ShowDialog();
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
                    if (Data.TestUser(ref cmd, this.textBox1.Text))
                    {
                        transaction.Rollback();
                        new FrmMsg(1, "ERRO", "N\x00e3o \x00e9 possivel criar este utilizador").ShowDialog();
                        return;
                    }
                    Data.CreateUser(ref cmd, this.textBox1.Text, Convert.ToBase64String(Encoding.ASCII.GetBytes(Security.Encrypt(this.textBox2.Text, "CARDEX"))), this.checkBox1.Checked, this.checkBox2.Checked, this.checkBox3.Checked, this.checkBox4.Checked, this.checkBox5.Checked, this.checkBox6.Checked, this.checkBox7.Checked);
                    transaction.Commit();
                    new FrmMsg(1, "AVISO", "Utilizador criado").ShowDialog();
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

        private void button4_Click(object sender, EventArgs e)
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

        private void FrmNewUser_Load(object sender, EventArgs e)
        {
            this.style.Attach(this, EFEECT.Buttons.CLOSE, true);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmNewUser));
            this.groupBox1 = new GroupBox();
            this.button4 = new Button();
            this.button3 = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.textBox1 = new TextBox();
            this.checkBox6 = new CheckBox();
            this.textBox2 = new TextBox();
            this.checkBox5 = new CheckBox();
            this.textBox3 = new TextBox();
            this.checkBox4 = new CheckBox();
            this.checkBox3 = new CheckBox();
            this.checkBox1 = new CheckBox();
            this.checkBox2 = new CheckBox();
            this.checkBox7 = new CheckBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.BackColor = Color.White;
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.ForeColor = Color.SteelBlue;
            this.groupBox1.Location = new Point(2, 0x17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x232, 160);
            this.groupBox1.TabIndex = 0x2f;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.Location = new Point(0x123, 0x77);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x4b, 0x17);
            this.button4.TabIndex = 0x2d;
            this.button4.Text = "CANCELAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.Location = new Point(210, 0x77);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x4b, 0x17);
            this.button3.TabIndex = 0x2c;
            this.button3.Text = "GRAVAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x66, 0x10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x21, 13);
            this.label1.TabIndex = 0x1c;
            this.label1.Text = "Login";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x52, 0x29);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x35, 13);
            this.label2.TabIndex = 0x1d;
            this.label2.Text = "Password";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x1a, 0x41);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x6d, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Verifica\x00e7\x00e3o Password";
            this.textBox1.BackColor = Color.White;
            this.textBox1.ForeColor = Color.SteelBlue;
            this.textBox1.Location = new Point(0x8d, 0x10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x79, 20);
            this.textBox1.TabIndex = 0x1f;
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = Color.White;
            this.checkBox6.Location = new Point(0x1a0, 0x40);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new Size(0x75, 0x11);
            this.checkBox6.TabIndex = 0x29;
            this.checkBox6.Text = "Gest\x00e3o de Recibos";
            this.checkBox6.UseVisualStyleBackColor = false;
            this.textBox2.BackColor = Color.White;
            this.textBox2.ForeColor = Color.SteelBlue;
            this.textBox2.Location = new Point(0x8d, 0x2a);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new Size(0x79, 20);
            this.textBox2.TabIndex = 0x20;
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = Color.White;
            this.checkBox5.Location = new Point(0x1a0, 0x2a);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new Size(0x89, 0x11);
            this.checkBox5.TabIndex = 40;
            this.checkBox5.Text = "Gest\x00e3o de Tratamentos";
            this.checkBox5.UseVisualStyleBackColor = false;
            this.textBox3.BackColor = Color.White;
            this.textBox3.ForeColor = Color.SteelBlue;
            this.textBox3.Location = new Point(0x8d, 0x44);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new Size(0x79, 20);
            this.textBox3.TabIndex = 0x21;
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = Color.White;
            this.checkBox4.Location = new Point(0x1a0, 0x13);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new Size(0x87, 0x11);
            this.checkBox4.TabIndex = 0x27;
            this.checkBox4.Text = "Gest\x00e3o de Devolu\x00e7\x00f5es";
            this.checkBox4.UseVisualStyleBackColor = false;
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = Color.White;
            this.checkBox3.Location = new Point(0x123, 0x3f);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new Size(120, 0x11);
            this.checkBox3.TabIndex = 0x26;
            this.checkBox3.Text = "Gest\x00e3o de Recibos ";
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = Color.White;
            this.checkBox1.Location = new Point(0x123, 0x13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x34, 0x11);
            this.checkBox1.TabIndex = 0x24;
            this.checkBox1.Text = "Login";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = Color.White;
            this.checkBox2.Location = new Point(0x123, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(80, 0x11);
            this.checkBox2.TabIndex = 0x25;
            this.checkBox2.Text = "Utilizadores";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox7.AutoSize = true;
            this.checkBox7.BackColor = Color.White;
            this.checkBox7.Location = new Point(0x1a0, 0x57);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new Size(0x8e, 0x11);
            this.checkBox7.TabIndex = 0x2e;
            this.checkBox7.Text = "Gest\x00e3o de Notas Credito";
            this.checkBox7.UseVisualStyleBackColor = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x235, 0xca);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FrmNewUser";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "UTILIZADOR - Novo";
            base.Load += new EventHandler(this.FrmNewUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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

