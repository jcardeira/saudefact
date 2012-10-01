namespace SISFACT
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public static class Security
    {
        public static void Apply(string[] Permission, MenuStrip menuStrip1)
        {
            foreach (string str in Permission)
            {
                string str2 = str;
                if (str2 != null)
                {
                    if (!(str2 == "UTILIZADOR"))
                    {
                        if (str2 == "TRATAMENTOS")
                        {
                            goto Label_008F;
                        }
                        if (str2 == "FACTURACAO_FACT")
                        {
                            goto Label_00CF;
                        }
                        if (str2 == "FACTURACAO_DEV")
                        {
                            goto Label_0142;
                        }
                        if (str2 == "FACTURACAO_REC")
                        {
                            goto Label_01B2;
                        }
                    }
                    else
                    {
                        ((ToolStripMenuItem) menuStrip1.Items[0]).DropDownItems[0].Enabled = true;
                    }
                }
                goto Label_0222;
            Label_008F:
                ((ToolStripMenuItem) menuStrip1.Items[1]).Enabled = true;
                ((ToolStripMenuItem) menuStrip1.Items[1]).DropDownItems[0].Enabled = true;
                goto Label_0222;
            Label_00CF:
                ((ToolStripMenuItem) menuStrip1.Items[1]).Enabled = true;
                ((ToolStripMenuItem) menuStrip1.Items[1]).DropDownItems[1].Enabled = true;
                ((ToolStripMenuItem) ((ToolStripMenuItem) menuStrip1.Items[1]).DropDownItems[1]).DropDownItems[0].Enabled = true;
                goto Label_0222;
            Label_0142:
                ((ToolStripMenuItem) menuStrip1.Items[1]).Enabled = true;
                ((ToolStripMenuItem) menuStrip1.Items[1]).DropDownItems[1].Enabled = true;
                ((ToolStripMenuItem) ((ToolStripMenuItem) menuStrip1.Items[1]).DropDownItems[1]).DropDownItems[1].Enabled = true;
                goto Label_0222;
            Label_01B2:
                ((ToolStripMenuItem) menuStrip1.Items[1]).Enabled = true;
                ((ToolStripMenuItem) menuStrip1.Items[1]).DropDownItems[1].Enabled = true;
                ((ToolStripMenuItem) ((ToolStripMenuItem) menuStrip1.Items[1]).DropDownItems[1]).DropDownItems[2].Enabled = true;
            Label_0222:;
            }
        }

        public static string Decrypt(string cipherText, string Password)
        {
            byte[] cipherData = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            byte[] buffer2 = Decrypt(cipherData, bytes.GetBytes(0x20), bytes.GetBytes(0x10));
            return Encoding.Unicode.GetString(buffer2);
        }

        public static byte[] Decrypt(byte[] cipherData, string Password)
        {
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            return Decrypt(cipherData, bytes.GetBytes(0x20), bytes.GetBytes(0x10));
        }

        public static void Decrypt(string fileIn, string fileOut, string Password)
        {
            int num2;
            FileStream stream = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            FileStream stream2 = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = bytes.GetBytes(0x20);
            rijndael.IV = bytes.GetBytes(0x10);
            CryptoStream stream3 = new CryptoStream(stream2, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
            int count = 0x1000;
            byte[] buffer = new byte[count];
            do
            {
                num2 = stream.Read(buffer, 0, count);
                stream3.Write(buffer, 0, num2);
            }
            while (num2 != 0);
            stream3.Close();
            stream.Close();
        }

        public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream stream = new MemoryStream();
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = Key;
            rijndael.IV = IV;
            CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(cipherData, 0, cipherData.Length);
            stream2.Close();
            return stream.ToArray();
        }

        public static byte[] Encrypt(byte[] clearData, string Password)
        {
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            return Encrypt(clearData, bytes.GetBytes(0x20), bytes.GetBytes(0x10));
        }

        public static string Encrypt(string clearText, string Password)
        {
            byte[] clearData = Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            return Convert.ToBase64String(Encrypt(clearData, bytes.GetBytes(0x20), bytes.GetBytes(0x10)));
        }

        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream stream = new MemoryStream();
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = Key;
            rijndael.IV = IV;
            CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(clearData, 0, clearData.Length);
            stream2.Close();
            return stream.ToArray();
        }

        public static void Encrypt(string fileIn, string fileOut, string Password)
        {
            int num2;
            FileStream stream = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            FileStream stream2 = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = bytes.GetBytes(0x20);
            rijndael.IV = bytes.GetBytes(0x10);
            CryptoStream stream3 = new CryptoStream(stream2, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            int count = 0x1000;
            byte[] buffer = new byte[count];
            do
            {
                num2 = stream.Read(buffer, 0, count);
                stream3.Write(buffer, 0, num2);
            }
            while (num2 != 0);
            stream3.Close();
            stream.Close();
        }

        public static string GetCnn()
        {
            string gama = Getgama();
            switch (gama)
            {
                case "MEDINFOT-471C1F":
                {
                    string str2 = ConfigurationSettings.AppSettings["SqlCnn"].Replace("servidor", "MEDINFOT-471C1F");
                    break;
                }
                case "Antonio-NLS":
                    return ConfigurationSettings.AppSettings["SqlCnn"].Replace("servidor", @".\sql2005").Replace("a27pw82xb", "sa1234");
            }
            string servidor = GetServidor(gama);
            return ConfigurationSettings.AppSettings["SqlCnn"].Replace("servidor", servidor);
        }

        public static string Getgama()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry hostByName = Dns.GetHostByName(hostName);
            switch (hostName)
            {
                case "Antonio-NLS":
                    return "20";

                case "MEDINFOT-471C1F":
                    return "MEDINFOT-471C1F";
            }
            IPAddress[] addressList = hostByName.AddressList;
            for (int i = 0; i < addressList.Length; i++)
            {
                if (addressList[i].ToString().StartsWith("192."))
                {
                    string str2 = "";
                    str2 = addressList[i].ToString().Remove(addressList[i].ToString().LastIndexOf("."));
                    return str2.Remove(0, str2.LastIndexOf(".") + 1);
                }
            }
            return "";
        }

        public static void GetIpSMS(out string clinicaip, out string clinica)
        {
            string servidor = GetServidor(Getgama());
            clinicaip = "";
            clinica = "";
            XmlTextReader reader = new XmlTextReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt\GamasIP.xml");
            XmlDocument document = new XmlDocument();
            document.Load(reader);
            reader.Close();
            string xpath = "connections/ips/gama/servidor";
            foreach (XmlNode node in document.SelectNodes(xpath))
            {
                if (node.InnerText == servidor)
                {
                    XmlNode nextSibling = node.NextSibling;
                    clinicaip = nextSibling.InnerText;
                    nextSibling = nextSibling.NextSibling;
                    clinica = nextSibling.InnerText;
                }
            }
        }

        public static void GetSenderAndPhone(out string senderID, out string senderPhone)
        {
            string servidor = GetServidor(Getgama());
            senderID = "";
            senderPhone = "";
            XmlTextReader reader = new XmlTextReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt\GamasIP.xml");
            XmlDocument document = new XmlDocument();
            document.Load(reader);
            reader.Close();
            string xpath = "connections/ips/gama/servidor";
            foreach (XmlNode node in document.SelectNodes(xpath))
            {
                if (node.InnerText == servidor)
                {
                    XmlNode nextSibling = node.NextSibling;
                    nextSibling = nextSibling.NextSibling;
                    nextSibling = nextSibling.NextSibling;
                    senderID = nextSibling.InnerText;
                    nextSibling = nextSibling.NextSibling;
                    senderPhone = nextSibling.InnerText;
                }
            }
        }

        public static string GetServidor(string gama)
        {
            bool flag = false;
            XmlTextReader reader = new XmlTextReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\rpt\GamasIP.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text:
                        if (!flag)
                        {
                            break;
                        }
                        return reader.Value;

                    default:
                        goto Label_0090;
                }
                if (reader.Value == gama)
                {
                    flag = true;
                }
            Label_0090:;
            }
            return "";
        }

        public static bool TestPermission(string[] perm, string KEY)
        {
            for (int i = 0; i < perm.Length; i++)
            {
                if (perm[i] == KEY)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

