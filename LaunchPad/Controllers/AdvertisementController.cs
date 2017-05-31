using AutoMapper;
using LaunchPad.Data;
using LaunchPad.Data.Infrastructure;
using LaunchPad.Data.Repositories;
using LaunchPad.Entities;
using LaunchPad.Entities.Domain;
using LaunchPad.Entities.Domain.Dummy;
using LaunchPad.Infrastructure.Core;
using LaunchPad.Infrastructure.Extensions;
using LaunchPad.Models;
using LaunchPad.Models.Contact;
using LaunchPad.Models.DesignerDummy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using static LaunchPad.Models.DesignerDummy.DummyViewModel;

namespace LaunchPad.Controllers
{
    [Authorize]
    //[EnableCors(origins: "https://www.metrofamilylaunchpad.com", headers: "Origin, X-Requested-With, Content-Type, Accept, Authorization", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/dummy")]
    public class AdvertisementController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<tbl_media_page_number> _mediaPageNumberRepository;
        private readonly IEntityBaseRepository<lu_adsize_media_trim> _adsizeMediaTrimRepository;
        private readonly IEntityBaseRepository<lu_iss> _issueRepository;
        private readonly IEntityBaseRepository<lu_dummy_coordinate> _dummyCoordinatesRepository;
        private readonly IEntityBaseRepository<tbl_dummy_page_placement> _dummyPagePlacementRepository;
        public AdvertisementController(IEntityBaseRepository<lu_adsize_media_trim> adsizeMediaTrimRepository, IEntityBaseRepository<tbl_media_page_number> mediaPageNumberRepository
            , IEntityBaseRepository<tbl_dummy_page_placement> dummyPagePlacementRepository, IEntityBaseRepository<lu_iss> issueRepository, IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork<ClientDataContext> _unitOfWork
            , IEntityBaseRepository<lu_dummy_coordinate> dummyCoordinatesRepository) : base(_errorsRepository, _unitOfWork)
        {
            _mediaPageNumberRepository = mediaPageNumberRepository;
            _adsizeMediaTrimRepository = adsizeMediaTrimRepository;
            _issueRepository = issueRepository;
            _dummyCoordinatesRepository = dummyCoordinatesRepository;
            _dummyPagePlacementRepository = dummyPagePlacementRepository;

        }
        public IEnumerable<AdvertisementViewMode> AllAds(int pub_id, int iss_id)
        {
            var token = HttpContext.Current.User.Identity.Name;
            var repo = new SecurityRepository();
            var luClient = repo.GetClient(token);
            var mediaTrim = _adsizeMediaTrimRepository.GetAll().ToList();

            var result = _mediaPageNumberRepository.GetAll().Where(x => x.pub_id == pub_id && x.iss_id == iss_id && x.tbl_io_detail.lu_ad_rate.pagination_req==0).ToList().Select(ad => DesignDummyRepository.BuildAdViewModel(ad, luClient));
            var test = result.Join(
                 mediaTrim,
                 mediaPage => new { mediaPage.adsize_id, mediaPage.pub_id },
                 trim => new { trim.adsize_id, trim.pub_id },
                 (t1, t2) => new { t1, t2 })
                .Where(o => o.t2.lu_adsize_trim != null && o.t1.ad_shape_id == o.t2.lu_adsize_trim.ad_shape_id.GetValueOrDefault())
             .Select(o => new { o.t1, o.t2.lu_adsize_trim.adsize_trim_desc, o.t2.lu_adsize_trim.lu_dummy_coordinate });

            var adsList = new List<AdvertisementViewMode>();
            foreach (var i in test)
            {
                i.t1.adsize_trim_desc = i.adsize_trim_desc;
                
                if (i.lu_dummy_coordinate != null)
                {
                    i.t1.coordinates = Mapper.Map<lu_dummy_coordinate, CoordinatesViewMode>(i.lu_dummy_coordinate);
                }
                adsList.Add(i.t1);
            }
            var uniquPlacedAds = _dummyPagePlacementRepository.GetAll().ToList().Select(x => x.media_page_number_id).Distinct();
            return adsList.Where(x => !uniquPlacedAds.Contains(x.ad_id) && x.adsize_trim_desc != null && x.status).OrderBy(x => x.company_name).Distinct();
        }
      
        [Route("GetAvailableAds/{iss_id:int}")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, int iss_id)
        {
            var token = HttpContext.Current.User.Identity.Name;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var issue = _issueRepository.GetSingle(iss_id);
                if (issue != null)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, AllAds(issue.pub_id, issue.iss_id));
                }
                return response;
            });
        }
       
    }
}
