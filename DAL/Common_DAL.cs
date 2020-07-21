using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//using Log;

namespace DAL
{
 public   class Common_DAL
    {
        ClsCommonDBOperations objCommon = new ClsCommonDBOperations();
        SqlManager QueryManager = SqlManager.Create(AppDomain.CurrentDomain.BaseDirectory + @"\XML\CommonQuery.xml");
     
     public DataTable GetProjectDetails(string ClientID)
     {
         string Query = "";
         QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\CommonQuery.xml");
         Query = QueryManager.GetQuery("GET_PROJECTS");
         Query = string.Format(Query, ClientID);
         DataSet ds = objCommon.RetriveDataset(Query);
         DataTable dt = new DataTable();
         dt = ds.Tables[0];
         return dt;
     }

     public DataTable GetPlazaList(string ProjectId, string ClientID)
     {
         try
         {
             string Query = "";
             QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\CommonQuery.xml");
             Query = QueryManager.GetQuery("GET_PLAZA_CODE");
             Query = string.Format(Query, ProjectId, ClientID);
             DataSet ds = objCommon.RetriveDataset(Query);
             DataTable dt = new DataTable();
             dt = ds.Tables[0];
             return dt;
         }
         catch (Exception ex)
         {
             return null;
         }
     }

     public DataTable GetVehicleClassList()
     {
         try
         {
             string Query = "";
             QueryManager.LoadSqlFile(AppDomain.CurrentDomain.BaseDirectory + @"\XML\CommonQuery.xml");
             Query = QueryManager.GetQuery("GET_VEHICLE_CLASS");
             Query = string.Format(Query);
             DataSet ds = objCommon.RetriveDataset(Query);
             DataTable dt = new DataTable();
             dt = ds.Tables[0];
             return dt;
         }
         catch (Exception ex)
         {
             return null;
         }
     }

    }
}
