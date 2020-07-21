using BAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace InventoryManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IInventoryService
    {

        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/Get_CONFIG_VALUE?CONFIG_DESC={CONFIG_DESC}")]
        [OperationContract]
        string Get_Inventory_CONFIG_VALUE(string CONFIG_DESC);

        [WebInvoke(Method = "GET",
ResponseFormat = WebMessageFormat.Json,
UriTemplate = "/GetMasterDetails")]
        [OperationContract]
        DataTable GetInventory_MasterDetails(InventoryMasterRequest mReq, string ID);

        [WebInvoke(Method = "GET",
   ResponseFormat = WebMessageFormat.Json,
   UriTemplate = "/SQLValidate")]
        [OperationContract]
        bool InventorySQLValidate(InventoryMasterRequest mReq);

        [WebInvoke(Method = "GET",
ResponseFormat = WebMessageFormat.Json,
UriTemplate = "/ProcessMaster")]
        [OperationContract]
        bool InventoryProcessMaster(InventoryMasterRequest mReq, EnumInventoryOperationType operation_type);
    }
}