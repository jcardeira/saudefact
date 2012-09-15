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

    [Serializable, HelpKeyword("vs.data.DataSet"), XmlSchemaProvider("GetTypedDataSetSchema"), XmlRoot("listagem"), ToolboxItem(true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), DesignerCategory("code")]
    public class listagem : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private listagemDataTable tablelistagem;

        [DebuggerNonUserCode]
        public listagem()
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
        protected listagem(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["listagem"] != null)
                    {
                        base.Tables.Add(new listagemDataTable(dataSet.Tables["listagem"]));
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
            listagem listagem = (listagem) base.Clone();
            listagem.InitVars();
            listagem.SchemaSerializationMode = this.SchemaSerializationMode;
            return listagem;
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
            listagem listagem = new listagem();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny();
            item.Namespace = listagem.Namespace;
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = listagem.GetSchemaSerializable();
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
            base.DataSetName = "listagem";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/listagem.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tablelistagem = new listagemDataTable();
            base.Tables.Add(this.tablelistagem);
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
            this.tablelistagem = (listagemDataTable) base.Tables["listagem"];
            if (initTable && (this.tablelistagem != null))
            {
                this.tablelistagem.InitVars();
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
                if (dataSet.Tables["listagem"] != null)
                {
                    base.Tables.Add(new listagemDataTable(dataSet.Tables["listagem"]));
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
        private bool ShouldSerialize_listagem()
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

        [DebuggerNonUserCode, Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public listagemDataTable _listagem
        {
            get
            {
                return this.tablelistagem;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
        public DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DebuggerNonUserCode]
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
        public class listagemDataTable : TypedTableBase<listagem.listagemRow>
        {
            private System.Data.DataColumn columnData;
            private System.Data.DataColumn columnEstado;
            private System.Data.DataColumn columnNumero;
            private System.Data.DataColumn columnPaciente;
            private System.Data.DataColumn columnTipo;
            private System.Data.DataColumn columnTotal;

            public event listagem.listagemRowChangeEventHandler listagemRowChanged;

            public event listagem.listagemRowChangeEventHandler listagemRowChanging;

            public event listagem.listagemRowChangeEventHandler listagemRowDeleted;

            public event listagem.listagemRowChangeEventHandler listagemRowDeleting;

            [DebuggerNonUserCode]
            public listagemDataTable()
            {
                base.TableName = "listagem";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal listagemDataTable(DataTable table)
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
            protected listagemDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddlistagemRow(listagem.listagemRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public listagem.listagemRow AddlistagemRow(string Numero, string Tipo, string Estado, string Data, string Paciente, decimal Total)
            {
                listagem.listagemRow row = (listagem.listagemRow) base.NewRow();
                row.ItemArray = new object[] { Numero, Tipo, Estado, Data, Paciente, Total };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                listagem.listagemDataTable table = (listagem.listagemDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new listagem.listagemDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(listagem.listagemRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                listagem listagem = new listagem();
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
                attribute.FixedValue = listagem.Namespace;
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "listagemDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = listagem.GetSchemaSerializable();
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
                this.columnNumero = new System.Data.DataColumn("Numero", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNumero);
                this.columnTipo = new System.Data.DataColumn("Tipo", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTipo);
                this.columnEstado = new System.Data.DataColumn("Estado", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEstado);
                this.columnData = new System.Data.DataColumn("Data", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnData);
                this.columnPaciente = new System.Data.DataColumn("Paciente", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPaciente);
                this.columnTotal = new System.Data.DataColumn("Total", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnTotal);
                base.ExtendedProperties.Add("Generator_TablePropName", "_listagem");
                base.ExtendedProperties.Add("Generator_UserTableName", "listagem");
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnNumero = base.Columns["Numero"];
                this.columnTipo = base.Columns["Tipo"];
                this.columnEstado = base.Columns["Estado"];
                this.columnData = base.Columns["Data"];
                this.columnPaciente = base.Columns["Paciente"];
                this.columnTotal = base.Columns["Total"];
            }

            [DebuggerNonUserCode]
            public listagem.listagemRow NewlistagemRow()
            {
                return (listagem.listagemRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new listagem.listagemRow(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.listagemRowChanged != null)
                {
                    this.listagemRowChanged(this, new listagem.listagemRowChangeEvent((listagem.listagemRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.listagemRowChanging != null)
                {
                    this.listagemRowChanging(this, new listagem.listagemRowChangeEvent((listagem.listagemRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.listagemRowDeleted != null)
                {
                    this.listagemRowDeleted(this, new listagem.listagemRowChangeEvent((listagem.listagemRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.listagemRowDeleting != null)
                {
                    this.listagemRowDeleting(this, new listagem.listagemRowChangeEvent((listagem.listagemRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemovelistagemRow(listagem.listagemRow row)
            {
                base.Rows.Remove(row);
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
            public System.Data.DataColumn DataColumn
            {
                get
                {
                    return this.columnData;
                }
            }

            [DebuggerNonUserCode]
            public System.Data.DataColumn EstadoColumn
            {
                get
                {
                    return this.columnEstado;
                }
            }

            [DebuggerNonUserCode]
            public listagem.listagemRow this[int index]
            {
                get
                {
                    return (listagem.listagemRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public System.Data.DataColumn NumeroColumn
            {
                get
                {
                    return this.columnNumero;
                }
            }

            [DebuggerNonUserCode]
            public System.Data.DataColumn PacienteColumn
            {
                get
                {
                    return this.columnPaciente;
                }
            }

            [DebuggerNonUserCode]
            public System.Data.DataColumn TipoColumn
            {
                get
                {
                    return this.columnTipo;
                }
            }

            [DebuggerNonUserCode]
            public System.Data.DataColumn TotalColumn
            {
                get
                {
                    return this.columnTotal;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class listagemRow : DataRow
        {
            private listagem.listagemDataTable tablelistagem;

            [DebuggerNonUserCode]
            internal listagemRow(DataRowBuilder rb) : base(rb)
            {
                this.tablelistagem = (listagem.listagemDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsDataNull()
            {
                return base.IsNull(this.tablelistagem.DataColumn);
            }

            [DebuggerNonUserCode]
            public bool IsEstadoNull()
            {
                return base.IsNull(this.tablelistagem.EstadoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsNumeroNull()
            {
                return base.IsNull(this.tablelistagem.NumeroColumn);
            }

            [DebuggerNonUserCode]
            public bool IsPacienteNull()
            {
                return base.IsNull(this.tablelistagem.PacienteColumn);
            }

            [DebuggerNonUserCode]
            public bool IsTipoNull()
            {
                return base.IsNull(this.tablelistagem.TipoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsTotalNull()
            {
                return base.IsNull(this.tablelistagem.TotalColumn);
            }

            [DebuggerNonUserCode]
            public void SetDataNull()
            {
                base[this.tablelistagem.DataColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetEstadoNull()
            {
                base[this.tablelistagem.EstadoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetNumeroNull()
            {
                base[this.tablelistagem.NumeroColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPacienteNull()
            {
                base[this.tablelistagem.PacienteColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetTipoNull()
            {
                base[this.tablelistagem.TipoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetTotalNull()
            {
                base[this.tablelistagem.TotalColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string Data
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablelistagem.DataColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Data' in table 'listagem' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablelistagem.DataColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Estado
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablelistagem.EstadoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Estado' in table 'listagem' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablelistagem.EstadoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Numero
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablelistagem.NumeroColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Numero' in table 'listagem' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablelistagem.NumeroColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Paciente
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablelistagem.PacienteColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Paciente' in table 'listagem' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablelistagem.PacienteColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Tipo
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablelistagem.TipoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Tipo' in table 'listagem' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablelistagem.TipoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public decimal Total
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tablelistagem.TotalColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Total' in table 'listagem' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablelistagem.TotalColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class listagemRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private listagem.listagemRow eventRow;

            [DebuggerNonUserCode]
            public listagemRowChangeEvent(listagem.listagemRow row, DataRowAction action)
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
            public listagem.listagemRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void listagemRowChangeEventHandler(object sender, listagem.listagemRowChangeEvent e);
    }
}

