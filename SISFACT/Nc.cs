namespace SISFACT
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), DesignerCategory("code"), ToolboxItem(true), XmlRoot("Nc"), HelpKeyword("vs.data.DataSet"), XmlSchemaProvider("GetTypedDataSetSchema")]
    public class Nc : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private vNcDataTable tablevNc;

        [DebuggerNonUserCode]
        public Nc()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            base.EndInit();
        }

        [DebuggerNonUserCode]
        protected Nc(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            if (base.IsBinarySerialized(info, context))
            {
                this.InitVars(false);
                CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += handler;
                this.Relations.CollectionChanged += handler;
            }
            else
            {
                string s = (string) info.GetValue("XmlSchema", typeof(string));
                if (base.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                    if (dataSet.Tables["vNc"] != null)
                    {
                        base.Tables.Add(new vNcDataTable(dataSet.Tables["vNc"]));
                    }
                    base.DataSetName = dataSet.DataSetName;
                    base.Prefix = dataSet.Prefix;
                    base.Namespace = dataSet.Namespace;
                    base.Locale = dataSet.Locale;
                    base.CaseSensitive = dataSet.CaseSensitive;
                    base.EnforceConstraints = dataSet.EnforceConstraints;
                    base.Merge(dataSet, false, MissingSchemaAction.Add);
                    this.InitVars();
                }
                else
                {
                    base.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                }
                base.GetSerializationData(info, context);
                CollectionChangeEventHandler handler2 = new CollectionChangeEventHandler(this.SchemaChanged);
                base.Tables.CollectionChanged += handler2;
                this.Relations.CollectionChanged += handler2;
            }
        }

        [DebuggerNonUserCode]
        public override DataSet Clone()
        {
            Nc nc = (Nc) base.Clone();
            nc.InitVars();
            nc.SchemaSerializationMode = this.SchemaSerializationMode;
            return nc;
        }

        [DebuggerNonUserCode]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            Nc nc = new Nc();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny();
            item.Namespace = nc.Namespace;
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = nc.GetSchemaSerializable();
            if (xs.Contains(schemaSerializable.TargetNamespace))
            {
                MemoryStream stream = new MemoryStream();
                MemoryStream stream2 = new MemoryStream();
                try
                {
                    XmlSchema current = null;
                    schemaSerializable.Write(stream);
                    IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (XmlSchema) enumerator.Current;
                        stream2.SetLength(0L);
                        current.Write(stream2);
                        if (stream.Length == stream2.Length)
                        {
                            stream.Position = 0L;
                            stream2.Position = 0L;
                            while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                            {
                            }
                            if (stream.Position == stream.Length)
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (stream2 != null)
                    {
                        stream2.Close();
                    }
                }
            }
            xs.Add(schemaSerializable);
            return type;
        }

        [DebuggerNonUserCode]
        private void InitClass()
        {
            base.DataSetName = "Nc";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/Nc.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tablevNc = new vNcDataTable();
            base.Tables.Add(this.tablevNc);
        }

        [DebuggerNonUserCode]
        protected override void InitializeDerivedDataSet()
        {
            base.BeginInit();
            this.InitClass();
            base.EndInit();
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [DebuggerNonUserCode]
        internal void InitVars(bool initTable)
        {
            this.tablevNc = (vNcDataTable) base.Tables["vNc"];
            if (initTable && (this.tablevNc != null))
            {
                this.tablevNc.InitVars();
            }
        }

        [DebuggerNonUserCode]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["vNc"] != null)
                {
                    base.Tables.Add(new vNcDataTable(dataSet.Tables["vNc"]));
                }
                base.DataSetName = dataSet.DataSetName;
                base.Prefix = dataSet.Prefix;
                base.Namespace = dataSet.Namespace;
                base.Locale = dataSet.Locale;
                base.CaseSensitive = dataSet.CaseSensitive;
                base.EnforceConstraints = dataSet.EnforceConstraints;
                base.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                base.ReadXml(reader);
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializevNc()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
        public DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true), DebuggerNonUserCode]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode]
        public vNcDataTable vNc
        {
            get
            {
                return this.tablevNc;
            }
        }

        [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
        public class vNcDataTable : TypedTableBase<Nc.vNcRow>
        {
            private DataColumn columnapellido1;
            private DataColumn columnapellido2;
            private DataColumn columnbasica_id;
            private DataColumn columncif;
            private DataColumn columncpostal;
            private DataColumn columndata;
            private DataColumn columndebe;
            private DataColumn columndescripcion;
            private DataColumn columnDescT;
            private DataColumn columndescuento;
            private DataColumn columnDIREC;
            private DataColumn columndireccion;
            private DataColumn columnfactura_id;
            private DataColumn columnfax;
            private DataColumn columnhaber;
            private DataColumn columnimporte;
            private DataColumn columnNc_id;
            private DataColumn columnnhc;
            private DataColumn columnnif;
            private DataColumn columnnombre;
            private DataColumn columnpais;
            private DataColumn columnpeca;
            private DataColumn columnPOB;
            private DataColumn columnpoblacion;
            private DataColumn columnpoliza;
            private DataColumn columnpostal;
            private DataColumn columnPROV;
            private DataColumn columnprovincia;
            private DataColumn columntelefono;
            private DataColumn columntratamiento_id;
            private DataColumn columnvalorf;

            public event Nc.vNcRowChangeEventHandler vNcRowChanged;

            public event Nc.vNcRowChangeEventHandler vNcRowChanging;

            public event Nc.vNcRowChangeEventHandler vNcRowDeleted;

            public event Nc.vNcRowChangeEventHandler vNcRowDeleting;

            [DebuggerNonUserCode]
            public vNcDataTable()
            {
                base.TableName = "vNc";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal vNcDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode]
            protected vNcDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddvNcRow(Nc.vNcRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public Nc.vNcRow AddvNcRow(string nhc, string nombre, string apellido1, string apellido2, string nif, string cpostal, string PROV, string POB, string DIREC, string pais, int basica_id, string descripcion, string direccion, string poblacion, string provincia, string telefono, string fax, string postal, string cif, string factura_id, string Nc_id, int tratamiento_id, string DescT, decimal haber, string peca, string poliza, DateTime data, decimal importe, decimal descuento, decimal debe, string valorf)
            {
                Nc.vNcRow row = (Nc.vNcRow) base.NewRow();
                row.ItemArray = new object[] { 
                    nhc, nombre, apellido1, apellido2, nif, cpostal, PROV, POB, DIREC, pais, basica_id, descripcion, direccion, poblacion, provincia, telefono, 
                    fax, postal, cif, factura_id, Nc_id, tratamiento_id, DescT, haber, peca, poliza, data, importe, descuento, debe, valorf
                 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                Nc.vNcDataTable table = (Nc.vNcDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new Nc.vNcDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(Nc.vNcRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                Nc nc = new Nc();
                XmlSchemaAny item = new XmlSchemaAny();
                item.Namespace = "http://www.w3.org/2001/XMLSchema";
                item.MinOccurs = 0M;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = 1M;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute();
                attribute.Name = "namespace";
                attribute.FixedValue = nc.Namespace;
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "vNcDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = nc.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnnhc = new DataColumn("nhc", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnnhc);
                this.columnnombre = new DataColumn("nombre", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnnombre);
                this.columnapellido1 = new DataColumn("apellido1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnapellido1);
                this.columnapellido2 = new DataColumn("apellido2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnapellido2);
                this.columnnif = new DataColumn("nif", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnnif);
                this.columncpostal = new DataColumn("cpostal", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncpostal);
                this.columnPROV = new DataColumn("PROV", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPROV);
                this.columnPOB = new DataColumn("POB", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPOB);
                this.columnDIREC = new DataColumn("DIREC", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDIREC);
                this.columnpais = new DataColumn("pais", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpais);
                this.columnbasica_id = new DataColumn("basica_id", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnbasica_id);
                this.columndescripcion = new DataColumn("descripcion", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columndescripcion);
                this.columndireccion = new DataColumn("direccion", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columndireccion);
                this.columnpoblacion = new DataColumn("poblacion", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpoblacion);
                this.columnprovincia = new DataColumn("provincia", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnprovincia);
                this.columntelefono = new DataColumn("telefono", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columntelefono);
                this.columnfax = new DataColumn("fax", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnfax);
                this.columnpostal = new DataColumn("postal", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpostal);
                this.columncif = new DataColumn("cif", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncif);
                this.columnfactura_id = new DataColumn("factura_id", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnfactura_id);
                this.columnNc_id = new DataColumn("Nc_id", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNc_id);
                this.columntratamiento_id = new DataColumn("tratamiento_id", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columntratamiento_id);
                this.columnDescT = new DataColumn("DescT", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDescT);
                this.columnhaber = new DataColumn("haber", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnhaber);
                this.columnpeca = new DataColumn("peca", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpeca);
                this.columnpoliza = new DataColumn("poliza", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpoliza);
                this.columndata = new DataColumn("data", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columndata);
                this.columnimporte = new DataColumn("importe", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnimporte);
                this.columndescuento = new DataColumn("descuento", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columndescuento);
                this.columndebe = new DataColumn("debe", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columndebe);
                this.columnvalorf = new DataColumn("valorf", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnvalorf);
                this.columnnhc.AllowDBNull = false;
                this.columnnhc.MaxLength = 10;
                this.columnnombre.AllowDBNull = false;
                this.columnnombre.MaxLength = 50;
                this.columnapellido1.AllowDBNull = false;
                this.columnapellido1.MaxLength = 50;
                this.columnapellido2.AllowDBNull = false;
                this.columnapellido2.MaxLength = 50;
                this.columnnif.MaxLength = 9;
                this.columncpostal.AllowDBNull = false;
                this.columncpostal.MaxLength = 7;
                this.columnPROV.MaxLength = 50;
                this.columnPOB.MaxLength = 50;
                this.columnDIREC.AllowDBNull = false;
                this.columnDIREC.MaxLength = 50;
                this.columnpais.MaxLength = 50;
                this.columnbasica_id.AllowDBNull = false;
                this.columndescripcion.MaxLength = 200;
                this.columndireccion.MaxLength = 200;
                this.columnpoblacion.MaxLength = 200;
                this.columnprovincia.MaxLength = 200;
                this.columntelefono.MaxLength = 9;
                this.columnfax.MaxLength = 9;
                this.columnpostal.MaxLength = 7;
                this.columncif.MaxLength = 10;
                this.columnfactura_id.ReadOnly = true;
                this.columnfactura_id.MaxLength = 9;
                this.columnNc_id.ReadOnly = true;
                this.columnNc_id.MaxLength = 0x10;
                this.columntratamiento_id.AllowDBNull = false;
                this.columnDescT.MaxLength = 50;
                this.columnpeca.MaxLength = 2;
                this.columnpoliza.ReadOnly = true;
                this.columnpoliza.MaxLength = 20;
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnnhc = base.Columns["nhc"];
                this.columnnombre = base.Columns["nombre"];
                this.columnapellido1 = base.Columns["apellido1"];
                this.columnapellido2 = base.Columns["apellido2"];
                this.columnnif = base.Columns["nif"];
                this.columncpostal = base.Columns["cpostal"];
                this.columnPROV = base.Columns["PROV"];
                this.columnPOB = base.Columns["POB"];
                this.columnDIREC = base.Columns["DIREC"];
                this.columnpais = base.Columns["pais"];
                this.columnbasica_id = base.Columns["basica_id"];
                this.columndescripcion = base.Columns["descripcion"];
                this.columndireccion = base.Columns["direccion"];
                this.columnpoblacion = base.Columns["poblacion"];
                this.columnprovincia = base.Columns["provincia"];
                this.columntelefono = base.Columns["telefono"];
                this.columnfax = base.Columns["fax"];
                this.columnpostal = base.Columns["postal"];
                this.columncif = base.Columns["cif"];
                this.columnfactura_id = base.Columns["factura_id"];
                this.columnNc_id = base.Columns["Nc_id"];
                this.columntratamiento_id = base.Columns["tratamiento_id"];
                this.columnDescT = base.Columns["DescT"];
                this.columnhaber = base.Columns["haber"];
                this.columnpeca = base.Columns["peca"];
                this.columnpoliza = base.Columns["poliza"];
                this.columndata = base.Columns["data"];
                this.columnimporte = base.Columns["importe"];
                this.columndescuento = base.Columns["descuento"];
                this.columndebe = base.Columns["debe"];
                this.columnvalorf = base.Columns["valorf"];
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Nc.vNcRow(builder);
            }

            [DebuggerNonUserCode]
            public Nc.vNcRow NewvNcRow()
            {
                return (Nc.vNcRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.vNcRowChanged != null)
                {
                    this.vNcRowChanged(this, new Nc.vNcRowChangeEvent((Nc.vNcRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.vNcRowChanging != null)
                {
                    this.vNcRowChanging(this, new Nc.vNcRowChangeEvent((Nc.vNcRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.vNcRowDeleted != null)
                {
                    this.vNcRowDeleted(this, new Nc.vNcRowChangeEvent((Nc.vNcRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.vNcRowDeleting != null)
                {
                    this.vNcRowDeleting(this, new Nc.vNcRowChangeEvent((Nc.vNcRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemovevNcRow(Nc.vNcRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn apellido1Column
            {
                get
                {
                    return this.columnapellido1;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn apellido2Column
            {
                get
                {
                    return this.columnapellido2;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn basica_idColumn
            {
                get
                {
                    return this.columnbasica_id;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn cifColumn
            {
                get
                {
                    return this.columncif;
                }
            }

            [DebuggerNonUserCode, Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn cpostalColumn
            {
                get
                {
                    return this.columncpostal;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn dataColumn
            {
                get
                {
                    return this.columndata;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn debeColumn
            {
                get
                {
                    return this.columndebe;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn descripcionColumn
            {
                get
                {
                    return this.columndescripcion;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn DescTColumn
            {
                get
                {
                    return this.columnDescT;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn descuentoColumn
            {
                get
                {
                    return this.columndescuento;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn direccionColumn
            {
                get
                {
                    return this.columndireccion;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn DIRECColumn
            {
                get
                {
                    return this.columnDIREC;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn factura_idColumn
            {
                get
                {
                    return this.columnfactura_id;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn faxColumn
            {
                get
                {
                    return this.columnfax;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn haberColumn
            {
                get
                {
                    return this.columnhaber;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn importeColumn
            {
                get
                {
                    return this.columnimporte;
                }
            }

            [DebuggerNonUserCode]
            public Nc.vNcRow this[int index]
            {
                get
                {
                    return (Nc.vNcRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Nc_idColumn
            {
                get
                {
                    return this.columnNc_id;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn nhcColumn
            {
                get
                {
                    return this.columnnhc;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn nifColumn
            {
                get
                {
                    return this.columnnif;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn nombreColumn
            {
                get
                {
                    return this.columnnombre;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn paisColumn
            {
                get
                {
                    return this.columnpais;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn pecaColumn
            {
                get
                {
                    return this.columnpeca;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn POBColumn
            {
                get
                {
                    return this.columnPOB;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn poblacionColumn
            {
                get
                {
                    return this.columnpoblacion;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn polizaColumn
            {
                get
                {
                    return this.columnpoliza;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn postalColumn
            {
                get
                {
                    return this.columnpostal;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn PROVColumn
            {
                get
                {
                    return this.columnPROV;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn provinciaColumn
            {
                get
                {
                    return this.columnprovincia;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn telefonoColumn
            {
                get
                {
                    return this.columntelefono;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn tratamiento_idColumn
            {
                get
                {
                    return this.columntratamiento_id;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn valorfColumn
            {
                get
                {
                    return this.columnvalorf;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class vNcRow : DataRow
        {
            private Nc.vNcDataTable tablevNc;

            [DebuggerNonUserCode]
            internal vNcRow(DataRowBuilder rb) : base(rb)
            {
                this.tablevNc = (Nc.vNcDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IscifNull()
            {
                return base.IsNull(this.tablevNc.cifColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdataNull()
            {
                return base.IsNull(this.tablevNc.dataColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdebeNull()
            {
                return base.IsNull(this.tablevNc.debeColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdescripcionNull()
            {
                return base.IsNull(this.tablevNc.descripcionColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDescTNull()
            {
                return base.IsNull(this.tablevNc.DescTColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdescuentoNull()
            {
                return base.IsNull(this.tablevNc.descuentoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdireccionNull()
            {
                return base.IsNull(this.tablevNc.direccionColumn);
            }

            [DebuggerNonUserCode]
            public bool Isfactura_idNull()
            {
                return base.IsNull(this.tablevNc.factura_idColumn);
            }

            [DebuggerNonUserCode]
            public bool IsfaxNull()
            {
                return base.IsNull(this.tablevNc.faxColumn);
            }

            [DebuggerNonUserCode]
            public bool IshaberNull()
            {
                return base.IsNull(this.tablevNc.haberColumn);
            }

            [DebuggerNonUserCode]
            public bool IsimporteNull()
            {
                return base.IsNull(this.tablevNc.importeColumn);
            }

            [DebuggerNonUserCode]
            public bool IsNc_idNull()
            {
                return base.IsNull(this.tablevNc.Nc_idColumn);
            }

            [DebuggerNonUserCode]
            public bool IsnifNull()
            {
                return base.IsNull(this.tablevNc.nifColumn);
            }

            [DebuggerNonUserCode]
            public bool IspaisNull()
            {
                return base.IsNull(this.tablevNc.paisColumn);
            }

            [DebuggerNonUserCode]
            public bool IspecaNull()
            {
                return base.IsNull(this.tablevNc.pecaColumn);
            }

            [DebuggerNonUserCode]
            public bool IspoblacionNull()
            {
                return base.IsNull(this.tablevNc.poblacionColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPOBNull()
            {
                return base.IsNull(this.tablevNc.POBColumn);
            }

            [DebuggerNonUserCode]
            public bool IspolizaNull()
            {
                return base.IsNull(this.tablevNc.polizaColumn);
            }

            [DebuggerNonUserCode]
            public bool IspostalNull()
            {
                return base.IsNull(this.tablevNc.postalColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprovinciaNull()
            {
                return base.IsNull(this.tablevNc.provinciaColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPROVNull()
            {
                return base.IsNull(this.tablevNc.PROVColumn);
            }

            [DebuggerNonUserCode]
            public bool IstelefonoNull()
            {
                return base.IsNull(this.tablevNc.telefonoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsvalorfNull()
            {
                return base.IsNull(this.tablevNc.valorfColumn);
            }

            [DebuggerNonUserCode]
            public void SetcifNull()
            {
                base[this.tablevNc.cifColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdataNull()
            {
                base[this.tablevNc.dataColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdebeNull()
            {
                base[this.tablevNc.debeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdescripcionNull()
            {
                base[this.tablevNc.descripcionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDescTNull()
            {
                base[this.tablevNc.DescTColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdescuentoNull()
            {
                base[this.tablevNc.descuentoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdireccionNull()
            {
                base[this.tablevNc.direccionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void Setfactura_idNull()
            {
                base[this.tablevNc.factura_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetfaxNull()
            {
                base[this.tablevNc.faxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SethaberNull()
            {
                base[this.tablevNc.haberColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetimporteNull()
            {
                base[this.tablevNc.importeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetNc_idNull()
            {
                base[this.tablevNc.Nc_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetnifNull()
            {
                base[this.tablevNc.nifColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpaisNull()
            {
                base[this.tablevNc.paisColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpecaNull()
            {
                base[this.tablevNc.pecaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpoblacionNull()
            {
                base[this.tablevNc.poblacionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPOBNull()
            {
                base[this.tablevNc.POBColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpolizaNull()
            {
                base[this.tablevNc.polizaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpostalNull()
            {
                base[this.tablevNc.postalColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetprovinciaNull()
            {
                base[this.tablevNc.provinciaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPROVNull()
            {
                base[this.tablevNc.PROVColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SettelefonoNull()
            {
                base[this.tablevNc.telefonoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetvalorfNull()
            {
                base[this.tablevNc.valorfColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string apellido1
            {
                get
                {
                    return (string) base[this.tablevNc.apellido1Column];
                }
                set
                {
                    base[this.tablevNc.apellido1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public string apellido2
            {
                get
                {
                    return (string) base[this.tablevNc.apellido2Column];
                }
                set
                {
                    base[this.tablevNc.apellido2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public int basica_id
            {
                get
                {
                    return (int) base[this.tablevNc.basica_idColumn];
                }
                set
                {
                    base[this.tablevNc.basica_idColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string cif
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.cifColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'cif' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.cifColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string cpostal
            {
                get
                {
                    return (string) base[this.tablevNc.cpostalColumn];
                }
                set
                {
                    base[this.tablevNc.cpostalColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public DateTime data
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tablevNc.dataColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'data' in table 'vNc' is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tablevNc.dataColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal debe
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tablevNc.debeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'debe' in table 'vNc' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevNc.debeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string descripcion
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.descripcionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'descripcion' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.descripcionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string DescT
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.DescTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DescT' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.DescTColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal descuento
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tablevNc.descuentoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'descuento' in table 'vNc' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevNc.descuentoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string DIREC
            {
                get
                {
                    return (string) base[this.tablevNc.DIRECColumn];
                }
                set
                {
                    base[this.tablevNc.DIRECColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string direccion
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.direccionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'direccion' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.direccionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string factura_id
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.factura_idColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'factura_id' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.factura_idColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string fax
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.faxColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'fax' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.faxColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal haber
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tablevNc.haberColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'haber' in table 'vNc' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevNc.haberColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal importe
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tablevNc.importeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'importe' in table 'vNc' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevNc.importeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Nc_id
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.Nc_idColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Nc_id' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.Nc_idColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string nhc
            {
                get
                {
                    return (string) base[this.tablevNc.nhcColumn];
                }
                set
                {
                    base[this.tablevNc.nhcColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string nif
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.nifColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'nif' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.nifColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string nombre
            {
                get
                {
                    return (string) base[this.tablevNc.nombreColumn];
                }
                set
                {
                    base[this.tablevNc.nombreColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string pais
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.paisColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'pais' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.paisColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string peca
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.pecaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'peca' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.pecaColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string POB
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.POBColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'POB' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.POBColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string poblacion
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.poblacionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'poblacion' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.poblacionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string poliza
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.polizaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'poliza' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.polizaColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string postal
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.postalColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'postal' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.postalColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string PROV
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.PROVColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PROV' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.PROVColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string provincia
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.provinciaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'provincia' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.provinciaColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string telefono
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.telefonoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'telefono' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.telefonoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int tratamiento_id
            {
                get
                {
                    return (int) base[this.tablevNc.tratamiento_idColumn];
                }
                set
                {
                    base[this.tablevNc.tratamiento_idColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string valorf
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevNc.valorfColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'valorf' in table 'vNc' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevNc.valorfColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class vNcRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Nc.vNcRow eventRow;

            [DebuggerNonUserCode]
            public vNcRowChangeEvent(Nc.vNcRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode]
            public Nc.vNcRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void vNcRowChangeEventHandler(object sender, Nc.vNcRowChangeEvent e);
    }
}

