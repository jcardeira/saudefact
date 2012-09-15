namespace SISFACT.rpt
{
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.ComponentModel;

    public class ReportADO_ReciboClientes : ReportClass
    {
        public override string FullResourceName
        {
            get
            {
                return "SISFACT.rpt.ReportADO_ReciboClientes.rpt";
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
                return "ReportADO_ReciboClientes.rpt";
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
                return this.ReportDefinition.Sections[3];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section12
        {
            get
            {
                return this.ReportDefinition.Sections[1];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section2
        {
            get
            {
                return this.ReportDefinition.Sections[8];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section3
        {
            get
            {
                return this.ReportDefinition.Sections[2];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section4
        {
            get
            {
                return this.ReportDefinition.Sections[6];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section5
        {
            get
            {
                return this.ReportDefinition.Sections[4];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section6
        {
            get
            {
                return this.ReportDefinition.Sections[7];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section7
        {
            get
            {
                return this.ReportDefinition.Sections[5];
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

