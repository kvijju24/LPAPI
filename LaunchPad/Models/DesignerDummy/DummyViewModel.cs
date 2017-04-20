using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchPad.Models.DesignerDummy
{
    public class DummyViewModel
    {
        public class DesignDummyViewModel
        {
            public string ad_id { get; set; }
            public string page_id { get; set; }
            public string xStart { get; set; }
            public string yStart { get; set; }
        }

        public class AdvertisementViewMode
        {
            public int ad_id { get; set; }
            public string company_name { get; set; }
            public string adsize_desc { get; set; }
            public string iss_dt { get; set; }
            public string pub_desc { get; set; }
            public string spec_o_file { get; set; }
            public string edition_desc { get; set; }
            public string sect_desc { get; set; }
            public string ad_shape_desc { get; set; }
            public string ad_position_desc { get; set; }
            public string ad_clr_desc { get; set; }
            public string dropbox_filename { get; set; }

        }
    }
}