using BAL;
using Entity;
using System;

namespace InventoryManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class InventoryManagementService : IInventoryService
    {

        public string Get_Inventory_CONFIG_VALUE(string CONFIG_DESC)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetInventory_MasterDetails(BAL.InventoryMasterRequest mReq, string ID)
        {
            try
            {
                if (mReq == null)
                {
                    return null;
                }
                return mReq.Fun_GetDetails(ID);
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                ErrorLog objel = new ErrorLog();
                objel.DoBalErrorLogging(ex);
                return null;

            }
            finally
            {

            }
        }

        public bool InventorySQLValidate(BAL.InventoryMasterRequest mReq)
        {
            throw new NotImplementedException();
        }

        public bool InventoryProcessMaster(BAL.InventoryMasterRequest mReq, Entity.EnumInventoryOperationType operation_type)
        {
            try
            {
                bool breturn = false;

                if (mReq == null)
                {
                    breturn = false;
                }
                switch (operation_type)
                {
                    case EnumInventoryOperationType.Insert:
                        breturn = mReq.Fun_Insert();
                        break;
                    case EnumInventoryOperationType.Update:
                        breturn = mReq.Fun_Update();
                        break;
                    case EnumInventoryOperationType.GetDetails:

                        break;
                    default:
                        break;
                }

                return breturn;
            }
            catch (Exception ex)
            {
                // Custom Error Logging
                ErrorLog objel = new ErrorLog();
                objel.DoBalErrorLogging(ex);
                return false;
            }
        }
    }
}
