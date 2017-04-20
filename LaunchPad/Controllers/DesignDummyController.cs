using LaunchPad.Entities.Domain;
using LaunchPad.Models.DesignerDummy;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using static LaunchPad.Models.DesignerDummy.DummyViewModel;

namespace LaunchPad.Controllers
{
    public class DesignDummyController : ApiController
    {
        [Route("GetAvailableAds")]
        [HttpGet]
        public IEnumerable<AdvertisementViewMode> Get()
        {
            var result = Unity.Work.Repository<tbl_media_page_number>().GetAll().Take(1000).ToList().Select(ad => new AdvertisementViewMode
            {
                ad_id = ad.media_page_number,
                company_name = ad.tbl_master.company_name,
                adsize_desc = ad.lu_adsize != null ? ad.lu_adsize.adsize_desc : null,
                iss_dt = ad.lu_iss != null ? ad.lu_iss.iss_dt.ToString() : null,
                pub_desc = ad.lu_pub != null ? ad.lu_pub.pub_desc : null,
                spec_o_file = ad.tbl_specad_upload !=null ? ad.tbl_specad_upload.spec_o_file:null,
                edition_desc = ad.lu_edition != null ? ad.lu_edition.edition_desc : null,
                sect_desc = ad.lu_ad_sect != null ? ad.lu_ad_sect.sect_desc : null,
                ad_shape_desc = ad.lu_ad_shape != null ? ad.lu_ad_shape.ad_shape_desc : null,
                ad_position_desc = ad.lu_ad_position != null ? ad.lu_ad_position.ad_position_desc : null,
                ad_clr_desc = ad.lu_ad_clr != null ? ad.lu_ad_clr.ad_clr_desc : null

            });
            return result;
        }
        [Route("SaveDesign")]
        [HttpPost]
        public bool SaveDesign([FromBody]dynamic value)
        {
            var jss = new JavaScriptSerializer();
            List<DesignDummyViewModel> items = jss.Deserialize<List<DesignDummyViewModel>>(value);
            //var data = formData["data"];
            //foreach(var item in items)
            //{
            //    DesignDummyRepository.Insert(item);
            //}
            return true;
        }
        

        
    }
}
