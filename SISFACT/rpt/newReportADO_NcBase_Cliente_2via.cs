namespace SISFACT.rpt
{
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.ComponentModel;

    public class newReportADO_NcBase_Cliente_2via : ReportClass
    {
        public override string FullResourceName
        {
            get
            {
                return "SISFACT.rpt.newReportADO_NcBase_Cliente_2via.rpt";
            }
            set
            {
            }
        }

        public override bool NewGenerator
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public override string ResourceName
        {
            get
            {
                return "newReportADO_NcBase_Cliente_2via.rpt";
            }
            set
            {
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section1
        {
            get
            {
                return this.ReportDefinition.Sections[4];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section10
        {
            get
            {
                return this.ReportDefinition.Sections[1];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section12
        {
            get
            {
                return this.ReportDefinition.Sections[3];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section2
        {
            get
            {
                return this.ReportDefinition.Sections[10];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section3
        {
            get
            {
                return this.ReportDefinition.Sections[6];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section4
        {
            get
            {
                return this.ReportDefinition.Sections[8];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section5
        {
            get
            {
                return this.ReportDefinition.Sections[5];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section6
        {
            get
            {
                return this.ReportDefinition.Sections[9];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section7
        {
            get
            {
                return this.ReportDefinition.Sections[2];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section8
        {
            get
            {
                return this.ReportDefinition.Sections[7];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section9
        {
            get
            {
                return this.ReportDefinition.Sections[0];
            }
        }
    }
}

