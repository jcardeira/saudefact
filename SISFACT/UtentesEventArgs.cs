namespace SISFACT
{
    using System;

    public class UtentesEventArgs
    {
        private string _nhc;
        private string _nome;
        private int _paciente_id;

        public UtentesEventArgs(string nhc, string nome, int paciente_id)
        {
            this._nhc = nhc;
            this._nome = nome;
            this._paciente_id = paciente_id;
        }

        public string nhc
        {
            get
            {
                return this._nhc;
            }
        }

        public string Nome
        {
            get
            {
                return this._nome;
            }
        }

        public int paciente_id
        {
            get
            {
                return this._paciente_id;
            }
        }
    }
}

