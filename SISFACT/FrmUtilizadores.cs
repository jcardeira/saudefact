namespace SISFACT
{
    using STYLE;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmUtilizadores : Form
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private IContainer components = null;
        private SqlConnection con = null;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private EFEECT style = new EFEECT();
        private TextBox textBox1;

        public FrmUtilizadores(Form parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
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
                    }
                    else
                    {
                        Data.UpdateUserPermissions(ref cmd, id, this.checkBox1.Checked, this.checkBox2.Checked, this.checkBox3.Checked, this.checkBox4.Checked, this.checkBox5.Checked, this.checkBox6.Checked, this.checkBox7.Checked);
                        transaction.Commit();
                        new FrmMsg(1, "AVISO", "Utilizador alterado").ShowDialog();
                        this.dataGridView1.DataSource = Data.GetUsers(ref cmd);
                        if (((DataTable) this.dataGridView1.DataSource).Rows.Count > 0)
                        {
                            this.dataGridView1.Rows[0].Selected = true;
                        }
                    }
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
            }
            else
            {
                new FrmMsg(1, "AVISO", "Seleccione um utilizador").ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                if (new FrmMsg(2, "AVISO", "Tem a certeza que quer apagar o utilizador seleccionado?").ShowDialog() == DialogResult.OK)
                {
                    int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
                    this.con = new SqlConnection(Security.GetCnn());
                    SqlTransaction transaction = null;
                    try
                    {
                        this.con.Open();
                        SqlCommand cmd = this.con.CreateCommand();
                        transaction = this.con.BeginTransaction();
                        cmd.Transaction = transaction;
                        Data.DeleteUser(ref cmd, id);
                        transaction.Commit();
                        new FrmMsg(1, "AVISO", "Utilizador apagado").ShowDialog();
                        this.dataGridView1.DataSource = Data.GetUsers(ref cmd);
                        if (((DataTable) this.dataGridView1.DataSource).Rows.Count > 0)
                        {
                            this.dataGridView1.Rows[0].Selected = true;
                        }
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
                }
            }
            else
            {
                new FrmMsg(1, "AVISO", "Seleccione um utilizador").ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (new FrmNewUser().ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.con.Open();
                    SqlCommand cmd = this.con.CreateCommand();
                    this.dataGridView1.DataSource = Data.GetUsers(ref cmd);
                    if (((DataTable) this.dataGridView1.DataSource).Rows.Count > 0)
                    {
                        this.dataGridView1.Rows[0].Selected = true;
                    }
                }
                catch (Exception exception)
                {
                    new FrmMsg(1, "ERRO", exception.Message).ShowDialog();
                }
                finally
                {
                    if ((this.con != null) && (this.con.State == ConnectionState.Open))
                    {
                        this.con.Close();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                new FrmPwdReset(Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value), this.textBox1.Text).ShowDialog();
            }
            else
            {
                new FrmMsg(1, "AVISO", "Seleccione um utilizador").ShowDialog();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                this.textBox1.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
                this.checkBox1.Checked = false;
                this.checkBox2.Checked = false;
                this.checkBox3.Checked = false;
                this.checkBox4.Checked = false;
                this.checkBox5.Checked = false;
                this.checkBox6.Checked = false;
                this.con = new SqlConnection(Security.GetCnn());
                try
                {
                    this.con.Open();
                    DataTable associatedPermissions = Data.GetAssociatedPermissions(this.con.CreateCommand(), id);
                    foreach (DataRow row in associatedPermissions.Rows)
                    {
                        string str = row["cod_menu"].ToString();
                        if (str != null)
                        {
                            if (!(str == "1"))
                            {
                                if (str == "2")
                                {
                                    goto Label_0199;
                                }
                                if (str == "3")
                                {
                                    goto Label_01A8;
                                }
                                if (str == "4")
                                {
                                    goto Label_01B7;
                                }
                                if (str == "5")
                                {
                                    goto Label_01C6;
                                }
                                if (str == "6")
                                {
                                    goto Label_01D5;
                                }
                            }
                            else
                            {
                                this.checkBox2.Checked = true;
                            }
                        }
                        goto Label_01E4;
                    Label_0199:
                        this.checkBox3.Checked = true;
                        goto Label_01E4;
                    Label_01A8:
                        this.checkBox4.Checked = true;
                        goto Label_01E4;
                    Label_01B7:
                        this.checkBox5.Checked = true;
                        goto Label_01E4;
                    Label_01C6:
                        this.checkBox6.Checked = true;
                        goto Label_01E4;
                    Label_01D5:
                        this.checkBox1.Checked = true;
                    Label_01E4:;
                    }
                }
                catch
                {
                }
                finally
                {
                    if ((this.con != null) && (this.con.State == ConnectionState.Open))
                    {
                        this.con.Close();
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmUtilizadores_Load(object sender, EventArgs e)
        {
            this.style.Attach(this, EFEECT.Buttons.CLOSE_MINIMIZE, true);
            this.dataGridView1.SelectionChanged += new EventHandler(this.dataGridView1_SelectionChanged);
            this.con = new SqlConnection(Security.GetCnn());
            try
            {
                this.con.Open();
                SqlCommand cmd = this.con.CreateCommand();
                this.dataGridView1.DataSource = Data.GetUsers(ref cmd);
                if (((DataTable) this.dataGridView1.DataSource).Rows.Count > 0)
                {
                    this.dataGridView1.Rows[0].Selected = true;
                }
            }
            catch
            {
            }
            finally
            {
                if ((this.con != null) && (this.con.State == ConnectionState.Open))
                {
                    this.con.Close();
                }
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmUtilizadores));
            this.groupBox2 = new GroupBox();
            this.dataGridView1 = new DataGridView();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.checkBox1 = new CheckBox();
            this.checkBox2 = new CheckBox();
            this.checkBox3 = new CheckBox();
            this.checkBox4 = new CheckBox();
            this.checkBox5 = new CheckBox();
            this.checkBox6 = new CheckBox();
            this.button2 = new Button();
            this.button1 = new Button();
            this.button3 = new Button();
            this.button4 = new Button();
            this.groupBox1 = new GroupBox();
            this.checkBox7 = new CheckBox();
            this.button5 = new Button();
            this.label2 = new Label();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox2.BackColor = Color.White;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.ForeColor = Color.SteelBlue;
            this.groupBox2.Location = new Point(3, 0x1c);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x322, 0xdf);
            this.groupBox2.TabIndex = 0x1b;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Utilizadores";
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = Color.White;
            this.dataGridView1.Location = new Point(6, 14);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(990, 0xcf);
            this.dataGridView1.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0xde, 0x15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x21, 13);
            this.label1.TabIndex = 0x1c;
            this.label1.Text = "Login";
            this.textBox1.BackColor = Color.White;
            this.textBox1.ForeColor = Color.SteelBlue;
            this.textBox1.Location = new Point(0x105, 0x15);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(0x79, 20);
            this.textBox1.TabIndex = 0x1f;
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = Color.White;
            this.checkBox1.Location = new Point(0x19b, 0x18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x34, 0x11);
            this.checkBox1.TabIndex = 0x24;
            this.checkBox1.Text = "Login";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = Color.White;
            this.checkBox2.Location = new Point(0x19b, 0x2d);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(80, 0x11);
            this.checkBox2.TabIndex = 0x25;
            this.checkBox2.Text = "Utilizadores";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = Color.White;
            this.checkBox3.Location = new Point(0x19b, 0x44);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new Size(0x75, 0x11);
            this.checkBox3.TabIndex = 0x26;
            this.checkBox3.Text = "Gest\x00e3o de Recibos";
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = Color.White;
            this.checkBox4.Location = new Point(0x216, 0x18);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new Size(0x87, 0x11);
            this.checkBox4.TabIndex = 0x27;
            this.checkBox4.Text = "Gest\x00e3o de Devolu\x00e7\x00f5es";
            this.checkBox4.UseVisualStyleBackColor = false;
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = Color.White;
            this.checkBox5.Location = new Point(0x216, 0x2d);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new Size(0x89, 0x11);
            this.checkBox5.TabIndex = 40;
            this.checkBox5.Text = "Gest\x00e3o de Tratamentos";
            this.checkBox5.UseVisualStyleBackColor = false;
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = Color.White;
            this.checkBox6.Location = new Point(0x216, 0x43);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new Size(0x77, 0x11);
            this.checkBox6.TabIndex = 0x29;
            this.checkBox6.Text = "Gest\x00e3o de Facturas";
            this.checkBox6.UseVisualStyleBackColor = false;
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.Location = new Point(320, 0x7b);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 0x2b;
            this.button2.Text = "APAGAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.Location = new Point(0xef, 0x7b);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0x2a;
            this.button1.Text = "ALTERAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.Location = new Point(0x207, 0x7b);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x4b, 0x17);
            this.button3.TabIndex = 0x2c;
            this.button3.Text = "NOVO";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.Location = new Point(0x191, 0x7b);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x4b, 0x17);
            this.button4.TabIndex = 0x2d;
            this.button4.Text = "CANCELAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.groupBox1.BackColor = Color.White;
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.ForeColor = Color.SteelBlue;
            this.groupBox1.Location = new Point(3, 0x101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x322, 0xa7);
            this.groupBox1.TabIndex = 0x2e;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalhe";
            this.checkBox7.AutoSize = true;
            this.checkBox7.BackColor = Color.White;
            this.checkBox7.Location = new Point(0x216, 90);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new Size(0x9d, 0x11);
            this.checkBox7.TabIndex = 0x2f;
            this.checkBox7.Text = "Gest\x00e3o de Notas de Credito";
            this.checkBox7.UseVisualStyleBackColor = false;
            this.button5.FlatStyle = FlatStyle.Popup;
            this.button5.Location = new Point(0x105, 0x3e);
            this.button5.Name = "button5";
            this.button5.Size = new Size(0x36, 0x17);
            this.button5.TabIndex = 0x2e;
            this.button5.Text = "RESET";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new EventHandler(this.button5_Click);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0xca, 0x3e);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x35, 13);
            this.label2.TabIndex = 0x1d;
            this.label2.Text = "Password";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x339, 0x1de);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FrmUtilizadores";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Utilizadores";
            base.Load += new EventHandler(this.FrmUtilizadores_Load);
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridView1).EndInit();
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

