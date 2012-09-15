namespace SISFACT
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class cUtentes
    {
        private DataTable _dtUtentes;
        private SqlConnection con = null;
        public const int nhc = 1;
        public const int Nome = 2;
        public const int paciente_id = 0;

        public cUtentes()
        {
            DataTable utentes = this.GetUtentes();
            this._dtUtentes = utentes;
        }

        public DataTable GetNHC(string nhc, int paciente_id)
        {
            DataTable dataTable = new DataTable();
            this.con = new SqlConnection(Security.GetCnn());
            string selectCommandText = "select paciente_id,NHC,nombre + ' ' + apellido1 AS Nome  from paciente";
            selectCommandText = selectCommandText + " where paciente.NHC like '" + nhc + "'";
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

        public DataTable GetNome(string nome, int paciente_id)
        {
            DataTable dataTable = new DataTable();
            this.con = new SqlConnection(Security.GetCnn());
            string selectCommandText = "select paciente_id,NHC,isnull(nombre,'') + ' ' + isnull(apellido1,'') AS Nome  from paciente";
            selectCommandText = selectCommandText + " where paciente.nombre +' '+paciente.apellido1 like '%" + nome + "%'";
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

        private DataTable GetUtentes()
        {
            DataTable dataTable = new DataTable();
            this.con = new SqlConnection(Security.GetCnn());
            string selectCommandText = "select paciente_id,NHC,isnull(nombre,'') + ' ' + isnull(apellido1,'')  AS Nome  from paciente";
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

        public DataTable Utentes
        {
            get
            {
                return this._dtUtentes;
            }
        }
    }
}

