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

    public class FrmFacturas : Form
    {
        private DataTable _dt;
        private int _medico;
        private int _paciente;
        private decimal _total;
        private bool _upMedico;
        private Button button1;
        private Button button2;
        private Button button4;
        private IContainer components;
        private SqlConnection con;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Data mstr;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private const int tipoventaid = 5;

        public FrmFacturas(Form parent)
        {
            this.components = null;
            this._dt = new DataTable();
            this._upMedico = false;
            this._paciente = 0;
            this._medico = 0;
            this._total = 0M;
            this.con = null;
            this.mstr = null;
            this.InitializeComponent();
        }

        public FrmFacturas(Form parent, DataTable mDt, string nMed, string nome, decimal valor, int puntoservicioid, int paciente)
        {
            this.components = null;
            this._dt = new DataTable();
            this._upMedico = false;
            this._paciente = 0;
            this._medico = 0;
            this._total = 0M;
            this.con = null;
            this.mstr = null;
            this.InitializeComponent();
            this._medico = puntoservicioid;
            this._paciente = paciente;
            this._total = valor;
            this._dt = mDt;
            this.button1.Enabled = true;
            this.textBox4.Enabled = false;
            this.textBox1.Enabled = false;
            this.textBox1.Text = valor.ToString();
            this.textBox2.Text = nome;
            this.textBox4.Text = nMed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._upMedico = true;
            FrmPesquisaMedico medico = new FrmPesquisaMedico(this);
            medico.MedicoSelecionado = (MedicoEventHandler) Delegate.Combine(medico.MedicoSelecionado, new MedicoEventHandler(this.Medicos_medicoSelecionado));
            medico.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num3;
            int num = 0;
            int num2 = 0;
            string str = "";
            string str2 = "";
            this.numeroDocumentosSelecionados(out num3);
            if ((num3 != 0) || (new FrmMsg(2, "AVISO", "N\x00e3o selecionou nenhum recibo para a factura que \nvai ser gerada.\nDeseja continuar?").ShowDialog() == DialogResult.OK))
            {
                if (num3 >= 0x186a0)
                {
                    new FrmMsg(1, "AVISO", "N\x00e3o pode selecionar mais de um recibo para a factura que \nvai ser gerada. \n").ShowDialog();
                }
                else
                {
                    Exception exception;
                    DataTable dataSource = (DataTable) this.dataGridView1.DataSource;
                    this.con = new SqlConnection(Security.GetCnn());
                    SqlTransaction transaction = null;
                    try
                    {
                        int num6;
                        string str9;
                        string str3 = "";
                        string str4 = "0";
                        string str5 = "0";
                        this.con.Open();
                        SqlCommand cmd = this.con.CreateCommand();
                        this.mstr = new Data();
                        string str6 = this.mstr.executeScalar(ref this.con, ref cmd, "Select nhc from paciente where paciente_id=" + this._paciente).ToString();
                        string str7 = this.mstr.executeScalar(ref this.con, ref cmd, "Select paciente.nombre +' '+paciente.apellido1+' '+paciente.apellido2 from paciente where paciente_id=" + this._paciente).ToString();
                        int num4 = 0;
                        int num5 = 0;
                        str5 = this.mstr.executeScalar(ref this.con, ref cmd, "select max(numero) from factura where ejercicio=year(getdate())").ToString();
                        if (str5 == "")
                        {
                            str5 = this.mstr.executeScalar(ref this.con, ref cmd, "select max(numero) from factura where ejercicio=year(getdate())-1").ToString();
                        }
                        if (str5 == "")
                        {
                            str5 = "0";
                        }
                        str4 = this.mstr.executeScalar(ref this.con, ref cmd, "select max(factura_id) from factura").ToString();
                        if (str4 == "")
                        {
                            str4 = "0";
                        }
                        num4 = int.Parse(str4.ToString()) + 1;
                        num2 = num4;
                        num5 = int.Parse(str5.ToString()) + 1;
                        num = num5;
                        transaction = this.con.BeginTransaction();
                        cmd.Transaction = transaction;
                        if (this._upMedico)
                        {
                            this.upMedicoTratamento(ref cmd);
                            this._upMedico = !this._upMedico;
                            str3 = "Medico Actualizado.\n";
                        }
                        this.button2.Enabled = false;
                        cmd.CommandType = CommandType.Text;
                        string str8 = "INSERT factura ([paciente_id],[numero],[ejercicio],[fecha],[cobrada],[borrada] ";
                        str8 = string.Concat(new object[] { str8, ",[formapago_id],[tipo_venta_id],[sociedad_id]) VALUES ( ", this._paciente, ",", num5, ",YEAR(getdate()),getdate()" });
                        str8 = string.Concat(new object[] { str8, ",'N','N',2, 4,", 0x11, ")" });
                        cmd.CommandText = str8;
                        cmd.ExecuteNonQuery();
                        str8 = "INSERT INTO [histoestado]([fecha],[paciente_id],[estado]) VALUES (";
                        str8 = string.Concat(new object[] { str8, "getdate(),", this._paciente, ",5)" });
                        cmd.CommandText = str8;
                        cmd.ExecuteNonQuery();
                        for (num6 = 0; num6 < this._dt.Rows.Count; num6++)
                        {
                            str9 = this._dt.Rows[num6]["D\x00e9bito"].ToString().Replace(",", ".");
                            str8 = "INSERT INTO actuacion ";
                            str8 = string.Concat(new object[] { str8, " SELECT [paciente_id],[tratamiento_id],", num4, ",[presupuesto_id],[numero]" });
                            str8 = ((string.Concat(new object[] { str8, ",getdate(),[importe],[rechazado],'T',[puntoservicio_id],[padre_id],", this._dt.Rows[num6]["actuacion_id"], ",[notas],[descuento]" }) + ",[debe]," + str9 + ",[m],[o],[d],[l],[gp],[gl],[p],[gv],[v],[prioridad],[aceptado]") + ",[f_plan],[f_cita_previa],[f_aceptado],'S',[auxiliar_id],[debe_sociedad]") + " ,[revisado],[factura_doc_id] FROM [actuacion] where actuacion_id=" + this._dt.Rows[num6]["actuacion_id"];
                            cmd.CommandText = str8;
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        str3 = "Vai ser impressa a factura. Seleccione 'OK' e aguarde por favor.";
                        new FrmMsg(1, "AVISO", "Factura criada.\n" + str3).ShowDialog();
                        this.button2.Enabled = false;
                        try
                        {
                            int num7 = 0;
                            if (dataSource.Rows.Count > 0)
                            {
                                for (num6 = 0; num6 < dataSource.Rows.Count; num6++)
                                {
                                    transaction = this.con.BeginTransaction();
                                    cmd.Transaction = transaction;
                                    if (dataSource.Rows[num6].ItemArray[0].ToString() == "True")
                                    {
                                        num7++;
                                        str = str + "'" + dataSource.Rows[num6].ItemArray[1].ToString() + "',";
                                        str2 = str2 + dataSource.Rows[num6].ItemArray[6].ToString().Replace(",", ".") + ",";
                                        for (int i = 0; i < this._dt.Rows.Count; i++)
                                        {
                                            str9 = this._dt.Rows[i]["D\x00e9bito"].ToString().Replace(",", ".");
                                            str8 = "insert into pago_actuacion ([fecha],[pago_id],[actuacion_id],[haber],[f_update]) ";
                                            object obj2 = str8;
                                            str8 = string.Concat(new object[] { obj2, "values (getdate(),", dataSource.Rows[num6]["pago_id"].ToString(), ",", this._dt.Rows[i]["actuacion_id"], ",", str9, ",getdate())" });
                                            cmd.CommandText = str8;
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                    transaction.Commit();
                                }
                            }
                            string strSQL = string.Concat(new object[] { "select * from vFactura WHERE ( Factura_id = convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10),", num5, ")and recibo_id=convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10),", str, ") and fecha >=CONVERT(datetime,'01-01-2011',105) and haber >=0 " });
                            DataTable rsRPT = new Data().executeResultSet(ref this.con, ref cmd, strSQL);
                            if (rsRPT.Rows.Count <= 0)
                            {
                                strSQL = string.Concat(new object[] { "select distinct nhc, nombre, apellido1, apellido2, nif, cpostal, PROV, POB, DIREC, pais, sociedad_id, descripcion, direccion, poblacion, provincia, telefono, fax, postal, cif, factura_id, fecha, tratamiento_id, DescT, importe, descuento, debe, haber, peca, '' recibo_id, '' valorrec, poliza from vFactura WHERE ( Factura_id = convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10),", num5, ")and recibo_id in (", str, ")) and fecha >=CONVERT(datetime,'01-01-2011',105) and haber >=0" });
                                rsRPT = new Data().executeResultSet(ref this.con, ref cmd, strSQL);
                            }
                            if (rsRPT.Rows.Count <= 0)
                            {
                                strSQL = "select * from vFactura2 WHERE ( Factura_id = convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10)," + num5 + ")) and fecha >=CONVERT(datetime,'01-01-2011',105) and haber>=0 ";
                                rsRPT = new Data().executeResultSet(ref this.con, ref cmd, strSQL);
                            }
                            if (str != "")
                            {
                                int startIndex = str.LastIndexOf(",");
                                str = str.Remove(startIndex);
                                str2 = str2.Replace("0,", ",");
                                startIndex = str2.LastIndexOf(",");
                                str2 = str2.Remove(startIndex);
                                foreach (DataRow row in rsRPT.Rows)
                                {
                                    row.BeginEdit();
                                    row[0x1c] = str;
                                    row[0x1d] = str2;
                                    row.EndEdit();
                                }
                            }
                            new cVerRelatorios().MostraRelatorio(rsRPT, Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt", "newReportADO_FacturaBase_Cliente.rpt", "Facturas");
                        }
                        catch (Exception exception1)
                        {
                            exception = exception1;
                            transaction.Rollback();
                            new FrmMsg(1, "ERRO", exception.Message).ShowDialog();
                        }
                    }
                    catch (Exception exception2)
                    {
                        exception = exception2;
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void carregaRecibos()
        {
            this.con = new SqlConnection(Security.GetCnn());
            try
            {
                DataTable table = new DataTable();
                this.con.Open();
                SqlCommand sp = this.con.CreateCommand();
                this.dataGridView1.DataSource = Data.GetRecibos(ref sp, this._paciente, this.con);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if ((e.ColumnIndex == 0) && (rowIndex > -1))
            {
                bool flag = bool.Parse(this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
                this.dataGridView1.EndEdit();
                this.dataGridView1.Rows[rowIndex].Cells[0].Value = !flag;
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

        private void FrmFacturas_Load(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dateTimePicker1.MinDate = DateTime.Now.Date;
            this.dateTimePicker1.MaxDate = DateTime.Now.Date;
            this.carregaRecibos();
        }

        private void GridFormat()
        {
            this.dataGridView1.AutoResizeColumns();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmFacturas));
            this.groupBox1 = new GroupBox();
            this.dateTimePicker1 = new DateTimePicker();
            this.label5 = new Label();
            this.textBox2 = new TextBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.button4 = new Button();
            this.button2 = new Button();
            this.label4 = new Label();
            this.textBox4 = new TextBox();
            this.groupBox2 = new GroupBox();
            this.dataGridView1 = new DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.groupBox1.BackColor = Color.White;
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.ForeColor = Color.SteelBlue;
            this.groupBox1.Location = new Point(2, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(420, 0x85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
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
            this.textBox2.Location = new Point(0x4a, 0x34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(330, 20);
            this.textBox2.TabIndex = 0x35;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(13, 0x3b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x34, 13);
            this.label3.TabIndex = 0x34;
            this.label3.Text = "M\x00c9DICO:";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(10, 0x5f);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2e, 13);
            this.label2.TabIndex = 0x33;
            this.label2.Text = "VALOR:";
            this.textBox1.BackColor = Color.White;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new Point(0x3e, 0x5c);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x89, 20);
            this.textBox1.TabIndex = 50;
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(0xb6, 0x11);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x1d, 20);
            this.button1.TabIndex = 0x30;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.Location = new Point(0x149, 90);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x4b, 0x17);
            this.button4.TabIndex = 0x2f;
            this.button4.Text = "CANCELAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.Location = new Point(0xf8, 90);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 0x2e;
            this.button2.Text = "GRAVAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(13, 0x15);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x30, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "N.ORD.:";
            this.textBox4.BackColor = Color.White;
            this.textBox4.Enabled = false;
            this.textBox4.Location = new Point(0x3e, 0x12);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(0x72, 20);
            this.textBox4.TabIndex = 0x10;
            this.groupBox2.BackColor = Color.White;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.ForeColor = Color.SteelBlue;
            this.groupBox2.Location = new Point(2, 0xb2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(420, 0x107);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recibos";
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new Point(6, 0x13);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new Size(0x198, 0xee);
            this.dataGridView1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x1b2, 0x1c5);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "FrmFacturas";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Factura";
            base.Load += new EventHandler(this.FrmFacturas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        private void Medicos_medicoSelecionado(object sender, MedicosEventArgs e)
        {
            this._medico = e.puntoservicio_id;
            this.textBox4.Text = e.colegiado.ToString();
            this.textBox2.Text = e.Nome.ToString();
        }

        private void numeroDocumentosSelecionados(out int numeroSelecionados)
        {
            numeroSelecionados = 0;
            DataTable dataSource = (DataTable) this.dataGridView1.DataSource;
            for (int i = 0; i < dataSource.Rows.Count; i++)
            {
                if ((bool) this.dataGridView1.Rows[i].Cells[0].Value)
                {
                    numeroSelecionados++;
                }
            }
        }

        private void upMedicoTratamento(ref SqlCommand cmd)
        {
            string str = "";
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i < this._dt.Rows.Count; i++)
            {
                str = ("update actuacion set puntoservicio_id=" + this._medico) + " where actuacion_id=" + this._dt.Rows[i]["actuacion_id"];
                cmd.CommandText = str;
                cmd.ExecuteNonQuery();
            }
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

