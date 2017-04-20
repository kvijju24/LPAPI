using LaunchPad.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LaunchPad.Models.DesignerDummy.DummyViewModel;
using LaunchPad.Entities.Domain.Dummy;

namespace LaunchPad.Models.DesignerDummy
{
    public class DesignDummyRepository
    {
        public IEnumerable<AdvertisementViewMode> All()
        {
            var result = Unity.Work.Repository<tbl_media_page_number>().GetAll().Take(1000).ToList().Select(ad => new AdvertisementViewMode
            {
                ad_id = ad.media_page_number,
                company_name = ad.tbl_master.company_name,
                adsize_desc = ad.lu_adsize != null ? ad.lu_adsize.adsize_desc : null,
                iss_dt = ad.lu_iss != null ? ad.lu_iss.iss_dt.ToString() : null,
                pub_desc = ad.lu_pub != null ? ad.lu_pub.pub_desc : null,
                spec_o_file = ad.tbl_specad_upload != null ? ad.tbl_specad_upload.spec_o_file : null,
                edition_desc = ad.lu_edition != null ? ad.lu_edition.edition_desc : null,
                sect_desc = ad.lu_ad_sect != null ? ad.lu_ad_sect.sect_desc : null,
                ad_shape_desc = ad.lu_ad_shape != null ? ad.lu_ad_shape.ad_shape_desc : null,
                ad_position_desc = ad.lu_ad_position != null ? ad.lu_ad_position.ad_position_desc : null,
                ad_clr_desc = ad.lu_ad_clr != null ? ad.lu_ad_clr.ad_clr_desc : null

            });
            return result;
        }

        public static bool Insert(DesignDummyViewModel dummy)
        {
            if (dummy.ad_id != "0")
            {
                var FolioEntity = CreateDummyFolio();
                var PageEntity = CreateDummyPage();
                PageEntity.tbl_dummy_folio = FolioEntity;
                var PagePlacementEntity = CreateDummyPagePlacement(dummy);
                PagePlacementEntity.tbl_dummy_page = PageEntity;
                Unity.Work.Repository<tbl_dummy_folio>().Insert(FolioEntity);
                Unity.Work.Repository<tbl_dummy_page>().Insert(PageEntity);
                Unity.Work.Repository<tbl_dummy_page_placement>().Insert(PagePlacementEntity);

                Unity.Work.Save();
            }
            return true;;
        }
        public static tbl_dummy_folio CreateDummyFolio()
        {
            return new tbl_dummy_folio();
        }
        public static tbl_dummy_page CreateDummyPage()
        {
            return new tbl_dummy_page { page_name = "Vijay Test" };
        }
        public static tbl_dummy_page_placement CreateDummyPagePlacement(DesignDummyViewModel dummy)
        {
            return new tbl_dummy_page_placement { x_position_start = Int32.Parse(dummy.xStart), y_position_start= Int32.Parse(dummy.yStart),media_page_number_id = Int32.Parse(dummy.ad_id)};
        }
    }
}