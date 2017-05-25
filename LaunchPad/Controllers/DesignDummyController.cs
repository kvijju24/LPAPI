using LaunchPad.Data;
using LaunchPad.Entities.Domain;
using LaunchPad.Entities.Domain.Dummy;
using LaunchPad.Models.DesignerDummy;
using LaunchPad.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private IRepository<tbl_dummy_page_placement> _repository;

        [Route("GetAvailableAds")]
        [HttpGet]
        public IEnumerable<AdvertisementViewMode> Get()
        {
            return DesignDummyRepository.AllAds(69,4520);
        }
       
        [Route("SaveDesign")]
        [HttpPost]
        public bool SaveDesign([FromBody]JObject value)
        {
            var designItems = JsonConvert.DeserializeObject<DummyData>(value.ToString());
            using (LPDataContext context = new LPDataContext())
            {
                // Remove all the rows for the page 
                var existingItems = context.tbl_dummy_page_placement.Where(x => x.dummy_page_id == designItems.page_id);
                foreach (var item in existingItems)
                {
                    context.tbl_dummy_page_placement.Remove(item);
                   // Unity.Work.Repository<tbl_dummy_page_placement>().Delete(item);
                }
                //Unity.Work.Save();
                context.SaveChanges();


                if (designItems.dummy != null)
                {
                    foreach (var item in designItems.dummy)
                    {
                        DesignDummyRepository.CreateDesign(item, designItems.page_id);
                    }
                }
            }

            return true;
        }
        [Route("LoadDummyPage")]
        [HttpPost]
        public DummyData LoadDummyPage([FromBody]JObject page_id)
        {
            var pageId = JsonConvert.DeserializeObject<Dictionary<string,int>>(page_id.ToString());
            return DesignDummyRepository.GetDesignDataByPageId(pageId["page_id"]);
        }
        [Route("AddFolio")]
        [HttpPost]
        public FolioLoadViewModel AddFolio([FromBody]JObject input)
        {
            //var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(input.ToString());
            var folioData = JsonConvert.DeserializeObject<FolioData>(input.ToString());
            //if(folioData!=null)
                return DesignDummyRepository.CreateDummyFolio(folioData.folio, folioData.pub_id, folioData.iss_id);
            //var iss_id = data["iss_id"];
            //var pub_id = data["pub_id"];
            //var folio = new FolioViewMode { folio_name= data["folio_name"],}
           // return true;
            //return DesignDummyRepository.GetDesignDataByPageId(pageId["page_id"]);
        }
        [Route("LoadFolioPages")]
        [HttpGet]
        public List<FolioLoadViewModel> LoadFolioPages(int iss_id)
        {
           // var issueId = JsonConvert.DeserializeObject<Dictionary<string, int>>(issue_id.ToString());
            return DesignDummyRepository.GetPubIssueData(69, 4520);
        }
        [Route("UpdateFolioName")]
        [HttpPost]
        public bool UpdateFolioName([FromBody]JObject folio)
        {
            //var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(input.ToString());
            var folioData = JsonConvert.DeserializeObject<Dictionary<string, string>>(folio.ToString());
            var folio_id = 0;
            Int32.TryParse(folioData["folio_id"], out folio_id);
            var folio_name = folioData["folio_name"];
            using (LPDataContext context = new LPDataContext())
            {
               var folioObj= context.tbl_dummy_folio.Where(x => x.dummy_folio_id == folio_id).FirstOrDefault();
                folioObj.folio_name = folio_name;
                context.SaveChanges();
            }
                return true;
           
        }
        [Route("DeleteFolio")]
        [HttpPost]
        public bool DeleteFolio([FromBody]JObject folio)
        {
            //var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(input.ToString());
            var folioData = JsonConvert.DeserializeObject<Dictionary<string, string>>(folio.ToString());
            var folio_id = 0;
            Int32.TryParse(folioData["folio_id"], out folio_id);
            DesignDummyRepository.DeleteDummyFolio(folio_id);
            return true;

        }
        [Route("AddPage")]
        [HttpPost]
        public DummyPageViewModel AddPage([FromBody]JObject folio)
        {
            //var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(input.ToString());
            var folioData = JsonConvert.DeserializeObject<Dictionary<string, string>>(folio.ToString());
            var folio_id = 0;
            Int32.TryParse(folioData["folio_id"], out folio_id);

            return DesignDummyRepository.CreatePageByFolio(folio_id);

        }


    }
}
