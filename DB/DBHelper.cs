using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using SaudeFact.Properties;
using System.Data;

namespace SaudeFact.DB
{
    public class DBHelper
    {
        public static DataSet GetInvoices(DateTime start, DateTime end)
        {
            string q = @"select factura_id invoiceno, fecha invoicedate, fecha systementrydate, nhc customerid, tratamiento_id productcode,
desct productdescription, debe unitprice, fecha taxpointdate, debe creditamount, importe-debe settlementamount
from vfactura2

where fecha between @start and @end
order by factura_id";
            return GetDataSet(start, end,q);

        }
        public static DataSet GetProductsWithInvs(DateTime start, DateTime end)
        {
            string q = @"select distinct 'S' producttype, t.tratamiento_id productcode, t.descripcion productdescription, t.tratamiento_id productnumbercode

 from actuacion act join factura fact on act.factura_id=fact.factura_id 
 join tratamiento t on act.tratamiento_id = t.tratamiento_id
where fact.fecha between @start and @end";
            return GetDataSet(start, end, q);
        }

        public static DataSet GetCustomersWithInvs(DateTime start, DateTime end)
        {
            string q = @"
select distinct 'Desconhecido' AccountID, pac.nhc customerid, 
pac.nif customertaxid, isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') as CompanyName, 
pac.direccion AddressDetail, pac.poblacion city, pac.cpostal postalcode, 'PT' Country

 from actuacion act join factura fact on act.factura_id=fact.factura_id 
join paciente pac on pac.paciente_id = act.paciente_id

where fact.fecha between @start and @end";

            return  GetDataSet(start, end, q);
            
        }

        private static DataSet GetDataSet(DateTime start, DateTime end, string q)
        {
            DataSet result = new DataSet();
            using (SqlConnection sconn = new SqlConnection(Settings.Default.sqlConn))
            {
                SqlDataAdapter a = new SqlDataAdapter(q, sconn);
                a.SelectCommand.Parameters.AddWithValue("@start", start);
                a.SelectCommand.Parameters.AddWithValue("@end", end);
                sconn.Open();
                a.Fill(result);
            }
            return result;
        }

        public static DataRow GetHeader()
        {
            string q = "select nif companyid, nombre companyname, direccion addressdetail, poblacion city, postal postalcode from basica";
            DataSet ds = GetDataSet(DateTime.Now, DateTime.Now, q);
            return ds.Tables[0].Rows[0];
        }
    }
}
