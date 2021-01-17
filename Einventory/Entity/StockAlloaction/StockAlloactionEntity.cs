using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.StockAlloaction
{
    public class StockAlloactionEntity
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


        public string SMstationarytype { get; set; }
        public string SMstatus { get; set; }
        public string SMvendor { get; set; }
        public string SMlotno { get; set; }
        public string SMfromdate { get; set; }
        public string SMtodate { get; set; }

        public string DueDate { get; set; }
      
        public string orderid { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }



    }

    public class Order
    {
        public string SupplierType { get; set; }
        public string SupplierName { get; set; }
        public string DueDate { get; set; }
        public string StationaryType { get; set; }
        public string StationaryName { get; set; }
        public string Quantity { get; set; }
        public string AddressId { get; set; }
        public string AddressText { get; set; }
    }
}
