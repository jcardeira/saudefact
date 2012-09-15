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
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class FrmNc : Form
    {
        private int _paciente_id = 0;
        private cUtentes _Utentes;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button7;
        private ComboBox comboBox1;
        private IContainer components = null;
        private SqlConnection con = new SqlConnection(Security.GetCnn());
        private DataGridView dataGridView2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private SqlCommand mCmd = new SqlCommand();
        private Data mstr = null;
        private DataTable sDt = new DataTable();
        private TextBox textBox1;
        private TextBox textBox4;
        private decimal total = 0M;
        public UtenteEventHandler UtenteSelecionado;

        public FrmNc(Form parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox4.Text != "")
            {
                this.CarregaGrid2(this.mCmd);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox4.Clear();
            this.dateTimePicker2.Value = DateTime.Today;
            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddDays(-30.0);
            this.CarregaGrid2(this.mCmd);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int num;
            this.total = 0M;
            this.numeroDocumentosSelecionados(out num, out this.total);
            if (num <= 0)
            {
                new FrmMsg(1, "AVISO", "Tem de selecionar pelo menos 1 documento \ne o total tem de ser positivo.").ShowDialog();
            }
            else
            {
                this.con = new SqlConnection(Security.GetCnn());
            }
            SqlTransaction transaction = null;
            try
            {
                int num4;
                string str = "";
                string str2 = "0";
                this.con.Open();
                SqlCommand cmd = this.con.CreateCommand();
                this.mstr = new Data();
                int num2 = 0;
                str2 = this.mstr.executeScalar(ref this.con, ref cmd, "select max(numero) from Cert_NC where exercicio=year(getdate())").ToString();
                if (str2 == "")
                {
                    str2 = this.mstr.executeScalar(ref this.con, ref cmd, "select max(numero) from Cert_NC where exercicio=year(getdate())-1").ToString();
                }
                else
                {
                    num2 = int.Parse(str2.ToString());
                }
                num2++;
                int num3 = 0;
                string str3 = this.mstr.executeScalar(ref this.con, ref cmd, "select max(nc_id) from Cert_Nc where exercicio=year(getdate())").ToString();
                if (str3 == "")
                {
                    str3 = this.mstr.executeScalar(ref this.con, ref cmd, "select max(nc_id) from Cert_NC where exercicio=year(getdate())-1").ToString();
                }
                else
                {
                    num3 = int.Parse(str3.ToString());
                }
                num3++;
                transaction = this.con.BeginTransaction();
                cmd.Transaction = transaction;
                this.button4.Enabled = false;
                cmd.CommandType = CommandType.Text;
                string str4 = "insert into [Cert_Nc](paciente_id,numero,exercicio,data) ";
                object obj2 = str4;
                str4 = string.Concat(new object[] { obj2, "values (", this._paciente_id, ",", num2, ",year(getdate()),convert(smalldatetime,getdate(),105))" });
                cmd.CommandText = str4;
                cmd.ExecuteNonQuery();
                for (num4 = 0; num4 < this.sDt.Rows.Count; num4++)
                {
                    string str5 = this.sDt.Rows[num4]["Recebido"].ToString().Replace(",", ".");
                    str4 = "INSERT INTO [Cert_Nc_Det]([nc_id],[factura_id],[actuacion_id],[valor])";
                    obj2 = str4;
                    str4 = string.Concat(new object[] { obj2, " VALUES (", num3, ",", this.sDt.Rows[num4]["factura_id"], ",", this.sDt.Rows[num4]["actuacion_id"] }) + "," + str5 + ")";
                    cmd.CommandText = str4;
                    cmd.ExecuteNonQuery();
                    decimal num5 = -1M * decimal.Parse(this.sDt.Rows[num4]["Recebido"].ToString());
                    string str6 = num5.ToString().Replace(",", ".");
                    str4 = "INSERT INTO actuacion ";
                    str4 = (((str4 + " SELECT [paciente_id],[tratamiento_id],[factura_id],[presupuesto_id],[numero]" + ",getdate(),-1 * [importe],[rechazado],'T',[puntoservicio_id],[padre_id],[generador_id],[notas],[descuento]") + ",-1 * [debe]," + str6 + ",[m],[o],[d],[l],[gp],[gl],[p],[gv],[v],[prioridad],[aceptado]") + ",[f_plan],[f_cita_previa],[f_aceptado],'S',[auxiliar_id],[debe_sociedad]") + " ,[revisado],[factura_doc_id] FROM [actuacion] where actuacion_id=" + this.sDt.Rows[num4]["actuacion_id"];
                    cmd.CommandText = str4;
                    cmd.ExecuteNonQuery();
                    str4 = "INSERT INTO actuacion ";
                    str4 = ((str4 + " select [paciente_id],[tratamiento_id],[factura_id],[presupuesto_id],[numero]" + ",fecha,[importe],[rechazado],'P',[puntoservicio_id],[padre_id],[generador_id],[notas],[descuento]") + ",[debe],[haber],[m],[o],[d],[l],[gp],[gl],[p],[gv],[v],[prioridad],[aceptado]" + ",[f_plan],[f_cita_previa],[f_aceptado],'N',[auxiliar_id],[debe_sociedad]") + " ,[revisado],[factura_doc_id] FROM [actuacion] where actuacion_id=" + this.sDt.Rows[num4]["generador_id"];
                    cmd.CommandText = str4;
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                str = "Vai ser impressa a nota de cr\x00e9dito. Seleccione 'OK' e aguarde por favor.";
                new FrmMsg(1, "AVISO", "Nota de Cr\x00e9dito criada.\n" + str).ShowDialog();
                this.button4.Enabled = false;
                string strSQL = "select * from vNc WHERE (Nc_id = convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10)," + num2 + "))";
                DataTable rsRPT = new Data().executeResultSet(ref this.con, ref cmd, strSQL);
                int num6 = 0;
                string str8 = "";
                string str9 = this.dataGridView2.SelectedCells[0].Value.ToString();
                if (str9.StartsWith("0"))
                {
                    str8 = str9.Remove(0, 4);
                }
                else
                {
                    str8 = str9;
                }
                strSQL = "select distinct f.numero, sum(act.debe) from cert_nc nc,cert_nc_det ncd,actuacion act,factura f where f.factura_id=act.factura_id and ";
                strSQL = (strSQL + " act.factura_id=ncd.factura_id and nc.nc_id=ncd.nc_id and nc.numero=" + int.Parse(num2.ToString())) + " and act.actuacion_id=ncd.actuacion_id group by f.numero";
                DataTable table2 = new Data().executeResultSet(ref this.con, ref cmd, strSQL);
                string str10 = "";
                string str11 = "";
                if (table2.Rows.Count > 0)
                {
                    for (num4 = 0; num4 < table2.Rows.Count; num4++)
                    {
                        num6++;
                        str10 = str10 + "'" + table2.Rows[num4].ItemArray[0].ToString() + "',";
                        str11 = str11 + table2.Rows[num4].ItemArray[1].ToString().Replace(",", ".") + ",";
                    }
                }
                if (str10 != "")
                {
                    int startIndex = str10.LastIndexOf(",");
                    str10 = str10.Remove(startIndex);
                    str11 = str11.Replace("0,", ",");
                    startIndex = str11.LastIndexOf(",");
                    str11 = str11.Remove(startIndex);
                    foreach (DataRow row in rsRPT.Rows)
                    {
                        row.BeginEdit();
                        row[0x13] = str10;
                        row[30] = str11;
                        row.EndEdit();
                    }
                }
                new cVerRelatorios().MostraRelatorio(rsRPT, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt", "newReportADO_NcBase_Cliente.rpt", "Notas de Cr\x00e9dito");
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
                this.CarregaGrid2(this.mCmd);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmPesquisa pesquisa = new FrmPesquisa(this);
            pesquisa.UtenteSelecionado = (UtenteEventHandler) Delegate.Combine(pesquisa.UtenteSelecionado, new UtenteEventHandler(this.Utentes_utenteSelecionado));
            pesquisa.ShowDialog();
            this.button4.Enabled = true;
        }

        private void CarregaGrid2(SqlCommand cmd)
        {
            try
            {
                DataTable table = new DataTable();
                this.con.Open();
                cmd = this.con.CreateCommand();
                table = Data.GetFacturasDet(ref cmd, this._paciente_id, this.con);
                this.dataGridView2.DataSource = table;
                this.GridFormat2();
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if ((e.ColumnIndex == 0) && (rowIndex > -1))
            {
                bool flag = bool.Parse(this.dataGridView2.Rows[rowIndex].Cells[0].Value.ToString());
                this.dataGridView2.EndEdit();
                this.dataGridView2.Rows[rowIndex].Cells[0].Value = !flag;
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

        private void FrmNc_Load(object sender, EventArgs e)
        {
            this.dataGridView2.CellClick += new DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dateTimePicker2.Value = DateTime.Today;
            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddDays(-30.0);
            this.CarregaGrid2(this.mCmd);
        }

        private void GridFormat2()
        {
            this.dataGridView2.Columns[0].ReadOnly = false;
            this.dataGridView2.Columns[1].ReadOnly = true;
            this.dataGridView2.Columns[2].ReadOnly = true;
            this.dataGridView2.Columns[3].ReadOnly = true;
            this.dataGridView2.Columns[4].ReadOnly = true;
            this.dataGridView2.Columns[5].ReadOnly = true;
            this.dataGridView2.Columns[6].ReadOnly = true;
            this.dataGridView2.Columns[7].ReadOnly = true;
            this.dataGridView2.Columns[8].ReadOnly = true;
            this.dataGridView2.Columns[9].ReadOnly = true;
            this.dataGridView2.Columns[10].ReadOnly = true;
            this.dataGridView2.Columns[11].ReadOnly = true;
            this.dataGridView2.Columns[12].ReadOnly = true;
            this.dataGridView2.Columns[13].ReadOnly = true;
            this.dataGridView2.Columns[14].ReadOnly = true;
            this.dataGridView2.Columns[15].ReadOnly = true;
            this.dataGridView2.Columns[0].Width = 80;
            this.dataGridView2.Columns[0].Visible = true;
            this.dataGridView2.Columns[1].Width = 90;
            this.dataGridView2.Columns[2].Width = 350;
            this.dataGridView2.Columns[3].Width = 350;
            this.dataGridView2.Columns[4].Width = 350;
            this.dataGridView2.Columns[4].Visible = true;
            this.dataGridView2.Columns[5].Width = 350;
            this.dataGridView2.Columns[5].Visible = true;
            this.dataGridView2.Columns[6].Width = 100;
            this.dataGridView2.Columns[6].Visible = true;
            this.dataGridView2.Columns[7].Width = 100;
            this.dataGridView2.Columns[7].Visible = true;
            this.dataGridView2.Columns[8].Width = 100;
            this.dataGridView2.Columns[8].Visible = true;
            this.dataGridView2.Columns[9].Width = 50;
            this.dataGridView2.Columns[9].Visible = false;
            this.dataGridView2.Columns[10].Width = 350;
            this.dataGridView2.Columns[10].Visible = true;
            this.dataGridView2.Columns[11].Width = 50;
            this.dataGridView2.Columns[11].Visible = false;
            this.dataGridView2.Columns[12].Width = 50;
            this.dataGridView2.Columns[12].Visible = false;
            this.dataGridView2.Columns[13].Width = 50;
            this.dataGridView2.Columns[13].Visible = false;
            this.dataGridView2.Columns[14].Width = 50;
            this.dataGridView2.Columns[14].Visible = false;
            this.dataGridView2.Columns[15].Width = 50;
            this.dataGridView2.Columns[15].Visible = false;
            this.dataGridView2.Columns[0].HeaderText = "Seleccionar";
            this.dataGridView2.Columns[1].HeaderText = "Factura";
            this.dataGridView2.Columns[2].HeaderText = "Data";
            this.dataGridView2.Columns[3].HeaderText = "Pe\x00e7a";
            this.dataGridView2.Columns[4].HeaderText = "Tratamento";
            this.dataGridView2.Columns[5].HeaderText = "Valor";
            this.dataGridView2.Columns[6].HeaderText = "Dto%";
            this.dataGridView2.Columns[7].HeaderText = "Recebido";
            this.dataGridView2.Columns[8].HeaderText = "Rejeitado";
            this.dataGridView2.Columns[9].HeaderText = "id";
            this.dataGridView2.Columns[10].HeaderText = "Medico";
            this.dataGridView2.Columns[11].HeaderText = "Colegiado";
            this.dataGridView2.Columns[12].HeaderText = "puntoservicio_id";
            this.dataGridView2.Columns[13].HeaderText = "factura_id";
            this.dataGridView2.Columns[14].HeaderText = "generador_id";
            this.dataGridView2.Columns[15].HeaderText = "paciente_id";
            this.dataGridView2.AutoResizeColumns();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmNc));
            this.textBox4 = new TextBox();
            this.label4 = new Label();
            this.dateTimePicker1 = new DateTimePicker();
            this.dateTimePicker2 = new DateTimePicker();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.comboBox1 = new ComboBox();
            this.button1 = new Button();
            this.textBox1 = new TextBox();
            this.label5 = new Label();
            this.groupBox1 = new GroupBox();
            this.button7 = new Button();
            this.button2 = new Button();
            this.groupBox3 = new GroupBox();
            this.button4 = new Button();
            this.button3 = new Button();
            this.dataGridView2 = new DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize) this.dataGridView2).BeginInit();
            base.SuspendLayout();
            this.textBox4.BackColor = Color.White;
            this.textBox4.ForeColor = Color.SteelBlue;
            this.textBox4.Location = new Point(0xf5, 0x13);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(0x9c, 20);
            this.textBox4.TabIndex = 10;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0xce, 0x16);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x21, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "NHC:";
            this.dateTimePicker1.CalendarForeColor = Color.SteelBlue;
            this.dateTimePicker1.CalendarTitleBackColor = Color.SteelBlue;
            this.dateTimePicker1.CalendarTitleForeColor = Color.White;
            this.dateTimePicker1.Format = DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new Point(0x11d, 60);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(0x60, 20);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.Value = new DateTime(0x7da, 12, 0x1c, 0x10, 0x2e, 0, 0);
            this.dateTimePicker2.CalendarForeColor = Color.SteelBlue;
            this.dateTimePicker2.CalendarTitleBackColor = Color.SteelBlue;
            this.dateTimePicker2.CalendarTitleForeColor = Color.White;
            this.dateTimePicker2.Format = DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new Point(0x1f2, 60);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size(0x5b, 20);
            this.dateTimePicker2.TabIndex = 12;
            this.dateTimePicker2.Value = new DateTime(0x7da, 12, 0x1d, 0, 0, 0, 0);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0xf2, 60);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x25, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "In\x00edcio:";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x1d2, 60);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1a, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fim:";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x265, 0x3f);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x2b, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Estado:";
            this.label3.Visible = false;
            this.comboBox1.BackColor = Color.SteelBlue;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(0x296, 0x3f);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0xb7, 0x15);
            this.comboBox1.TabIndex = 0x10;
            this.comboBox1.Visible = false;
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.Location = new Point(0x367, 0x3f);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x56, 0x17);
            this.button1.TabIndex = 0x11;
            this.button1.Text = "PESQUISAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox1.BackColor = Color.White;
            this.textBox1.ForeColor = Color.SteelBlue;
            this.textBox1.Location = new Point(0x1f2, 0x13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x15b, 20);
            this.textBox1.TabIndex = 0x13;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x1c6, 0x16);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x26, 13);
            this.label5.TabIndex = 0x12;
            this.label5.Text = "Nome:";
            this.groupBox1.BackColor = Color.White;
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button2);
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
            this.groupBox1.ForeColor = Color.SteelBlue;
            this.groupBox1.Location = new Point(3, 0x18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x3eb, 0x5b);
            this.groupBox1.TabIndex = 0x15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            this.button7.FlatStyle = FlatStyle.Popup;
            this.button7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.button7.Location = new Point(0x1a3, 0x13);
            this.button7.Name = "button7";
            this.button7.Size = new Size(0x1d, 20);
            this.button7.TabIndex = 0x31;
            this.button7.Text = "...";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new EventHandler(this.button7_Click);
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.Location = new Point(0x367, 0x22);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x56, 0x17);
            this.button2.TabIndex = 20;
            this.button2.Text = "LIMPAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.groupBox3.BackColor = Color.White;
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.ForeColor = Color.SteelBlue;
            this.groupBox3.Location = new Point(2, 0x79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x3ec, 0x22e);
            this.groupBox3.TabIndex = 0x19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tratamentos";
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.Location = new Point(0x331, 0x207);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x56, 0x17);
            this.button4.TabIndex = 0x16;
            this.button4.Text = "GRAVAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.Location = new Point(0x38d, 0x207);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x56, 0x17);
            this.button3.TabIndex = 0x15;
            this.button3.Text = "CANCELAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.GridColor = Color.DarkGray;
            this.dataGridView2.Location = new Point(6, 0x13);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new Size(0x3e0, 0x1db);
            this.dataGridView2.TabIndex = 20;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x3fe, 0x2b3);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox1);
            this.ForeColor = Color.White;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FrmNc";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nova Nota de Cr\x00e9dito";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.FrmNc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridView2).EndInit();
            base.ResumeLayout(false);
        }

        private void numeroDocumentosSelecionados(out int numeroSelecionados, out decimal total)
        {
            numeroSelecionados = 0;
            total = 0M;
            DataTable dataSource = (DataTable) this.dataGridView2.DataSource;
            this.sDt = dataSource.Clone();
            for (int i = 0; i < dataSource.Rows.Count; i++)
            {
                if ((bool) this.dataGridView2.Rows[i].Cells[0].Value)
                {
                    numeroSelecionados++;
                    total += (decimal) dataSource.Rows[i]["Recebido"];
                    this.sDt.ImportRow(dataSource.Rows[i]);
                }
            }
        }

        private void Utentes_utenteSelecionado(object sender, UtentesEventArgs e)
        {
            this._paciente_id = e.paciente_id;
            this.textBox4.Text = e.nhc.ToString();
            this.textBox1.Text = e.Nome.ToString();
            this.CarregaGrid2(this.mCmd);
        }
    }
}

