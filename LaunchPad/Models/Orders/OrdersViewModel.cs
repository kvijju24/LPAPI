using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchPad.Models.Orders
{
    public class OrdersViewModel
    {
        public string io_detail1_id { get; set; }
        public string cust_accp_dt { get; set; }
        public string pub_desc { get; set; }
        public string sect_desc { get; set; }
        public string adsize_desc { get; set; }
        public double ? qty { get; set; }
        public double ? net_rate { get; set; }
        public string iis_dt { get; set; }
        public string ad_shape_desc { get; set; }
        public string io_status_desc { get; set; }
        public int master_id { get; set; }
        public string master_company { get; set; }
        public string ad_position_desc { get; set; }
        public string currency { get; set; }
    }
}