//using LaunchPad.Entities.Domain;
//using LaunchPad.Models.Orders;
//using LaunchPad.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.ModelBinding;
//using Kendo.Mvc.Extensions;
//using System.Web.Http.Cors;

//namespace LaunchPad.Controllers
//{
//    public class OrderController : ApiController
//    {
//        [Authorize]
//        [EnableCors(origins: "https://www.metrofamilylaunchpad.com", headers: "Origin, X-Requested-With, Content-Type, Accept, Authorization", methods: "*", SupportsCredentials = true)]
//        [Route("Order")]
//        [HttpGet]
//        public Kendo.Mvc.UI.DataSourceResult Index([ModelBinder(typeof(ModelBinders.DataSourceRequestModelBinder))] Kendo.Mvc.UI.DataSourceRequest request)
//        {
//            //return this.Jsonp();
//            var result = Unity.Work.Repository<tbl_io_detail>().GetAll().Take(1000).ToList().ToDataSourceResult(request ,order => new OrdersViewModel
//            {
//                io_detail1_id = order.io_detail1_id.ToString(),
//                cust_accp_dt = order.tbl_io != null ? order.tbl_io.cust_accp_dt.ToString() : null,
//                pub_desc = order.lu_pub != null ? order.lu_pub.pub_desc : null,
//                sect_desc = order.lu_ad_sect != null ? order.lu_ad_sect.sect_desc : null,
//                adsize_desc = order.lu_adsize != null ? order.lu_adsize.adsize_desc : null,
//                qty = order.qty,
//                net_rate = order.net_rate,
//                iis_dt = order.lu_iss != null ? order.lu_iss.iss_dt.ToString() : null,
//                ad_shape_desc = order.lu_ad_shape != null ? order.lu_ad_shape.ad_shape_desc : null,
//                io_status_desc = order.lu_io_status != null ? order.lu_io_status.io_status_desc : null,
//                master_company = order.tbl_master.company_name,
//                master_id = order.agree_with,
//                ad_position_desc = order.lu_ad_position!= null ? order.lu_ad_position.ad_position_desc : null,
//                currency = GetCurrencyName(order.currency_id)


//            });
//            return result;
//        }
//        public string GetCurrencyName(int Id)
//        {
//            switch(Id)
//            {
//                case 1 :
//                    return "USD";
//                case 28:
//                    return "CAD";
//                default:
//                    return "USD";
//            }
//        }
//    }
//}
