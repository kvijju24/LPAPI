using LaunchPad.Entities.Domain.Dummy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchPad.Models.DesignerDummy
{
    public class DummyViewModel
    {
        public class DummyData
        {
            public int page_id { get; set; }
            public List<DesignDummyViewModel> dummy { get; set; }
            public List<AdvertisementViewMode> placedAds { get; set; }
            public string PageName { get; set; }
            public int page_number { get; set; }
            public string folio_name { get; set; }
        }
       
        public class PubIssueData
        {
            public List<FolioLoadViewModel> Folios { get; set; }
        }
        public class FolioLoadViewModel
        {
            public FolioLoadViewModel()
            {
                pages = new List<DummyPageViewModel>();
            }
            public string folio_name { get; set; }
            public int folio_id { get; set; }
            public int folio_sequence { get; set; }
            public int iss_id { get; set; }
            public List<DummyPageViewModel> pages { get; set; }
        }
        public class FolioData
        {
            public int iss_id { get; set; }
            public int pub_id { get; set; }
            public FolioViewMode folio { get; set; }
        }
        public class IssueDetail
        {
            public int iss_id { get; set; }
            public int pub_id { get; set; }
            public string pub_desc { get; set; }
            public string iss_dt { get; set; }
        }
        public class DesignDummyViewModel
        {
            public int dummy_page_placement_id { get; set; }
            public int ad_id { get; set; }
            public int xStart { get; set; }
            public int yStart { get; set; }
            public AdvertisementViewMode placed_ad { get; set; }
            public tbl_dummy_page_placement ToEntity()
            {
                if (true)
                {
                    return new tbl_dummy_page_placement
                    {
                        x_position_start = xStart,
                        y_position_start = yStart,
                        media_page_number_id = ad_id
                    };
                }
                else
                {
                    var designEntity = Unity.Work.Repository<tbl_dummy_page_placement>().GetById(dummy_page_placement_id);
                    designEntity.x_position_start = xStart;
                    designEntity.y_position_start = yStart;
                    designEntity.media_page_number_id = ad_id;
                    return designEntity;
                }
            }
        }
        public class DummyPageViewModel
        {
            public DummyPageViewModel()
            {
                PagePleacements = new List<DesignDummyViewModel>();
            }
            public int dummy_page_id { get; set; }
            public int dummy_folio_id { get; set; }
            public string page_name { get; set; }
            public int page_number { get; set; }
            public string page_note { get; set; }
            public string page_status { get; set; }
            public bool is_deleted { get; set; }
            public List<DesignDummyViewModel> PagePleacements { get; set; } 

        }
        public class DeletePages
        {
            public int dummy_folio_id { get; set; }
            public int no_pages { get; set; }
        }
        public class FolioViewMode
        {
            public int dummy_folio_id { get; set; }
            public string folio_name { get; set; }
            public int dummy_page_dimension_id { get; set; }
            public Nullable<int> total_page { get; set; }
            public Nullable<int> start_page_number { get; set; }
            public int iss_id { get; set; }
            public Nullable<int> page_sequence { get; set; }
            public Nullable<bool> is_deleted { get; set; }
            public string page_desc { get; set; }
            public string insertAt { get; set; }
            public int? folioAt { get; set; }

            public tbl_dummy_folio ToEntity()
            {
                return new tbl_dummy_folio
                {
                    total_page = total_page,
                    start_page_number = start_page_number,
                    iss_id = iss_id,
                    page_sequence = start_page_number,
                    is_deleted = is_deleted,
                    folio_name = folio_name
                };
            }
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

            public int adsize_id { get; set; }
            public int pub_id { get; set; }
            public int ad_shape_id { get; set; }

            public string adsize_trim_desc { get; set; }
            public int AdSizeType { get; set; }
            public string spec_file { get; set; }

        }
    }
}