namespace SISFACT.rpt
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using System;
    using System.ComponentModel;

    public class listagem : ReportClass
    {
        public override string FullResourceName
        {
            get
            {
                return "SISFACT.rpt.listagem.rpt";
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IParameterField Parameter_Data1
        {
            get
            {
                return this.DataDefinition.ParameterFields[0];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IParameterField Parameter_Data2
        {
            get
            {
                return this.DataDefinition.ParameterFields[1];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IParameterField Parameter_titulo
        {
            get
            {
                return this.DataDefinition.ParameterFields[2];
            }
        }

        public override string ResourceName
        {
            get
            {
                return "listagem.rpt";
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
                return this.ReportDefinition.Sections[0];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section2
        {
            get
            {
                return this.ReportDefinition.Sections[1];
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section4
        {
            get
            {
                return this.ReportDefinition.Sections[3];
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
    }
}

