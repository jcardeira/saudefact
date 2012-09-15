namespace SISFACT
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class cFormasPag
    {
        private DataTable _dtFormasPag;
        public const int banco = 2;
        private SqlConnection con = null;
        public const int descripcion = 1;
        public const int forma_pago_id = 0;
        public const int plazos = 3;

        public cFormasPag()
        {
            this._dtFormasPag = this.GetFormasPagamento();
        }

        public bool GetDescricao(int forma_pago_id)
        {
            DataRow[] rowArray = this._dtFormasPag.Select("forma_pago_id=" + forma_pago_id.ToString());
            bool flag = false;
            if (rowArray.Length > 0)
            {
                flag = (bool) rowArray[0][1];
            }
            return flag;
        }

        private DataTable GetFormasPagamento()
        {
            DataTable dataTable = new DataTable();
            this.con = new SqlConnection(Security.GetCnn());
            string selectCommandText = "select forma_pago_id, descripcion, banco, plazos from forma_pago";
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

        public DataTable FormasPagamento
        {
            get
            {
                return this._dtFormasPag;
            }
        }
    }
}

