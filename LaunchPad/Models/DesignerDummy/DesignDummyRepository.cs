using LaunchPad.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LaunchPad.Models.DesignerDummy.DummyViewModel;
using LaunchPad.Entities.Domain.Dummy;
using LaunchPad.Data;
using LaunchPad.Data.Repositories;

namespace LaunchPad.Models.DesignerDummy
{
    public class DesignDummyRepository
    {
        private static LPDataContext db = new LPDataContext();
        public DesignDummyRepository(LPDataContext lp)
        {
            db = lp;
        }
        public static AdvertisementViewMode GetAdViewById(int ad_id)
        {
            using (LPDataContext context = new LPDataContext())
            {
                var ad = context.tbl_media_page_number.Where(x => x.media_page_number == ad_id).FirstOrDefault();
                var adView = BuildAdViewModel(ad);
                var mediaTrim = context.lu_adsize_media_trim.ToList()
                    .Where(x => x.adsize_id == adView.adsize_id && x.pub_id == adView.pub_id && (adView.ad_shape_id == (x.lu_adsize_trim != null ? x.lu_adsize_trim.ad_shape_id.GetValueOrDefault() : 0))).FirstOrDefault();
                if (mediaTrim != null && mediaTrim.lu_adsize_trim != null)
                {
                    adView.adsize_trim_desc = mediaTrim.lu_adsize_trim.adsize_trim_desc;
                    adView.AdSizeType = GetAdSizeType(mediaTrim.lu_adsize_trim.adsize_trim_desc);
                }
                return adView;
            }

        }
        //private ESEntities db = new ESEntities();
        //public MasterController(ESEntities es)
        //{
        //    db = es;
        //}
        public static string TruncateLongString(string str, int maxLength)
        {
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }
        public static IEnumerable<AdvertisementViewMode> AllAds(int pub_id, int iss_id)
        {
            using (LPDataContext context = new LPDataContext())
            {
                var mediaTrim = context.lu_adsize_media_trim.ToList();

                var result = context.tbl_media_page_number.Where(x => x.pub_id == pub_id && x.iss_id == iss_id).ToList().Select(ad => BuildAdViewModel(ad));
                var test = result.Join(
                     mediaTrim,
                     mediaPage => new { mediaPage.adsize_id, mediaPage.pub_id },
                     trim => new { trim.adsize_id, trim.pub_id },
                     (t1, t2) => new { t1, t2 })
                    .Where(o => o.t2.lu_adsize_trim != null && o.t1.ad_shape_id == o.t2.lu_adsize_trim.ad_shape_id.GetValueOrDefault())
                 .Select(o => new { o.t1, o.t2.lu_adsize_trim.adsize_trim_desc });

                var adsList = new List<AdvertisementViewMode>();
                foreach (var i in test)
                {
                    i.t1.adsize_trim_desc = i.adsize_trim_desc;
                    i.t1.AdSizeType = GetAdSizeType(i.adsize_trim_desc);
                    adsList.Add(i.t1);
                }
                var uniquPlacedAds = context.tbl_dummy_page_placement.ToList().Select(x => x.media_page_number_id).Distinct();
                return adsList.Where(x => !uniquPlacedAds.Contains(x.ad_id) && x.adsize_trim_desc != null).OrderBy(x => x.company_name).Distinct();
            }
        }
        
