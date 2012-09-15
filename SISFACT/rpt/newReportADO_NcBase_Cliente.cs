namespace SISFACT.rpt
{
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.ComponentModel;

    public class newReportADO_NcBase_Cliente : ReportClass
    {
        public override string FullResourceName
        {
            get
            {
                return "SISFACT.rpt.newReportADO_NcBase_Cliente.rpt";
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
                return "newReportADO_NcBase_Cliente.rpt";
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section9
        {
            get
            {
                return this.ReportDefinition.Sections[0];
            }
        }
    }
}

