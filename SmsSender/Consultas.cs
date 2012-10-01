using System.Data.Odbc;
namespace CardeiraVenancio {
    
    
    public partial class Consultas {
    }
}

namespace CardeiraVenancio.ConsultasTableAdapters {
    
    
    public partial class sp_consultasTableAdapter {
        public OdbcCommand GetTheCommand(){
            return this.CommandCollection[1];
        }

        
    }
}