        public static AdvertisementViewMode BuildAdViewModel(tbl_media_page_number ad)
        {
            return new AdvertisementViewMode
            {
                ad_id = ad.media_page_number,
                company_name = ad.tbl_master != null ? TruncateLongString(ad.tbl_master.company_name, 20) : null,
                adsize_desc = ad.lu_adsize != null ? IfNullEmpty(ad.lu_adsize.adsize_desc) : null,
                iss_dt = ad.lu_iss != null ? ad.lu_iss.iss_dt.ToString() : null,
                pub_desc = ad.lu_pub != null ? ad.lu_pub.pub_desc : null,
                spec_o_file = ad.tbl_specad_upload != null ? ad.tbl_specad_upload.spec_o_file : null,
                edition_desc = ad.lu_edition != null ? ad.lu_edition.edition_desc : null,
                sect_desc = ad.lu_ad_sect != null ? ad.lu_ad_sect.sect_desc : null,
                ad_shape_desc = ad.lu_ad_shape != null ? ad.lu_ad_shape.ad_shape_desc : null,
                ad_position_desc = ad.lu_ad_position != null ? ad.lu_ad_position.ad_position_desc : null,
                ad_clr_desc = ad.lu_ad_clr != null ? ad.lu_ad_clr.ad_clr_desc : null,
                adsize_id = ad.adsize_id.GetValueOrDefault(),
                pub_id = ad.pub_id.GetValueOrDefault(),
                ad_shape_id = ad.ad_shape_id.GetValueOrDefault(),
                spec_file = ad.tbl_specad_upload != null ? ad.tbl_specad_upload.spec_file : null,

            };
        }
        public static string IfNullEmpty(string input)
        {
            if (input == null)
                return "";
            else
                return input;
        }
        public static int GetAdSizeType(string desc)
        {
            switch (desc.ToLower())
            {
                case "full page":
                    return 1;
                case "half page vert":
                    return 7;
                case "half page horz":
                    return 2;
                case "1/4 page":
                    return 4;
                case "third page":
                    return 3;
                case "sixth page":
                    return 6;
                case "1/6 page vertical":
                    return 6;
                case "2/3 page":
                    return 8;
                default:
                    return 0;
            }

        }

        public static List<FolioLoadViewModel> GetPubIssueData(int pub_id, int iss_id)
        {
            var pubIssueData = new PubIssueData();
            // pubIssueData.Folios = new List<FolioLoadViewModel>();
            var Folios = new List<FolioLoadViewModel>();
            using (LPDataContext context = new LPDataContext())
            {
                var folios = context.tbl_dummy_folio.Where(x => x.iss_id == iss_id).Select(fo =>
                    new FolioViewMode { folio_name = fo.folio_name,
                        page_sequence = fo.page_sequence,
                        dummy_folio_id = fo.dummy_folio_id,
                        total_page = fo.total_page
                    });

                foreach (var folio in folios)
                {
                    var item = new FolioLoadViewModel();
                    //item.folio = folio;
                    item.pages = GetPagesByFolioId(folio.dummy_folio_id);
                    item.folio_name = folio.folio_name;
                    item.folio_id = folio.dummy_folio_id;
                    item.folio_sequence = folio.page_sequence.GetValueOrDefault();
                    Folios.Add(item);
                }

            }
            return Folios;
        }
        public static List<DummyPageViewModel> GetPagesByFolioId(int folio_id)
        {
            using (LPDataContext context = new LPDataContext())
            {
                // var pageData = new PageData();
                //pageData.folio_id = folio_id;
                var pages = context.tbl_dummy_page.ToList().Where(x => x.dummy_folio_id == folio_id).Select(pl => new DummyPageViewModel
                {
                    dummy_page_id = pl.dummy_page_id,
                    page_number = pl.page_number.GetValueOrDefault(),
                    page_name = pl.page_name,
                    page_note = pl.page_note,
                    page_status = pl.page_status,
                    is_deleted = pl.is_deleted.GetValueOrDefault()

                }).ToList();
                //pageData.pages = pages;
                return pages;
            }
        }
        public static DummyData GetDesignDataByPageId(int page_id)
        {
            using (LPDataContext context = new LPDataContext())
            {
                var dummyData = new DummyData();
                var PageEntity = context.tbl_dummy_page.Where(x => x.dummy_page_id == page_id).FirstOrDefault();
                dummyData.page_id = page_id;
                if (PageEntity != null)
                {
                    dummyData.PageName = PageEntity.page_name;
                    dummyData.page_number = PageEntity.page_number.GetValueOrDefault();
                    var placements = context.tbl_dummy_page_placement.ToList().Where(x => x.dummy_page_id == page_id).Select(pl => new DesignDummyViewModel
                    {
                        ad_id = pl.media_page_number_id,
                        xStart = pl.x_position_start,
                        yStart = pl.y_position_start,
                        placed_ad = GetAdViewById(pl.media_page_number_id)
                    }).ToList();
                    dummyData.dummy = placements;
                    //var uniquAds = placements.Select(x => x.ad_id).Distinct();
                }
                return dummyData;
            }
        }
        public static bool CreatePages(DesignDummyViewModel dummy, int page_id)
        {

            return true;
        }
        public static bool CreateDesign(DesignDummyViewModel dummy, int page_id)
        {
            using (LPDataContext context = new LPDataContext())
            {
                if (dummy.ad_id != 0)
                {
                    //var FolioEntity = CreateDummyFolio();
                    //var FolioEntity = context.tbl_dummy_folio;
                    var PageEntity = context.tbl_dummy_page.Where(x => x.dummy_page_id == page_id).FirstOrDefault();
                    // PageEntity.tbl_dummy_folio = FolioEntity;
                    var PagePlacementEntity = dummy.ToEntity();
                    PagePlacementEntity.tbl_dummy_page = PageEntity;
                    //Unity.Work.Repository<tbl_dummy_page_placement>().Insert(PagePlacementEntity);
                    context.tbl_dummy_page_placement.Add(PagePlacementEntity);
                    context.SaveChanges();

                    ////remove existing item
                    //var existingItem = Unity.Work.Repository<tbl_dummy_page_placement>().GetAll().Where(x => x.dummy_page_id == page_id && x.media_page_number_id == dummy.ad_id).FirstOrDefault();
                    //if(existingItem!= null)
                    //{
                    //    Unity.Work.Repository<tbl_dummy_page_placement>().Delete(existingItem);
                    //}

                    // Unity.Work.Save();
                }
                return true;
            }
        }
        //public static bool UpdateDesign(DesignDummyViewModel dummy,int page_id)
        //{
        //    if (dummy.ad_id != 0)
        //    {
        //        var PageEntity = Unity.Work.Repository<tbl_dummy_page>().GetById(page_id);
        //        var PagePlacementEntity = Unity.Work.Repository<tbl_dummy_page_placement>().GetAll().Where(x => x.dummy_page_id == page_id).FirstOrDefault();
        //        var PagePlacementEntity = dummy.ToEntity(PagePlacementEntity.dummy_page_placement_id);
        //        PagePlacementEntity.tbl_dummy_page = PageEntity;
        //        Unity.Work.Repository<tbl_dummy_page_placement>().Update(PagePlacementEntity);

