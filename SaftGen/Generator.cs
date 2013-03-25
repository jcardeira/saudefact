using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;

namespace SaftGen
{
    public class Generator
    {
        private AuditFile af = new AuditFile();
        private List<Customer> custs = new List<Customer>();
        private List<Product> prods = new List<Product>();
        private List<SourceDocumentsSalesInvoicesInvoice> invs = new List<SourceDocumentsSalesInvoicesInvoice>();

        private DateTime startDate;
        private DateTime endDate;

        public Generator(DateTime start, DateTime end)
        {
            startDate = start;
            endDate = end.AddDays(-1);
        }

        public void GenerateXML()
        {
            FillMasterFiles();
            FillSourceDocuments();
            using (
            FileStream fs = new FileStream("c:/temp/out.xml", FileMode.Create))
            {
                new XmlSerializer(typeof(AuditFile)).Serialize(fs, af);
                //string a = sw.ToString();
            }
        }

        private void FillSourceDocuments()
        {
            af.SourceDocuments = new SourceDocuments();
            af.SourceDocuments.SalesInvoices = new SourceDocumentsSalesInvoices();   
            af.SourceDocuments.SalesInvoices.NumberOfEntries = invs.Count.ToString();
            af.SourceDocuments.SalesInvoices.Invoice = invs.ToArray();
            decimal totalcredit = 0;
            foreach (SourceDocumentsSalesInvoicesInvoice i in invs)
                totalcredit += i.DocumentTotals.NetTotal;
            af.SourceDocuments.SalesInvoices.TotalCredit = totalcredit;
            
        }

        private void FillMasterFiles()
        {
            int arraylen = custs.Count + prods.Count + 1;
            af.MasterFiles = new object[arraylen];
            int i = 0;
            FillTaxTable(i++);
            FillCustomers(i);
            i += custs.Count;
            FillProducts(i);            
        }

        private void FillCustomers(int i)
        {
            foreach (Customer c in custs)
                af.MasterFiles[i++] = c;
        }

        private void FillProducts(int i)
        {
            foreach (Product p in prods)
                af.MasterFiles[i++] = p;            
        }

