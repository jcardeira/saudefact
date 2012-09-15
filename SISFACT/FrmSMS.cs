namespace SISFACT
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class FrmSMS : Form
    {
        private int _paciente_id = 0;
        private Button button1;
        private Button button3;
        private Button button4;
        private IContainer components = null;
        private SqlConnection con = new SqlConnection(Security.GetCnn());
        private DataGridView dataGridView2;
        private DateTimePicker dateTimePicker1;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Label label1;
        private SqlCommand mCmd = new SqlCommand();
        private Data mstr = null;
        private DataTable sDt = new DataTable();
        private decimal total = 0M;
        public UtenteEventHandler UtenteSelecionado;
        private WebBrowser webBrowser1;

        public FrmSMS(Form parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.button4.Enabled = true;
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
                new FrmMsg(1, "AVISO", "Tem de selecionar pelo menos 1 Paciente.").ShowDialog();
            }
            else
            {
                try
                {
                    try
                    {
                        string urlString = "";
                        string text = "";
                        string clinicaip = "";
                        string clinica = "";
                        text = "V\x00e3o ser enviadas " + this.sDt.Rows.Count + " SMS. \nSeleccione 'OK' e aguarde por favor.";
                        new FrmMsg(1, "AVISO", text).ShowDialog();
                        this.button4.Enabled = false;
                        Security.GetIpSMS(out clinicaip, out clinica);
                        this.con.Open();
                        string str5 = new Data().executeScalar(ref this.con, ref this.mCmd, "select top 1 telefono from basica").ToString();
                        this.con.Close();
                        if ((clinicaip != "") & (clinica != ""))
                        {
                            for (int i = 0; i < this.sDt.Rows.Count; i++)
                            {
                                urlString = "";
                                DateTime time = DateTime.Parse(this.sDt.Rows[i][3].ToString());
                                string str6 = ((("http://www.clinicasvitaldent.pt/sms/s.aspx?c=" + clinica + "&id=" + clinicaip + "&nhc=") + this.sDt.Rows[i][1].ToString() + "&n=") + this.sDt.Rows[i][2].ToString() + "&t=") + this.sDt.Rows[i][4].ToString() + "&m=";
                                urlString = str6 + "Lembramos que tem consulta dia " + time.ToShortDateString() + " as " + this.len2(time.TimeOfDay.Hours.ToString()) + ":" + this.len2(time.TimeOfDay.Minutes.ToString()) + " na clinica VitalDent " + clinica + ". Em caso de indisponibilidade ligue " + str5 + ".&u=smsvital&p=sd4df68ewn7";
                                WebBrowser browser = new WebBrowser();
                                browser.Navigate(urlString);
                                while (browser.ReadyState != WebBrowserReadyState.Complete)
                                {
                                    Application.DoEvents();
                                }
                                browser.Dispose();
                            }
                            text = "SMS enviadas!";
                            new FrmMsg(1, "AVISO", text).ShowDialog();
                        }
                        else
                        {
                            text = "As " + this.sDt.Rows.Count + " SMS, \nn\x00e3o puderam ser enviadas \nporque n\x00e3o existe identificador v\x00e1lido.";
                            new FrmMsg(1, "AVISO", text).ShowDialog();
                        }
                    }
                    catch (Exception exception)
                    {
                        new FrmMsg(1, "ERRO", exception.Message).ShowDialog();
                    }
                }
                finally
                {
                }
            }
        }

        private void CarregaGrid2(SqlCommand cmd)
        {
            try
            {
                DataTable table = new DataTable();
                this.con.Open();
                cmd = this.con.CreateCommand();
                table = Data.GetPacientes(ref cmd, this.dateTimePicker1.Value.ToString(), this.con);
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
                if (this.dataGridView2.Rows[rowIndex].Cells[4].Value == "")
                {
                    new FrmMsg(1, "AVISO", "Este paciente n\x00e3o t\x00eam tel\x00e9movel associado!").ShowDialog();
                }
                else
                {
                    bool flag = bool.Parse(this.dataGridView2.Rows[rowIndex].Cells[0].Value.ToString());
                    this.dataGridView2.EndEdit();
                    this.dataGridView2.Rows[rowIndex].Cells[0].Value = !flag;
                }
            }
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (e.RowCount >= 0)
                {
                    for (int i = 0; i < (e.RowCount + 1); i++)
                    {
                        if (this.dataGridView2.Rows[i].Cells[4].Value == "")
                        {
                            this.dataGridView2.Rows[i].Cells[0].Value = false;
                            this.dataGridView2.EndEdit();
                        }
                    }
                }
            }
            catch (Exception)
            {
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

        private void FrmSMS_Load(object sender, EventArgs e)
        {
            this.dataGridView2.CellClick += new DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dateTimePicker1.Value = DateTime.Today.AddDays(1.0);
            this.dateTimePicker1.MinDate = DateTime.Today.AddDays(1.0);
            this.dateTimePicker1.MaxDate = DateTime.Today.AddDays(2.0);
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmSMS));
            this.dateTimePicker1 = new DateTimePicker();
            this.label1 = new Label();
            this.button1 = new Button();
            this.groupBox1 = new GroupBox();
            this.groupBox3 = new GroupBox();
            this.button4 = new Button();
            this.button3 = new Button();
            this.dataGridView2 = new DataGridView();
            this.webBrowser1 = new WebBrowser();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize) this.dataGridView2).BeginInit();
            base.SuspendLayout();
            this.dateTimePicker1.CalendarForeColor = Color.SteelBlue;
            this.dateTimePicker1.CalendarTitleBackColor = Color.SteelBlue;
            this.dateTimePicker1.CalendarTitleForeColor = Color.White;
            this.dateTimePicker1.Format = DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new Point(0x1a2, 0x21);
            this.dateTimePicker1.MinDate = new DateTime(0x7d1, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(0x60, 20);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.Value = new DateTime(0x7db, 2, 15, 12, 2, 3, 0);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x149, 0x21);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x53, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Seleccionar dia:";
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.Location = new Point(0x349, 0x22);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x56, 0x17);
            this.button1.TabIndex = 0x11;
            this.button1.Text = "PESQUISAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click_1);
            this.groupBox1.BackColor = Color.White;
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = Color.SteelBlue;
            this.groupBox1.Location = new Point(3, 0x18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x3eb, 0x5b);
            this.groupBox1.TabIndex = 0x15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            this.groupBox3.BackColor = Color.White;
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Controls.Add(this.webBrowser1);
            this.groupBox3.ForeColor = Color.SteelBlue;
            this.groupBox3.Location = new Point(2, 0x79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x3ec, 0x22e);
            this.groupBox3.TabIndex = 0x19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Agendamentos";
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.Location = new Point(0x331, 0x207);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x56, 0x17);
            this.button4.TabIndex = 0x16;
            this.button4.Text = "ENVIAR";
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
            this.dataGridView2.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dataGridView2_RowsAdded);
            this.webBrowser1.Location = new Point(0x143, 0x58);
            this.webBrowser1.MinimumSize = new Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new Size(250, 250);
            this.webBrowser1.TabIndex = 0x17;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x3fe, 0x2b3);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox1);
            this.ForeColor = Color.White;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FrmSMS";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Envio de SMS";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.FrmSMS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridView2).EndInit();
            base.ResumeLayout(false);
        }

        private string len2(string valor)
        {
            if (valor.Length == 2)
            {
                return valor;
            }
            return ("0" + valor);
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
                    this.sDt.ImportRow(dataSource.Rows[i]);
                }
            }
        }
    }
}