        //        Unity.Work.Save();
        //    }
        //    return true; ;
        //}
        public static List<tbl_dummy_page> CreatePages(int count, int start_page_number, int folio_id, string page_desc)
        {
            using (LPDataContext context = new LPDataContext())
            {
                var FolioEntity = context.tbl_dummy_folio.Where(x => x.dummy_folio_id == folio_id);
                var pages = new List<tbl_dummy_page>();
                if (FolioEntity != null)
                {
                    for (var page = 0; page < count; page++)
                    {
                        pages.Add(CreateDummyPage(folio_id, new DummyPageViewModel { page_name = page_desc , page_number = (page + start_page_number) }));
                        context.tbl_dummy_page.AddRange(pages);
                    }
                    context.SaveChanges();
                }
                return pages;
            }
            
        }
        public static bool UpdatePages() {
            var pages = Unity.Work.Repository<tbl_dummy_page>().GetAll().ToList();
            int i = 3;
            foreach (var page in pages)
            {
                page.page_name = "Page";
                page.page_number = i;
                i++;
                Unity.Work.Repository<tbl_dummy_page>().Update(page);
            }
            Unity.Work.Save();
            return true;

        }

        public static FolioLoadViewModel CreateDummyFolio(FolioViewMode folio, int pub_id, int iss_id)
        {
            using (LPDataContext context = new LPDataContext())
            {
                var newfolio = new tbl_dummy_folio
                {
                    dummy_page_dimension_id = context.lu_dummy_page_dimension.Where(x => x.pub_id == pub_id).FirstOrDefault().dummy_page_dimension_id,
                    total_page = folio.total_page,
                    start_page_number = folio.start_page_number,
                    iss_id = iss_id,
                    page_sequence = folio.start_page_number,
                    is_deleted = folio.is_deleted,
                    folio_name = folio.folio_name
                };
                context.tbl_dummy_folio.Add(newfolio);
               // UpdateFolioSequence(newfolio, folio.insertAt, folio.folioAt, context);
                context.SaveChanges();
                var result = new FolioLoadViewModel();
                result.pages = new List<DummyPageViewModel>();
                result.pages =  CreatePages(folio.total_page.GetValueOrDefault(), folio.start_page_number.GetValueOrDefault(), newfolio.dummy_folio_id,folio.page_desc).Select(pl => new DummyPageViewModel
               {
                   dummy_page_id = pl.dummy_page_id,
                   page_number = pl.page_number.GetValueOrDefault(),
                   page_name = pl.page_name,
                   page_note = pl.page_note,
                   page_status = pl.page_status,
                   is_deleted = pl.is_deleted.GetValueOrDefault()

               }).ToList();
                result.folio_id = newfolio.dummy_folio_id;
                result.folio_name = newfolio.folio_name;
                result.folio_sequence = newfolio.page_sequence.GetValueOrDefault();
                return result;

            }
        }
        public static void UpdateFolioSequence(tbl_dummy_folio folio, string insertAt, int folioAt, IEntityBaseRepository<tbl_dummy_folio> dummyFolioRepository)
        {
            var destFolio = dummyFolioRepository.GetAll().Where(x => x.dummy_folio_id == folioAt).FirstOrDefault();
            if (destFolio != null)
            {
                if (insertAt == "Before")
                {
                    folio.page_sequence = destFolio.page_sequence;
                    var bottommFolios = dummyFolioRepository.GetAll().Where(x => x.iss_id == folio.iss_id && x.page_sequence > destFolio.page_sequence);
                    foreach (var fo in bottommFolios)
                    {
                        fo.page_sequence++;
                    }
                    destFolio.page_sequence++;
                }
                else
                {
                    folio.page_sequence = destFolio.page_sequence + 1;
                    var bottommFolios = dummyFolioRepository.GetAll().Where(x => x.iss_id == folio.iss_id && x.page_sequence > (destFolio.page_sequence+1));
                    foreach (var fo in bottommFolios)
                    {
                        fo.page_sequence++;
                    }

                }
            }
            else
                folio.page_sequence = 1;
        }
        public static bool DeleteDummyFolio(int folio_id)
        {
            using (LPDataContext context = new LPDataContext())
            {
                var folioObj = context.tbl_dummy_folio.Where(x => x.dummy_folio_id == folio_id).FirstOrDefault();
                var pages = context.tbl_dummy_page.Where(x => x.dummy_folio_id == folio_id);
                foreach (var page in pages)
                {
                    var placements = context.tbl_dummy_page_placement.Where(x => x.dummy_page_id == page.dummy_page_id);
                    context.tbl_dummy_page_placement.RemoveRange(placements);
                }
                context.tbl_dummy_page.RemoveRange(pages);
                context.tbl_dummy_folio.Remove(folioObj);
                var bottommFolios = context.tbl_dummy_folio.Where(x => x.iss_id == folioObj.iss_id && x.page_sequence > folioObj.page_sequence);
                foreach (var fo in bottommFolios)
                {
                    fo.page_sequence--;
                }

                context.SaveChanges();
            }
            return true;
        }
        public static DummyPageViewModel CreatePageByFolio(int folio_id) {
            using (LPDataContext context = new LPDataContext())
            {
                var maxPageCount = context.tbl_dummy_page.Where(x => x.dummy_folio_id == folio_id).Max(x => x.page_number).GetValueOrDefault();
                var pageModel = new DummyPageViewModel { page_name = "page",page_number= (maxPageCount+1) };
                var page = CreateDummyPage(folio_id, pageModel);
                context.tbl_dummy_page.Add(page);
                context.SaveChanges();
                return new DummyPageViewModel
                {
                    dummy_page_id = page.dummy_page_id,
                    page_number = page.page_number.GetValueOrDefault(),
                    page_name = page.page_name,
                    page_note = page.page_note,
                    page_status = page.page_status,
                    is_deleted = page.is_deleted.GetValueOrDefault()

                };
            }
        }
        
        public static tbl_dummy_page CreateDummyPage(int folio_id, DummyPageViewModel page)
        {
            return new tbl_dummy_page { page_name = page.page_name, dummy_folio_id = folio_id,
                page_number =page.page_number,page_note=page.page_note,page_status=page.page_status };
        }
        public static tbl_dummy_page_placement CreateDummyPagePlacement(DesignDummyViewModel dummy)
        {
            return new tbl_dummy_page_placement { x_position_start = dummy.xStart, y_position_start= dummy.yStart,media_page_number_id = dummy.ad_id};
        }
    }
}