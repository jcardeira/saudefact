namespace SISFACT
{
    using SISFACT.rpt;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    public class FrmFacturacao : Form
    {
        private string _Documento;
        private int _medico;
        private cFormasPag _oFormasPag;
        private cTipoVenda _oTV;
        private int _paciente;
        private Button button1;
        private Button button2;
        private Button button4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private IContainer components;
        private SqlConnection con;
        private DateTimePicker dateTimePicker1;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Data mstr;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private const int tipoventaid = 5;

        public FrmFacturacao(Form parent, string Documento)
        {
            this.components = null;
            this._Documento = "";
            this._paciente = 0;
            this._medico = 0;
            this.con = null;
            this.mstr = null;
            this.InitializeComponent();
            this._Documento = Documento;
        }

        public FrmFacturacao(Form parent, string Documento, int pacienteid, string nhc, string nome, decimal valor, string MedNome, int puntoservicioid)
        {
            this.components = null;
            this._Documento = "";
            this._paciente = 0;
            this._medico = 0;
            this.con = null;
            this.mstr = null;
            this.InitializeComponent();
            this._Documento = Documento;
            this._paciente = pacienteid;
            this._medico = puntoservicioid;
            this.button1.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox1.Enabled = false;
            this.textBox1.Text = valor.ToString();
            this.textBox2.Text = nome;
            this.textBox4.Text = nhc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPesquisa pesquisa = new FrmPesquisa(this);
            pesquisa.UtenteSelecionado = (UtenteEventHandler) Delegate.Combine(pesquisa.UtenteSelecionado, new UtenteEventHandler(this.Utentes_utenteSelecionado));
            pesquisa.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((this.textBox1.Text == "") || (this.textBox2.Text == ""))
            {
                new FrmMsg(1, "AVISO", "Obrigat\x00f3rio preenchimento dos campos!").ShowDialog();
            }
            else
            {
                int num = 0;
                this.con = new SqlConnection(Security.GetCnn());
                SqlTransaction transaction = null;
                try
                {
                    string str3;
                    DataTable table;
                    string s = "0";
                    string str2 = "0";
                    this.con.Open();
                    SqlCommand cmd = this.con.CreateCommand();
                    this.mstr = new Data();
                    string str5 = this._Documento;
                    if (str5 != null)
                    {
                        if (!(str5 == "D"))
                        {
                            if (str5 == "R")
                            {
                                goto Label_01F8;
                            }
                            if (str5 == "F")
                            {
                                goto Label_02FC;
                            }
                        }
                        else if (this.validaCampos())
                        {
                            str2 = this.mstr.executeScalar(ref this.con, ref cmd, "select max(numero) from recibo where Tipo='N' ").ToString();
                            if (str2 == "")
                            {
                                str2 = "0";
                            }
                            s = this.mstr.executeScalar(ref this.con, ref cmd, "select max(recibo_id) from recibo").ToString();
                            num = int.Parse(str2.ToString());
                            transaction = this.con.BeginTransaction();
                            cmd.Transaction = transaction;
                            Data.SetRecibo(ref cmd, this._paciente, this.dateTimePicker1.Value, -1M * decimal.Parse(this.textBox1.Text.ToString()), int.Parse(this.comboBox1.SelectedValue.ToString()), 5, "", int.Parse(s), "T", 0, this.dateTimePicker1.Value, 0, 0, "", DateTime.Now, int.Parse(str2.ToString()), "N", 0);
                        }
                    }
                    goto Label_030F;
                Label_01F8:
                    if (this.validaCampos())
                    {
                        str2 = this.mstr.executeScalar(ref this.con, ref cmd, "select max(numero) from recibo where Tipo='R' ").ToString();
                        s = this.mstr.executeScalar(ref this.con, ref cmd, "select max(recibo_id) from recibo").ToString();
                        num = int.Parse(str2.ToString());
                        transaction = this.con.BeginTransaction();
                        cmd.Transaction = transaction;
                        Data.SetRecibo(ref cmd, this._paciente, this.dateTimePicker1.Value, decimal.Parse(this.textBox1.Text.ToString()), int.Parse(this.comboBox1.SelectedValue.ToString()), int.Parse(this.comboBox2.SelectedValue.ToString()), "", int.Parse(s), "T", 0, this.dateTimePicker1.Value, 0, 0, "", DateTime.Now, int.Parse(str2.ToString()), "R", 0);
                    }
                    goto Label_030F;
                Label_02FC:
                    if (this.validaCampos())
                    {
                    }
                Label_030F:
                    this.button2.Enabled = false;
                    transaction.Commit();
                    new FrmMsg(1, "AVISO", "Documento criado.\n Seleccione 'OK' e aguarde por favor.").ShowDialog();
                    this.button2.Enabled = false;
                    str5 = this._Documento;
                    if (str5 != null)
                    {
                        if (!(str5 == "R"))
                        {
                            if (str5 == "D")
                            {
                                goto Label_0414;
                            }
                        }
                        else
                        {
                            num++;
                            str3 = string.Concat(new object[] { "select * from vPagos WHERE (Recibo_id = convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10),", num, ") and tipo='", this._Documento, "')" });
                            table = new Data().executeResultSet(ref this.con, ref cmd, str3);
                            new cVerRelatorios().MostraRelatorio(table, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt", "ReportADO_ReciboClientes.rpt", "Recibos");
                        }
                    }
                    return;
                Label_0414:
                    num++;
                    str3 = "select * from vPagos WHERE (Recibo_id = convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10)," + num + ") and tipo='N')";
                    table = new Data().executeResultSet(ref this.con, ref cmd, str3);
                    new cVerRelatorios().MostraRelatorio(table, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt", "ReportADO_ReciboClientes.rpt", "Devolu\x00e7\x00f5es");
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
                    base.Dispose();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void CarregaFormasPagamento()
        {
            this._oFormasPag = new cFormasPag();
            this.comboBox1.DataSource = this._oFormasPag.FormasPagamento;
            this.comboBox1.DisplayMember = "Descripcion";
            this.comboBox1.ValueMember = "forma_pago_id";
        }

        private void CarregaTipoVendas()
        {
            this._oTV = new cTipoVenda(this._Documento);
            this.comboBox2.DataSource = this._oTV.TiposVenda;
            this.comboBox2.DisplayMember = "Descripcion";
            this.comboBox2.ValueMember = "tipo_venta_id";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmFacturacao_Load(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
            this.dateTimePicker1.MinDate = DateTime.Now.Date;
            this.dateTimePicker1.MaxDate = DateTime.Now.Date;
            this.textBox4.KeyPress += new KeyPressEventHandler(this.textBox4_KeyPress);
            this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            if (this._Documento == "F")
            {
                this.Text = "Gest\x00e3o Facturas";
            }
            if (this._Documento == "R")
            {
                this.Text = "Novo recibo";
            }
            if (this._Documento == "D")
            {
                this.Text = "Nova Devolu\x00e7\x00e3o";
            }
            this.CarregaFormasPagamento();
            this.CarregaTipoVendas();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmFacturacao));
            this.groupBox1 = new GroupBox();
            this.comboBox2 = new ComboBox();
            this.label6 = new Label();
            this.dateTimePicker1 = new DateTimePicker();
            this.label5 = new Label();
            this.textBox2 = new TextBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.textBox1 = new TextBox();
            this.comboBox1 = new ComboBox();
            this.button1 = new Button();
            this.button4 = new Button();
            this.button2 = new Button();
            this.label4 = new Label();
            this.textBox4 = new TextBox();
            this.label1 = new Label();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.BackColor = Color.White;
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = Color.SteelBlue;
            this.groupBox1.Location = new Point(2, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(420, 0xac);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new Point(0x41, 130);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(0x9d, 0x15);
            this.comboBox2.TabIndex = 0x39;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(4, 0x85);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x40, 13);
            this.label6.TabIndex = 0x38;
            this.label6.Text = "TP.VENDA:";
            this.dateTimePicker1.CalendarForeColor = Color.SteelBlue;
            this.dateTimePicker1.CalendarTitleBackColor = Color.SteelBlue;
            this.dateTimePicker1.CalendarTitleForeColor = Color.White;
            this.dateTimePicker1.Format = DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new Point(0x134, 0x13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(0x60, 20);
            this.dateTimePicker1.TabIndex = 0x36;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x108, 0x17);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x27, 13);
            this.label5.TabIndex = 0x37;
            this.label5.Text = "DATA:";
            this.textBox2.BackColor = Color.White;
            this.textBox2.Enabled = false;
            this.textBox2.ForeColor = Color.SteelBlue;
            this.textBox2.Location = new Point(0x3d, 0x38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0x157, 20);
            this.textBox2.TabIndex = 0x35;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(13, 0x3b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x2a, 13);
            this.label3.TabIndex = 0x34;
            this.label3.Text = "NOME:";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0xd7, 0x61);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2e, 13);
            this.label2.TabIndex = 0x33;
            this.label2.Text = "VALOR:";
            this.textBox1.BackColor = Color.White;
            this.textBox1.Location = new Point(0x10b, 0x5e);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x89, 20);
            this.textBox1.TabIndex = 50;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(0x41, 0x5d);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0x90, 0x15);
            this.comboBox1.TabIndex = 0x31;
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(0xa7, 0x11);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x1d, 20);
            this.button1.TabIndex = 0x30;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.Location = new Point(0x149, 0x85);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x4b, 0x17);
            this.button4.TabIndex = 0x2f;
            this.button4.Text = "CANCELAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.Location = new Point(0xf8, 0x85);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 0x2e;
            this.button2.Text = "GRAVAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(13, 0x15);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x21, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "NHC:";
            this.textBox4.BackColor = Color.White;
            this.textBox4.Location = new Point(0x2f, 0x12);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(0x72, 20);
            this.textBox4.TabIndex = 0x10;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 0x60);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x35, 13);
            this.label1.TabIndex = 0x13;
            this.label1.Text = "FM.PAG.:";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x1b2, 0xd5);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "FrmFacturacao";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Tratamentos - Documentos";
            base.Load += new EventHandler(this.FrmFacturacao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool flag = true;
            string numberDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string str2 = e.KeyChar.ToString();
            if (char.IsDigit(e.KeyChar))
            {
                flag = false;
            }
            if (str2.Equals(numberDecimalSeparator))
            {
                flag = false;
            }
            if (e.KeyChar == '\b')
            {
                flag = false;
            }
            e.Handled = flag;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            string numberDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (text.IndexOf(numberDecimalSeparator) != text.LastIndexOf(numberDecimalSeparator))
            {
                new FrmMsg(1, "AVISO", "S\x00f3 pode existir uma virgula no valor!").ShowDialog();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void Utentes_utenteSelecionado(object sender, UtentesEventArgs e)
        {
            this._paciente = e.paciente_id;
            this.textBox4.Text = e.nhc.ToString();
            this.textBox2.Text = e.Nome.ToString();
        }

        private bool validaCampos()
        {
            if (((this.textBox4.Text == "") | (this.textBox1.Text == "")) | (this.textBox1.Text == "0"))
            {
                return false;
            }
            return true;
        }
    }
}

