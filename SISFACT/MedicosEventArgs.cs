namespace SISFACT
{
    using System;

    public class MedicosEventArgs
    {
        private string _colegiado;
        private string _nome;
        private int _puntoservicio_id;

        public MedicosEventArgs(string colegiado, string nome, int puntoservicio_id)
        {
            this._colegiado = colegiado;
            this._nome = nome;
            this._puntoservicio_id = puntoservicio_id;
        }

        public string colegiado
        {
            get
            {
                return this._colegiado;
            }
        }

        public string Nome
        {
            get
            {
                return this._nome;
            }
        }

        public int puntoservicio_id
        {
            get
            {
                return this._puntoservicio_id;
            }
        }
    }
}

