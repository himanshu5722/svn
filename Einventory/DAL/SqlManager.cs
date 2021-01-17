using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.Data;

namespace DAL
{
  public  class SqlManager
    {
        private StringDictionary Queries;
        private static SqlManager sqlManager = null;
        string FName;
        protected SqlManager()
        {
            
        }

        public static SqlManager Create(string FileName)
        {
            if (sqlManager == null)
            {
                sqlManager = new SqlManager();
                sqlManager.LoadSqlFile(FileName);
            }
            return sqlManager;
        }

        public void LoadSqlFile(string FileName)
        {
            FName = FileName;
        }

        public string GetQuery(string ID)
        {
            try
            {
                XmlTextReader qr = new XmlTextReader(FName);
                //DataTable dt = qr.MoveToContent
                string Query = string.Empty;

                string id = "";
                //bool btrue = true;
                //if (btrue)
                //{
                while (qr.Read())
                {
                    switch (qr.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (qr.Name.Equals("SQL"))
                            {
                                while (qr.MoveToNextAttribute())
                                {
                                    if (qr.Name.Equals("ID"))
                                    {
                                        id = qr.Value;
                                        if (id.Trim().ToLower() == ID.Trim().ToLower())
                                        {
                                            Query = qr.ReadString();
                                            //btrue = false;
                                        }
                                        break;
                                    }
                                }
                            }
                            break;
                        case XmlNodeType.Comment:
                            Queries.Add(id, qr.Value);
                            id = "";
                            break;
                    }
                }
                //}

                qr.Close();
                return Query;
            }
            catch (Exception ex)
            {
                  return "";
                throw;
            }
        }
    }
}
