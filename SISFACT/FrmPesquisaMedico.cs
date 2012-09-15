namespace SISFACT
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmPesquisaMedico : Form
    {
        private cMedicos _Medicos;
        private Button btnSair;
        private Button button1;
        private Button button2;
        private IContainer components = null;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label4;
        private Label label5;
        public MedicoEventHandler MedicoSelecionado;
        private TextBox textBox1;
        private TextBox textBox4;

        public FrmPesquisaMedico(Form parent)
        {
            this.InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = "%" + this.textBox1.Text.Replace("'", "") + "%";
            string colegiado = "";
            int num = 0;
            try
            {
                colegiado = this.textBox4.Text;
            }
            catch
            {
                colegiado = "";
            }
            if (colegiado.Length > 0)
            {
                this.carregaGrid(this._Medicos.GetColegiado(colegiado, num));
            }
            else
            {
                this.carregaGrid(this._Medicos.GetNome(nome, num));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox4.Clear();
            this.carregaGrid(this._Medicos.Medicos);
        }

        private void carregaGrid(DataTable dt)
        {
            this.dataGridView1.DataSource = dt;
            this.GridFormat();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                BindingManagerBase base2 = this.dataGridView1.BindingContext[this.dataGridView1.DataSource];
                DataRow row = ((DataRowView) base2.Current).Row;
                string colegiado = row["Colegiado"].ToString();
                string nome = row["Nome"].ToString();
                int num = int.Parse(row["puntoservicio_id"].ToString());
                MedicosEventArgs args = new MedicosEventArgs(colegiado, nome, num);
                this.MedicoSelecionado(this, args);
                base.Close();
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

        private void FrmPesquisaMedico_Load(object sender, EventArgs e)
        {
            this._Medicos = new cMedicos();
            this.textBox4.KeyPress += new KeyPressEventHandler(this.textBox4_KeyPress);
            this.carregaGrid(this._Medicos.Medicos);
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
        }

        private void GridFormat()
        {
            this.dataGridView1.Columns[0].ReadOnly = true;
            this.dataGridView1.Columns[1].ReadOnly = true;
            this.dataGridView1.Columns[2].ReadOnly = true;
            this.dataGridView1.Columns[0].Width = 70;
            this.dataGridView1.Columns[1].Width = 90;
            this.dataGridView1.Columns[2].Width = 90;
            this.dataGridView1.Columns[0].HeaderText = "Id";
            this.dataGridView1.Columns[1].HeaderText = "NUM.ORDEM";
            this.dataGridView1.Columns[2].HeaderText = "NOME";
            this.dataGridView1.AutoResizeColumns();
            this.dataGridView1.Columns[0].Visible = false;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmPesquisaMedico));
            this.textBox4 = new TextBox();
            this.label4 = new Label();
            this.button1 = new Button();
            this.textBox1 = new TextBox();
            this.label5 = new Label();
            this.dataGridView1 = new DataGridView();
            this.groupBox1 = new GroupBox();
            this.button2 = new Button();
            this.groupBox2 = new GroupBox();
            this.btnSair = new Button();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.textBox4.BackColor = Color.White;
            this.textBox4.ForeColor = Color.SteelBlue;
            this.textBox4.Location = new Point(0x3d, 0x13);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(0x9c, 20);
            this.textBox4.TabIndex = 10;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(10, 0x13);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2d, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "N.ORD:";
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.Location = new Point(0x252, 0x30);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x56, 0x17);
            this.button1.TabIndex = 0x11;
            this.button1.Text = "PESQUISAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox1.BackColor = Color.White;
            this.textBox1.ForeColor = Color.SteelBlue;
            this.textBox1.Location = new Point(0x3d, 0x39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x209, 20);
            this.textBox1.TabIndex = 0x13;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(10, 0x39);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x2a, 13);
            this.label5.TabIndex = 0x12;
            this.label5.Text = "NOME:";
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = Color.DarkGray;
            this.dataGridView1.Location = new Point(6, 0x13);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(0x2a3, 0x199);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.groupBox1.BackColor = Color.White;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.ForeColor = Color.SteelBlue;
            this.groupBox1.Location = new Point(3, 0x18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x2af, 0x5e);
            this.groupBox1.TabIndex = 0x15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.Location = new Point(0x252, 0x13);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x56, 0x17);
            this.button2.TabIndex = 0x16;
            this.button2.Text = "LIMPAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.groupBox2.BackColor = Color.White;
            this.groupBox2.Controls.Add(this.btnSair);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.ForeColor = Color.SteelBlue;
            this.groupBox2.Location = new Point(2, 0x7c);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x2b0, 0x1d7);
            this.groupBox2.TabIndex = 0x18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documentos";
            this.btnSair.FlatStyle = FlatStyle.Popup;
            this.btnSair.Location = new Point(0x253, 0x1b2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new Size(0x56, 0x17);
            this.btnSair.TabIndex = 0x1b;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new EventHandler(this.btnSair_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x2be, 0x25e);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.groupBox2);
            this.ForeColor = Color.White;
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "FrmPesquisaMedico";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Pesquisa -  Utentes";
            base.Load += new EventHandler(this.FrmPesquisaMedico_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}

