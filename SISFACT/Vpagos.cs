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

    [Serializable, XmlRoot("Vpagos"), ToolboxItem(true), XmlSchemaProvider("GetTypedDataSetSchema"), HelpKeyword("vs.data.DataSet"), DesignerCategory("code"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class Vpagos : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VpagosDataTable tableVpagos;

        [DebuggerNonUserCode]
        public Vpagos()
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
        protected Vpagos(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["Vpagos"] != null)
                    {
                        base.Tables.Add(new VpagosDataTable(dataSet.Tables["Vpagos"]));
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
            Vpagos vpagos = (Vpagos) base.Clone();
            vpagos.InitVars();
            vpagos.SchemaSerializationMode = this.SchemaSerializationMode;
            return vpagos;
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
            Vpagos vpagos = new Vpagos();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny();
            item.Namespace = vpagos.Namespace;
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = vpagos.GetSchemaSerializable();
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
            base.DataSetName = "Vpagos";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/Vpagos.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableVpagos = new VpagosDataTable();
            base.Tables.Add(this.tableVpagos);
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
            this.tableVpagos = (VpagosDataTable) base.Tables["Vpagos"];
            if (initTable && (this.tableVpagos != null))
            {
                this.tableVpagos.InitVars();
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
                if (dataSet.Tables["Vpagos"] != null)
                {
                    base.Tables.Add(new VpagosDataTable(dataSet.Tables["Vpagos"]));
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
        private bool ShouldSerialize_Vpagos()
        {
            return false;
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

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public VpagosDataTable _Vpagos
        {
            get
            {
                return this.tableVpagos;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
        public class VpagosDataTable : TypedTableBase<Vpagos.VpagosRow>
        {
            private DataColumn columnapellido1;
            private DataColumn columnapellido2;
            private DataColumn columncif;
            private DataColumn columncpostal;
            private DataColumn columndescripcion;
            private DataColumn columnDIREC;
            private DataColumn columndireccion;
            private DataColumn columnfax;
            private DataColumn columnfecha;
            private DataColumn columnimporte;
            private DataColumn columnMoedaFracção;
            private DataColumn columnMoedaNome;
            private DataColumn columnnhc;
            private DataColumn columnnif;
            private DataColumn columnnombre;
            private DataColumn columnPais;
            private DataColumn columnPOB;
            private DataColumn columnpoblacion;
            private DataColumn columnpoliza;
            private DataColumn columnpostal;
            private DataColumn columnPROV;
            private DataColumn columnprovincia;
            private DataColumn columnrecibo_id;
            private DataColumn columntelefono;
            private DataColumn columntipo;

            public event Vpagos.VpagosRowChangeEventHandler VpagosRowChanged;

            public event Vpagos.VpagosRowChangeEventHandler VpagosRowChanging;

            public event Vpagos.VpagosRowChangeEventHandler VpagosRowDeleted;

            public event Vpagos.VpagosRowChangeEventHandler VpagosRowDeleting;

            [DebuggerNonUserCode]
            public VpagosDataTable()
            {
                base.TableName = "Vpagos";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal VpagosDataTable(DataTable table)
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
            protected VpagosDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddVpagosRow(Vpagos.VpagosRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public Vpagos.VpagosRow AddVpagosRow(string nhc, string nombre, string apellido1, string apellido2, string nif, string cpostal, string PROV, string POB, string DIREC, string Pais, string recibo_id, string descripcion, string direccion, string poblacion, string provincia, string telefono, string fax, string postal, string cif, DateTime fecha, string tipo, decimal importe, decimal MoedaFracção, decimal MoedaNome, string poliza)
            {
                Vpagos.VpagosRow row = (Vpagos.VpagosRow) base.NewRow();
                row.ItemArray = new object[] { 
                    nhc, nombre, apellido1, apellido2, nif, cpostal, PROV, POB, DIREC, Pais, recibo_id, descripcion, direccion, poblacion, provincia, telefono, 
                    fax, postal, cif, fecha, tipo, importe, MoedaFracção, MoedaNome, poliza
                 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                Vpagos.VpagosDataTable table = (Vpagos.VpagosDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new Vpagos.VpagosDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(Vpagos.VpagosRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                Vpagos vpagos = new Vpagos();
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
                attribute.FixedValue = vpagos.Namespace;
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "VpagosDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = vpagos.GetSchemaSerializable();
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
                this.columnrecibo_id = new DataColumn("recibo_id", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnrecibo_id);
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
                this.columnfecha = new DataColumn("fecha", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnfecha);
                this.columntipo = new DataColumn("tipo", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columntipo);
                this.columnimporte = new DataColumn("importe", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnimporte);
                this.columnMoedaFracção = new DataColumn("MoedaFrac\x00e7\x00e3o", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnMoedaFracção);
                this.columnMoedaNome = new DataColumn("MoedaNome", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnMoedaNome);
                this.columnpoliza = new DataColumn("poliza", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpoliza);
                this.columnrecibo_id.Caption = "basica_id";
                this.columntipo.Caption = "tratamiento_id";
                this.columnMoedaFracção.Caption = "descuento";
                this.columnMoedaNome.Caption = "debe";
                base.ExtendedProperties.Add("Generator_TablePropName", "_Vpagos");
                base.ExtendedProperties.Add("Generator_UserTableName", "Vpagos");
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
                this.columnrecibo_id = base.Columns["recibo_id"];
                this.columndescripcion = base.Columns["descripcion"];
                this.columndireccion = base.Columns["direccion"];
                this.columnpoblacion = base.Columns["poblacion"];
                this.columnprovincia = base.Columns["provincia"];
                this.columntelefono = base.Columns["telefono"];
                this.columnfax = base.Columns["fax"];
                this.columnpostal = base.Columns["postal"];
                this.columncif = base.Columns["cif"];
                this.columnfecha = base.Columns["fecha"];
                this.columntipo = base.Columns["tipo"];
                this.columnimporte = base.Columns["importe"];
                this.columnMoedaFracção = base.Columns["MoedaFrac\x00e7\x00e3o"];
                this.columnMoedaNome = base.Columns["MoedaNome"];
                this.columnpoliza = base.Columns["poliza"];
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Vpagos.VpagosRow(builder);
            }

            [DebuggerNonUserCode]
            public Vpagos.VpagosRow NewVpagosRow()
            {
                return (Vpagos.VpagosRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VpagosRowChanged != null)
                {
                    this.VpagosRowChanged(this, new Vpagos.VpagosRowChangeEvent((Vpagos.VpagosRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VpagosRowChanging != null)
                {
                    this.VpagosRowChanging(this, new Vpagos.VpagosRowChangeEvent((Vpagos.VpagosRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VpagosRowDeleted != null)
                {
                    this.VpagosRowDeleted(this, new Vpagos.VpagosRowChangeEvent((Vpagos.VpagosRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VpagosRowDeleting != null)
                {
                    this.VpagosRowDeleting(this, new Vpagos.VpagosRowChangeEvent((Vpagos.VpagosRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveVpagosRow(Vpagos.VpagosRow row)
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
            public DataColumn descripcionColumn
            {
                get
                {
                    return this.columndescripcion;
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
            public DataColumn importeColumn
            {
                get
                {
                    return this.columnimporte;
                }
            }

            [DebuggerNonUserCode]
            public Vpagos.VpagosRow this[int index]
            {
                get
                {
                    return (Vpagos.VpagosRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn MoedaFracçãoColumn
            {
                get
                {
                    return this.columnMoedaFracção;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn MoedaNomeColumn
            {
                get
                {
                    return this.columnMoedaNome;
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
            public DataColumn tipoColumn
            {
                get
                {
                    return this.columntipo;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class VpagosRow : DataRow
        {
            private Vpagos.VpagosDataTable tableVpagos;

            [DebuggerNonUserCode]
            internal VpagosRow(DataRowBuilder rb) : base(rb)
            {
                this.tableVpagos = (Vpagos.VpagosDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool Isapellido1Null()
            {
                return base.IsNull(this.tableVpagos.apellido1Column);
            }

            [DebuggerNonUserCode]
            public bool Isapellido2Null()
            {
                return base.IsNull(this.tableVpagos.apellido2Column);
            }

            [DebuggerNonUserCode]
            public bool IscifNull()
            {
                return base.IsNull(this.tableVpagos.cifColumn);
            }

            [DebuggerNonUserCode]
            public bool IscpostalNull()
            {
                return base.IsNull(this.tableVpagos.cpostalColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdescripcionNull()
            {
                return base.IsNull(this.tableVpagos.descripcionColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdireccionNull()
            {
                return base.IsNull(this.tableVpagos.direccionColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDIRECNull()
            {
                return base.IsNull(this.tableVpagos.DIRECColumn);
            }

            [DebuggerNonUserCode]
            public bool IsfaxNull()
            {
                return base.IsNull(this.tableVpagos.faxColumn);
            }

            [DebuggerNonUserCode]
            public bool IsfechaNull()
            {
                return base.IsNull(this.tableVpagos.fechaColumn);
            }

            [DebuggerNonUserCode]
            public bool IsimporteNull()
            {
                return base.IsNull(this.tableVpagos.importeColumn);
            }

            [DebuggerNonUserCode]
            public bool IsMoedaFracçãoNull()
            {
                return base.IsNull(this.tableVpagos.MoedaFracçãoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsMoedaNomeNull()
            {
                return base.IsNull(this.tableVpagos.MoedaNomeColumn);
            }

            [DebuggerNonUserCode]
            public bool IsnhcNull()
            {
                return base.IsNull(this.tableVpagos.nhcColumn);
            }

            [DebuggerNonUserCode]
            public bool IsnifNull()
            {
                return base.IsNull(this.tableVpagos.nifColumn);
            }

            [DebuggerNonUserCode]
            public bool IsnombreNull()
            {
                return base.IsNull(this.tableVpagos.nombreColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPaisNull()
            {
                return base.IsNull(this.tableVpagos.PaisColumn);
            }

            [DebuggerNonUserCode]
            public bool IspoblacionNull()
            {
                return base.IsNull(this.tableVpagos.poblacionColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPOBNull()
            {
                return base.IsNull(this.tableVpagos.POBColumn);
            }

            [DebuggerNonUserCode]
            public bool IspolizaNull()
            {
                return base.IsNull(this.tableVpagos.polizaColumn);
            }

            [DebuggerNonUserCode]
            public bool IspostalNull()
            {
                return base.IsNull(this.tableVpagos.postalColumn);
            }

            [DebuggerNonUserCode]
            public bool IsprovinciaNull()
            {
                return base.IsNull(this.tableVpagos.provinciaColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPROVNull()
            {
                return base.IsNull(this.tableVpagos.PROVColumn);
            }

            [DebuggerNonUserCode]
            public bool Isrecibo_idNull()
            {
                return base.IsNull(this.tableVpagos.recibo_idColumn);
            }

            [DebuggerNonUserCode]
            public bool IstelefonoNull()
            {
                return base.IsNull(this.tableVpagos.telefonoColumn);
            }

            [DebuggerNonUserCode]
            public bool IstipoNull()
            {
                return base.IsNull(this.tableVpagos.tipoColumn);
            }

            [DebuggerNonUserCode]
            public void Setapellido1Null()
            {
                base[this.tableVpagos.apellido1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void Setapellido2Null()
            {
                base[this.tableVpagos.apellido2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetcifNull()
            {
                base[this.tableVpagos.cifColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetcpostalNull()
            {
                base[this.tableVpagos.cpostalColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdescripcionNull()
            {
                base[this.tableVpagos.descripcionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdireccionNull()
            {
                base[this.tableVpagos.direccionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDIRECNull()
            {
                base[this.tableVpagos.DIRECColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetfaxNull()
            {
                base[this.tableVpagos.faxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetfechaNull()
            {
                base[this.tableVpagos.fechaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetimporteNull()
            {
                base[this.tableVpagos.importeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetMoedaFracçãoNull()
            {
                base[this.tableVpagos.MoedaFracçãoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetMoedaNomeNull()
            {
                base[this.tableVpagos.MoedaNomeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetnhcNull()
            {
                base[this.tableVpagos.nhcColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetnifNull()
            {
                base[this.tableVpagos.nifColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetnombreNull()
            {
                base[this.tableVpagos.nombreColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPaisNull()
            {
                base[this.tableVpagos.PaisColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpoblacionNull()
            {
                base[this.tableVpagos.poblacionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPOBNull()
            {
                base[this.tableVpagos.POBColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpolizaNull()
            {
                base[this.tableVpagos.polizaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetpostalNull()
            {
                base[this.tableVpagos.postalColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetprovinciaNull()
            {
                base[this.tableVpagos.provinciaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPROVNull()
            {
                base[this.tableVpagos.PROVColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void Setrecibo_idNull()
            {
                base[this.tableVpagos.recibo_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SettelefonoNull()
            {
                base[this.tableVpagos.telefonoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SettipoNull()
            {
                base[this.tableVpagos.tipoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string apellido1
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVpagos.apellido1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'apellido1' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.apellido1Column] = value;
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
                        str = (string) base[this.tableVpagos.apellido2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'apellido2' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.apellido2Column] = value;
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
                        str = (string) base[this.tableVpagos.cifColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'cif' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.cifColumn] = value;
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
                        str = (string) base[this.tableVpagos.cpostalColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'cpostal' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.cpostalColumn] = value;
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
                        str = (string) base[this.tableVpagos.descripcionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'descripcion' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.descripcionColumn] = value;
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
                        str = (string) base[this.tableVpagos.DIRECColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DIREC' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.DIRECColumn] = value;
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
                        str = (string) base[this.tableVpagos.direccionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'direccion' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.direccionColumn] = value;
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
                        str = (string) base[this.tableVpagos.faxColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'fax' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.faxColumn] = value;
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
                        time = (DateTime) base[this.tableVpagos.fechaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'fecha' in table 'Vpagos' is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tableVpagos.fechaColumn] = value;
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
                        num = (decimal) base[this.tableVpagos.importeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'importe' in table 'Vpagos' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableVpagos.importeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal MoedaFracção
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableVpagos.MoedaFracçãoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'MoedaFrac\x00e7\x00e3o' in table 'Vpagos' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableVpagos.MoedaFracçãoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal MoedaNome
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableVpagos.MoedaNomeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'MoedaNome' in table 'Vpagos' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableVpagos.MoedaNomeColumn] = value;
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
                        str = (string) base[this.tableVpagos.nhcColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'nhc' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.nhcColumn] = value;
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
                        str = (string) base[this.tableVpagos.nifColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'nif' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.nifColumn] = value;
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
                        str = (string) base[this.tableVpagos.nombreColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'nombre' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.nombreColumn] = value;
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
                        str = (string) base[this.tableVpagos.PaisColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Pais' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.PaisColumn] = value;
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
                        str = (string) base[this.tableVpagos.POBColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'POB' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.POBColumn] = value;
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
                        str = (string) base[this.tableVpagos.poblacionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'poblacion' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.poblacionColumn] = value;
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
                        str = (string) base[this.tableVpagos.polizaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'poliza' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.polizaColumn] = value;
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
                        str = (string) base[this.tableVpagos.postalColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'postal' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.postalColumn] = value;
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
                        str = (string) base[this.tableVpagos.PROVColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PROV' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.PROVColumn] = value;
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
                        str = (string) base[this.tableVpagos.provinciaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'provincia' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.provinciaColumn] = value;
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
                        str = (string) base[this.tableVpagos.recibo_idColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'recibo_id' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.recibo_idColumn] = value;
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
                        str = (string) base[this.tableVpagos.telefonoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'telefono' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.telefonoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string tipo
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableVpagos.tipoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'tipo' in table 'Vpagos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVpagos.tipoColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class VpagosRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Vpagos.VpagosRow eventRow;

            [DebuggerNonUserCode]
            public VpagosRowChangeEvent(Vpagos.VpagosRow row, DataRowAction action)
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
            public Vpagos.VpagosRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VpagosRowChangeEventHandler(object sender, Vpagos.VpagosRowChangeEvent e);
    }
}

