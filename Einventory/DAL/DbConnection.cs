using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class DbConnection
    {
        //public static string objConnString = ConfigurationManager.AppSettings["ConnectionString"].ToString();

        private static SqlConnection objConn = new SqlConnection(objConnString());
        public static string connectionString = "";

        private static ConnectionPasswordDecryption oPwdDecryption;

        public static ConnectionPasswordDecryption GetInstance_of_decryptionclass()
        {
            if (oPwdDecryption == null)
            {
                oPwdDecryption = new ConnectionPasswordDecryption();
            }
            return oPwdDecryption;
        }

        static public string objConnString()
        {
            //To avoid storing the connection string in your code, 
            // retrieve it from a configuration file

            //return System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionString").ToString();

            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    oPwdDecryption = GetInstance_of_decryptionclass();
            //    connectionString = oPwdDecryption.DecryptConnectionPassword();
            //}
            //return connectionString;
            //string ConnectionStringEncrypted = ConfigurationManager.AppSettings["ConnectionStringEncrypted"].ToString();
            //if (ConnectionStringEncrypted.Trim().ToUpper() == "TRUE")
            //{
            //    if (string.IsNullOrEmpty(connectionString))
            //    {
            //        oPwdDecryption = GetInstance_of_decryptionclass();
            //        connectionString = oPwdDecryption.DecryptConnectionPassword();
            //    }
            //    return connectionString;
            //}
            //else
            //{
                connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            //}
            return connectionString;
        }

        public static SqlConnection Open()
        {
            try
            {
                if ((objConn.State == ConnectionState.Closed) || (objConn.State == ConnectionState.Broken))
                {
                    objConn.Open();
                }
                return objConn;
            }
            catch (Exception SqlEx)
            {
                throw (SqlEx);
            }
        }

        public static void Close()
        {
            try
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }
            }
            catch (Exception SqlEx)
            {
                throw (SqlEx);
            }
        }
    }
}
