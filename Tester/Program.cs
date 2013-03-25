using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaftGen;
using System.Data.SqlClient;
using Tester.Properties;
using SaudeFact.DB;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator g = new SaftGen.Generator();
            DateTime start = new DateTime(2013, 2, 1);
            DateTime end = new DateTime(2013, 3, 1);
            g.FillHeader(DBHelper.GetHeader());
            g.FillCustomers(DBHelper.GetCustomersWithInvs(start, end));
            g.FillProducts(DBHelper.GetProductsWithInvs(start, end));
            g.FillInvoices(DBHelper.GetInvoices(start, end));
            g.GenerateXML();
        }
    }
}
