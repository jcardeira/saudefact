namespace SISFACT
{
    using CrystalDecisions.Windows.Forms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmCrystalViewer : Form
    {
        private IContainer components = null;
        public CrystalReportViewer crystalReportViewer1;

        public FrmCrystalViewer()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmCrystalViewer_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmCrystalViewer));
            this.crystalReportViewer1 = new CrystalReportViewer();
            base.SuspendLayout();
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new Point(3, 0x1b);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ShowExportButton = false;
            this.crystalReportViewer1.ShowGotoPageButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.ShowTextSearchButton = false;
            this.crystalReportViewer1.ShowZoomButton = false;
            this.crystalReportViewer1.Size = new Size(0x2af, 0x224);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SteelBlue;
            base.ClientSize = new Size(0x2be, 0x25e);
            base.Controls.Add(this.crystalReportViewer1);
            this.ForeColor = Color.White;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "FrmCrystalViewer";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Impress\x00e3o -  Documentos";
            base.Load += new EventHandler(this.FrmCrystalViewer_Load);
            base.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
    }
}

