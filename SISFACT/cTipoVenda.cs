namespace SISFACT
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    internal class cTipoVenda
    {
        private string _dev = "";
        private DataTable _dt;
        private SqlConnection con = null;
        public const int descripcion = 1;
        public const int devolucion = 2;
        public const int tipo_venta_id = 0;

        public cTipoVenda(string Dev)
        {
            this._dev = Dev;
            this._dt = this.GetTiposVenda();
        }

        public bool GetDescricao(int tipo_venta_id)
        {
            DataRow[] rowArray = this._dt.Select("tipo_venta_id=" + tipo_venta_id.ToString());
            bool flag = false;
            if (rowArray.Length > 0)
            {
                flag = (bool) rowArray[0][1];
            }
            return flag;
        }

        private DataTable GetTiposVenda()
        {
            DataTable dataTable = new DataTable();
            this.con = new SqlConnection(Security.GetCnn());
            string selectCommandText = "";
            if (this._dev != "D")
            {
                selectCommandText = "select tipo_venta_id, descripcion, devolucion from Tipo_venta where devolucion='N'";
            }
            else
            {
                selectCommandText = "select tipo_venta_id, descripcion, devolucion from Tipo_venta where devolucion='S'";
            }
            if ((this.con != null) && (this.con.State == ConnectionState.Open))
            {
                this.con.Close();
            }
            this.con.Open();
            try
            {
                new SqlDataAdapter(selectCommandText, this.con).Fill(dataTable);
                this.con.Close();
            }
            catch (Exception)
            {
            }
            return dataTable;
        }

        public DataTable TiposVenda
        {
            get
            {
                return this._dt;
            }
        }
    }
}

