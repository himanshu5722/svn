using System.Data;
using System.Runtime.Serialization;

namespace BAL
{
    [DataContract]
    [KnownType(typeof(StockAlloactionBAL))]
   abstract public class InventoryMasterRequest
    {
        public abstract string ID { get; set; }
        public abstract bool Fun_Insert();
        public abstract bool Fun_Update();
        public abstract DataTable Fun_GetDetails(string ID);
        public abstract bool Fun_SQLValidate();
    }
}
