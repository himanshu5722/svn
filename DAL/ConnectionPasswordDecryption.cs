using System;
using System.Collections.Generic;
using System.Text;
//using CryptoXML;
using System.Data;
using System.Configuration;
//using System.Windows.Forms;

namespace DAL
{
    public class ConnectionPasswordDecryption
    {
        public string DecryptConnectionPassword()
        {
            string connection = string.Empty;

            try
            {
                //XMLEncryptor enc = new XMLEncryptor("EFKON", "efkon$123");
                //DataSet ds = enc.ReadEncryptedXML(Application.StartupPath + "\\EncryptedConnection.enc");
                DataSet ds = new DataSet();
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string dataSource = ds.Tables[0].Rows[0][0].ToString();
                    string userId = ds.Tables[0].Rows[0][1].ToString();
                    string passWord = ds.Tables[0].Rows[0][2].ToString();

                    connection = "Data Source=" + dataSource + "; User Id=" + userId + "; Password=" + passWord + ";";

                }

                if (connection == string.Empty)
                {
                    //MessageBox.Show("Connection string not found.");
                }

                return connection;

            }
            catch
            {
                //MessageBox.Show("Failed to read encrypted connection.");
                return connection = "";
            }

        }
    }
}