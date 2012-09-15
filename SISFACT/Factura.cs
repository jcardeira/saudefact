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

    [Serializable, HelpKeyword("vs.data.DataSet"), ToolboxItem(true), XmlSchemaProvider("GetTypedDataSetSchema"), XmlRoot("Factura"), DesignerCategory("code"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class Factura : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VFacturaDataTable tableVFactura;

        [DebuggerNonUserCode]
        public Factura()
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
        protected Factura(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["VFactura"] != null)
                    {
                        base.Tables.Add(new VFacturaDataTable(dataSet.Tables["VFactura"]));
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
            Factura factura = (Factura) base.Clone();
            factura.InitVars();
            factura.SchemaSerializationMode = this.SchemaSerializationMode;
            return factura;
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
            Factura factura = new Factura();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny();
            item.Namespace = factura.Namespace;
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = factura.GetSchemaSerializable();
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
            base.DataSetName = "Factura";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/Factura.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableVFactura = new VFacturaDataTable();
            base.Tables.Add(this.tableVFactura);
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
            this.tableVFactura = (VFacturaDataTable) base.Tables["VFactura"];
            if (initTable && (this.tableVFactura != null))
            {
                this.tableVFactura.InitVars();
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
                if (dataSet.Tables["VFactura"] != null)
                {
                    base.Tables.Add(new VFacturaDataTable(dataSet.Tables["VFactura"]));
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
        private bool ShouldSerializeVFactura()
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

        [DebuggerNonUserCode, Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Browsable(false), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public VFacturaDataTable VFactura
        {
            get
            {
                return this.tableVFactura;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class VFacturaDataTable : TypedTableBase<Factura.VFacturaRow>
        {
            private DataColumn columnapellido1;
            private DataColumn columnapellido2;
            private DataColumn columnbasica_id;
            private DataColumn columncif;
            private DataColumn columncpostal;
            private DataColumn columndebe;
            private DataColumn columndescripcion;
            private DataColumn columnDescT;
            private DataColumn columndescuento;
            private DataColumn columnDIREC;
            private DataColumn columndireccion;
            private DataColumn columnfactura_id;
            private DataColumn columnfax;
            private DataColumn columnfecha;
            private DataColumn columnhaber;
            private DataColumn columnimporte;
            private DataColumn columnnhc;
            private DataColumn columnnif;
            private DataColumn columnnombre;
            private DataColumn columnPais;
            private DataColumn columnpeca;
            private DataColumn columnPOB;
            private DataColumn columnpoblacion;
            private DataColumn columnpoliza;
            private DataColumn columnpostal;
            private DataColumn columnPROV;
            private DataColumn columnprovincia;
            private DataColumn columnrecibo_id;
            private DataColumn columntelefono;
            private DataColumn columntratamiento_id;
            private DataColumn columnvalorrec;

            public event Factura.VFacturaRowChangeEventHandler VFacturaRowChanged;

            public event Factura.VFacturaRowChangeEventHandler VFacturaRowChanging;

            public event Factura.VFacturaRowChangeEventHandler VFacturaRowDeleted;

            public event Factura.VFacturaRowChangeEventHandler VFacturaRowDeleting;

            [DebuggerNonUserCode]
            public VFacturaDataTable()
            {
                base.TableName = "VFactura";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal VFacturaDataTable(DataTable table)
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
            protected VFacturaDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddVFacturaRow(Factura.VFacturaRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public Factura.VFacturaRow AddVFacturaRow(string nhc, string nombre, string apellido1, string apellido2, string nif, string cpostal, string PROV, string POB, string DIREC, string Pais, string basica_id, string descripcion, string direccion, string poblacion, string provincia, string telefono, string fax, string postal, string cif, string factura_id, DateTime fecha, string tratamiento_id, string DescT, decimal importe, decimal descuento, decimal debe, decimal haber, string peca, string recibo_id, string valorrec, string poliza)
            {
                Factura.VFacturaRow row = (Factura.VFacturaRow) base.NewRow();
                row.ItemArray = new object[] { 
                    nhc, nombre, apellido1, apellido2, nif, cpostal, PROV, POB, DIREC, Pais, basica_id, descripcion, direccion, poblacion, provincia, telefono, 
                    fax, postal, cif, factura_id, fecha, tratamiento_id, DescT, importe, descuento, debe, haber, peca, recibo_id, valorrec, poliza
                 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                Factura.VFacturaDataTable table = (Factura.VFacturaDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new Factura.VFacturaDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(Factura.VFacturaRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                Factura factura = new Factura();
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
                attribute.FixedValue = factura.Namespace;
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "VFacturaDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = factura.GetSchemaSerializable();
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
                this.columnPais = new DataColumn("Pais", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPais);
                this.columnbasica_id = new DataColumn("basica_id", typeof(string), null, MappingType.Element);
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
                this.columnfecha = new DataColumn("fecha", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnfecha);
                this.columntratamiento_id = new DataColumn("tratamiento_id", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columntratamiento_id);
                this.columnDescT = new DataColumn("DescT", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDescT);
                this.columnimporte = new DataColumn("importe", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnimporte);
                this.columndescuento = new DataColumn("descuento", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columndescuento);
                this.columndebe = new DataColumn("debe", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columndebe);
                this.columnhaber = new DataColumn("haber", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnhaber);
                this.columnpeca = new DataColumn("peca", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpeca);
                this.columnrecibo_id = new DataColumn("recibo_id", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnrecibo_id);
                this.columnvalorrec = new DataColumn("valorrec", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnvalorrec);
                this.columnpoliza = new DataColumn("poliza", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpoliza);
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
                this.columnPais = base.Columns["Pais"];
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
                this.columnfecha = base.Columns["fecha"];
                this.columntratamiento_id = base.Columns["tratamiento_id"];
                this.columnDescT = base.Columns["DescT"];
                this.columnimporte = base.Columns["importe"];
                this.columndescuento = base.Columns["descuento"];
                this.columndebe = base.Columns["debe"];
                this.columnhaber = base.Columns["haber"];
                this.columnpeca = base.Columns["peca"];
                this.columnrecibo_id = base.Columns["recibo_id"];
                this.columnvalorrec = base.Columns["valorrec"];
                this.columnpoliza = base.Columns["poliza"];
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Factura.VFacturaRow(builder);
            }

            [DebuggerNonUserCode]
            public Factura.VFacturaRow NewVFacturaRow()
            {
                return (Factura.VFacturaRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VFacturaRowChanged != null)
                {
                    this.VFacturaRowChanged(this, new Factura.VFacturaRowChangeEvent((Factura.VFacturaRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VFacturaRowChanging != null)
                {
                    this.VFacturaRowChanging(this, new Factura.VFacturaRowChangeEvent((Factura.VFacturaRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VFacturaRowDeleted != null)
                {
                    this.VFacturaRowDeleted(this, new Factura.VFacturaRowChangeEvent((Factura.VFacturaRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VFacturaRowDeleting != null)
                {
                    this.VFacturaRowDeleting(this, new Factura.VFacturaRowChangeEvent((Factura.VFacturaRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveVFacturaRow(Factura.VFacturaRow row)
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

            [Browsable(false), DebuggerNonUserCode]
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
            public DataColumn fechaColumn
            {
                get
                {
                    return this.columnfecha;
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
            public Factura.VFacturaRow this[int index]
            {
                get
                {
                    return (Factura.VFacturaRow) base.Rows[index];
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
            public DataColumn PaisColumn
            {
                get
                {
                    return this.columnPais;
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
            public DataColumn recibo_idColumn
            {
                get
                {
                    return this.columnrecibo_id;
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
            public DataColumn valorrecColumn
            {
                get
                {
                    return this.columnvalorrec;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class VFacturaRow : DataRow
        {
            private Factura.VFacturaDataTable tableVFactura;

            [DebuggerNonUserCode]
            internal VFacturaRow(DataRowBuilder rb) : base(rb)
            {
                this.tableVFactura = (Factura.VFacturaDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool Isapellido1Null()
            {
                return base.IsNull(this.tableVFactura.apellido1Column);
            }

            [DebuggerNonUserCode]
            public bool Isapellido2Null()
            {
                return base.IsNull(this.tableVFactura.apellido2Column);
            }

            [DebuggerNonUserCode]
            public bool Isbasica_idNull()
            {
                return base.IsNull(this.tableVFactura.basica_idColumn);
            }

            [DebuggerNonUserCode]
            public bool IscifNull()
            {
                return base.IsNull(this.tableVFactura.cifColumn);
            }

            [DebuggerNonUserCode]
            public bool IscpostalNull()
            {
                return base.IsNull(this.tableVFactura.cpostalColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdebeNull()
            {
                return base.IsNull(this.tableVFactura.debeColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdescripcionNull()
            {
                return base.IsNull(this.tableVFactura.descripcionColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDescTNull()
            {
                return base.IsNull(this.tableVFactura.DescTColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdescuentoNull()
            {
                return base.IsNull(this.tableVFactura.descuentoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdireccionNull()
            {
                return base.IsNull(this.tableVFactura.direccionColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDIRECNull()
            {
                return base.IsNull(this.tableVFactura.DIRECColumn);
            }

            [DebuggerNonUserCode]
            public bool Isfactura_idNull()
            {
                return base.IsNull(this.tableVFactura.factura_idColumn);
            }

            [DebuggerNonUserCode]
            public bool IsfaxNull()
            {
                return base.IsNull(this.tableVFactura.faxColumn);
            }

            [DebuggerNonUserCode]
            public bool IsfechaNull()
            {
                return base.IsNull(this.tableVFactura.fechaColumn);
            }

            [DebuggerNonUserCode]
            public bool IshaberNull()
            {
                return base.IsNull(this.tableVFactura.haberColumn);
            }

            [DebuggerNonUserCode]
            public bool IsimporteNull()
            {
                return base.IsNull(this.tableVFactura.importeColumn);
            }

            [DebuggerNonUserCode]
            public bool IsnhcNull()
            {
                return base.IsNull(this.tableVFactura.nhcColumn);
            }

            [DebuggerNonUserCode]
            public bool IsnifNull()
            {
                return base.IsNull(this.tableVFactura.nifColumn);
            }

            [DebuggerNonUserCode]
            public bool IsnombreNull()
            {
                return base.IsNull(this.tableVFactura.nombreColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPaisNull()
            {
                return base.IsNull(this.tableVFactura.PaisColumn);
            }

            [DebuggerNonUserCode]
            public bool IspecaNull()
            {
                return base.IsNull(this.tableVFactura.pecaColumn);
            }

            [DebuggerNonUserCode]
            public bool IspoblacionNull()
            {
                return base.IsNull(this.tableVFactura.poblacionColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPOBNull()
            {
                return base.IsNull(this.tableVFactura.POBColumn);
            }

            [DebuggerNonUserCode]
            public bool IspolizaNull()
            {
                return base.IsNull(this.tableVFactura.polizaColumn);
            }

            [DebuggerNonUserCode]
            public bool IspostalNull()
            {
                return base.IsNull(this.tableVFactura.postalColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprovinciaNull()
            {
                return base.IsNull(this.tableVFactura.provinciaColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPROVNull()
            {
                return base.IsNull(this.tableVFactura.PROVColumn);
            }

            [DebuggerNonUserCode]
            public bool Isrecibo_idNull()
            {
                return base.IsNull(this.tableVFactura.recibo_idColumn);
            }

            [DebuggerNonUserCode]
            public bool IstelefonoNull()
            {
                return base.IsNull(this.tableVFactura.telefonoColumn);
            }

            [DebuggerNonUserCode]
            public bool Istratamiento_idNull()
            {
                return base.IsNull(this.tableVFactura.tratamiento_idColumn);
            }

            [DebuggerNonUserCode]
            public bool IsvalorrecNull()
            {
                return base.IsNull(this.tableVFactura.valorrecColumn);
            }

            [DebuggerNonUserCode]
            public void Setapellido1Null()
            {
                base[this.tableVFactura.apellido1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void Setapellido2Null()
            {
                base[this.tableVFactura.apellido2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void Setbasica_idNull()
            {
                base[this.tableVFactura.basica_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetcifNull()
            {
                base[this.tableVFactura.cifColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetcpostalNull()
            {
                base[this.tableVFactura.cpostalColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdebeNull()
            {
                base[this.tableVFactura.debeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdescripcionNull()
            {
                base[this.tableVFactura.descripcionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDescTNull()
            {
                base[this.tableVFactura.DescTColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdescuentoNull()
            {
                base[this.tableVFactura.descuentoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdireccionNull()
            {
                base[this.tableVFactura.direccionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDIRECNull()
            {
                base[this.tableVFactura.DIRECColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void Setfactura_idNull()
            {
                base[this.tableVFactura.factura_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetfaxNull()
            {
                base[this.tableVFactura.faxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetfechaNull()
            {
                base[this.tableVFactura.fechaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SethaberNull()
            {
                base[this.tableVFactura.haberColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetimporteNull()
            {
                base[this.tableVFactura.importeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetnhcNull()
            {
                base[this.tableVFactura.nhcColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetnifNull()
            {
                base[this.tableVFactura.nifColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetnombreNull()
            {
                base[this.tableVFactura.nombreColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPaisNull()
            {
                base[this.tableVFactura.PaisColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpecaNull()
            {
                base[this.tableVFactura.pecaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpoblacionNull()
            {
                base[this.tableVFactura.poblacionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPOBNull()
            {
                base[this.tableVFactura.POBColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpolizaNull()
            {
                base[this.tableVFactura.polizaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpostalNull()
            {
                base[this.tableVFactura.postalColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetprovinciaNull()
            {
                base[this.tableVFactura.provinciaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPROVNull()
            {
                base[this.tableVFactura.PROVColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void Setrecibo_idNull()
            {
                base[this.tableVFactura.recibo_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SettelefonoNull()
            {
                base[this.tableVFactura.telefonoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void Settratamiento_idNull()
            {
                base[this.tableVFactura.tratamiento_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetvalorrecNull()
            {
                base[this.tableVFactura.valorrecColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string apellido1
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.apellido1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'apellido1' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.apellido1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public string apellido2
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.apellido2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'apellido2' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.apellido2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public string basica_id
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.basica_idColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'basica_id' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.basica_idColumn] = value;
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
                        str = (string) base[this.tableVFactura.cifColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'cif' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.cifColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string cpostal
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.cpostalColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'cpostal' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.cpostalColumn] = value;
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
                        num = (decimal) base[this.tableVFactura.debeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'debe' in table 'VFactura' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableVFactura.debeColumn] = value;
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
                        str = (string) base[this.tableVFactura.descripcionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'descripcion' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.descripcionColumn] = value;
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
                        str = (string) base[this.tableVFactura.DescTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DescT' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.DescTColumn] = value;
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
                        num = (decimal) base[this.tableVFactura.descuentoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'descuento' in table 'VFactura' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableVFactura.descuentoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string DIREC
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.DIRECColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DIREC' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.DIRECColumn] = value;
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
                        str = (string) base[this.tableVFactura.direccionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'direccion' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.direccionColumn] = value;
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
                        str = (string) base[this.tableVFactura.factura_idColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'factura_id' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.factura_idColumn] = value;
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
                        str = (string) base[this.tableVFactura.faxColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'fax' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.faxColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public DateTime fecha
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tableVFactura.fechaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'fecha' in table 'VFactura' is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tableVFactura.fechaColumn] = value;
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
                        num = (decimal) base[this.tableVFactura.haberColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'haber' in table 'VFactura' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableVFactura.haberColumn] = value;
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
                        num = (decimal) base[this.tableVFactura.importeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'importe' in table 'VFactura' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableVFactura.importeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string nhc
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.nhcColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'nhc' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.nhcColumn] = value;
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
                        str = (string) base[this.tableVFactura.nifColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'nif' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.nifColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string nombre
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.nombreColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'nombre' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.nombreColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Pais
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.PaisColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Pais' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.PaisColumn] = value;
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
                        str = (string) base[this.tableVFactura.pecaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'peca' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.pecaColumn] = value;
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
                        str = (string) base[this.tableVFactura.POBColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'POB' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.POBColumn] = value;
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
                        str = (string) base[this.tableVFactura.poblacionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'poblacion' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.poblacionColumn] = value;
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
                        str = (string) base[this.tableVFactura.polizaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'poliza' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.polizaColumn] = value;
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
                        str = (string) base[this.tableVFactura.postalColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'postal' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.postalColumn] = value;
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
                        str = (string) base[this.tableVFactura.PROVColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PROV' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.PROVColumn] = value;
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
                        str = (string) base[this.tableVFactura.provinciaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'provincia' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.provinciaColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string recibo_id
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.recibo_idColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'recibo_id' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.recibo_idColumn] = value;
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
                        str = (string) base[this.tableVFactura.telefonoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'telefono' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.telefonoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string tratamiento_id
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.tratamiento_idColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'tratamiento_id' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.tratamiento_idColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string valorrec
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVFactura.valorrecColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'valorrec' in table 'VFactura' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVFactura.valorrecColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class VFacturaRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Factura.VFacturaRow eventRow;

            [DebuggerNonUserCode]
            public VFacturaRowChangeEvent(Factura.VFacturaRow row, DataRowAction action)
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
            public Factura.VFacturaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VFacturaRowChangeEventHandler(object sender, Factura.VFacturaRowChangeEvent e);
    }
}

