using AutoMapper;
using LaunchPad.Data.Infrastructure;
using LaunchPad.Data.Repositories;
using LaunchPad.Entities;
using LaunchPad.Entities.Domain;
using LaunchPad.Infrastructure.Core;
using LaunchPad.Infrastructure.Extensions;
using LaunchPad.Models;
using LaunchPad.Models.Contact;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace LaunchPad.Controllers
{
    [RoutePrefix("api/lookup")]
    public class LookUpController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<lu_brand> _brandRepository;
        public LookUpController(IEntityBaseRepository<lu_brand> brandRepository, IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork) : base(_errorsRepository, _unitOfWork)
        {
            _brandRepository = brandRepository;
        }
        [HttpGet]
        [Route("brand")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var brands = _brandRepository.GetAll().Where(x => x.status == 0).ToList();

                var brandVMs = Mapper.Map<IEnumerable<lu_brand>, IEnumerable<Models.BrandViewModel>>(brands);

                response = request.CreateResponse(HttpStatusCode.OK, brandVMs);

                return response;
            });
        }
        [HttpGet]
        [Route("addbrand")]
        public HttpResponseMessage Add(HttpRequestMessage request)
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
                    var brands = request.DeserializeObject<IEnumerable<BrandViewModel>>("brand");
                    var newBrand = new lu_brand();
                    newBrand.UpdateBrand(brands.FirstOrDefault());
                    _brandRepository.Add(newBrand);

                    _unitOfWork.Commit();

                    // Update view model
                    var brand = Mapper.Map<lu_brand, BrandViewModel>(newBrand);
                    response = request.CreateResponse<BrandViewModel>(HttpStatusCode.Created, brand);
                }

                return response;
            });
        }
    }
}
