using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using Log;

//namespace Lane_monitor.Classes
namespace DAL
{
    public class ClsCommonDBOperations
    {
        //public string mvcclassified = "false";
        private static ClsCommonDBOperations m_instance;
        SqlConnection connection = null;
      //  ErrorLog errorLog = new ErrorLog();

        public ClsCommonDBOperations()
        {
            connection = new SqlConnection(GetConnectionString());
        }
        //implementation of single ton calsss
        //so that only one instance is created

        public static ClsCommonDBOperations GetInstance_of_common_fu()
        {
            if (m_instance == null)
            {
                m_instance = new ClsCommonDBOperations();
            }
            return m_instance;
        }
        SqlManager QueryManager = SqlManager.Create(AppDomain.CurrentDomain.BaseDirectory + @"\XML\Master_Query.xml");

        public SqlCommand get_new_sql_connection(string commandname, SqlConnection con)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(commandname, con);
                cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["default_command_timeout"]);

                return cmd;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);

                // Error logging For elmah
                //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                return null;
            }
        }
        public SqlCommand get_new_sql_connection(string commandname, SqlConnection con, SqlTransaction transaction)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(commandname, con, transaction);
                cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["default_command_timeout"]);

                return cmd;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);

                // Error logging For elmah
                //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                return null;
            }

        }
        public SqlCommand get_new_sql_connection()
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["default_command_timeout"]);

                return cmd;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);

                // Error logging For elmah
                //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                return null;
            }

        }

        public bool Open_Sql_Connection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string user_code(string p_username, string p_password)
        {
            try
            {

                Open_Sql_Connection();

                String connectionString = String.Empty;
                SqlCommand objCmd = new SqlCommand();
                //objCmd.Connection = connection;
                //objCmd.CommandText = "F_CHK_USER_PASS_1";
                //objCmd.CommandType = CommandType.StoredProcedure;
                //objCmd.Parameters.Add("p_username", SqlType.VarChar).Value = p_username;
                //objCmd.Parameters.Add("p_password", SqlType.VarChar).Value = p_password;
                //objCmd.Parameters.Add("USER_ID_NO", SqlType.VarChar, 8).Direction = ParameterDirection.ReturnValue;
                //objCmd.ExecuteNonQuery();
                //connection.Close();
                // MessageBox.Show(Convert.ToString(objCmd.Parameters["USER_ID_NO"].Value));
                return Convert.ToString(objCmd.Parameters["USER_ID_NO"].Value);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return "0";
            }
            finally
            {
                connection.Close();
            }
        }

        public string user_lock(string p_username) // for user locking system 
        {
            try
            {

                //Open_Sql_Connection();
                //String connectionString = String.Empty;
                SqlCommand objCmd = new SqlCommand();
                //objCmd.Connection = connection;
                //objCmd.CommandText = "F_CHK_USER_LOCK_1";
                //objCmd.CommandType = CommandType.StoredProcedure;
                //objCmd.Parameters.Add("p_username", SqlType.VarChar).Value = p_username;
                ////objCmd.Parameters.Add("p_password", SqlType.VarChar).Value = p_password;
                //objCmd.Parameters.Add("USER_ID_NO", SqlType.VarChar, 8).Direction = ParameterDirection.ReturnValue;
                //objCmd.ExecuteNonQuery();
                //connection.Close();
                string USER_ID_NO_Value = Convert.ToString(objCmd.Parameters["USER_ID_NO"].Value);
                //switch (USER_ID_NO_Value)
                //{
                //    case "7":
                //        break;
                //    case "11":
                //        break;
                //    default:
                //        UpdateForUserStatusLocked(USER_ID_NO_Value);
                //        break;
                //}
              

                // MessageBox.Show(Convert.ToString(objCmd.Parameters["USER_ID_NO"].Value));
                return USER_ID_NO_Value;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return "0";
            }
            finally
            {
                connection.Close();
            }
        }

        public string Get_CurrentPlza() 
        {
            try
            {
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\Master_Query.xml");
                string Query = "";
                Query = QueryManager.GetQuery("GetPlazaCode");
                string sPlazaCode = ExecuteScalar(Query);
                return sPlazaCode;
            }
            catch (Exception Ex)
            {
                return "0";
            }
        }

        public string Get_RollID(string sUserID)
        {
            try
            {
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\Master_Query.xml");
                 string Query = "";
                Query = QueryManager.GetQuery("GetPlazaCode");
                string sPlazaCode = ExecuteScalar(Query);
                
                 Query = QueryManager.GetQuery("GetRollID");
                 Query = string.Format(Query, sUserID, sPlazaCode);
                 string sRollID = ExecuteScalar(Query);
                 return sRollID;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string GetPOS_NO(string sUserID)
        {
            try
            {
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\Master_Query.xml");
                string Query = "";
                Query = QueryManager.GetQuery("GetPlazaCode");
                string sPlazaCode = ExecuteScalar(Query);

                Query = QueryManager.GetQuery("GetPOS_NO");
                Query = string.Format(Query, sUserID, sPlazaCode);
                string sPOS_NO = ExecuteScalar(Query);
                return sPOS_NO;
            }
            catch (Exception)
            {
                return "1";
            }
        }
        public string Get_MaxUserID()
        {
            try
            {
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\Master_Query.xml");
                string Query = "";
                Query = QueryManager.GetQuery("GetMAXUserID");
                string sMaxUserID = ExecuteScalar(Query);
                return sMaxUserID;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public Int64 GetMAXSM_CUST_ID(Int16 POS_NO)
        {
            try
            {
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\Master_Query.xml");
                string Query = "";
                Query = QueryManager.GetQuery("GetMAXSM_CUST_ID");                
                Query = string.Format(Query, POS_NO);
                string sMaxSM_CUST_ID = ExecuteScalar(Query);
                if (string.IsNullOrEmpty(sMaxSM_CUST_ID))
                {
                    return Convert.ToInt64(0);
                }
                else
                {
                    return Convert.ToInt64(sMaxSM_CUST_ID);
                }
            }
            catch (Exception)
            {
                return Convert.ToInt64(0);
            }
        }
        public Int64 GetMAXSM_RFID_SERIALNO(Int16 POS_NO)
        {
            try
            {
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\Master_Query.xml");
                string Query = "";
                Query = QueryManager.GetQuery("GetMAXSM_RFID_SERIALNO");                
                Query = string.Format(Query, POS_NO);
                string sMaxSM_RFID_SERIALNO = ExecuteScalar(Query);
                if (string.IsNullOrEmpty(sMaxSM_RFID_SERIALNO))
                {
                    return Convert.ToInt64(0);
                }
                else
                {
                    return Convert.ToInt64(sMaxSM_RFID_SERIALNO);
                }
            }
            catch (Exception)
            {
                return Convert.ToInt64(0);
            }
        }
        public Int64 GetMAXSM_POS_ACTIVITY_ID(Int16 POS_NO)
        {
            try
            {
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\Master_Query.xml");
                string Query = "";
                Query = QueryManager.GetQuery("GetMAXSM_POS_ACTIVITY_ID");
                Query = string.Format(Query, POS_NO);
                string sMAXSM_POS_ACTIVITY_ID = ExecuteScalar(Query);
                if (string.IsNullOrEmpty(sMAXSM_POS_ACTIVITY_ID))
                {
                    return Convert.ToInt64(0);
                }
                else
                {
                    return Convert.ToInt64(sMAXSM_POS_ACTIVITY_ID);
                }
            }
            catch (Exception)
            {
                return Convert.ToInt64(0);
            }
        }
       

        public Int64 Get_TariffFare(Int32 VehID, Int32 VehType)
        {
            try
            {
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\Master_Query.xml");
                string Query = "";
                Query = QueryManager.GetQuery("GetTariffFare");
                Query = string.Format(Query, VehID, VehType, 1, 1);
                string sTariffFare = ExecuteScalar(Query);
                if (string.IsNullOrEmpty(sTariffFare))
                {
                    return Convert.ToInt64(0);
                }
                else
                {
                    return Convert.ToInt64(sTariffFare);
                }
            }
            catch (Exception)
            {
                return Convert.ToInt64(0);
            }
        }

        public string Get_CONFIG_VALUE(string CONFIG_DESC) // for password configuration value set 24th octo07
        {
            try
            {

                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\Master_Query.xml");
                string Query = "";
                Query = QueryManager.GetQuery("GetPlazaCode");
                string sPlazaCode = ExecuteScalar(Query);
                Query = QueryManager.GetQuery("Get_CONFIG_VALUE");
                Query = string.Format(Query, CONFIG_DESC, sPlazaCode);
                string CONFIG_VALUE = ExecuteScalar(Query);
                return CONFIG_VALUE;
            }
            catch (Exception)
            {
                return "";
            }
        }
        
        public string Get_CurrentPasswordLock() // for password configuration value set 24th octo07
        {
            string Query_CurrentPlaza;
            string currentPlaza = string.Empty;
            string CurrentPlazastatus = Get_CurrentPlza();
            Open_Sql_Connection();
            try
            {
                Query_CurrentPlaza = "select CONFIG_VALUE from PT_ETMS_CONFG where  CONFIG_DESC like  'PASSWORDLOCK' AND B_cancel=0 and PLAZA_CODE='" + CurrentPlazastatus + "'";
                SqlCommand Command_CurrentPlaza = new SqlCommand(Query_CurrentPlaza, connection);
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                SqlDataReader CurrentPlazaReader;

                CurrentPlazaReader = Command_CurrentPlaza.ExecuteReader();
                CurrentPlazaReader.Read();
                //SqlNumber CurrentPlazaID = CurrentPlazaReader.GetSqlNumber(0);
                //SqlString CurrentPlazaID = CurrentPlazaReader.GetString(0);

                //if (CurrentPlazaID.IsNull == true)
                //{
                //    currentPlaza = "0";
                //}
                //else
                //{
                //    currentPlaza = Convert.ToString(CurrentPlazaReader["CONFIG_VALUE"]);
                //}
                CurrentPlazaReader.Close();
                return currentPlaza;
            }
            catch (Exception Ex)
            {
                // if (obj_common_function.IsTestMode == true)
                //{
                //MessageBox.Show(Ex.Message, "Get_CurrentPlza : ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //  ObjErrorLog1.WriteApplicationLog(this.Name, "Get_CurrentPlza", Ex.ToString());
                return "0";
                //  }
                // else
                //{
                //  ObjErrorLog1.WriteApplicationLog(this.Name, "Get_CurrentPlza", Ex.ToString());
                // return "0";
                // }
            }
            finally
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
            }
        }

        public void UpdateForUserStatusLocked(string UserLock)
        {
            try
            {
                string UpdateStr = "update MD_ETMS_USERS set USER_STATUS = 10 where USER_ID = '" + UserLock + "' and PLAZA_CODE='" + Get_CurrentPlza() + "'";
                //string UpdateStr = "update ADMIN_UESR_DETAIL set USER_STATUS = 10 where USER_ID = '" + obj_login.UserLockId + "'";
                SaveData(UpdateStr);
            }
            catch (Exception Ex)
            {
                ////MessageBox.Show(Ex.Message, "Update :", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //if (ObjCommonFunction.IsTestMode == true)
                //{
                //    MessageBox.Show(Ex.Message, "UpdateForUserStatusLocked: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ObjErrorLog.WriteApplicationLog(this.Name, "UpdateForUserStatusLocked", Ex.ToString());
                //    ObjDberrorLog.INSERT_PLAZA_ETMS_LOG(Ex, "UpdateForUserStatusLocked");
                //}
                //else
                //{
                //    ObjErrorLog.WriteApplicationLog(this.Name, "UpdateForUserStatusLocked", Ex.ToString());
                //    ObjDberrorLog.INSERT_PLAZA_ETMS_LOG(Ex, "UpdateForUserStatusLocked");
                //}
            }
        }

        public DataSet RetriveDataset(string str)
        {
            DataSet dataset = new DataSet();
            SqlConnection con = new SqlConnection(GetConnectionString());

            //if (Open_Sql_Connection())
            //{
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(str, con);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception ex)
            {
                return dataset = null;
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            //}
            //else
            //{
            //    return dataset;
            //}
        }

        string[] myIntArray = new string[5];
        Regex r = new Regex("'");


        public string ExecuteScalar(string strQuery)
        {
            string strScalar = "";
            try
            {
                using (SqlConnection ocnn = new SqlConnection(GetConnectionString()))
                {
                    ocnn.Open();
                    using (SqlCommand ocmd = new SqlCommand(strQuery, ocnn))
                    {
                        strScalar = ocmd.ExecuteScalar().ToString();
                    }
                    ocnn.Close();
                }
            }
            catch (Exception ex)
            { }
            return strScalar;
        }

        public DataTable FillDataTable(string sQuery, string TableNme)
        {
            Open_Sql_Connection();
            try
            {
                DataTable objTable = new DataTable(TableNme);
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                SqlDataAdapter objAdpter = new SqlDataAdapter();
                objAdpter.SelectCommand = get_new_sql_connection(sQuery, connection);
                objAdpter.SelectCommand.CommandType = CommandType.Text;
                objAdpter.Fill(objTable);
                return objTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
            }
        }
                      
        public string GetDateFormat(string InputDate)
        {
            string TempSplit, TempDate;
            TempSplit = InputDate;
            TempDate = TempSplit.Remove(0, 2);
            TempDate = TempDate.Remove(2);
            InputDate = TempDate + "/" + TempSplit.Remove(2) + "/20" + TempSplit.Remove(0, 4);
            return Convert.ToDateTime(InputDate).ToString("dd-MMM-yyyy");
        }

        public int SaveData(string str)
        {
            int rows_effected;
            SqlTransaction ot = null;
            SqlConnection conn = new SqlConnection(GetConnectionString());
            try
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    return 3;
                }

                //Open_Sql_Connection();
                ot = conn.BeginTransaction();
                SqlCommand command = new SqlCommand(str, conn, ot);
                command.CommandText = str;
                rows_effected = command.ExecuteNonQuery();
                command.Dispose();
                if (rows_effected == 0)
                {
                    ot.Rollback();
                    return 4;
                }
                ot.Commit();
                return 1;
            }
            catch (Exception ex)
            {
                ot.Rollback();
                return 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) { conn.Close(); }
            }
        }

        private static ConnectionPasswordDecryption oPwdDecryption;

        public static ConnectionPasswordDecryption GetInstance_of_decryptionclass()
        {
            if (oPwdDecryption == null)
            {
                oPwdDecryption = new ConnectionPasswordDecryption();
            }
            return oPwdDecryption;
        }

        static public string GetConnectionString()
        {
            string connectionString = string.Empty;

            //string ConnectionStringEncrypted = ConfigurationManager.AppSettings["ConnectionStringEncrypted"].ToString();
            //if (ConnectionStringEncrypted.Trim().ToUpper() == "TRUE")
            //{
            //    oPwdDecryption = GetInstance_of_decryptionclass();
            //    connectionString = oPwdDecryption.DecryptConnectionPassword();
            //    return connectionString;
            //}
            //else
            //{
            connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            //}
            return connectionString;
        }

        public string GetSingleRecord(string FieldName, string TableName, string WhereClause, bool ContainsWhereClause)
        {
            string GetRecord = "0", CmdQuery;
            string ConnectionString = GetConnectionString();
            SqlConnection connection_GetRecord = new SqlConnection(ConnectionString);
            if (ContainsWhereClause == true)
            {
                CmdQuery = "SELECT " + FieldName + " FROM " + TableName + " " + WhereClause + "";
            }
            else
            {
                CmdQuery = "SELECT " + FieldName + " FROM " + TableName + "";
            }
            SqlCommand RecCmd = new SqlCommand(CmdQuery, connection_GetRecord);

            try
            {
                if (connection_GetRecord.State == ConnectionState.Closed) { connection_GetRecord.Open(); }
                GetRecord = Convert.ToString(RecCmd.ExecuteScalar());
                if (GetRecord == "")
                {
                    GetRecord = "0";
                }
                RecCmd.Dispose();
                return GetRecord;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);                
                return null;
            }
            finally
            {
                if (connection_GetRecord.State == ConnectionState.Open) { connection_GetRecord.Close(); }
            }
        }

        /// <summary>
        /// Where Clause Will Be generated accoring to column name in PT_CTP_TABLE_KEYS
        /// </summary>
        /// <param name="Tablename"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public string GenerateWhereClause(string Tablename, DataRow r)
        {
            string WhereTableName = Tablename;
            DataSet dsKeys = new DataSet();
            try
            {
                string Query = "select IDX_COL_NAME1, IDX_COL_NAME2, IDX_COL_NAME3,IDX_COL_NAME4,IDX_COL_NAME5 from PT_CTP_TABLE_KEYS where TABLE_NAME = '" + Tablename + "'";
                dsKeys = RetriveDataset(Query);
                int intWhereIndex = dsKeys.Tables[0].Columns.Count;
                string whereclause = "";
                if (dsKeys.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < intWhereIndex && i < 5; i++)
                    {
                        if (dsKeys.Tables[0].Rows[0][i] != DBNull.Value)
                        {
                            if (string.IsNullOrEmpty(whereclause))
                            {
                                string s = dsKeys.Tables[0].Rows[0][i].ToString();
                                string ss = r[s].ToString();
                                whereclause = String.Format("{0} = '{1}'", dsKeys.Tables[0].Rows[0][i], ss);
                            }
                            else
                            {
                                string s = dsKeys.Tables[0].Rows[0][i].ToString();
                                string ss = r[s].ToString();
                                whereclause = whereclause + " and " + String.Format("{0} = '{1}'", dsKeys.Tables[0].Rows[0][i], ss);
                            }
                        }
                    }
                }
                return whereclause;
            }
            catch (Exception ex)
            {
                //if (ClsCommonVariables.InfoLog.ToString() == "TRUE")
                //{
                //    (new ClsCommonVariables().objLog).WriteApplicationLog("MSMQDataExport", "Transfer" + ex.Message, ex.StackTrace);
                //}
                //errorLog.INSERT_PLAZA_ETMS_LOG(ex, "GenerateWhereClause :");
                return null;
            }
        }

        //Executes nonquery
        public bool ExecuteNonQuery(string sQuery, SqlTransaction objTrans)
        {
            //SqlTransaction objTrans;
            //objTrans = DbConnection.Open().BeginTransaction();
            try
            {
                SqlCommand objCmd = get_new_sql_connection(sQuery, objTrans.Connection);

                objCmd.CommandType = CommandType.Text;
                objCmd.Transaction = objTrans;

                objCmd.ExecuteNonQuery();

                //objTrans.Commit();
                //DbConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                objTrans.Rollback();
                return false;
                //throw (ex);

            }
        }

        public bool ExecuteNonQuery(string sQuery)
        {
            SqlTransaction objTrans;
            objTrans = DbConnection.Open().BeginTransaction();
            try
            {
                SqlCommand objCmd = get_new_sql_connection(sQuery, objTrans.Connection);
                objCmd.CommandType = CommandType.Text;
                objCmd.Transaction = objTrans;

                objCmd.ExecuteNonQuery();

                objTrans.Commit();
                DbConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                objTrans.Rollback();
                throw (ex);
                //return false;
            }
        }

    }
}