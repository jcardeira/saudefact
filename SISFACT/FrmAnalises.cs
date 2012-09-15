namespace SISFACT
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class FrmAnalises : Form
    {
        private int _paciente_id = 0;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private ComboBox comboBox1;
        private IContainer components = null;
        private SqlConnection con = new SqlConnection(Security.GetCnn());
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
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

        public FrmAnalises(Form parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Carrega();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox4.Clear();
            this.dateTimePicker2.Value = DateTime.Today;
            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddDays(-30.0);
            this.CarregaGrid1(this.mCmd);
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
                new FrmFacturas(this, this.sDt, this.dataGridView2.SelectedCells[10].Value.ToString(), this.dataGridView2.SelectedCells[9].Value.ToString(), this.total, int.Parse(this.dataGridView2.SelectedCells[11].Value.ToString()), int.Parse(this.dataGridView1.SelectedCells[7].Value.ToString())).ShowDialog();
            }
            this.Carrega();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FrmFacturacao(this, "R").ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FrmFacturacao(this, "D").ShowDialog();
        }

        public void Carrega()
        {
            this.CarregaGrid1(this.mCmd);
            this.CarregaGrid2(this.mCmd);
        }

        private void CarregaGrid1(SqlCommand cmd)
        {
            try
            {
                this.con.Open();
                cmd = this.con.CreateCommand();
                this.dataGridView1.DataSource = Data.GetAnalises(ref cmd, this.textBox4.Text, this.textBox1.Text, this.dateTimePicker1.Value, this.dateTimePicker2.Value);
                this.GridFormat();
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

        private void CarregaGrid2(SqlCommand cmd)
        {
            try
            {
                DataTable table = new DataTable();
                this.con.Open();
                if (((DataTable) this.dataGridView1.DataSource).Rows.Count > 0)
                {
                    this.dataGridView1.CurrentRow.Selected = true;
                    this._paciente_id = int.Parse(this.dataGridView1.SelectedCells[7].Value.ToString());
                    cmd = this.con.CreateCommand();
                    table = Data.GetDetalhe(ref cmd, int.Parse(this.dataGridView1.SelectedCells[5].Value.ToString()), this.con);
                    this.dataGridView2.DataSource = table;
                    this.GridFormat2();
                }
                else
                {
                    this.dataGridView2.DataSource = table;
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
            if (rowIndex > -1)
            {
                this.dataGridView1.CurrentRow.Selected = false;
                this.dataGridView1.Rows[rowIndex].Selected = true;
                this.CarregaGrid2(this.mCmd);
                this.GridFormat2();
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

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool flag = false;
            int rowIndex = e.RowIndex;
            if ((e.ColumnIndex == 0) && (rowIndex == 0))
            {
                for (int i = 0; i < this.dataGridView1.RowCount; i++)
                {
                    this.dataGridView1.EndEdit();
                    flag = bool.Parse(this.dataGridView1.Rows[i].Cells[0].Value.ToString());
                    this.dataGridView1.Rows[i].Cells[0].Value = !flag;
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

        private void FrmAnalises_Load(object sender, EventArgs e)
        {
            this.dataGridView2.CellClick += new DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dateTimePicker2.Value = DateTime.Today;
            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddDays(-30.0);
            this.CarregaGrid1(this.mCmd);
            this.CarregaGrid2(this.mCmd);
        }

        private void GridFormat()
        {
            this.dataGridView1.Columns[0].ReadOnly = true;
            this.dataGridView1.Columns[1].ReadOnly = true;
            this.dataGridView1.Columns[2].ReadOnly = true;
            this.dataGridView1.Columns[3].ReadOnly = true;
            this.dataGridView1.Columns[4].ReadOnly = true;
            this.dataGridView1.Columns[5].ReadOnly = true;
            this.dataGridView1.Columns[6].ReadOnly = true;
            this.dataGridView1.Columns[7].ReadOnly = true;
            this.dataGridView1.Columns[8].ReadOnly = true;
            this.dataGridView1.Columns[9].ReadOnly = true;
            this.dataGridView1.Columns[10].ReadOnly = true;
            this.dataGridView1.Columns[0].Width = 70;
            this.dataGridView1.Columns[0].Visible = true;
            this.dataGridView1.Columns[1].Width = 90;
            this.dataGridView1.Columns[2].Width = 90;
            this.dataGridView1.Columns[3].Width = 350;
            this.dataGridView1.Columns[4].Width = 150;
            this.dataGridView1.Columns[5].Width = 90;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[6].Width = 100;
            this.dataGridView1.Columns[6].Visible = false;
            this.dataGridView1.Columns[7].Width = 100;
            this.dataGridView1.Columns[7].Visible = false;
            this.dataGridView1.Columns[8].Width = 100;
            this.dataGridView1.Columns[8].Visible = false;
            this.dataGridView1.Columns[9].Width = 100;
            this.dataGridView1.Columns[9].Visible = false;
            this.dataGridView1.Columns[10].Width = 100;
            this.dataGridView1.Columns[10].Visible = true;
            this.dataGridView1.Columns[0].HeaderText = "Exercicio";
            this.dataGridView1.Columns[1].HeaderText = "Numero";
            this.dataGridView1.Columns[2].HeaderText = "Data";
            this.dataGridView1.Columns[3].HeaderText = "Paciente";
            this.dataGridView1.Columns[4].HeaderText = "Medico";
            this.dataGridView1.Columns[5].HeaderText = "OrcamentoId";
            this.dataGridView1.Columns[6].HeaderText = "MedicoId";
            this.dataGridView1.Columns[7].HeaderText = "PacienteId";
            this.dataGridView1.Columns[8].HeaderText = "Tarifa";
            this.dataGridView1.Columns[9].HeaderText = "Desconto";
            this.dataGridView1.Columns[10].HeaderText = "Valor";
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
            this.dataGridView2.Columns[8].Visible = false;
            this.dataGridView2.Columns[9].Width = 350;
            this.dataGridView2.Columns[9].Visible = true;
            this.dataGridView2.Columns[10].Width = 50;
            this.dataGridView2.Columns[10].Visible = false;
            this.dataGridView2.Columns[11].Width = 50;
            this.dataGridView2.Columns[11].Visible = false;
            this.dataGridView2.Columns[0].HeaderText = "Seleccionar";
            this.dataGridView2.Columns[1].HeaderText = "Data";
            this.dataGridView2.Columns[2].HeaderText = "Pe\x00e7a";
            this.dataGridView2.Columns[3].HeaderText = "Tratamento";
            this.dataGridView2.Columns[4].HeaderText = "Valor";
            this.dataGridView2.Columns[5].HeaderText = "Dto%";
            this.dataGridView2.Columns[6].HeaderText = "Debito";
            this.dataGridView2.Columns[7].HeaderText = "Rejeitado";
            this.dataGridView2.Columns[8].HeaderText = "id";
            this.dataGridView2.Columns[9].HeaderText = "Medico";
            this.dataGridView2.Columns[10].HeaderText = "Colegiado";
            this.dataGridView2.Columns[11].HeaderText = "puntoservicio_id";
            this.dataGridView2.AutoResizeColumns();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmAnalises));
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
            this.dataGridView1 = new DataGridView();
            this.groupBox1 = new GroupBox();
            this.button2 = new Button();
            this.groupBox2 = new GroupBox();
            this.groupBox3 = new GroupBox();
            this.button6 = new Button();
            this.button4 = new Button();
            this.button5 = new Button();
            this.button3 = new Button();
            this.dataGridView2 = new DataGridView();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize) this.dataGridView2).BeginInit();
            base.SuspendLayout();
            this.textBox4.BackColor = Color.White;
            this.textBox4.ForeColor = Color.SteelBlue;
            this.textBox4.Location = new Point(0x11d, 0x13);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(0x9c, 20);
            this.textBox4.TabIndex = 10;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0xf6, 0x16);
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
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = Color.White;
            this.dataGridView1.Location = new Point(6, 0x13);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(0x3e0, 0x97);
            this.dataGridView1.TabIndex = 20;
            this.groupBox1.BackColor = Color.White;
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
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.Location = new Point(0x367, 0x22);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x56, 0x17);
            this.button2.TabIndex = 20;
            this.button2.Text = "LIMPAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.groupBox2.BackColor = Color.White;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.ForeColor = Color.SteelBlue;
            this.groupBox2.Location = new Point(2, 0x79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x3ec, 0xb1);
            this.groupBox2.TabIndex = 0x18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Or\x00e7amentos";
            this.groupBox3.BackColor = Color.White;
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.ForeColor = Color.SteelBlue;
            this.groupBox3.Location = new Point(2, 0x130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x3ec, 0x177);
            this.groupBox3.TabIndex = 0x19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tratamentos";
            this.button6.FlatStyle = FlatStyle.Popup;
            this.button6.Location = new Point(0x2b6, 0x13b);
            this.button6.Name = "button6";
            this.button6.Size = new Size(0x67, 0x17);
            this.button6.TabIndex = 0x18;
            this.button6.Text = "DEVOLU\x00c7\x00c3O";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new EventHandler(this.button6_Click);
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.Location = new Point(0x323, 0x13b);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x67, 0x17);
            this.button4.TabIndex = 0x16;
            this.button4.Text = "FACTURAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button5.FlatStyle = FlatStyle.Popup;
            this.button5.Location = new Point(0x24b, 0x13b);
            this.button5.Name = "button5";
            this.button5.Size = new Size(0x65, 0x17);
            this.button5.TabIndex = 0x17;
            this.button5.Text = "RECIBO/PAGAR";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new EventHandler(this.button5_Click);
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.Location = new Point(0x390, 0x13b);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x56, 0x17);
            this.button3.TabIndex = 0x15;
            this.button3.Text = "FECHAR";
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
            this.dataGridView2.Size = new Size(0x3e0, 0x110);
            this.dataGridView2.TabIndex = 20;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x3fe, 0x2b3);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.groupBox2);
            this.ForeColor = Color.White;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FrmAnalises";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Gest\x00e3o -  Tratamentos";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.FrmAnalises_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
                    total += (decimal) dataSource.Rows[i]["D\x00e9bito"];
                    this.sDt.ImportRow(dataSource.Rows[i]);
                }
            }
        }
    }
}

