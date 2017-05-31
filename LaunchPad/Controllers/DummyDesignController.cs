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
using XsPDF.Pdf;
using static LaunchPad.Models.DesignerDummy.DummyViewModel;

namespace LaunchPad.Controllers
{
    [Authorize]
   // [EnableCors(origins: "https://www.metrofamilylaunchpad.com", headers: "Origin, X-Requested-With, Content-Type, Accept, Authorization", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/dummy")]
    public class DummyDesignController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<tbl_dummy_page> _dummyPageRepository;
        private readonly IEntityBaseRepository<tbl_dummy_folio> _dummyFolioRepository;
        private readonly IEntityBaseRepository<tbl_dummy_page_placement> _dummyPagePlacementRepository;
        private readonly IEntityBaseRepository<lu_dummy_page_dimension> _dummyPageDimentionRepository;
        private readonly IEntityBaseRepository<tbl_media_page_number> _mediaPageNumberRepository;
        private readonly IEntityBaseRepository<lu_adsize_media_trim> _adsizeMediaTrimRepository;
        private readonly IEntityBaseRepository<lu_iss> _issueRepository;
        private readonly IEntityBaseRepository<lu_dummy_coordinate> _dummyCoordinatesRepository;
        public DummyDesignController(IEntityBaseRepository<tbl_dummy_page> dummyPageRepository, IEntityBaseRepository<tbl_dummy_folio> dummyFolioRepository, IEntityBaseRepository<tbl_dummy_page_placement> dummyPagePlacementRepository
            ,IEntityBaseRepository<lu_adsize_media_trim> adsizeMediaTrimRepository, IEntityBaseRepository<tbl_media_page_number> mediaPageNumberRepository, IEntityBaseRepository<lu_dummy_page_dimension> dummyPageDimentionRepository,
             IEntityBaseRepository<lu_iss> issueRepository, IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork<ClientDataContext> _unitOfWork
            ,IEntityBaseRepository<lu_dummy_coordinate> dummyCoordinatesRepository) : base(_errorsRepository, _unitOfWork)
        {
            _dummyPageRepository = dummyPageRepository;
            _dummyFolioRepository = dummyFolioRepository;
            _dummyPagePlacementRepository = dummyPagePlacementRepository;
            _mediaPageNumberRepository = mediaPageNumberRepository;
            _adsizeMediaTrimRepository = adsizeMediaTrimRepository;
            _dummyPageDimentionRepository = dummyPageDimentionRepository;
            _issueRepository = issueRepository;
            _dummyCoordinatesRepository = dummyCoordinatesRepository;
        }
        

