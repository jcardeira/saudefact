namespace SISFACT
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class Data
    {
        private static SqlParameter BuildParameter(string name, SqlDbType type, ParameterDirection direction)
        {
            SqlParameter parameter = new SqlParameter(name, type);
            parameter.Direction = direction;
            return parameter;
        }

        private static SqlParameter BuildParameter(string name, SqlDbType type, ParameterDirection direction, int size)
        {
            SqlParameter parameter = new SqlParameter(name, type);
            parameter.Direction = direction;
            parameter.Size = size;
            return parameter;
        }

        private static SqlParameter BuildParameter(string name, SqlDbType type, ParameterDirection direction, object value)
        {
            SqlParameter parameter = new SqlParameter(name, type);
            parameter.Direction = direction;
            parameter.Value = value;
            return parameter;
        }

        private static SqlParameter BuildParameter(string name, SqlDbType type, ParameterDirection direction, int size, object value)
        {
            SqlParameter parameter = new SqlParameter(name, type);
            parameter.Direction = direction;
            parameter.Size = size;
            parameter.Value = value;
            return parameter;
        }

        internal static void CorreScriptBD()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Security.GetCnn());
                DirectoryInfo info = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace(@"file:\", "") + @"\rpt\");
                FileInfo info2 = null;
                foreach (FileInfo info3 in info.GetFiles())
                {
                    if (info3.Name.Contains(".sql"))
                    {
                        info2 = info3;
                        break;
                    }
                }
                if (info2 != null)
                {
                    string s = info2.Name.Replace("SISFACT", "").Replace(".sql", "");
                    string versao = GetVersao();
                    if (short.Parse(s) > short.Parse(versao))
                    {
                        string[] strArray = Regex.Replace(Regex.Replace(info2.OpenText().ReadToEnd(), "([/*][*]).*([*][/])", ""), @"\s{2,}", " ").Replace("\t", " ").Replace("\n", " ").Split(new string[] { "go\r\n", "go ", "go\t" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string str5 in strArray)
                        {
                            SqlCommand command = new SqlCommand(str5, connection);
                            command.Connection.Open();
                            command.ExecuteNonQuery();
                            command.Connection.Close();
                        }
                        SqlCommand command2 = new SqlCommand("Update CERT_SYS_VER SET CERT_VER='" + s + "'", connection);
                        command2.Connection.Open();
                        command2.ExecuteNonQuery();
                        command2.Connection.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                exception.Message.ToString();
            }
        }

        public static void CreateUser(ref SqlCommand cmd, string user, string pwd, bool LOGIN, bool UTILIZADOR, bool FACTURACAO_REC, bool FACTURACAO_DEV, bool ANALISE, bool FACTURACAO_FACT, bool FACTURACAO_NC)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CRIA_UTILIZADOR";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(BuildParameter("USER", SqlDbType.VarChar, ParameterDirection.Input, user.Length, user));
            cmd.Parameters.Add(BuildParameter("PWD", SqlDbType.VarChar, ParameterDirection.Input, pwd.Length, pwd));
            cmd.Parameters.Add(BuildParameter("seq", SqlDbType.Int, ParameterDirection.Output));
            cmd.ExecuteNonQuery();
            int num = Convert.ToInt32(cmd.Parameters["seq"].Value);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            if (LOGIN)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(6," + num + ")";
                cmd.ExecuteNonQuery();
            }
            if (UTILIZADOR)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(1," + num + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_REC)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(2," + num + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_DEV)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(3," + num + ")";
                cmd.ExecuteNonQuery();
            }
            if (ANALISE)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(4," + num + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_FACT)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(5," + num + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_NC)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(7," + num + ")";
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteUser(ref SqlCommand cmd, int id)
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.CommandText = "delete from cert_sys_acessos where cod_utilizador=" + id.ToString();
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from cert_sys_utilizadores where cod_utilizador=" + id.ToString();
            cmd.ExecuteNonQuery();
        }

        public DataTable executeResultSet(ref SqlConnection con, ref SqlCommand cmd, string strSQL)
        {
            DataTable dataTable = new DataTable();
            try
            {
                new SqlDataAdapter(strSQL, con).Fill(dataTable);
                return dataTable;
            }
            catch (Exception exception)
            {
                exception.Message.ToString();
                return dataTable;
            }
        }

        public object executeScalar(ref SqlConnection con, ref SqlCommand cmd, string mSql)
        {
            object obj2 = new object();
            try
            {
                cmd = new SqlCommand(mSql, con);
                obj2 = cmd.ExecuteScalar();
                if (obj2 == null)
                {
                    obj2 = -1;
                }
                return obj2;
            }
            catch (Exception exception)
            {
                exception.Message.ToString();
                return -1;
            }
        }

        public static DataTable GetAnalises(ref SqlCommand cmd, string NHC, string NOME, DateTime dtINI, DateTime dtEND)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select distinct ejercicio as Exjercicio,p.numero,p.fecha as Data,isnull(paciente.nombre ,'')+' '+isnull(paciente.apellido1,'') as Paciente, ";
            cmd.CommandText = cmd.CommandText + "isnull(med.nombre,'') +' '+isnull(med.apellido1,'') as Medico ,p.presupuesto_id as OrcamentoId, med.puntoservicio_id as MedicoID, ";
            cmd.CommandText = cmd.CommandText + "p.paciente_id, tarifa,p.descuento as Desconto, SUM(act.debe) Valor ";
            cmd.CommandText = cmd.CommandText + "from presupuesto p, paciente,puntoservicio med ,actuacion act where p.paciente_id= paciente.paciente_id ";
            cmd.CommandText = cmd.CommandText + "and p.puntoservicio_id=med.puntoservicio_id ";
            cmd.CommandText = cmd.CommandText + "and p.presupuesto_id =act.presupuesto_id and act.tratamiento_id is not null ";
            if ((NHC == "") & (NOME == ""))
            {
                cmd.CommandText = cmd.CommandText + "and p.fecha >= convert(datetime,'" + GetDate(dtINI) + "',105 ) and p.fecha <convert(datetime,'" + GetDate(dtEND) + "',105) +1 ";
            }
            string str = "";
            if (NHC != "")
            {
                str = str + " AND paciente.NHC like '" + NHC + "'";
            }
            if (NOME != "")
            {
                str = str + " AND paciente.nombre +' '+paciente.apellido1 like '%" + NOME + "%'";
            }
            if (str != "")
            {
                cmd.CommandText = cmd.CommandText + str;
            }
            cmd.CommandText = cmd.CommandText + " and act.actuacion_id not in( Select generador_id from actuacion act, tratamiento tr, puntoservicio ps where act.tratamiento_id is not null and act.tratamiento_id=tr.tratamiento_id and act.puntoservicio_id=ps.puntoservicio_id ";
            cmd.CommandText = cmd.CommandText + " and act.generador_id is not null and act.factura_id is not null) ";
            cmd.CommandText = cmd.CommandText + " group by ejercicio ,p.numero,p.fecha ,isnull(paciente.nombre ,'')+' '+isnull(paciente.apellido1,''), ";
            cmd.CommandText = cmd.CommandText + "isnull(med.nombre,'') +' '+isnull(med.apellido1,''),p.presupuesto_id, med.puntoservicio_id , ";
            cmd.CommandText = cmd.CommandText + "p.paciente_id, tarifa,p.descuento ";
            cmd.Parameters.Clear();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable GetAssociatedPermissions(SqlCommand cmd, int id)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from cert_sys_acessos where cod_utilizador=" + id.ToString();
            cmd.Parameters.Clear();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            return dataTable;
        }

        private static string GetDate(DateTime dt)
        {
            return (dt.Day.ToString().PadLeft(2, '0') + "-" + dt.Month.ToString().PadLeft(2, '0') + "-" + dt.Year.ToString());
        }

        public static DataTable GetDetalhe(ref SqlCommand sp, int presupuesto_id, SqlConnection cn)
        {
            sp = new SqlCommand("CertTrataDetalhe", cn);
            sp.CommandType = CommandType.StoredProcedure;
            sp.Parameters.Add("@PresupuestoId", SqlDbType.Int);
            sp.Parameters["@PresupuestoId"].Value = presupuesto_id;
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sp;
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable GetDocumentos(SqlCommand cmd, string NHC, string NOME, string NUMDOC, DateTime dtINI, DateTime dtEND, string ESTADO)
        {
            string str = "";
            string str2 = "";
            cmd.CommandType = CommandType.Text;
            string str3 = ESTADO;
            if (str3 != null)
            {
                if (!(str3 == "F"))
                {
                    if (str3 == "R")
                    {
                        str = "select case when r.fecha >=CONVERT(datetime,'01-01-2011',105) then convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10),r.numero) else  convert(varchar(10),r.numero) end as Numero,'Recibo' Tipo,'S' Estado, r.fecha Data, ";
                        str = (str + "isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') as Paciente, " + "SUM(p.importe) Total ") + "from recibo r , pagos p , paciente pac where r.recibo_id=p.recibo_id " + "and r.paciente_id=pac.paciente_id and p.tipo_venta_id<>5 ";
                        if ((NHC == "") & (NOME == ""))
                        {
                            str = str + "and r.fecha >= convert(datetime,'" + GetDate(dtINI) + "',105 ) and r.fecha < convert(datetime,'" + GetDate(dtEND) + "',105) +1 ";
                        }
                        if (NHC != "")
                        {
                            str2 = str2 + " AND pac.NHC like '" + NHC + "'";
                        }
                        if (NOME != "")
                        {
                            str2 = str2 + " AND pac.nombre +' '+pac.apellido1 like '%" + NOME + "%'";
                        }
                        if (NUMDOC != "")
                        {
                            str2 = str2 + " AND r.numero like '%" + NUMDOC + "%'";
                        }
                        if (str2 != "")
                        {
                            str = str + str2;
                        }
                        str = str + " group by r.numero  ,r.fecha,isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') " + " order by 4 ";
                    }
                    else if (str3 == "D")
                    {
                        str = "select case when r.fecha >=CONVERT(datetime,'01-01-2011',105) then convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10),r.numero) else  convert(varchar(10),r.numero) end Numero,'Devolu\x00e7\x00e3o' Tipo,'S' Estado, r.fecha Data, ";
                        str = (str + "isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') as Paciente, " + "SUM(p.importe) Total ") + "from recibo r , pagos p , paciente pac where r.recibo_id=p.recibo_id " + "and r.paciente_id=pac.paciente_id and p.tipo_venta_id=5 ";
                        if ((NHC == "") & (NOME == ""))
                        {
                            str = str + "and r.fecha >= convert(datetime,'" + GetDate(dtINI) + "',105 ) and r.fecha < convert(datetime,'" + GetDate(dtEND) + "',105) +1 ";
                        }
                        if (NHC != "")
                        {
                            str2 = str2 + " AND pac.NHC like '" + NHC + "'";
                        }
                        if (NOME != "")
                        {
                            str2 = str2 + " AND pac.nombre +' '+pac.apellido1 like '%" + NOME + "%'";
                        }
                        if (NUMDOC != "")
                        {
                            str2 = str2 + " AND r.numero like '%" + NUMDOC + "%'";
                        }
                        if (str2 != "")
                        {
                            str = str + str2;
                        }
                        str = str + " group by r.numero  ,r.fecha,isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') " + " order by 4 ";
                    }
                    else if (str3 == "C")
                    {
                        str = "Select distinct case when nc.data >=CONVERT(datetime,'01-01-2011',105) then convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10),nc.numero) else  convert(varchar(10),nc.numero) end Numero, ";
                        str = ((str + "'Nota de Cr\x00e9dito' Tipo,'S' Estado, nc.data Data," + "isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') as Paciente, ") + "SUM(ncd.valor) Total " + "from Cert_Nc nc,Cert_Nc_det ncd,paciente pac ") + "where pac.paciente_id=nc.paciente_id and " + "nc.nc_id=ncd.nc_id ";
                        if ((NHC == "") & (NOME == ""))
                        {
                            str = str + "and nc.data >= convert(datetime,'" + GetDate(dtINI) + "',105 ) and nc.data < convert(datetime,'" + GetDate(dtEND) + "',105) +1 ";
                        }
                        if (NHC != "")
                        {
                            str2 = str2 + " AND pac.NHC like '" + NHC + "'";
                        }
                        if (NOME != "")
                        {
                            str2 = str2 + " AND pac.nombre +' '+pac.apellido1 like '%" + NOME + "%'";
                        }
                        if (NUMDOC != "")
                        {
                            str2 = str2 + " AND nc.numero like '%" + NUMDOC + "%'";
                        }
                        if (str2 != "")
                        {
                            str = str + str2;
                        }
                        str = str + " group by nc.numero  ,nc.data,isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') " + " order by 4 ";
                    }
                    else if (str3 == "T")
                    {
                        str = "select  fact.factura_id Numero,'Factura' Tipo,fact.cobrada Estado,fact.fecha Data, ";
                        str = (str + "isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') as Paciente, " + "SUM(act.haber) Total ") + "from actuacion act , factura fact,paciente pac, tratamiento tr where act.factura_id=fact.factura_id " + "and fact.paciente_id=act.paciente_id and fact.paciente_id =pac.paciente_id and act.tratamiento_id=tr.tratamiento_id ";
                        if ((NHC == "") & (NOME == ""))
                        {
                            str = str + "and fact.fecha >= convert(datetime,'" + GetDate(dtINI) + "',105 ) and fact.fecha < convert(datetime,'" + GetDate(dtEND) + "',105) +1 ";
                        }
                        if (NHC != "")
                        {
                            str2 = str2 + " AND pac.NHC like '" + NHC + "'";
                        }
                        if (NOME != "")
                        {
                            str2 = str2 + " AND pac.nombre +' '+pac.apellido1 like '%" + NOME + "%'";
                        }
                        if (NUMDOC != "")
                        {
                            str2 = str2 + " AND fact.numero like '%" + NUMDOC + "%'";
                        }
                        if (str2 != "")
                        {
                            str = str + str2;
                        }
                        str = (((str + " group by fact.factura_id  ,fact.cobrada ,fact.fecha,isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') ") + " Union all " + "select r.recibo_id Numero,case p.tipo_venta_id when 5 then 'Devolu\x00e7\x00e3o' else 'Recibo' end Tipo,'S' Estado, r.fecha Data, ") + "isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') as Utente, " + "SUM(p.importe) Total ") + "from recibo r , pagos p , paciente pac where r.recibo_id=p.recibo_id " + "and r.paciente_id=pac.paciente_id ";
                        if ((NHC == "") & (NOME == ""))
                        {
                            str = str + "and r.fecha >= convert(datetime,'" + GetDate(dtINI) + "',105 ) and r.fecha < convert(datetime,'" + GetDate(dtEND) + "',105) +1 ";
                        }
                        if (NHC != "")
                        {
                            str2 = str2 + " AND pac.NHC like '" + NHC + "'";
                        }
                        if (NOME != "")
                        {
                            str2 = str2 + " AND pac.nombre +' '+pac.apellido1 like '%" + NOME + "%'";
                        }
                        if (NUMDOC != "")
                        {
                            str2 = str2 + " AND r.recibo_id =" + int.Parse(NUMDOC);
                        }
                        if (str2 != "")
                        {
                            str = str + str2;
                        }
                        str = str + " group by r.recibo_id  ,r.fecha,isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') ,p.tipo_venta_id " + " order by 1 ";
                    }
                }
                else
                {
                    str = "select  case when fact.fecha >=CONVERT(datetime,'01-01-2011',105) then convert(varchar(3),(select * from cert_sys_pre)) + ' ' + convert(varchar(10),fact.numero) else  convert(varchar(5),fact.numero) end  as Numero,'Factura' Tipo,fact.cobrada Estado,fact.fecha Data, ";
                    str = (str + "isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') as Paciente, " + "SUM(act.haber) Total ") + "from actuacion act , factura fact,paciente pac, tratamiento tr where act.factura_id=fact.factura_id " + "and fact.paciente_id=act.paciente_id and act.paciente_id =pac.paciente_id and act.tratamiento_id=tr.tratamiento_id ";
                        if ((NHC == "") & (NOME == ""))
                    {
                        str = str + "and fact.fecha >= convert(datetime,'" + GetDate(dtINI) + "',105 ) and fact.fecha < convert(datetime,'" + GetDate(dtEND) + "',105) +1 ";
                    }
                    if (NHC != "")
                    {
                        str2 = str2 + " AND pac.NHC like '" + NHC + "'";
                    }
                    if (NOME != "")
                    {
                        str2 = str2 + " AND pac.nombre +' '+pac.apellido1 like '%" + NOME + "%'";
                    }
                    if (NUMDOC != "")
                    {
                        str2 = str2 + " AND fact.numero like '%" + NUMDOC + "%'";
                    }
                    if (str2 != "")
                    {
                        str = str + str2;
                    }
                    str = str + " and haber>=0 group by fact.numero  ,fact.cobrada ,fact.fecha,isnull(pac.nombre ,'')+' '+isnull(pac.apellido1,'') " + " order by 4";
                }
            }
            cmd.CommandText = str;
            cmd.Parameters.Clear();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable GetFacturasDet(ref SqlCommand sp, int paciente_id, SqlConnection cn)
        {
            sp = new SqlCommand("CertFacturasDetalhe", cn);
            sp.CommandType = CommandType.StoredProcedure;
            sp.Parameters.Add("@PacienteId", SqlDbType.Int);
            sp.Parameters["@PacienteId"].Value = paciente_id;
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sp;
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable GetPacientes(ref SqlCommand sp, string Data, SqlConnection cn)
        {
            sp = new SqlCommand("GetPacientes", cn);
            sp.CommandType = CommandType.StoredProcedure;
            sp.Parameters.Add("@Data", SqlDbType.Text);
            sp.Parameters["@Data"].Value = Data;
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sp;
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static string[] GetPermissions(ref SqlCommand cmd, ref int userID, string name, string pwd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select sm.pagina,su.COD_UTILIZADOR from cert_sys_utilizadores su,cert_sys_acessos sa,cert_sys_menus sm where su.cod_utilizador=sa.cod_utilizador and sa.cod_menu= sm.cod_menu and su.name='" + name + "' and su.pass='" + pwd + "'";
            cmd.Parameters.Clear();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            string[] strArray = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (i == 0)
                {
                    userID = Convert.ToInt32(dataTable.Rows[i][1]);
                }
                strArray[i] = dataTable.Rows[i][0].ToString();
            }
            return strArray;
        }

        public static DataTable GetRecibos(ref SqlCommand sp, int paciente_id, SqlConnection cn)
        {
            sp.CommandType = CommandType.Text;
            sp = new SqlCommand("CertGetRecibos", cn);
            sp.CommandType = CommandType.StoredProcedure;
            sp.Parameters.Add("@PacienteId", SqlDbType.Int);
            sp.Parameters["@PacienteId"].Value = paciente_id;
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sp;
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable GetUsers(ref SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select COD_UTILIZADOR Codigo,NAME Nome from cert_sys_utilizadores";
            cmd.Parameters.Clear();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            return dataTable;
        }

        internal static string GetVersao()
        {
            try
            {
                string cmdText = "select cert_ver from Cert_sys_ver";
                SqlConnection connection = new SqlConnection(Security.GetCnn());
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Connection.Open();
                return new Data().executeScalar(ref connection, ref cmd, cmdText).ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        public static string GetVersaoBD()
        {
            try
            {
                string cmdText = "select cert_ver from Cert_sys_ver";
                SqlConnection connection = new SqlConnection(Security.GetCnn());
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Connection.Open();
                return new Data().executeScalar(ref connection, ref cmd, cmdText).ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        public static void ResetPWD(ref SqlCommand cmd, int ID, string pwd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE cert_sys_utilizadores set pass='" + pwd + "' where cod_utilizador=" + ID.ToString();
            cmd.Parameters.Clear();
            cmd.ExecuteNonQuery();
        }

        public static void SetRecibo(ref SqlCommand cmd, int id, DateTime data, decimal importe, int fpagid, int tpventaid, string notas, int recid, string tipo, int bid, DateTime dataaceite, int plazos, int periodo, string nident, DateTime dataup, int numero, string rtipo, int numrecibo)
        {
            cmd.CommandType = CommandType.Text;
            numero++;
            string str = "INSERT recibo (fecha,paciente_id,numero,tipo,num_recibo) VALUES (convert(datetime,'";
            str = string.Concat(new object[] { str, data, "' ,105),", id, ",", numero, ",'", rtipo, "',", numrecibo, ")" });
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            recid++;
            str = "";
            string str2 = importe.ToString().Replace(",", ".");
            str = "INSERT INTO pagos ([paciente_id],[fecha],[importe],[formapago_id]";
            str = (str + ",[tipo_venta_id],[notas],[recibo_id],[tipo],[banco_id],[f_acepta]") + ",[plazos],[periodo],[nidentificacion],[f_update])" + " VALUES ( ";
            str = string.Concat(new object[] { str, id, ",convert(datetime,'", data, "',105),", str2, "," });
            str = string.Concat(new object[] { str, fpagid, ",", tpventaid, ",'", notas, "',", recid, ",'", tipo, "'," });
            if (bid == 0)
            {
                str = str + "null";
            }
            else
            {
                str = str + bid;
            }
            str = string.Concat(new object[] { str, ",convert(datetime,'", dataaceite, "',105),", plazos, "," });
            if (periodo > 0)
            {
                str = str + periodo;
            }
            else
            {
                str = str + "null";
            }
            str = string.Concat(new object[] { str, ",'", nident, "',convert(datetime,'", dataup, "',105))" });
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
        }

        public static bool TestUser(ref SqlCommand cmd, string name)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from cert_sys_utilizadores where name='" + name + "'";
            cmd.Parameters.Clear();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            return (dataTable.Rows.Count > 0);
        }

        public static void UpdateUser(ref SqlCommand cmd, int id, string user, string pwd, bool LOGIN, bool UTILIZADOR, bool FACTURACAO_REC, bool FACTURACAO_DEV, bool ANALISE, bool FACTURACAO_FACT, bool FACTURACAO_NC)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE cert_sys_utilizadores set NAME='" + user + "' , pass='" + pwd + "' where cod_utilizador=" + id.ToString();
            cmd.Parameters.Clear();
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from cert_sys_acessos where cod_utilizador=" + id.ToString();
            cmd.ExecuteNonQuery();
            if (LOGIN)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(6," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (UTILIZADOR)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(1," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_REC)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(2," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_DEV)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(3," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (ANALISE)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(4," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_FACT)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(5," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_NC)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(7," + id + ")";
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateUserPermissions(ref SqlCommand cmd, int id, bool LOGIN, bool UTILIZADOR, bool FACTURACAO_REC, bool FACTURACAO_DEV, bool ANALISE, bool FACTURACAO_FACT, bool FACTURACAO_NC)
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.CommandText = "delete from cert_sys_acessos where cod_utilizador=" + id.ToString();
            cmd.ExecuteNonQuery();
            if (LOGIN)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(6," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (UTILIZADOR)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(1," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_REC)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(2," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_DEV)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(3," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (ANALISE)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(4," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_FACT)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(5," + id + ")";
                cmd.ExecuteNonQuery();
            }
            if (FACTURACAO_NC)
            {
                cmd.CommandText = "insert into cert_sys_acessos(COD_MENU,COD_UTILIZADOR) values(7," + id + ")";
                cmd.ExecuteNonQuery();
            }
        }
    }
}

