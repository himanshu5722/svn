using Entity.StockAlloaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL
{
    public class StockAlloactionDAL
    {
        ClsCommonDBOperations objCommon = new ClsCommonDBOperations();
        SqlManager QueryManager = SqlManager.Create(AppDomain.CurrentDomain.BaseDirectory + @"\XML\CustomerDetails\CustDetails.xml");

        public DataTable GetAssignType(string pRoleId)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetAssignType").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("GetDataTable");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", pRoleId);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }

        public DataTable GetSupplier(string pRoleId)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetSupplier").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("GetDataTable");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", pRoleId);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }


        public DataTable GetTagTrace(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetTagTrace").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);

                    sqlComm.Parameters.AddWithValue("@P_DATE_FROM", entity.fromdate);
                    sqlComm.Parameters.AddWithValue("@P_DATE_TO", entity.todate);
                    sqlComm.Parameters.AddWithValue("@P_TAG_SEQ", entity.seriesfrom);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);
                    sqlComm.Parameters.AddWithValue("@p_next", entity.limit);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }


        public DataTable GetStockeAllocatedByOrderid(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetStockeAllocatedByOrderid").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);

                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", entity.PARTNER_ID);
                    sqlComm.Parameters.AddWithValue("@P_ORDER_ID", entity.orderid);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);
                    sqlComm.Parameters.AddWithValue("@p_next", entity.limit);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }


        public DataTable GetAvailableStock(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetAvailableStock").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", entity.RoleId);
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", entity.PARTNER_ID);
                    sqlComm.Parameters.AddWithValue("@P_Stationary_Type", entity.SMstationarytype);
                    sqlComm.Parameters.AddWithValue("@P_Vendor_id", entity.SMvendor);
                    sqlComm.Parameters.AddWithValue("@P_Lot_No", entity.SMlotno);
                    sqlComm.Parameters.AddWithValue("@P_From_Date", entity.SMfromdate);
                    sqlComm.Parameters.AddWithValue("@P_To_Date", entity.SMtodate);
                    sqlComm.Parameters.AddWithValue("@P_Status", entity.SMstatus);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);
                    sqlComm.Parameters.AddWithValue("@p_next", entity.limit);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }


        public DataTable GetAllocatedDataDispatched(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetAllocatedDataDispatched").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_FROM_DATE", entity.fromdate);
                    sqlComm.Parameters.AddWithValue("@P_TO_DATE", entity.todate);
                    sqlComm.Parameters.AddWithValue("@P_ITEM_TYPE", entity.SMstationarytype);
                    sqlComm.Parameters.AddWithValue("@P_ORDER_ID", entity.orderid == "" ? "ALL" : entity.orderid);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", entity.RoleId);
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", entity.PARTNER_ID);
                    sqlComm.Parameters.AddWithValue("@P_LOT_NO", entity.lotno == "" ? "-1" : entity.lotno);
                    sqlComm.Parameters.AddWithValue("@P_DISPATCH_STATUS", entity.remarks == "" ? "-1" : entity.remarks);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);
                    sqlComm.Parameters.AddWithValue("@p_next", entity.limit);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }


        public DataTable GetAllocatedData(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetAllocatedData").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", entity.RoleId);
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", entity.PARTNER_ID);
                    sqlComm.Parameters.AddWithValue("@P_LOT_NO", entity.lotno);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);
                    sqlComm.Parameters.AddWithValue("@p_next", entity.limit);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }

        public DataTable GetOrderDetails(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetOrderDetails").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", entity.RoleId);
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", entity.PARTNER_ID);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);
                    sqlComm.Parameters.AddWithValue("@p_next", entity.limit);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }


        public DataTable GetOrderDetailsToIndents(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetOrderDetailsToIndents").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", entity.RoleId);
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", entity.PARTNER_ID);
                    sqlComm.Parameters.AddWithValue("@P_FROM_DT", entity.fromdate);
                    sqlComm.Parameters.AddWithValue("@P_TO_DT", entity.todate);
                    sqlComm.Parameters.AddWithValue("@P_ORDER_STATUS", entity.SMstatus);
                    sqlComm.Parameters.AddWithValue("@P_ORDER_ID", entity.orderid);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);

                    
                   
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }
        public DataTable GetAssignTo(string pPatnerType, string pPatnerID, string flag)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                if (flag == "1")
                    Query = QueryManager.GetQuery("GetAssignTo").Trim();
                else
                    Query = QueryManager.GetQuery("suppliername").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_TYPE", Convert.ToString(pPatnerType));
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", Convert.ToString(pPatnerID));
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }

        public DataTable InsertAllocationInfo(StockAlloactionEntity Entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("SaveData").Trim();
                DataSet ds = new DataSet();

                DataTable dt = new DataTable("InventrySaveDT");
                dt.Columns.Add("Result");
                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    con.Open();
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.Add("@P_INDENT_ID", SqlDbType.VarChar).Value = Entity.user_id;
                    sqlComm.Parameters.Add("@P_LOT_NO", SqlDbType.VarChar).Value = Entity.lotno;

                    sqlComm.Parameters.Add("@P_SUB_LOT_NO", SqlDbType.VarChar).Value = Entity.OtherData == "" ? "0" : Entity.OtherData;
                    sqlComm.Parameters.Add("@P_INST_CAT", SqlDbType.Int).Value = 1;
                    sqlComm.Parameters.Add("@P_INST_ID", SqlDbType.Int).Value = 1;
                    sqlComm.Parameters.Add("@P_NO_OF_ITEMS", SqlDbType.Int).Value = Entity.quantity;
                    sqlComm.Parameters.Add("@P_SERIES_TYPE", SqlDbType.Int).Value = 1;
                    sqlComm.Parameters.Add("@P_URGENT_REQUIRED", SqlDbType.Int).Value = 1;
                    //sqlComm.Parameters.Add("@P_SERIES_FROM", SqlDbType.BigInt).Value = Entity.seriesfrom;
                    //sqlComm.Parameters.Add("@P_SERIES_TO", SqlDbType.BigInt).Value = Entity.seriesto;
                    sqlComm.Parameters.Add("@P_ROLE_ID", SqlDbType.Int).Value = Entity.RoleId;
                    sqlComm.Parameters.Add("@P_RAISED_BY_ID", SqlDbType.Int).Value = Entity.PARTNER_ID;
                    sqlComm.Parameters.Add("@P_RAISED_TO_TYPE", SqlDbType.Int).Value = Entity.raisedtotype;
                    sqlComm.Parameters.Add("@P_RAISED_TO_ID", SqlDbType.Int).Value = Entity.raisedtoid;
                    sqlComm.Parameters.Add("@P_RAISED_TO_NAME", SqlDbType.VarChar).Value = Entity.raisedtoname;
                    sqlComm.Parameters.Add("@P_REMARKS", SqlDbType.VarChar).Value = Entity.remarks;
                    sqlComm.Parameters.Add("@P_UID_EBY", SqlDbType.VarChar).Value = Entity.user_name;
                    sqlComm.Parameters.Add("@P_WITHOUT_IND_FLAG", SqlDbType.Int).Value = Entity.limit;
                    sqlComm.Parameters.Add("@P_VEH_CLASS", SqlDbType.Int).Value = Entity.count;
                    SqlParameter outParam = new SqlParameter("@P_OUT", SqlDbType.Int, 100);
                    outParam.Direction = ParameterDirection.Output;
                    sqlComm.Parameters.Add(outParam);
                    sqlComm.ExecuteNonQuery();
                    con.Close();
                    int returnValue = Convert.ToInt32(sqlComm.Parameters["@P_OUT"].Value);
                    dt.Rows.Add(returnValue.ToString());


                }


                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }

        //
        public DataTable StockIn(StockAlloactionEntity Entity)
        {
            try
            {

                string SHEET_NAME = "", FILE_DATE = "", VENDOR_NAME = "", VENDOR_REF_NO = "", NO_OF_TAG = "", SUB_CLASS = "", NO_OF_SUB_CLASS = "", FILE_STATUS = "0";
                string reasonCode = "0";
     
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("StockIn").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("InventrySaveDT");
                StringReader stream = null;
                XmlTextReader reader = null;
                dt.Columns.Add("Result");
                dt.Columns.Add("CODE");
                int m;
                long s;
                DataSet xmlDS = new DataSet();
                string filename = Entity.remarks.Split('.')[0].ToString();
                string[] filenameparts = filename.Split('_');
                if (filenameparts.Length != 4)
                {
                    dt.Rows.Add("Invalid file name", "1");
                    reasonCode = "INVFILENAME";
                    return dt;

                }
                else
                {
                    if (!Int32.TryParse(filenameparts[0], out m))
                    {
                        dt.Rows.Add("Invalid file name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (filenameparts[1] != "INV")
                    {
                        dt.Rows.Add("Invalid file name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (!Int64.TryParse(filenameparts[2], out s )|| filenameparts[2].Length!=8)
                    {
                        dt.Rows.Add("Invalid file name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (!Int32.TryParse(filenameparts[3], out m) || filenameparts[3].Length != 3)
                    {
                        dt.Rows.Add("Invalid file name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                }
                stream = new StringReader(Entity.FilterData);
                // Load the XmlTextReader from the stream
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);



                if (xmlDS != null && xmlDS.Tables.Count > 0)
                {
                    xmlDS.Tables[0].Rows.RemoveAt(0);
                    xmlDS.Tables[1].Rows.RemoveAt(0);
                
                DataTable dtHeader = new DataTable("test");
                DataTable dtBody = new DataTable();
                dtHeader = xmlDS.Tables[0];
                dtBody = xmlDS.Tables[1];


                string[] sheetnamepartsH = dtHeader.TableName.Split('_');
                if (sheetnamepartsH.Length != 5)
                {
                    dt.Rows.Add("Invalid file header sheet name", "1");
                    reasonCode = "INVFILENAME";
                    return dt;

                }
                else
                {
                    if (!Int32.TryParse(sheetnamepartsH[0], out m))
                    {
                        dt.Rows.Add("Invalid file header sheet name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (sheetnamepartsH[1] != "INV")
                    {
                        dt.Rows.Add("Invalid file header sheet name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (!Int64.TryParse(sheetnamepartsH[2], out s) || sheetnamepartsH[2].Length != 8)
                    {
                        dt.Rows.Add("Invalid file header sheet name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (!Int32.TryParse(sheetnamepartsH[3], out m) || sheetnamepartsH[3].Length != 3)
                    {
                        dt.Rows.Add("Invalid file header sheet name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (sheetnamepartsH[4].ToUpper() != "H")
                    {
                        dt.Rows.Add("Invalid file header sheet name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                }
                string[] sheetnamepartsD = dtBody.TableName.Split('_');
                if (sheetnamepartsD.Length != 5)
                {
                    dt.Rows.Add("Invalid file detail sheet name", "1");
                    reasonCode = "INVFILENAME";
                    return dt;

                }
                else
                {
                    if (!Int32.TryParse(sheetnamepartsD[0], out m))
                    {
                        dt.Rows.Add("Invalid file detail sheet name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (sheetnamepartsD[1] != "INV")
                    {
                        dt.Rows.Add("Invalid file detail sheet name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (!Int64.TryParse(sheetnamepartsD[2], out s) || sheetnamepartsD[2].Length != 8)
                    {
                        dt.Rows.Add("Invalid file detail sheet name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (!Int32.TryParse(sheetnamepartsD[3], out m) || sheetnamepartsD[3].Length != 3)
                    {
                        dt.Rows.Add("Invalid file detail sheet name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                    else if (sheetnamepartsD[4].ToUpper() != "D")
                    {
                        dt.Rows.Add("Invalid file detail sheet name", "1");
                        reasonCode = "INVFILENAME";
                        return dt;
                    }
                }


                //Validations
                int status = 0;


                if (dtHeader != null && dtHeader.Rows.Count > 0)
                {
                    SHEET_NAME = dtHeader.TableName;
                    if (dtHeader.Columns.Count == 5)
                    {
                        FILE_DATE = dtHeader.Rows[0][0].ToString();
                        VENDOR_NAME = dtHeader.Rows[0][1].ToString();
                        VENDOR_REF_NO = dtHeader.Rows[0][2].ToString();
                        NO_OF_TAG = dtHeader.Rows[0][3].ToString();
                        SUB_CLASS = dtHeader.Rows[0][4].ToString();
                        //NO_OF_SUB_CLASS = dtHeader.Rows[0][5].ToString();
                        Int32 a;
                        string sheetname = SHEET_NAME.Substring(0, SHEET_NAME.Length - 2);

                        DateTime datetime;
                        if (!DateTime.TryParse(FILE_DATE, out datetime))
                        {
                            dt.Rows.Add("Invalid File Date", "1");
                            reasonCode = "INVALIDDATE";
                            status = 2;
                        }
                        else
                        {
                            FILE_DATE = datetime.ToString("dd-MMM-yyyy");
                        }
                   
                     if (filename != sheetname)
                        {
                            dt.Rows.Add("Invalid file name or sheet name","1");
                            reasonCode = "INVFILENAME";
                            status = 2;
                        }
                        else
                        if (FILE_DATE == "")
                        {
                            dt.Rows.Add("file date does not exist", "1");
                            reasonCode = "FILEDATENOTEXIST";
                            status = 2;
                        }
                        else
                        if (VENDOR_NAME == "")
                        {
                            dt.Rows.Add("vendor ref no. does not exist", "1");
                            reasonCode = "VENDREFNOTEXIST";
                            status = 2;
                        }
                        else
                        if (SUB_CLASS == "")
                        {
                            dt.Rows.Add("Vehicle class field should not empty", "1");
                            reasonCode = "VEHCLASSEMPTY";
                            status = 2;
                        }
                        else if (VehClassIsAvailable(SUB_CLASS) == "0")
                        {
                            dt.Rows.Add("Invalid vehicle class.", "1");
                            reasonCode = "INVALIDVEHCLASS";
                            status = 2;
                        }
                        else  
                          if ((filename.Split('_'))[2] != DateTime.Now.ToString("ddMMyyyy"))
                          {
                              dt.Rows.Add("Invalid file name or sheet name", "1");
                              reasonCode = "INVFILENAME";
                              status = 2;
                           }
                          else
                               if (!Int32.TryParse(NO_OF_TAG, out a))
                            {

                                dt.Rows.Add("Number of tags must be numeric", "1");
                                reasonCode = "NOOFTAGNUM";
                                status = 2;
                            }
                            else
                            {
                               
                                if (0 >= Convert.ToInt32(NO_OF_TAG))
                                {
                                    dt.Rows.Add("Number of tags section should not less than zero or empty ", "1");
                                    reasonCode = "NOTOFTAGNOTZEROOREMPTY";
                                    status = 2;
                                }

                            }

                        if (reasonCode == "0")
                        {
                            dt.Rows.Add("File Uploaded successfully.", "2");
                            //reasonCode = "";
                            status = 1;
                        }
                        DataTable finalBody = new DataTable("TY_STOCK_IN_BODY_DATA");                     
                        finalBody.Columns.Add("TAG_SEQ", typeof(string));
                        finalBody.Columns.Add("TID", typeof(string));
                        finalBody.Columns.Add("EPC_ID", typeof(string));
                        finalBody.Columns.Add("SIGNATURE", typeof(string));
                        finalBody.Columns.Add("VEH_CLASS", typeof(Int16));
                        for (int i = 0; i < dtBody.Rows.Count; i++)
                        {
                            if (dtBody.Rows[i][0].ToString() != "" && dtBody.Rows[i][1].ToString() != "" && dtBody.Rows[i][0].ToString() != "")
                            {
                                finalBody.Rows.Add(
                                    //Entity.remarks, dtBody.TableName,
                                    dtBody.Rows[i][0].ToString(),
                                    dtBody.Rows[i][1].ToString(),
                                    dtBody.Rows[i][2].ToString(),
                                    dtBody.Rows[i][3].ToString(),
                                    SUB_CLASS);
                            }
                        }
                        if (NO_OF_TAG != finalBody.Rows.Count.ToString())
                        {
                            dt.Rows.Add("Number of tags in header not matching with number of row contains in body section", "1");
                            reasonCode = "NOOFTAGNOTMATCHCOUNT";
                            status = 2;
                        }
                        using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                        {

                            SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                            con.Open();
                            sqlComm.CommandType = CommandType.StoredProcedure;
                            sqlComm.Parameters.Add("@P_FILE_NAME", SqlDbType.VarChar).Value = filename;
                            sqlComm.Parameters.Add("@P_SHEET_NAME", SqlDbType.VarChar).Value = SHEET_NAME;
                            sqlComm.Parameters.Add("@P_FILE_DATE", SqlDbType.VarChar).Value = FILE_DATE;
                            sqlComm.Parameters.Add("@P_VENDOR_NAME", SqlDbType.VarChar).Value = VENDOR_NAME;
                            sqlComm.Parameters.Add("@P_VENDOR_REF_NO", SqlDbType.VarChar).Value = VENDOR_REF_NO;
                            sqlComm.Parameters.Add("@P_SUB_CLASS", SqlDbType.VarChar).Value = "0";
                            sqlComm.Parameters.Add("@P_NO_OF_TAG", SqlDbType.Int).Value = NO_OF_TAG;
                             
                            sqlComm.Parameters.Add("@P_NO_OF_SUB_CLASS", SqlDbType.Int).Value = "0";
                            sqlComm.Parameters.Add("@P_FILE_STATUS", SqlDbType.Int).Value = status;
                            sqlComm.Parameters.Add("@P_REJECT_REASON_CODE", SqlDbType.VarChar).Value = reasonCode;
                            sqlComm.Parameters.Add("@P_UID_EBY", SqlDbType.VarChar).Value = Entity.user_name;
                            sqlComm.Parameters.Add("@P_ROLE_ID", SqlDbType.Int).Value = Entity.RoleId;
                            sqlComm.Parameters.Add("@P_VENDOR_ID", SqlDbType.VarChar).Value = Entity.user_id;
                            sqlComm.Parameters.Add("@P_VEH_CLASS", SqlDbType.Int).Value = SUB_CLASS;
                            sqlComm.Parameters.Add("@P_STOCK_IN_BODY_DATA", SqlDbType.Structured).Value = finalBody;
                            SqlParameter outParam = new SqlParameter("@P_OUT", SqlDbType.Int, 100);
                            outParam.Direction = ParameterDirection.Output;
                            sqlComm.Parameters.Add(outParam);
                            sqlComm.ExecuteNonQuery();
                            con.Close();
                            int returnValue = Convert.ToInt32(sqlComm.Parameters["@P_OUT"].Value);
                            dt.Rows.Add(returnValue.ToString(),0);

                        }
                    }
                    else
                    {
                        dt.Rows.Add("Invalid File Header","1");
                        return dt;
                    }

                }
                    


                 
               
               
                
                }

                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }




        //
        public DataTable OrderDispatch(StockAlloactionEntity Entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("OrderDispatch").Trim();
                DataSet ds = new DataSet();

                DataTable dt = new DataTable("InventrySaveDT");
                dt.Columns.Add("Result");
                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    con.Open();
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.Add("@P_ORDER_ID", SqlDbType.VarChar).Value = Entity.FilterData;
                    sqlComm.Parameters.Add("@P_ST_ID", SqlDbType.VarChar).Value = Entity.limit;
                    sqlComm.Parameters.Add("@P_LOT_NO", SqlDbType.VarChar).Value = Entity.lotno;
                    sqlComm.Parameters.Add("@P_COURIER_ID", SqlDbType.Int).Value = Entity.OtherData;
                    sqlComm.Parameters.Add("@P_COURIER_TXN_ID", SqlDbType.VarChar).Value = Entity.raisedtoid;
                    sqlComm.Parameters.Add("@P_COURIER_DISP_DATE", SqlDbType.VarChar).Value = Entity.raisedtoname;
                    SqlParameter outParam = new SqlParameter("@P_OUT", SqlDbType.Int, 100);
                    outParam.Direction = ParameterDirection.Output;
                    sqlComm.Parameters.Add(outParam);
                    sqlComm.ExecuteNonQuery();
                    con.Close();
                    int returnValue = Convert.ToInt32(sqlComm.Parameters["@P_OUT"].Value);
                    dt.Rows.Add(returnValue.ToString());

                }


                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }
        public DataTable InsertOrder(StockAlloactionEntity Entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("InsertOrder").Trim();
                DataSet ds = new DataSet();

                DataTable dt = new DataTable("InventrySaveDT");
                dt.Columns.Add("Result");
                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    con.Open();
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.Add("@P_ITEM_TYPE", SqlDbType.Int).Value = Entity.seriesfrom;
                    sqlComm.Parameters.Add("@P_ITEM_ID", SqlDbType.Int).Value = Entity.seriesto;
                    sqlComm.Parameters.Add("@P_NO_OF_ITEMS", SqlDbType.Int).Value = Entity.quantity;
                    sqlComm.Parameters.Add("@P_URGENT_REQUIRED", SqlDbType.Int).Value = 1;
                    sqlComm.Parameters.Add("@P_DUE_DATE", SqlDbType.VarChar).Value = Entity.lotno;
                    sqlComm.Parameters.Add("@P_ROLE_ID", SqlDbType.Int).Value = Entity.RoleId;
                    sqlComm.Parameters.Add("@P_RAISED_BY_ID", SqlDbType.Int).Value = Entity.PARTNER_ID;
                    sqlComm.Parameters.Add("@P_RAISED_TO_TYPE", SqlDbType.Int).Value = Entity.raisedtotype;
                    sqlComm.Parameters.Add("@P_RAISED_TO_ID", SqlDbType.Int).Value = Entity.raisedtoname;
                    sqlComm.Parameters.Add("@P_RAISED_TO_NAME", SqlDbType.VarChar).Value = Entity.PARTNER_TYPE;
                    sqlComm.Parameters.Add("@P_REMARKS", SqlDbType.VarChar).Value = Entity.user_name;
                    sqlComm.Parameters.Add("@P_ADDRESS_ID", SqlDbType.VarChar).Value = Entity.remarks;
                    sqlComm.Parameters.Add("@P_FLAG", SqlDbType.Int).Value = Entity.limit;
                    sqlComm.Parameters.Add("@P_ORDER_ID", SqlDbType.VarChar).Value = Entity.user_id;
                    sqlComm.Parameters.Add("@P_UID_EBY", SqlDbType.VarChar).Value = Entity.user_name;
                    sqlComm.Parameters.Add("@P_VEH_CLASS", SqlDbType.VarChar).Value = Entity.count;
                    SqlParameter outParam = new SqlParameter("@P_OUT", SqlDbType.Int, 100);
                    outParam.Direction = ParameterDirection.Output;
                    sqlComm.Parameters.Add(outParam);
                    sqlComm.ExecuteNonQuery();
                    con.Close();
                    int returnValue = Convert.ToInt32(sqlComm.Parameters["@P_OUT"].Value);
                    dt.Rows.Add(returnValue.ToString());

                }


                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }

        public DataTable CancelOrder(StockAlloactionEntity Entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("CancelOrder").Trim();
                DataSet ds = new DataSet();

                DataTable dt = new DataTable("InventrySaveDT");
                dt.Columns.Add("Result");
                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    con.Open();
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    sqlComm.Parameters.Add("@P_FLAG", SqlDbType.Int).Value = Entity.OtherData;
                    sqlComm.Parameters.Add("@P_ORDER_ID", SqlDbType.VarChar).Value = Entity.FilterData;
                    sqlComm.Parameters.Add("@P_UID_EBY", SqlDbType.VarChar).Value = Entity.user_name;
                    sqlComm.Parameters.Add("@P_NO_OF_ITEMS", SqlDbType.Int).Value = Entity.quantity == "" ? "0" : Entity.quantity;

                    sqlComm.Parameters.Add("@P_LOT_NO", SqlDbType.VarChar).Value =  Entity.lotno == "" ? "0" : Entity.lotno;
                    sqlComm.Parameters.Add("@P_SUB_LOT_NO", SqlDbType.VarChar).Value = Entity.raisedtoname == "" ? "0" : Entity.raisedtoname;
                    sqlComm.Parameters.Add("@P_FROM_SERIES", SqlDbType.BigInt).Value = Entity.seriesfrom == "" ? "0" : Entity.seriesfrom;
                    sqlComm.Parameters.Add("@P_TO_SERIES", SqlDbType.BigInt).Value =   Entity.seriesto == "" ? "0" : Entity.seriesto;
                    SqlParameter outParam = new SqlParameter("@P_OUT", SqlDbType.Int, 100);
                    outParam.Direction = ParameterDirection.Output;
                    sqlComm.Parameters.Add(outParam);
                    sqlComm.ExecuteNonQuery();
                    con.Close();
                    int returnValue = Convert.ToInt32(sqlComm.Parameters["@P_OUT"].Value);
                    dt.Rows.Add(returnValue.ToString());

                }

                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }
        public DataTable GetStock(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetStock").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Datatable");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {


                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", entity.RoleId);
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", entity.PARTNER_ID);
                    sqlComm.Parameters.AddWithValue("@P_ITEM_TYPE", entity.raisedtotype);
                    sqlComm.Parameters.AddWithValue("@P_ITEM_ID", entity.raisedtoid);
                    sqlComm.Parameters.AddWithValue("@P_VEH_CLASS", entity.seriesfrom);
                    sqlComm.Parameters.AddWithValue("@P_COUNT", entity.count);
                    sqlComm.Parameters.AddWithValue("@P_OFFSET", entity.offset);
                    sqlComm.Parameters.AddWithValue("@P_NEXT", entity.limit);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0 )
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }

        public DataTable FillDropdown(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                //QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\CommonQuery.xml");
                Query = QueryManager.GetQuery(entity.FilterData);
                Query = string.Format(Query, entity.OtherData);

                DataSet ds = objCommon.RetriveDataset(Query);
                DataTable dt = new DataTable("Data");
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);

                // Error logging For elmah
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                return null;
            }
        }
        public DataTable FillDropdownBySP(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                //QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\CommonQuery.xml");
                Query = QueryManager.GetQuery("GetAddressTypes").Trim();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Data");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", entity.RoleId);
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", entity.PARTNER_ID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;

            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);

                // Error logging For elmah
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                return null;
            }
        }
        public DataTable GetAllocatedDataDS(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetAllocateDataDS").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", entity.RoleId);
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", entity.PARTNER_ID);
                    sqlComm.Parameters.AddWithValue("@P_Stationary_Type", entity.SMstationarytype);
                    sqlComm.Parameters.AddWithValue("@P_Vendor_id", entity.SMvendor);
                    sqlComm.Parameters.AddWithValue("@P_Lot_No", entity.SMlotno);
                    //sqlComm.Parameters.AddWithValue("@P_From_Date", entity.SMfromdate);
                    //sqlComm.Parameters.AddWithValue("@P_To_Date", entity.SMtodate);
                    sqlComm.Parameters.AddWithValue("@P_Status", entity.SMstatus);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);
                    sqlComm.Parameters.AddWithValue("@p_next", entity.limit);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }


        public DataTable GetPosStockAvailabel(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetPosStockAvailabel").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_ROLE_ID", entity.RoleId);
                    sqlComm.Parameters.AddWithValue("@P_PARTNER_ID", entity.PARTNER_ID);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);
                    sqlComm.Parameters.AddWithValue("@p_next", entity.limit);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }
        public DataTable GetStockSummary(StockAlloactionEntity entity)
        {
            try

            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");
                if (entity.count != "1")
                {
                    string Query = "";
                    QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                    Query = QueryManager.GetQuery("GetStockSummary").Trim();
                   

                    using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                    {

                        SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                        sqlComm.Parameters.AddWithValue("@P_UID_EBY", entity.user_id);
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlComm;
                        da.Fill(ds);
                    }

                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }
        



        public string VehClassIsAvailable(string Vclass)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                //QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\CommonQuery.xml");
                Query = QueryManager.GetQuery("IsVehClassAvail");
                Query = string.Format(Query, Vclass);

                return objCommon.ExecuteScalar(Query);
             
              
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);

                // Error logging For elmah
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                return null;
            }
        }

        public DataTable GetFileDetail(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetFileDetail").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {
                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_SEQ_NO", entity.SMstationarytype);                
                    //sqlComm.Parameters.AddWithValue("@P_Status", entity.SMstatus);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);
                    sqlComm.Parameters.AddWithValue("@p_next", entity.limit);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }


        public DataTable GetFileHeaderDetail(StockAlloactionEntity entity)
        {
            try
            {
                string Query = "";
                QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\stockallocation.xml");
                Query = QueryManager.GetQuery("GetFileHeaderDetail").Trim();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Test");

                using (SqlConnection con = new SqlConnection(ClsCommonDBOperations.GetConnectionString()))
                {

                    SqlCommand sqlComm = objCommon.get_new_sql_connection(Query, con);
                    sqlComm.Parameters.AddWithValue("@P_DATE_FROM", entity.SMfromdate);
                    sqlComm.Parameters.AddWithValue("@P_DATE_TO", entity.SMtodate);
                    sqlComm.Parameters.AddWithValue("@P_FILE_ID", entity.SMlotno);
                    sqlComm.Parameters.AddWithValue("@P_VENDOR_ID", entity.SMvendor);
                    sqlComm.Parameters.AddWithValue("@P_VEH_CLASS", entity.SMstationarytype);
                 
                    //sqlComm.Parameters.AddWithValue("@P_Status", entity.SMstatus);
                    sqlComm.Parameters.AddWithValue("@p_count", entity.count);
                    sqlComm.Parameters.AddWithValue("@p_offset", entity.offset);
                    sqlComm.Parameters.AddWithValue("@p_next", entity.limit);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                Log.ErrorLog objLog = new Log.ErrorLog();
                var methodInfo = System.Reflection.MethodBase.GetCurrentMethod(); string fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name; ex.Data["MethodName"] = fullName; objLog.DoErrorLogging(ex);
                return null;
            }
        }



    }
}
