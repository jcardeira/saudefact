namespace SISFACT
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using SmsSender;

    public class FrmMain : Form
    {
        private ToolStripMenuItem ajudaToolStripMenuItem;
        private ToolStripMenuItem alterarPwdToolStripMenuItem;
        private IContainer components = null;
        private ToolStripMenuItem devoluçõesToolStripMenuItem;
        private ToolStripMenuItem devoluçõesToolStripMenuItem1;
        private ToolStripMenuItem envioSMSToolStripMenuItem;
        private ToolStripMenuItem facturacaoToolStripMenuItem;
        private ToolStripMenuItem facturaçãoToolStripMenuItem;
        private ToolStripMenuItem facturasToolStripMenuItem;
        private ToolStripMenuItem gestaoToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem notasDeCreditoToolStripMenuItem;
        private ToolStripMenuItem notasDeCréditoToolStripMenuItem;
        private string[] permissions = null;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ToolStripMenuItem recibosToolStripMenuItem;
        private ToolStripMenuItem recibosToolStripMenuItem1;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem sistemaToolStripMenuItem;
        private Timer timer1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tratamentosToolStripMenuItem;
        private string user = null;
        private int userID = 0;
        private ToolStripMenuItem utilizadoresToolStripMenuItem;
        private ToolStripMenuItem versãoToolStripMenuItem;

        public FrmMain(string[] permissions, int userid, string user)
        {
            this.InitializeComponent();
            this.Text = "SaúdeFact - " + GetRunningVersion();

            this.permissions = permissions;
            this.user = user;
            this.userID = userid;
        }

        private void alterarPwdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmPwdReset(this.userID, this.user).ShowDialog();
        }

        private void devoluçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form is FrmDocumentos)
                {
                    return;
                }
            }
            new FrmDocumentos(this, "D").Show();
            base.LayoutMdi(MdiLayout.Cascade);
        }

        private void devoluçõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmFacturacao(this, "D").ShowDialog();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void envioSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(this);
            f.Connection = Security.GetServidor("");
            string clinica, ip, senderId, senderPhone;
            Security.GetIpSMS(out ip, out clinica);
            Security.GetSenderAndPhone(out senderId, out senderPhone);
            f.Clinica = clinica;
            f.SenderID = senderId;
            f.SenderPhone = senderPhone;
            f.Show();
            //new FrmAnalises(this).Show();
            base.LayoutMdi(MdiLayout.Cascade);
            
           /* foreach (Form form in base.MdiChildren)
            {
                if (form is FrmSMS)
                {
                    return;
                }
            }
            f.ShowDialog();
            base.LayoutMdi(MdiLayout.Cascade);*/
        }

        private void facturacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form is FrmAnalises)
                {
                    return;
                }
            }
            new FrmAnalises(this).Show();
            base.LayoutMdi(MdiLayout.Cascade);
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form is FrmDocumentos)
                {
                    return;
                }
            }
            new FrmDocumentos(this, "F").Show();
            base.LayoutMdi(MdiLayout.Cascade);
        }

        private void FrmMain2_Load(object sender, EventArgs e)
        {
            this.toolStripLabel1.Text = "UTILIZADOR:" + this.user;
            Security.Apply(this.permissions, this.menuStrip1);
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt\ManualUtilizador.pdf");
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarPwdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tratamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recibosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.devoluçõesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notasDeCréditoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recibosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devoluçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notasDeCreditoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envioSMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.gestaoToolStripMenuItem,
            this.envioSMSToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(621, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilizadoresToolStripMenuItem,
            this.alterarPwdToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.sistemaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.utilizadoresToolStripMenuItem.Enabled = false;
            this.utilizadoresToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.utilizadoresToolStripMenuItem.Text = "Utilizadores";
            this.utilizadoresToolStripMenuItem.Visible = false;
            this.utilizadoresToolStripMenuItem.Click += new System.EventHandler(this.utilizadoresToolStripMenuItem_Click);
            // 
            // alterarPwdToolStripMenuItem
            // 
            this.alterarPwdToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.alterarPwdToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.alterarPwdToolStripMenuItem.Name = "alterarPwdToolStripMenuItem";
            this.alterarPwdToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.alterarPwdToolStripMenuItem.Text = "Alterar pwd";
            this.alterarPwdToolStripMenuItem.Visible = false;
            this.alterarPwdToolStripMenuItem.Click += new System.EventHandler(this.alterarPwdToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.sairToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // gestaoToolStripMenuItem
            // 
            this.gestaoToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gestaoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tratamentosToolStripMenuItem,
            this.facturaçãoToolStripMenuItem});
            this.gestaoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gestaoToolStripMenuItem.Name = "gestaoToolStripMenuItem";
            this.gestaoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.gestaoToolStripMenuItem.Text = "Gestão";
            // 
            // tratamentosToolStripMenuItem
            // 
            this.tratamentosToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.tratamentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturacaoToolStripMenuItem,
            this.recibosToolStripMenuItem1,
            this.devoluçõesToolStripMenuItem1,
            this.notasDeCréditoToolStripMenuItem});
            this.tratamentosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tratamentosToolStripMenuItem.Name = "tratamentosToolStripMenuItem";
            this.tratamentosToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.tratamentosToolStripMenuItem.Text = "Gestão";
            this.tratamentosToolStripMenuItem.Click += new System.EventHandler(this.tratamentosToolStripMenuItem_Click);
            // 
            // facturacaoToolStripMenuItem
            // 
            this.facturacaoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.facturacaoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.facturacaoToolStripMenuItem.Name = "facturacaoToolStripMenuItem";
            this.facturacaoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.facturacaoToolStripMenuItem.Text = "Facturas";
            this.facturacaoToolStripMenuItem.Click += new System.EventHandler(this.facturacaoToolStripMenuItem_Click);
            // 
            // recibosToolStripMenuItem1
            // 
            this.recibosToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Menu;
            this.recibosToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.recibosToolStripMenuItem1.Name = "recibosToolStripMenuItem1";
            this.recibosToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.recibosToolStripMenuItem1.Text = "Recibos";
            this.recibosToolStripMenuItem1.Click += new System.EventHandler(this.recibosToolStripMenuItem1_Click);
            // 
            // devoluçõesToolStripMenuItem1
            // 
            this.devoluçõesToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Menu;
            this.devoluçõesToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.devoluçõesToolStripMenuItem1.Name = "devoluçõesToolStripMenuItem1";
            this.devoluçõesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.devoluçõesToolStripMenuItem1.Text = "Notas de Devolução";
            this.devoluçõesToolStripMenuItem1.Click += new System.EventHandler(this.devoluçõesToolStripMenuItem1_Click);
            // 
            // notasDeCréditoToolStripMenuItem
            // 
            this.notasDeCréditoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.notasDeCréditoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.notasDeCréditoToolStripMenuItem.Name = "notasDeCréditoToolStripMenuItem";
            this.notasDeCréditoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.notasDeCréditoToolStripMenuItem.Text = "Notas de Crédito";
            this.notasDeCréditoToolStripMenuItem.Click += new System.EventHandler(this.notasDeCréditoToolStripMenuItem_Click);
            // 
            // facturaçãoToolStripMenuItem
            // 
            this.facturaçãoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.facturaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturasToolStripMenuItem,
            this.recibosToolStripMenuItem,
            this.devoluçõesToolStripMenuItem,
            this.notasDeCreditoToolStripMenuItem});
            this.facturaçãoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.facturaçãoToolStripMenuItem.Name = "facturaçãoToolStripMenuItem";
            this.facturaçãoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.facturaçãoToolStripMenuItem.Text = "Listagem e 2ª vias";
            // 
            // facturasToolStripMenuItem
            // 
            this.facturasToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.facturasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
            this.facturasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.facturasToolStripMenuItem.Text = "Facturas";
            this.facturasToolStripMenuItem.Click += new System.EventHandler(this.facturasToolStripMenuItem_Click);
            // 
            // recibosToolStripMenuItem
            // 
            this.recibosToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.recibosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.recibosToolStripMenuItem.Name = "recibosToolStripMenuItem";
            this.recibosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recibosToolStripMenuItem.Text = "Recibos";
            this.recibosToolStripMenuItem.Click += new System.EventHandler(this.recibosToolStripMenuItem_Click);
            // 
            // devoluçõesToolStripMenuItem
            // 
            this.devoluçõesToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.devoluçõesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.devoluçõesToolStripMenuItem.Name = "devoluçõesToolStripMenuItem";
            this.devoluçõesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.devoluçõesToolStripMenuItem.Text = "Notas de Devolução";
            this.devoluçõesToolStripMenuItem.Click += new System.EventHandler(this.devoluçõesToolStripMenuItem_Click);
            // 
            // notasDeCreditoToolStripMenuItem
            // 
            this.notasDeCreditoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.notasDeCreditoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.notasDeCreditoToolStripMenuItem.Name = "notasDeCreditoToolStripMenuItem";
            this.notasDeCreditoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.notasDeCreditoToolStripMenuItem.Text = "Notas de Credito";
            this.notasDeCreditoToolStripMenuItem.Click += new System.EventHandler(this.notasDeCreditoToolStripMenuItem_Click);
            // 
            // envioSMSToolStripMenuItem
            // 
            this.envioSMSToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.envioSMSToolStripMenuItem.Name = "envioSMSToolStripMenuItem";
            this.envioSMSToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.envioSMSToolStripMenuItem.Text = "Envio SMS";
            this.envioSMSToolStripMenuItem.Click += new System.EventHandler(this.envioSMSToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indexToolStripMenuItem,
            this.versãoToolStripMenuItem});
            this.ajudaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ajudaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.SteelBlue;
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.indexToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.indexToolStripMenuItem.Text = "Manual";
            this.indexToolStripMenuItem.Click += new System.EventHandler(this.indexToolStripMenuItem_Click);
            // 
            // versãoToolStripMenuItem
            // 
            this.versãoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.versãoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.versãoToolStripMenuItem.Name = "versãoToolStripMenuItem";
            this.versãoToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.versãoToolStripMenuItem.Text = "Versão";
            this.versãoToolStripMenuItem.Click += new System.EventHandler(this.versãoToolStripMenuItem_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 323);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(621, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // FrmMain
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(621, 348);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public static Version GetRunningVersion()
        {
            try
            {
                return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        private void notasDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form is FrmDocumentos)
                {
                    return;
                }
            }
            new FrmDocumentos(this, "C").Show();
            base.LayoutMdi(MdiLayout.Cascade);
        }

        private void notasDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form is FrmNc)
                {
                    return;
                }
            }
            new FrmNc(this).Show();
            base.LayoutMdi(MdiLayout.Cascade);
        }

        private void recibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form is FrmDocumentos)
                {
                    return;
                }
            }
            new FrmDocumentos(this, "R").Show();
            base.LayoutMdi(MdiLayout.Cascade);
        }

        private void recibosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmFacturacao(this, "R").ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            this.toolStripLabel2.Text = now.Hour.ToString().PadLeft(2, '0') + ":" + now.Minute.ToString().PadLeft(2, '0') + ":" + now.Second.ToString().PadLeft(2, '0');
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form is FrmAnalises)
                {
                    return;
                }
            }
            new FrmAnalises(this).Show();
            base.LayoutMdi(MdiLayout.Cascade);
        }

        private void tratamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void utilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form is FrmUtilizadores)
                {
                    return;
                }
            }
            new FrmUtilizadores(this).Show();
            base.LayoutMdi(MdiLayout.Cascade);
        }

        private void versãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