        public void FillInvoices(DataSet ds)
        {
            string invoice="";
            invs.Clear();
            List<SourceDocumentsSalesInvoicesInvoiceLine> lines = new List<SourceDocumentsSalesInvoicesInvoiceLine>();
            SourceDocumentsSalesInvoicesInvoice i = new SourceDocumentsSalesInvoicesInvoice();
            int line=1;
            decimal nettotal=0;

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                if (invoice != "FA " + r["invoiceno"].ToString().Replace(' ', '/'))
                {
                    if (invoice != "")
                    {
                        i.DocumentTotals = new SourceDocumentsSalesInvoicesInvoiceDocumentTotals();
                        i.DocumentTotals.TaxPayable = 0;
                        i.DocumentTotals.NetTotal = nettotal;
                        i.DocumentTotals.GrossTotal = nettotal;
                        i.Line = lines.ToArray();
                        lines.Clear();
                        line = 1;
                        nettotal = 0;
                    }

                    i = new SourceDocumentsSalesInvoicesInvoice();
                    invs.Add(i);
                    invoice = "FA "+r["invoiceno"].ToString().Replace(' ','/');
                    i.InvoiceNo = invoice;
                    i.InvoiceDate = (DateTime)r["invoicedate"];
                    i.SystemEntryDate = (DateTime)r["systemEntryDate"];
                    i.CustomerID = (string)r["customerid"];
                    i.Hash = "0";
                    i.SelfBillingIndicator = "0";
                }
                    SourceDocumentsSalesInvoicesInvoiceLine l = new SourceDocumentsSalesInvoicesInvoiceLine();
                    lines.Add(l);
                    l.LineNumber = (line++).ToString() ;
                    l.ProductCode = r["ProductCode"].ToString();
                    l.ProductDescription = (string)r["ProductDescription"];
                    l.Quantity = 1;
                    l.UnitOfMeasure = "Unidade";
                    l.UnitPrice = (decimal)r["UnitPrice"];
                    l.TaxPointDate = (DateTime)r["TaxPointDate"];
                    l.Description = l.ProductDescription;
                    l.Item = (decimal)r["CreditAmount"];
                    l.SettlementAmount = (decimal)r["Settlementamount"];
                    l.ItemElementName = ItemChoiceType2.CreditAmount;
                    l.Tax = new Tax();
                    l.Tax.TaxType = TaxType.IVA;
                    l.Tax.TaxCountryRegion = "PT";
                    l.Tax.TaxCode = "ISE";
                    l.Tax.Item = 0;
                    l.Tax.ItemElementName = ItemChoiceType3.TaxPercentage;
                    l.TaxExemptionReason = "Isento ao abrigo do art. 9º do CIVA";
                    nettotal += l.Item;
                
            }
            i.DocumentTotals = new SourceDocumentsSalesInvoicesInvoiceDocumentTotals();
            i.DocumentTotals.TaxPayable = 0;
            i.DocumentTotals.NetTotal = nettotal;
            i.DocumentTotals.GrossTotal = nettotal;
            i.Line = lines.ToArray();
        }
        public void FillCustomers(DataSet ds)
        {
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Customer c = new Customer();
                custs.Add(c);
                c.AccountID = (string)r["AccountID"];
                c.CustomerID = (string)r["CustomerID"];
                c.CustomerTaxID = (string)r["CustomerTaxID"];
                c.CompanyName = (string)r["CompanyName"];
                c.BillingAddress = new AddressStructure();
                c.BillingAddress.AddressDetail = (string)r["AddressDetail"];
                c.BillingAddress.City = r.IsNull("city")?"   ":(string)r["city"]+" ";
                c.BillingAddress.PostalCode = (string)r["postalcode"];
                c.BillingAddress.Country = (string)r["country"];
                c.SelfBillingIndicator = "0";
            }
        }

        private void FillTaxTable(int i)
        {
            
            af.MasterFiles[0] = new TaxTable();
            ((TaxTable)af.MasterFiles[0]).TaxTableEntry = new TaxTableEntry[1];
            ((TaxTable)af.MasterFiles[0]).TaxTableEntry[0] = new TaxTableEntry();
            ((TaxTable)af.MasterFiles[0]).TaxTableEntry[0].TaxType = TaxType.IVA;
            ((TaxTable)af.MasterFiles[0]).TaxTableEntry[0].TaxCountryRegion = "PT";
            ((TaxTable)af.MasterFiles[0]).TaxTableEntry[0].TaxCode = "ISE";
            ((TaxTable)af.MasterFiles[0]).TaxTableEntry[0].Description = "ISENTO";
        }

        public void FillHeader(DataRow r)
        {
            af.Header = new Header();
            af.Header.AuditFileVersion = "1.01_01";
            af.Header.CompanyID = r["companyid"].ToString();
            af.Header.TaxRegistrationNumber = r["companyid"].ToString();
            af.Header.CompanyName = (string)r["CompanyName"];
            af.Header.CompanyAddress = new AddressStructurePT();
            af.Header.CompanyAddress.AddressDetail = (string)r["AddressDetail"];
            af.Header.CompanyAddress.City = (string)r["city"];
            af.Header.CompanyAddress.PostalCode = (string)r["postalcode"].ToString().Substring(0, 4) + "-" + r["postalcode"].ToString().Substring(4, 3);
            af.Header.CompanyAddress.Country = "PT";
            af.Header.FiscalYear = "2013";
            af.Header.StartDate = startDate;
            af.Header.EndDate = endDate;
            af.Header.CurrencyCode = "EUR";
            af.Header.DateCreated = DateTime.Now;
            af.Header.TaxEntity = "Global";
            af.Header.ProductCompanyTaxID = "508952395";
            af.Header.SoftwareCertificateNumber = "0";
            af.Header.ProductID = "Saúde Fact/HFJ MEDICINA DENTÁRIA LDA";
            af.Header.ProductVersion = "1.0";
        }

        
        public void FillProducts(DataSet dataSet)
        {
            prods.Clear();
            foreach (DataRow r in dataSet.Tables[0].Rows)
            {
                Product p = new Product();
                prods.Add(p);
                p.ProductCode = r["ProductCode"].ToString();
                p.ProductDescription = (string)r["ProductDescription"];
                p.ProductNumberCode = r["ProductNumberCode"].ToString();
                p.ProductType = ProductType.S;

            }
        }
    }
}
