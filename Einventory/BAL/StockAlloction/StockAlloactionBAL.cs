using DAL;
using Entity.StockAlloaction;
using System;
using System.Data;
using System.Web.Script.Serialization;
//using System.Web.;
namespace BAL
{
    public class StockAlloactionBAL : InventoryMasterRequest
    {

        public string RoleId { get; set; }
        public string PARTNER_TYPE { get; set; }
        public string PARTNER_ID { get; set; }
        public string count { get; set; }
        public string offset { get; set; }
        public string limit { get; set; }
        public string user_name { get; set; }
        public string lotno { get; set; }
        public string quantity { get; set; }
        public string seriesfrom { get; set; }
        public string seriesto { get; set; }
        public string user_id { get; set; }
        public string raisedtoid { get; set; }
        public string remarks { get; set; }
        public string raisedtotype { get; set; }
        public string raisedtoname { get; set; }

        public string FilterData { get; set; }
        public string OtherData { get; set; }

        public override string ID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool Fun_Insert()
        {
            throw new NotImplementedException();
        }

        public override bool Fun_Update()
        {
            throw new NotImplementedException();
        }

        public override DataTable Fun_GetDetails(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            StockAlloactionEntity entity = new StockAlloactionEntity();
            StockAlloactionDAL objDAL = new StockAlloactionDAL();
            entity.count = count;
            entity.FilterData = FilterData;
            entity.limit = limit;
            entity.lotno = lotno;
            entity.offset = offset;
            entity.OtherData = OtherData;
            entity.PARTNER_ID = PARTNER_ID;
            entity.PARTNER_TYPE = PARTNER_TYPE;
            entity.quantity = quantity;
            entity.raisedtoid = raisedtoid;
            entity.raisedtoname = raisedtoname;
            entity.raisedtotype = raisedtotype;
            entity.remarks = remarks;
            entity.RoleId = RoleId;
            entity.seriesfrom = seriesfrom;
            entity.seriesto = seriesto;
            entity.user_id = user_id;
            entity.user_name = user_name;
           

            switch (ID)
            {

                case "FillDropdown":
                    return objDAL.FillDropdown(entity);
                    break;
                case "FillDropdownBySP":
                    return objDAL.FillDropdownBySP(entity);
                    break;
                case "GetAssignType":
                    return objDAL.GetAssignType(RoleId);
                    break;
                case "GetSupplier":
                    return objDAL.GetSupplier(RoleId);
                    break;

                case "GetAssingTo":
                    return objDAL.GetAssignTo(PARTNER_TYPE, PARTNER_ID, OtherData);
                    break;
                case "GetStock":
                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetStock(entity);
                    break;
                case "SaveData":
                    return objDAL.InsertAllocationInfo(entity);
                    break;
                case "GetAllocatedDataDS":

                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetAllocatedDataDS(entity);
                    break;
                case "GetAvailableStock":

                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetAvailableStock(entity);
                    break;

                case "GetTagTrace":

                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetTagTrace(entity);
                    break;

                case "GetStockeAllocatedByOrderid":

                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetStockeAllocatedByOrderid(entity);
                    break;

                case "GetStockSummary":

                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    entity.user_id = user_id;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetStockSummary(entity);
                    break;

                    
                case "InsertOrder":
                    return objDAL.InsertOrder(entity);
                    break;
                //OrderDispatch
                case "OrderDispatch":
                    return objDAL.OrderDispatch(entity);
                    break;
                case "CancelOrder":
                    return objDAL.CancelOrder(entity);
                    break;
                case "GetOrderDetails":
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetOrderDetails(entity);
                    break;

                case "GetOrderDetailsToIndents":
                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetOrderDetailsToIndents(entity);
                    break;
                case "GetAllocatedData":

                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetAllocatedData(entity);
                    break;
                case "GetAllocatedDataDispatched":

                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetAllocatedDataDispatched(entity);
                    break;
                case "GetPosStockAvailabel":

                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetPosStockAvailabel(entity);
                    break;

                case "GetFileHeaderDetail":

                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetFileHeaderDetail(entity);
                    break;

                case "GetFileDetail":

                    entity = js.Deserialize<StockAlloactionEntity>(FilterData);
                    entity.PARTNER_ID = PARTNER_ID;
                    entity.limit = limit;
                    // entity.lotno = lotno;
                    entity.offset = offset;
                    entity.count = count;
                    entity.RoleId = RoleId;
                    return objDAL.GetFileDetail(entity);
                    break;

                case "StockIn":

                  
                    return objDAL.StockIn(entity);
                    break;



                    
                default:
                    break;
            }

            return null;
        }

        public override bool Fun_SQLValidate()
        {
            throw new NotImplementedException();
        }
    }
}