        [HttpPost]
        [Route("SaveDesign")]
        public HttpResponseMessage Add(HttpRequestMessage request, DummyData designItems)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    //var designItems = request.DeserializeObject<DummyData>("dummy");
                    var existingItems = _dummyPagePlacementRepository.GetAll().Where(x => x.dummy_page_id == designItems.page_id);
                    foreach (var item in existingItems)
                    {
                        _dummyPagePlacementRepository.Delete(item);
                    }
                    _unitOfWork.Commit();
                    var currentPage = _dummyPageRepository.GetSingle(designItems.page_id);
                    if (designItems.dummy != null)
                    {
                        foreach (var item in designItems.dummy)
                        {
                            var PagePlacementEntity = item.ToEntity();
                            PagePlacementEntity.tbl_dummy_page = currentPage;
                            _dummyPagePlacementRepository.Add(PagePlacementEntity);
                            var mediaPage = _mediaPageNumberRepository.GetSingle(PagePlacementEntity.media_page_number_id);
                            mediaPage.page_desc = currentPage.page_name;
                            mediaPage.page_number = currentPage.page_number;
                        }
                        _unitOfWork.Commit();
                    }
                    response = request.CreateResponse(HttpStatusCode.Created,true);
                }

                return response;
            });
        }
        
        [Route("TokenTest")]
        [HttpGet]
        public HttpResponseMessage GetToken(HttpRequestMessage request)
        {
            
            return CreateHttpResponse(request, () =>
            {
                var token = HttpContext.Current.User.Identity.Name;
                return request.CreateResponse(HttpStatusCode.OK, token);
               
            });
        }
        
        [Route("GetDummyCoordinates")]
        [HttpGet]
        public HttpResponseMessage GetCoordinates(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var coordinates = _dummyCoordinatesRepository.GetAll();
                    response = request.CreateResponse(HttpStatusCode.OK, coordinates);
                return response;
            });
        }
        [HttpGet]
        [Route("LoadDummyPage/{page_id:int}")]
        public HttpResponseMessage LoadDummyPage(HttpRequestMessage request, int page_id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var dummyData = new DummyData();
                var currentPage = _dummyPageRepository.GetSingle(page_id);
                if(currentPage!=null)
                {
                    dummyData.page_id = page_id;
                    dummyData.PageName = currentPage.page_name;
                    dummyData.page_number = currentPage.page_number.GetValueOrDefault();
                    dummyData.folio_name = currentPage.tbl_dummy_folio.folio_name;
                    var placements = _dummyPagePlacementRepository.GetAll().ToList().Where(x => x.dummy_page_id == page_id).Select(pl => new DesignDummyViewModel
                    {
                        ad_id = pl.media_page_number_id,
                        xStart = pl.x_position_start,
                        yStart = pl.y_position_start,
                        placed_ad = GetAdViewById(pl.media_page_number_id)
                    }).ToList();
                    dummyData.dummy = placements;
                }
                response = request.CreateResponse(HttpStatusCode.OK, dummyData);
                return response;
            });
        }
        public AdvertisementViewMode GetAdViewById(int ad_id)
        {
            var token = HttpContext.Current.User.Identity.Name;
            var repo = new SecurityRepository();
            var luClient = repo.GetClient(token);

            var ad = _mediaPageNumberRepository.GetAll().Where(x => x.media_page_number == ad_id).FirstOrDefault();
            var adView = DesignDummyRepository.BuildAdViewModel(ad,luClient);
            var mediaTrim = _adsizeMediaTrimRepository.GetAll().ToList()
                .Where(x => x.adsize_id == adView.adsize_id && x.pub_id == adView.pub_id && (adView.ad_shape_id == (x.lu_adsize_trim != null ? x.lu_adsize_trim.ad_shape_id.GetValueOrDefault() : 0))).FirstOrDefault();
            if (mediaTrim != null && mediaTrim.lu_adsize_trim != null)
            {
                adView.adsize_trim_desc = mediaTrim.lu_adsize_trim.adsize_trim_desc;
                adView.AdSizeType = DesignDummyRepository.GetAdSizeType(mediaTrim.lu_adsize_trim.adsize_trim_desc);
            }
            if(mediaTrim.lu_adsize_trim.lu_dummy_coordinate!=null)
                adView.coordinates = Mapper.Map<lu_dummy_coordinate, CoordinatesViewMode>(mediaTrim.lu_adsize_trim.lu_dummy_coordinate);
            return adView;

        }

        [HttpPost]
        [Route("AddFolio")]
        public HttpResponseMessage AddFolio(HttpRequestMessage request, FolioData folioData)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    //var folioData = request.DeserializeObject<FolioData>("folio");
                    var folio = folioData.folio;
                    var result = new FolioLoadViewModel();
                    if (folio != null)
                    {
                        var newfolio = folioData.folio.ToEntity();
                        newfolio.lu_dummy_page_dimension = _dummyPageDimentionRepository.GetAll().Where(x => x.pub_id == folioData.pub_id).FirstOrDefault();
                        newfolio.iss_id = folioData.iss_id;
                        _dummyFolioRepository.Add(newfolio);

                        DesignDummyRepository.UpdateFolioSequence(newfolio, folio.insertAt, folio.folioAt.GetValueOrDefault(), _dummyFolioRepository);
                        _unitOfWork.Commit();

                        for (var page = 0; page < folio.total_page; page++)
                        {
                            _dummyPageRepository.Add(new tbl_dummy_page { page_name = folio.page_desc, page_number = (page + folio.start_page_number), tbl_dummy_folio = newfolio });
                        }
                        _unitOfWork.Commit();
                        var pages = _dummyPageRepository.GetAll().Where(x => x.dummy_folio_id == newfolio.dummy_folio_id);
                        result.pages = Mapper.Map<IEnumerable<tbl_dummy_page>, List<DummyPageViewModel>>(pages);
                        result.folio_id = newfolio.dummy_folio_id;
                        result.folio_name = newfolio.folio_name;
                        result.folio_sequence = newfolio.page_sequence.GetValueOrDefault();
                        response = request.CreateResponse(HttpStatusCode.Created, result);
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                }

                return response;
            });
        }
        [HttpGet]
        [Route("LoadFolioPages/{iss_id:int}/{filter}")]
        public HttpResponseMessage LoadFolioPages(HttpRequestMessage request, int iss_id,string filter)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                //Delete all inactive ads from pages
                CleanPages();

                var Folios = new List<FolioLoadViewModel>();
                var currentIssue = _issueRepository.GetSingle(iss_id);
                if (filter=="previous")
                {
                    currentIssue = _issueRepository.GetAll().Where(x => x.pub_id == currentIssue.pub_id && x.iss_dt < currentIssue.iss_dt).First();
                }
                else if(filter == "next")
                {
                    currentIssue = _issueRepository.GetAll().Where(x => x.pub_id == currentIssue.pub_id && x.iss_dt > currentIssue.iss_dt).First();
                }
                var folios = _dummyFolioRepository.GetAll().Where(x => x.iss_id == currentIssue.iss_id);
                var foliosVM= Mapper.Map<IEnumerable<tbl_dummy_folio>, List<FolioViewMode>>(folios);
                foreach (var folio in foliosVM)
                {
                    var item = new FolioLoadViewModel();
                    item.pages = GetPagesByFolioId(folio.dummy_folio_id);
                    item.folio_name = folio.folio_name;
                    item.folio_id = folio.dummy_folio_id;
                    item.folio_sequence = folio.page_sequence.GetValueOrDefault();
                    item.iss_id = currentIssue.iss_id;
                    Folios.Add(item);
                }
                response = request.CreateResponse(HttpStatusCode.OK, Folios);
                return response;
            });
        }
        public void CleanPages()
        {
            var placements = _dummyPagePlacementRepository.GetAll().Where(x => x.tbl_media_page_number.status == 1);
            foreach(var placement in placements)
            {
                _dummyPagePlacementRepository.Delete(placement);
            }
            _unitOfWork.Commit();
        }
        [HttpGet]
        [Route("LoadIssueDetail/{iss_id:int}")]
        public HttpResponseMessage LoadIssueDetail(HttpRequestMessage request, int iss_id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var issue = new IssueDetail();
                var currentIssue = _issueRepository.GetSingle(iss_id);
                issue.pub_desc = currentIssue.lu_pub.pub_desc;
                issue.iss_dt = currentIssue.iss_dt.ToShortDateString();
                issue.iss_id = currentIssue.iss_id;
                response = request.CreateResponse(HttpStatusCode.OK, issue);
                return response;
            });
        }
        [HttpGet]
        [Route("GetIssueid/{iss_id:int}/{filter}")]
        public HttpResponseMessage GetIssueId(HttpRequestMessage request, int iss_id,string filter)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var currentIssue = _issueRepository.GetSingle(iss_id);
                if (filter == "previous")
                {
                    currentIssue = _issueRepository.GetAll().Where(x => x.pub_id == currentIssue.pub_id && x.iss_dt < currentIssue.iss_dt).OrderByDescending(x => x.iss_dt).First();
                }
                else if (filter == "next")
                {
                    currentIssue = _issueRepository.GetAll().Where(x => x.pub_id == currentIssue.pub_id && x.iss_dt > currentIssue.iss_dt).OrderBy(x=>x.iss_dt).First();
                }
                response = request.CreateResponse(HttpStatusCode.OK, currentIssue.iss_id);
                return response;
            });
        }
        public List<DummyPageViewModel> GetPagesByFolioId(int folio_id)
        {
            return _dummyPageRepository.GetAll().ToList().Where(x => x.dummy_folio_id == folio_id).Select(pl => new DummyPageViewModel
            {
                dummy_page_id = pl.dummy_page_id,
                page_number = pl.page_number.GetValueOrDefault(),
                page_name = pl.page_name,
                page_note = pl.page_note,
                page_status = pl.page_status,
                is_deleted = pl.is_deleted.GetValueOrDefault(),
                PagePleacements = _dummyPagePlacementRepository.GetAll().ToList().Where(x => x.dummy_page_id == pl.dummy_page_id).Select(de => new DesignDummyViewModel
                {
                    ad_id = de.media_page_number_id,
                    xStart = de.x_position_start,
                    yStart = de.y_position_start,
                    placed_ad = GetAdViewById(de.media_page_number_id)
                }).ToList()

        }).ToList();
        }
        [HttpPost]
        [Route("UpdateFolioName")]
        public HttpResponseMessage UpdateFolioName(HttpRequestMessage request, FolioViewMode folio)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var currentFolio = _dummyFolioRepository.GetSingle(folio.dummy_folio_id);
                    if (currentFolio != null)
                    {
                        currentFolio.folio_name = folio.folio_name;
                        _unitOfWork.Commit();
                        response = request.CreateResponse(HttpStatusCode.OK, true);
                    }
                    else
                    {
                        response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                }
                return response;
            });
        }
        [HttpPost]
        [Route("UpdatePageName")]
        public HttpResponseMessage UpdatePageName(HttpRequestMessage request, DummyPageViewModel Page)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var currentPage = _dummyPageRepository.GetSingle(Page.dummy_page_id);
                    if (currentPage != null)
                    {
                        currentPage.page_name = Page.page_name;
                        _unitOfWork.Commit();
                        response = request.CreateResponse(HttpStatusCode.OK, true);
                    }
                    else
                    {
                        response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                }
                return response;
            });
        }
        [HttpPost]
        [Route("UpdatePageNumber")]
        public HttpResponseMessage UpdatePageNumber(HttpRequestMessage request, DummyPageViewModel Page)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var currentPage = _dummyPageRepository.GetSingle(Page.dummy_page_id);
                    if (currentPage != null)
                    {
                        currentPage.page_number = Page.page_number;
                        _unitOfWork.Commit();
                        response = request.CreateResponse(HttpStatusCode.OK, true);
                    }
                    else
                    {
                        response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                }
                return response;
            });
        }

        [HttpPost]
        [Route("deletepages")]
        public HttpResponseMessage DeletePages(HttpRequestMessage request, DeletePages values)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var currentFolio = _dummyFolioRepository.GetAll().Where(x=>x.dummy_folio_id==values.dummy_folio_id).FirstOrDefault();
                    var pagesToDelete = values.no_pages;
                    if (currentFolio != null)
                    {
                        var pages = _dummyPageRepository.GetAll().Where(x => x.dummy_folio_id == currentFolio.dummy_folio_id).OrderByDescending(x=>x.page_number).Take(pagesToDelete);
                        foreach(var page in pages)
                        {
                            var placements = _dummyPagePlacementRepository.GetAll().Where(x => x.dummy_page_id == page.dummy_page_id);
                            foreach (var pla in placements)
                            {
                                _dummyPagePlacementRepository.Delete(pla);
                            }
                            _dummyPageRepository.Delete(page);
                        }
                        _unitOfWork.Commit();
                        response = request.CreateResponse(HttpStatusCode.OK,true);
                    }
                    else
                    {
                        response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                }
                return response;
            });
        }
        [HttpGet]
        [Route("DeleteFolio/{folio_id:int}")]
        public HttpResponseMessage DeleteFolio(HttpRequestMessage request, int folio_id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var currentFolio = _dummyFolioRepository.GetSingle(folio_id);                  
                    if (currentFolio != null)
                    {
                        var pages = _dummyPageRepository.GetAll().Where(x => x.dummy_folio_id == folio_id);
                        foreach (var page in pages)
                        {
                            var placements = _dummyPagePlacementRepository.GetAll().Where(x => x.dummy_page_id == page.dummy_page_id);
                            foreach(var pla in placements)
                            {
                                _dummyPagePlacementRepository.Delete(pla);
                            }
                            _dummyPageRepository.Delete(page);
                        }
                        _dummyFolioRepository.Delete(currentFolio);
                       
                        var bottommFolios = _dummyFolioRepository.GetAll().Where(x => x.iss_id == currentFolio.iss_id && x.page_sequence > currentFolio.page_sequence);
                        foreach (var fo in bottommFolios)
                        {
                            fo.page_sequence--;
                        }
                        _unitOfWork.Commit();
                        response = request.CreateResponse(HttpStatusCode.OK,true);
                    }
                    else
                    {
                        response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                }
                return response;
            });
        }
        [HttpGet]
        [Route("AddPage/{folio_id:int}")]
        public HttpResponseMessage AddPage(HttpRequestMessage request, int folio_id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var currentFolio = _dummyFolioRepository.GetSingle(folio_id);
                    if (currentFolio != null)
                    {
                        var maxPageCount = _dummyPageRepository.GetAll().Where(x => x.dummy_folio_id == folio_id).Max(x => x.page_number).GetValueOrDefault();
                        var page_desc = _dummyPageRepository.GetAll().Where(x => x.dummy_folio_id == folio_id).FirstOrDefault().page_name;
                        
                         var page = new tbl_dummy_page { page_name = page_desc, page_number = maxPageCount+1, tbl_dummy_folio = currentFolio };
                         _dummyPageRepository.Add(page);
                        _unitOfWork.Commit();
                       var pageVM = Mapper.Map<tbl_dummy_page, DummyPageViewModel>(page);
                        response = request.CreateResponse(HttpStatusCode.Created, pageVM);
                    }
                    else
                    {
                        response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                }
                return response;
            });
        }
        

    }
}
