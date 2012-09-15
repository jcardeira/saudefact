namespace SISFACT.rpt
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.Shared;
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [ToolboxBitmap(typeof(ExportOptions), "report.bmp")]
    public class Cachedlistagem : Component, ICachedReport
    {
        public virtual ReportDocument CreateReport()
        {
            listagem listagem = new listagem();
            listagem.Site = this.Site;
            return listagem;
        }

        public virtual string GetCustomizedCacheKey(RequestContext request)
        {
            return null;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual TimeSpan CacheTimeOut
        {
            get
            {
                return CachedReportConstants.DEFAULT_TIMEOUT;
            }
            set
            {
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool IsCacheable
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool ShareDBLogonInfo
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }
}

