namespace SISFACT
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class cMedicos
    {
        private DataTable _dtMedicos;
        public const int colegiado = 1;
        private SqlConnection con = null;
        public const int Nome = 2;
        public const int puntoservicio_id = 0;

        public cMedicos()
        {
            DataTable medicos = this.GetMedicos();
            this._dtMedicos = medicos;
        }

        public DataTable GetColegiado(string colegiado, int puntoservicio_id)
        {
            DataTable dataTable = new DataTable();
            this.con = new SqlConnection(Security.GetCnn());
            string selectCommandText = "select puntoservicio_id,colegiado,isnull(nombre,'')+' '+isnull(apellido1,'') as Nome from puntoservicio";
            selectCommandText = selectCommandText + " where puntoservicio.colegiado like '" + colegiado + "' and pasivo='N'";
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

        private DataTable GetMedicos()
        {
            DataTable dataTable = new DataTable();
            this.con = new SqlConnection(Security.GetCnn());
            string selectCommandText = "select puntoservicio_id,isnull(colegiado,'') as colegiado,isnull(nombre,'') + ' ' + isnull(apellido1,'') as Nome from puntoservicio where pasivo='N'";
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

        public DataTable GetNome(string nome, int puntoservicio_id)
        {
            DataTable dataTable = new DataTable();
            this.con = new SqlConnection(Security.GetCnn());
            string selectCommandText = "select puntoservicio_id,colegiado,isnull(nombre,'')+' '+isnull(apellido1,'') as Nome from puntoservicio";
            selectCommandText = selectCommandText + " where puntoservicio.nombre +' '+puntoservicio.apellido1 like '%" + nome + "%' and pasivo='N'";
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

        public DataTable Medicos
        {
            get
            {
                return this._dtMedicos;
            }
        }
    }
}

