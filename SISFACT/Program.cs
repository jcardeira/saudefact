namespace SISFACT
{
    using System;
    using System.Windows.Forms;
    using System.Diagnostics;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Data.CorreScriptBD();
            string[] perm = null;
            string user = null;
            int userid = 0;
            int num2 = 0;
            bool flag = false;
            try
            {
                while (num2 != 3)
                {
                    FrmLogin login = new FrmLogin();
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    perm = login.per;
                    user = login.user;
                    userid = login.userID;
                    if ((perm == null) | (perm.Length == 0))
                    {
                        new FrmMsg(1, "ERRO", "Utilizador incorrecto").ShowDialog();
                    }
                    else if (Security.TestPermission(perm, "LOGIN"))
                    {
                        flag = true;
                    }
                    else
                    {
                        new FrmMsg(1, "AVISO", "Utilizador desactivado").ShowDialog();
                    }
                    num2++;
                    if (flag)
                    {
                        break;
                    }
                }
                if (flag)
                {
                    Application.Run(new FrmMain(perm, userid, user));
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }
    }
}

