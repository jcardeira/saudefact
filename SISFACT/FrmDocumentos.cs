namespace SISFACT
{
    using SISFACT.rpt;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    public class FrmDocumentos : Form
    {
        private string _Documento = "";
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private IContainer components = null;
        private SqlConnection con = null;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Button btnSair;
        private Button button3;
        private Label label7;
        private Panel panel1;
        private Button button4;
        private TextBox textBox4;

        public FrmDocumentos(Form parent, string Documento)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
            this._Documento = Documento;
        }

        private void btnNova_Click(object sender, EventArgs e)
        {
            this._Documento = this.GetEnum(this.comboBox1.Text.ToString());
            new FrmFacturacao(this, this._Documento).ShowDialog();
        }

        private void btnPrn_Click(object sender, EventArgs e)
        {
            string str3 = this.dataGridView1.SelectedCells[1].Value.ToString();
            if (str3 != null)
            {
                if (!(str3 == "Recibo"))
                {
                    if (str3 == "Devolu\x00e7\x00e3o")
                    {
                        this._Documento = "D";
                    }
                    else if (str3 == "Factura")
                    {
                        this._Documento = "F";
                    }
                    else if (str3 == "NC")
                    {
                        this._Documento = "C";
                    }
                }
                else
                {
                    this._Documento = "R";
                }
            }
            this.con = new SqlConnection(Security.GetCnn());
            if ((this.con != null) && (this.con.State == ConnectionState.Open))
            {
                this.con.Close();
            }
            this.con.Open();
            SqlCommand cmd = this.con.CreateCommand();
            str3 = this._Documento;
            if (str3 != null)
            {
                int num;
                string str;
                DataTable table;
                if (!(str3 == "R"))
                {
                    cVerRelatorios relatorios;
                    string directoryName;
                    if (str3 == "D")
                    {
                        num = int.Parse(new Data().executeScalar(ref this.con, ref cmd, "select recibo_id from recibo where numero='" + this.dataGridView1.SelectedCells[0].Value.ToString() + "'").ToString());
                        str = "select * from vPagos WHERE (Recibo_id = " + num + " and tipo='N')";
                        table = new Data().executeResultSet(ref this.con, ref cmd, str);
                        relatorios = new cVerRelatorios();
                        directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                        relatorios.MostraRelatorio(table, directoryName + @"\rpt", "ReportADO_ReciboClientes.rpt", "Devolu\x00e7\x00f5es");
                    }
                    else if (str3 == "F")
                    {
                        num = int.Parse(new Data().executeScalar(ref this.con, ref cmd, "select factura_id from factura where numero='" + this.dataGridView1.SelectedCells[0].Value.ToString() + "'").ToString());
                        str = "select * from vFactura WHERE (Factura_id = " + num + ") and haber>=0";
                        table = new Data().executeResultSet(ref this.con, ref cmd, str);
                        relatorios = new cVerRelatorios();
                        directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                        relatorios.MostraRelatorio(table, directoryName + @"\rpt", "newReportADO_FacturaBase_Cliente.rpt", "Facturas");
                    }
                    else if (str3 == "C")
                    {
                        num = int.Parse(new Data().executeScalar(ref this.con, ref cmd, "select nc_id from cert_nc where numero='" + this.dataGridView1.SelectedCells[0].Value.ToString() + "'").ToString());
                        str = "select * from vNc WHERE (Nc_id = " + num + ")";
                        table = new Data().executeResultSet(ref this.con, ref cmd, str);
                        relatorios = new cVerRelatorios();
                        directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                        relatorios.MostraRelatorio(table, directoryName + @"\rpt", "newReportADO_NcBase_Cliente.rpt", "Notas de Cr\x00e9dito");
                    }
                }
                else
                {
                    num = int.Parse(new Data().executeScalar(ref this.con, ref cmd, "select recibo_id from recibo where numero='" + this.dataGridView1.SelectedCells[0].Value.ToString() + "'").ToString());
                    str = string.Concat(new object[] { "select * from vPagos WHERE ( = ", num, " and tipo='", this._Documento, "')" });
                    table = new Data().executeResultSet(ref this.con, ref cmd, str);
                    new cVerRelatorios().MostraRelatorio(table, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt", "ReportADO_ReciboClientes.rpt", "Recibos");
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._Documento = this.GetEnum(this.comboBox1.Text.ToString());
            this.con = new SqlConnection(Security.GetCnn());
            try
            {
                DataTable table = new DataTable();
                this.con.Open();
                SqlCommand cmd = this.con.CreateCommand();
                this.dataGridView1.DataSource = Data.GetDocumentos(cmd, this.textBox4.Text, this.textBox1.Text, this.textBox2.Text, this.dateTimePicker1.Value, this.dateTimePicker2.Value, this.GetEnum(this.comboBox1.Text.ToString()));
                this.GridFormat();
                if (((DataTable) this.dataGridView1.DataSource).Rows.Count > 0)
                {
                    this.dataGridView1.Rows[0].Selected = true;
                }
                else
                {
                    this.dataGridView1.DataSource = table;
                }
            }
            catch (Exception)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox4.Clear();
            this.dateTimePicker2.Value = DateTime.Today;
            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddDays(-30.0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this._Documento = this.GetEnum(this.comboBox1.Text.ToString());
            this.con = new SqlConnection(Security.GetCnn());
            try
            {
                DataTable table = new DataTable();
                this.con.Open();
                SqlCommand cmd = this.con.CreateCommand();
                this.dataGridView1.DataSource = Data.GetDocumentos(cmd, this.textBox4.Text, this.textBox1.Text, this.textBox2.Text, this.dateTimePicker1.Value, this.dateTimePicker2.Value, this.GetEnum(this.comboBox1.Text.ToString()));
                this.GridFormat();
                if (((DataTable)this.dataGridView1.DataSource).Rows.Count > 0)
                {
                    this.dataGridView1.Rows[0].Selected = true;
                }
                else
                {
                    this.dataGridView1.DataSource = table;
                }
            }
            catch (Exception)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (new FrmMsg(2, "AVISO", "Deseja imprimir uma 2\x00aavia do documento?\nCaso deseje continuar pressione 'OK' e aguarde.").ShowDialog() == DialogResult.OK)
            {
                this.via2();
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

        private void fillComboBox1()
        {
            DataTable table = new DataTable("TipoDoc");
            table.Columns.Add("tipoDoc", System.Type.GetType("System.String"));
            table.Columns.Add("Descricao", System.Type.GetType("System.String"));
            DataRow row = table.NewRow();
            row["tipoDoc"] = "T";
            row["Descricao"] = "Todos";
            table.Rows.Add(row);
            row = table.NewRow();
            row["tipoDoc"] = "F";
            row["Descricao"] = "Facturas";
            table.Rows.Add(row);
            row = table.NewRow();
            row["tipoDoc"] = "D";
            row["Descricao"] = "Devolu\x00e7\x00f5es";
            table.Rows.Add(row);
            row = table.NewRow();
            row["tipoDoc"] = "R";
            row["Descricao"] = "Recibos";
            table.Rows.Add(row);
            row = table.NewRow();
            row["tipoDoc"] = "C";
            row["Descricao"] = "Notas de Credito";
            table.Rows.Add(row);
            this.comboBox1.DataSource = table;
            this.comboBox1.ValueMember = "tipoDoc";
            this.comboBox1.DisplayMember = "Descricao";
        }

        private void FrmDocumentos_Load(object sender, EventArgs e)
        {
            this.textBox2.KeyPress += new KeyPressEventHandler(this.textBox2_KeyPress);
            this.dateTimePicker2.Value = DateTime.Today;
            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddDays(-30.0);
            this.fillComboBox1();
            this.comboBox1.SelectedValue = this._Documento;
            if (this._Documento == "F")
            {
                this.Text = "Listagem Facturas";
                this.button3.Visible = true;
            }
            if (this._Documento == "R")
            {
                this.Text = "Listagem Recibos";
            }
            if (this._Documento == "D")
            {
                this.Text = "Listagem Devolu\x00e7\x00f5es";
            }
            if (this._Documento == "C")
            {
                this.Text = "Listagem Notas de Cr\x00e9dito";
                this.button3.Visible = true;
            }
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
        }

        private string GetEnum(string cmbText)
        {
            switch (cmbText)
            {
                case "Facturas":
                    return "F";

                case "Devolu\x00e7\x00f5es":
                    return "D";

                case "Recibos":
                    return "R";

                case "Notas de Credito":
                    return "C";
            }
            return "T";
        }

        private void GridFormat()
        {
            this.dataGridView1.AutoResizeColumns();
        }

        private void InitializeComponent()
        {
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSair = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBox4.Location = new System.Drawing.Point(65, 47);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(156, 20);
            this.textBox4.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "NHC:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.SteelBlue;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(54, 84);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarForeColor = System.Drawing.Color.SteelBlue;
            this.dateTimePicker2.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.dateTimePicker2.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(267, 84);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(91, 20);
            this.dateTimePicker2.TabIndex = 12;
            this.dateTimePicker2.Value = new System.DateTime(2010, 12, 29, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Início:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fim:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Documento:";
            this.label3.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(431, 83);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(594, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "PESQUISAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBox1.Location = new System.Drawing.Point(267, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(305, 20);
            this.textBox1.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "NOME:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 118);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(594, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "LIMPAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBox2.Location = new System.Drawing.Point(65, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(133, 20);
            this.textBox2.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Nr.DOC.:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Location = new System.Drawing.Point(0, 118);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(694, 447);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnSair
            // 
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Location = new System.Drawing.Point(569, 16);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(86, 23);
            this.btnSair.TabIndex = 27;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(14, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "IMPRIMIR LISTAGEM";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(335, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Para 2ªas Vias, fazer duplo clique no documento e aguarde por favor.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 565);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 100);
            this.panel1.TabIndex = 25;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(12, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "SAFT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmDocumentos
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(694, 665);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrmDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestão -  Facturação";
            this.Load += new System.EventHandler(this.FrmDocumentos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private string SetEnum(string cmbText)
        {
            switch (cmbText)
            {
                case "F":
                    return "Facturas";

                case "D":
                    return "Devolu\x00e7\x00f5es";

                case "R":
                    return "Recibos";

                case "C":
                    return "NC";
            }
            return "T";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void via2()
        {
            string str8 = this.dataGridView1.SelectedCells[1].Value.ToString();
            if (str8 != null)
            {
                if (!(str8 == "Recibo"))
                {
                    if (str8 == "Devolu\x00e7\x00e3o")
                    {
                        this._Documento = "D";
                    }
                    else if (str8 == "Factura")
                    {
                        this._Documento = "F";
                    }
                    else if (str8 == "NC")
                    {
                        this._Documento = "C";
                    }
                }
                else
                {
                    this._Documento = "R";
                }
            }
            this.con = new SqlConnection(Security.GetCnn());
            if ((this.con != null) && (this.con.State == ConnectionState.Open))
            {
                this.con.Close();
            }
            this.con.Open();
            SqlCommand cmd = this.con.CreateCommand();
            str8 = this._Documento;
            if (str8 != null)
            {
                string str;
                DataTable table;
                if (!(str8 == "R"))
                {
                    cVerRelatorios relatorios;
                    string directoryName;
                    if (str8 == "D")
                    {
                        str = "select * from vPagos WHERE (Recibo_id = '" + this.dataGridView1.SelectedCells[0].Value.ToString() + "' and tipo='N') and convert(smalldatetime,fecha,105)= convert(smalldatetime,'" + this.dataGridView1.SelectedCells[3].Value.ToString() + "',105)";
                        table = new Data().executeResultSet(ref this.con, ref cmd, str);
                        relatorios = new cVerRelatorios();
                        directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                        relatorios.MostraRelatorio(table, directoryName + @"\rpt", "ReportADO_ReciboClientes_2via.rpt", "Devolu\x00e7\x00f5es");
                    }
                    else
                    {
                        string str3;
                        string str4;
                        DataTable table2;
                        string str6;
                        int num3;
                        int num4;
                        if (str8 == "C")
                        {
                            str = "select * from vNc WHERE (Nc_id = '" + this.dataGridView1.SelectedCells[0].Value.ToString() + "') and convert(smalldatetime,data,105)= convert(smalldatetime,'" + this.dataGridView1.SelectedCells[3].Value.ToString() + "',105)";
                            table = new Data().executeResultSet(ref this.con, ref cmd, str);
                            int num2 = 0;
                            str3 = "";
                            str4 = this.dataGridView1.SelectedCells[0].Value.ToString();
                            if (str4.StartsWith("0"))
                            {
                                str3 = str4.Remove(0, 4);
                            }
                            else
                            {
                                str3 = str4;
                            }
                            str = "select distinct f.numero, sum(act.debe) from cert_nc nc,cert_nc_det ncd,actuacion act,factura f where f.factura_id=act.factura_id and ";
                            str = (str + " act.factura_id=ncd.factura_id and nc.nc_id=ncd.nc_id and nc.numero=" + int.Parse(str3.ToString())) + " and act.actuacion_id=ncd.actuacion_id group by f.numero";
                            table2 = new Data().executeResultSet(ref this.con, ref cmd, str);
                            string str5 = "";
                            str6 = "";
                            if (table2.Rows.Count > 0)
                            {
                                for (num3 = 0; num3 < table2.Rows.Count; num3++)
                                {
                                    num2++;
                                    str5 = str5 + "'" + table2.Rows[num3].ItemArray[0].ToString() + "',";
                                    str6 = str6 + table2.Rows[num3].ItemArray[1].ToString().Replace(",", ".") + ",";
                                }
                            }
                            if (str5 != "")
                            {
                                num4 = str5.LastIndexOf(",");
                                str5 = str5.Remove(num4);
                                str6 = str6.Replace("0,", ",");
                                num4 = str6.LastIndexOf(",");
                                str6 = str6.Remove(num4);
                                foreach (DataRow row in table.Rows)
                                {
                                    row.BeginEdit();
                                    row[0x13] = str5;
                                    row[30] = str6;
                                    row.EndEdit();
                                }
                            }
                            relatorios = new cVerRelatorios();
                            directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            relatorios.MostraRelatorio(table, directoryName + @"\rpt", "newReportADO_NcBase_Cliente_2via.rpt", "Notas de Cr\x00e9dito");
                        }
                        else if (str8 == "F")
                        {
                            str = "select * from vFactura2 WHERE (Factura_id = '" + this.dataGridView1.SelectedCells[0].Value.ToString() + "') and convert(smalldatetime,fecha,105)= convert(smalldatetime,'" + this.dataGridView1.SelectedCells[3].Value.ToString() + "',105) and haber >=0";
                            table = new Data().executeResultSet(ref this.con, ref cmd, str);
                            if (table.Rows.Count < 1)
                            {
                                str = "select * from vFactura3 WHERE (Factura_id = '" + this.dataGridView1.SelectedCells[0].Value.ToString() + "') and convert(smalldatetime,fecha,105)= convert(smalldatetime,'" + this.dataGridView1.SelectedCells[3].Value.ToString() + "',105) and haber >=0";
                                table = new Data().executeResultSet(ref this.con, ref cmd, str);
                            }
                            int num5 = 0;
                            str3 = "";
                            str4 = this.dataGridView1.SelectedCells[0].Value.ToString();
                            if (str4.StartsWith("0"))
                            {
                                str3 = str4.Remove(0, 4);
                            }
                            else
                            {
                                str3 = str4;
                            }
                            str = "select distinct recibo.numero,pagos.importe  from pago_actuacion, recibo ,pagos ,factura, actuacion ";
                            str = (str + "where recibo.recibo_id=pagos.recibo_id and pagos.pago_id=pago_actuacion.pago_id " + "and actuacion.generador_id=pago_actuacion.actuacion_id and actuacion.factura_id=factura.factura_id and actuacion.haber>=0 ") + "and factura.numero= " + int.Parse(str3.ToString());
                            table2 = new Data().executeResultSet(ref this.con, ref cmd, str);
                            string str7 = "";
                            str6 = "";
                            if (table2.Rows.Count > 0)
                            {
                                for (num3 = 0; num3 < table2.Rows.Count; num3++)
                                {
                                    num5++;
                                    str7 = str7 + "'" + table2.Rows[num3].ItemArray[0].ToString() + "',";
                                    str6 = str6 + table2.Rows[num3].ItemArray[1].ToString().Replace(",", ".") + ",";
                                }
                            }
                            if (str7 != "")
                            {
                                num4 = str7.LastIndexOf(",");
                                str7 = str7.Remove(num4);
                                num4 = str6.LastIndexOf(",");
                                str6 = str6.Remove(num4);
                                foreach (DataRow row in table.Rows)
                                {
                                    row.BeginEdit();
                                    row[0x1c] = str7;
                                    row[0x1d] = str6.Substring(0, str6.Length - 1);
                                    row.EndEdit();
                                }
                            }
                            relatorios = new cVerRelatorios();
                            directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            relatorios.MostraRelatorio(table, directoryName + @"\rpt", "newReportADO_FacturaBase_Cliente_2via.rpt", "Facturas");
                        }
                    }
                }
                else
                {
                    int num = int.Parse(new Data().executeScalar(ref this.con, ref cmd, "select recibo_id from recibo where numero='" + this.dataGridView1.SelectedCells[0].Value.ToString() + "'").ToString());
                    str = "select * from vPagos WHERE (Recibo_id = '" + this.dataGridView1.SelectedCells[0].Value.ToString() + "' and tipo='" + this._Documento + "') and convert(smalldatetime,fecha,105)= convert(smalldatetime,'" + this.dataGridView1.SelectedCells[3].Value.ToString() + "',105)";
                    table = new Data().executeResultSet(ref this.con, ref cmd, str);
                    if (table.Rows.Count < 1)
                    {
                        str = "select * from vPagos WHERE (Recibo_id = '" + this.dataGridView1.SelectedCells[0].Value.ToString() + "' and tipo='" + this._Documento + "') and convert(smalldatetime,fecha,105)= convert(smalldatetime,'" + this.dataGridView1.SelectedCells[3].Value.ToString() + "',105)";
                        table = new Data().executeResultSet(ref this.con, ref cmd, str);
                    }
                    new cVerRelatorios().MostraRelatorio(table, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt", "ReportADO_ReciboClientes_2via.rpt", "Recibos");
                }
            }
        }

        private void via3()
        {
            this._Documento = this.GetEnum(this.comboBox1.Text.ToString());
            string titulo = "";
            if (this._Documento == "F")
            {
                titulo = "Facturas";
            }
            else
            {
                titulo = "Notas de Cr\x00e9dito";
            }
            this.con = new SqlConnection(Security.GetCnn());
            try
            {
                DataTable table = new DataTable();
                DataTable rsRPT = new DataTable();
                this.con.Open();
                rsRPT = Data.GetDocumentos(con.CreateCommand(), this.textBox4.Text, this.textBox1.Text, this.textBox2.Text, this.dateTimePicker1.Value, this.dateTimePicker2.Value, this.GetEnum(this.comboBox1.Text.ToString()));
                if (rsRPT.Rows.Count > 0)
                {
                    new cVerRelatorios().MostraRelatorio2(rsRPT, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt", "listagem.rpt", "Notas de Cr\x00e9dito", this.dateTimePicker1.Value.ToString(), this.dateTimePicker2.Value.ToString(), titulo);
                }
                else
                {
                    this.dataGridView1.DataSource = table;
                }
            }
            catch (Exception)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

