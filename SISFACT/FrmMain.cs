namespace SISFACT
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

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
            foreach (Form form in base.MdiChildren)
            {
                if (form is FrmSMS)
                {
                    return;
                }
            }
            new FrmSMS(this).Show();
            base.LayoutMdi(MdiLayout.Cascade);
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
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new MenuStrip();
            this.sistemaToolStripMenuItem = new ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem = new ToolStripMenuItem();
            this.alterarPwdToolStripMenuItem = new ToolStripMenuItem();
            this.sairToolStripMenuItem = new ToolStripMenuItem();
            this.gestaoToolStripMenuItem = new ToolStripMenuItem();
            this.tratamentosToolStripMenuItem = new ToolStripMenuItem();
            this.facturacaoToolStripMenuItem = new ToolStripMenuItem();
            this.recibosToolStripMenuItem1 = new ToolStripMenuItem();
            this.devoluçõesToolStripMenuItem1 = new ToolStripMenuItem();
            this.notasDeCréditoToolStripMenuItem = new ToolStripMenuItem();
            this.facturaçãoToolStripMenuItem = new ToolStripMenuItem();
            this.facturasToolStripMenuItem = new ToolStripMenuItem();
            this.recibosToolStripMenuItem = new ToolStripMenuItem();
            this.devoluçõesToolStripMenuItem = new ToolStripMenuItem();
            this.notasDeCreditoToolStripMenuItem = new ToolStripMenuItem();
            this.envioSMSToolStripMenuItem = new ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new ToolStripMenuItem();
            this.indexToolStripMenuItem = new ToolStripMenuItem();
            this.versãoToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripLabel1 = new ToolStripLabel();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.toolStripLabel2 = new ToolStripLabel();
            this.timer1 = new Timer(this.components);
            this.toolStrip1 = new ToolStrip();
            this.menuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.menuStrip1.BackColor = Color.SteelBlue;
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.sistemaToolStripMenuItem, this.gestaoToolStripMenuItem, this.envioSMSToolStripMenuItem, this.ajudaToolStripMenuItem });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0x26d, 0x18);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.utilizadoresToolStripMenuItem, this.alterarPwdToolStripMenuItem, this.sairToolStripMenuItem });
            this.sistemaToolStripMenuItem.ForeColor = Color.White;
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            this.utilizadoresToolStripMenuItem.BackColor = SystemColors.Menu;
            this.utilizadoresToolStripMenuItem.Enabled = false;
            this.utilizadoresToolStripMenuItem.ForeColor = Color.SteelBlue;
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new Size(0x87, 0x16);
            this.utilizadoresToolStripMenuItem.Text = "Utilizadores";
            this.utilizadoresToolStripMenuItem.Visible = false;
            this.utilizadoresToolStripMenuItem.Click += new EventHandler(this.utilizadoresToolStripMenuItem_Click);
            this.alterarPwdToolStripMenuItem.BackColor = SystemColors.Menu;
            this.alterarPwdToolStripMenuItem.ForeColor = Color.SteelBlue;
            this.alterarPwdToolStripMenuItem.Name = "alterarPwdToolStripMenuItem";
            this.alterarPwdToolStripMenuItem.Size = new Size(0x87, 0x16);
            this.alterarPwdToolStripMenuItem.Text = "Alterar pwd";
            this.alterarPwdToolStripMenuItem.Visible = false;
            this.alterarPwdToolStripMenuItem.Click += new EventHandler(this.alterarPwdToolStripMenuItem_Click);
            this.sairToolStripMenuItem.BackColor = SystemColors.Menu;
            this.sairToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new Size(0x87, 0x16);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new EventHandler(this.sairToolStripMenuItem_Click);
            this.gestaoToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.gestaoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.tratamentosToolStripMenuItem, this.facturaçãoToolStripMenuItem });
            this.gestaoToolStripMenuItem.ForeColor = Color.White;
            this.gestaoToolStripMenuItem.Name = "gestaoToolStripMenuItem";
            this.gestaoToolStripMenuItem.Size = new Size(0x37, 20);
            this.gestaoToolStripMenuItem.Text = "Gest\x00e3o";
            this.tratamentosToolStripMenuItem.BackColor = SystemColors.Menu;
            this.tratamentosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.facturacaoToolStripMenuItem, this.recibosToolStripMenuItem1, this.devoluçõesToolStripMenuItem1, this.notasDeCréditoToolStripMenuItem });
            this.tratamentosToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.tratamentosToolStripMenuItem.Name = "tratamentosToolStripMenuItem";
            this.tratamentosToolStripMenuItem.Size = new Size(0xa8, 0x16);
            this.tratamentosToolStripMenuItem.Text = "Gest\x00e3o";
            this.tratamentosToolStripMenuItem.Click += new EventHandler(this.tratamentosToolStripMenuItem_Click);
            this.facturacaoToolStripMenuItem.BackColor = SystemColors.Menu;
            this.facturacaoToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.facturacaoToolStripMenuItem.Name = "facturacaoToolStripMenuItem";
            this.facturacaoToolStripMenuItem.Size = new Size(180, 0x16);
            this.facturacaoToolStripMenuItem.Text = "Facturas";
            this.facturacaoToolStripMenuItem.Click += new EventHandler(this.facturacaoToolStripMenuItem_Click);
            this.recibosToolStripMenuItem1.BackColor = SystemColors.Menu;
            this.recibosToolStripMenuItem1.ForeColor = SystemColors.GrayText;
            this.recibosToolStripMenuItem1.Name = "recibosToolStripMenuItem1";
            this.recibosToolStripMenuItem1.Size = new Size(180, 0x16);
            this.recibosToolStripMenuItem1.Text = "Recibos";
            this.recibosToolStripMenuItem1.Click += new EventHandler(this.recibosToolStripMenuItem1_Click);
            this.devoluçõesToolStripMenuItem1.BackColor = SystemColors.Menu;
            this.devoluçõesToolStripMenuItem1.ForeColor = SystemColors.GrayText;
            this.devoluçõesToolStripMenuItem1.Name = "devolu\x00e7\x00f5esToolStripMenuItem1";
            this.devoluçõesToolStripMenuItem1.Size = new Size(180, 0x16);
            this.devoluçõesToolStripMenuItem1.Text = "Notas de Devolu\x00e7\x00e3o";
            this.devoluçõesToolStripMenuItem1.Click += new EventHandler(this.devoluçõesToolStripMenuItem1_Click);
            this.notasDeCréditoToolStripMenuItem.BackColor = SystemColors.Menu;
            this.notasDeCréditoToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.notasDeCréditoToolStripMenuItem.Name = "notasDeCr\x00e9ditoToolStripMenuItem";
            this.notasDeCréditoToolStripMenuItem.Size = new Size(180, 0x16);
            this.notasDeCréditoToolStripMenuItem.Text = "Notas de Cr\x00e9dito";
            this.notasDeCréditoToolStripMenuItem.Click += new EventHandler(this.notasDeCréditoToolStripMenuItem_Click);
            this.facturaçãoToolStripMenuItem.BackColor = SystemColors.Menu;
            this.facturaçãoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.facturasToolStripMenuItem, this.recibosToolStripMenuItem, this.devoluçõesToolStripMenuItem, this.notasDeCreditoToolStripMenuItem });
            this.facturaçãoToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.facturaçãoToolStripMenuItem.Name = "factura\x00e7\x00e3oToolStripMenuItem";
            this.facturaçãoToolStripMenuItem.Size = new Size(0xa8, 0x16);
            this.facturaçãoToolStripMenuItem.Text = "Listagem e 2\x00aa vias";
            this.facturasToolStripMenuItem.BackColor = SystemColors.Menu;
            this.facturasToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
            this.facturasToolStripMenuItem.Size = new Size(180, 0x16);
            this.facturasToolStripMenuItem.Text = "Facturas";
            this.facturasToolStripMenuItem.Click += new EventHandler(this.facturasToolStripMenuItem_Click);
            this.recibosToolStripMenuItem.BackColor = SystemColors.Menu;
            this.recibosToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.recibosToolStripMenuItem.Name = "recibosToolStripMenuItem";
            this.recibosToolStripMenuItem.Size = new Size(180, 0x16);
            this.recibosToolStripMenuItem.Text = "Recibos";
            this.recibosToolStripMenuItem.Click += new EventHandler(this.recibosToolStripMenuItem_Click);
            this.devoluçõesToolStripMenuItem.BackColor = SystemColors.Menu;
            this.devoluçõesToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.devoluçõesToolStripMenuItem.Name = "devolu\x00e7\x00f5esToolStripMenuItem";
            this.devoluçõesToolStripMenuItem.Size = new Size(180, 0x16);
            this.devoluçõesToolStripMenuItem.Text = "Notas de Devolu\x00e7\x00e3o";
            this.devoluçõesToolStripMenuItem.Click += new EventHandler(this.devoluçõesToolStripMenuItem_Click);
            this.notasDeCreditoToolStripMenuItem.BackColor = SystemColors.Menu;
            this.notasDeCreditoToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.notasDeCreditoToolStripMenuItem.Name = "notasDeCreditoToolStripMenuItem";
            this.notasDeCreditoToolStripMenuItem.Size = new Size(180, 0x16);
            this.notasDeCreditoToolStripMenuItem.Text = "Notas de Credito";
            this.notasDeCreditoToolStripMenuItem.Click += new EventHandler(this.notasDeCreditoToolStripMenuItem_Click);
            this.envioSMSToolStripMenuItem.ForeColor = Color.White;
            this.envioSMSToolStripMenuItem.Name = "envioSMSToolStripMenuItem";
            this.envioSMSToolStripMenuItem.Size = new Size(0x4a, 20);
            this.envioSMSToolStripMenuItem.Text = "Envio SMS";
            this.envioSMSToolStripMenuItem.Click += new EventHandler(this.envioSMSToolStripMenuItem_Click);
            this.ajudaToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.indexToolStripMenuItem, this.versãoToolStripMenuItem });
            this.ajudaToolStripMenuItem.ForeColor = Color.White;
            this.ajudaToolStripMenuItem.ImageTransparentColor = Color.SteelBlue;
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            this.indexToolStripMenuItem.BackColor = SystemColors.Menu;
            this.indexToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new Size(0x72, 0x16);
            this.indexToolStripMenuItem.Text = "Manual";
            this.indexToolStripMenuItem.Click += new EventHandler(this.indexToolStripMenuItem_Click);
            this.versãoToolStripMenuItem.BackColor = SystemColors.Menu;
            this.versãoToolStripMenuItem.ForeColor = SystemColors.GrayText;
            this.versãoToolStripMenuItem.Name = "vers\x00e3oToolStripMenuItem";
            this.versãoToolStripMenuItem.Size = new Size(0x72, 0x16);
            this.versãoToolStripMenuItem.Text = "Vers\x00e3o";
            this.versãoToolStripMenuItem.Click += new EventHandler(this.versãoToolStripMenuItem_Click);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new Size(0x4e, 0x16);
            this.toolStripLabel1.Text = "toolStripLabel1";
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 0x19);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new Size(0x4e, 0x16);
            this.toolStripLabel2.Text = "toolStripLabel2";
            this.timer1.Enabled = true;
            this.timer1.Interval = 0x3e8;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.toolStrip1.BackColor = Color.SteelBlue;
            this.toolStrip1.Dock = DockStyle.Bottom;
            this.toolStrip1.Location = new Point(0, 0x143);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = RightToLeft.Yes;
            this.toolStrip1.Size = new Size(0x26d, 0x19);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Control;
            this.BackgroundImageLayout = ImageLayout.None;
            base.ClientSize = new Size(0x26d, 0x15c);
            base.Controls.Add(this.toolStrip1);
            base.Controls.Add(this.menuStrip1);
            this.ForeColor = SystemColors.ControlText;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.IsMdiContainer = true;
            base.MainMenuStrip = this.menuStrip1;
            base.Name = "FrmMain";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SaúdeFact - " + GetRunningVersion();
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.FrmMain2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
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
    }
}

