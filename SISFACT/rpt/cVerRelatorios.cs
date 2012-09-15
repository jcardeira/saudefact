namespace SISFACT.rpt
{
    using CrystalDecisions.CrystalReports.Engine;
    using SISFACT;
    using System;
    using System.Data;

    public class cVerRelatorios
    {
        public ReportDocument crViewerDocument = new ReportDocument();
        public FrmCrystalViewer frmRpt = new FrmCrystalViewer();

        public void MostraRelatorio(DataTable rsRPT, string CaminhoRelatorio, string FicheiroRelatorio, string TituloJanela)
        {
            try
            {
                if (rsRPT.Rows.Count > 0)
                {
                    CaminhoRelatorio = CaminhoRelatorio.Substring(6);
                    this.crViewerDocument.Load(CaminhoRelatorio + @"\" + FicheiroRelatorio);
                    this.crViewerDocument.SetDataSource(rsRPT);
                }
                else
                {
                    new FrmMsg(1, "AVISO", "N\x00e3o existem registos para serem impressos.").ShowDialog();
                }
                this.frmRpt.crystalReportViewer1.ShowGroupTreeButton = true;
                this.frmRpt.crystalReportViewer1.DisplayGroupTree = false;
                if (this.frmRpt.crystalReportViewer1.ShowPrintButton)
                {
                    this.frmRpt.crystalReportViewer1.ReportSource = this.crViewerDocument;
                    this.frmRpt.Text = "Pr\x00e9-Visualiza\x00e7\x00e3o - " + TituloJanela;
                    this.frmRpt.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                new FrmMsg(1, "ERRO", exception.Message).ShowDialog();
            }
        }

        public void MostraRelatorio2(DataTable rsRPT, string CaminhoRelatorio, string FicheiroRelatorio, string TituloJanela, string data1, string data2, string titulo)
        {
            try
            {
                if (rsRPT.Rows.Count > 0)
                {
                    CaminhoRelatorio = CaminhoRelatorio.Substring(6);
                    this.crViewerDocument.Load(CaminhoRelatorio + @"\" + FicheiroRelatorio);
                    this.crViewerDocument.SetDataSource(rsRPT);
                    this.crViewerDocument.SetParameterValue(0, data1.Substring(0, 10));
                    this.crViewerDocument.SetParameterValue(1, data2.Substring(0, 10));
                    this.crViewerDocument.SetParameterValue(2, titulo);
                    this.frmRpt.crystalReportViewer1.ShowGroupTreeButton = true;
                    this.frmRpt.crystalReportViewer1.DisplayGroupTree = false;
                    if (this.frmRpt.crystalReportViewer1.ShowPrintButton)
                    {
                        this.frmRpt.crystalReportViewer1.ReportSource = this.crViewerDocument;
                        this.frmRpt.Text = "Pr\x00e9-Visualiza\x00e7\x00e3o - " + TituloJanela;
                        this.frmRpt.ShowDialog();
                    }
                    this.frmRpt.crystalReportViewer1.ShowExportButton = true;
                }
                else
                {
                    new FrmMsg(1, "AVISO", "N\x00e3o existem registos para serem impressos.").ShowDialog();
                }
            }
            catch (Exception exception)
            {
                new FrmMsg(1, "ERRO", exception.Message).ShowDialog();
            }
        }
    }
}

