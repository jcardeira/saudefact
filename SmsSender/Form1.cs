using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CardeiraVenancio;
using System.Configuration;
using System.Net;
using System.Diagnostics;
using System.Data.Odbc;
using CardeiraVenancio.Properties;

namespace SmsSender
{
    public partial class Form1 : Form
    {
        CardeiraVenancio.Consultas.sp_consultasDataTable dt;
        public string Connection;
        public string Clinica;
        public string SenderID;
        public string SenderPhone;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(Form parent)
        {
            InitializeComponent();
            base.MdiParent = parent;
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CardeiraVenancio.ConsultasTableAdapters.sp_consultasTableAdapter c = new CardeiraVenancio.ConsultasTableAdapters.sp_consultasTableAdapter();
             dt = new Consultas.sp_consultasDataTable();
            OdbcDataAdapter a = new OdbcDataAdapter();
            
            DateTime d = DateTime.Now.AddDays(1);
            d= d-d.TimeOfDay;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                d = d.AddDays(1);
            string dayFrom = d.ToString("dd-MM-yyyy");
            d=d.AddDays(1);
            string dayTo = d.ToString("dd-MM-yyyy"); 
            string sqlQuery = string.Format("select  fechaini,  nombre, apellido1, c.telefono, p.telefono2, p.telefono3, sexo, pacientenuevo  from contacto  c join paciente p on c.paciente_id=p.paciente_id where nombre != 'BLOQUEADO' and anulado='No' and fechaini > '{0}' and fechaini < '{1}' order by fechaini", dayFrom, dayTo);
            a.SelectCommand = new OdbcCommand(sqlQuery);
            Trace.WriteLine(sqlQuery);

            string cs = "Driver={SQL Server};uid=recepcion;pwd=vitalrec;server="+Connection;
            using (OdbcConnection con = new OdbcConnection(cs))
            {
                con.Open();
                a.SelectCommand.Connection = con;
                a.Fill(dt);
            }

            
            
            string to=null, when, time;
            foreach (Consultas.sp_consultasRow r in dt)
            {
                if (!r.IstelefonoNull() && !r.telefono.StartsWith("9"))
                {
                    if (!r.Istelefono2Null() && r.telefono2.StartsWith("9"))
                        r.telefono = r.telefono2;
                }
                if (r.apellido1 != null && r.apellido1.Length > 0)
                {
                    to = r.apellido1[0] + r.apellido1.Substring(1).ToLower();
                    
                }
                to = r.sexo == "V" ? "Sr(a) " + to : "Sra " + to;
                when = "amanhã";
                if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday) when = "segunda-feira";
                time = r.fechaini.ToShortTimeString();
                r.mensagem = string.Format(ConfigurationSettings.AppSettings["smsStringFormat"], to, when, time);
            }
            dataGridView1.DataSource=  dt;
           
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int len = dt.Select("telefono like '9%'").Length;
            if (MessageBox.Show("Tens a certeza que queres enviar estas " + len + " mensagens?", "Confirmação", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;
            button1.Text = "Por favor aguarda...";
            button1.Enabled = false;
            string guid = Guid.NewGuid().ToString();
            try
            {
                string to;
                foreach (Consultas.sp_consultasRow r in (Consultas.sp_consultasDataTable)dataGridView1.DataSource)
                {
                    if (!r.IstelefonoNull() && r.telefono.StartsWith("9"))
                    {
                        WebClient wc = new WebClient();

                        to = r.apellido1[0] + r.apellido1.Substring(1).ToLower();
                        to = r.sexo == "V" ? "Sr(a) " + to : "Sra " + to;
                        wc.QueryString["patient"] = to;

                        wc.QueryString["phoneNumber"] = "351" + r.telefono;
                        wc.QueryString["clinica"] = Clinica;
                        wc.QueryString["dia"] = "amanha";
                        wc.QueryString["hora"] = r.fechaini.ToShortTimeString();
                        wc.QueryString["guid"] = guid;
                        wc.QueryString["senderID"] = SenderID;
                        wc.QueryString["senderPhone"] = SenderPhone;

                        try
                        {
                            wc.DownloadString("http://sms.cardeiravenancio.com/sendsms/uploadfile");
                        }
                        catch (WebException ex)
                        {

                        }
                    }
                }
                Process.Start(new ProcessStartInfo("http://sms.cardeiravenancio.com/Sendsms.html?guid="+guid));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                button1.Text = "Enviar!";
                button1.Enabled = true;
            }
        }
    }
}
