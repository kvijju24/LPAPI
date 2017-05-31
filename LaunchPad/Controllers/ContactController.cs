//using AutoMapper;
//using LaunchPad.Data;
//using LaunchPad.Data.Infrastructure;
//using LaunchPad.Data.Repositories;
//using LaunchPad.Entities;
//using LaunchPad.Entities.Domain;
//using LaunchPad.Infrastructure.Core;
//using LaunchPad.Models;
//using LaunchPad.Models.Contact;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Cors;

//namespace LaunchPad.Controllers
//{
//    [Authorize]
//    [EnableCors(origins: "https://www.metrofamilylaunchpad.com", headers: "Origin, X-Requested-With, Content-Type, Accept, Authorization", methods: "*", SupportsCredentials = true)]
//    [RoutePrefix("api/contact")]
//    public class ContactController : ApiControllerBase
//    {
//        private readonly IEntityBaseRepository<tbl_master_contact> _masterContactRepository;
//        public ContactController(IEntityBaseRepository<tbl_master_contact> masterContactRepository, IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork<LPDataContext> _unitOfWorkSecurity, IUnitOfWork<ClientDataContext> _unitOfWork) : base(_errorsRepository, _unitOfWorkSecurity, _unitOfWork)
//        {
//            _masterContactRepository = masterContactRepository;
//        }

//        [HttpGet]
//        [Route("all")]
//        public HttpResponseMessage Get(HttpRequestMessage request)
//        {
//            return CreateHttpResponse(request, () =>
//            {
//                HttpResponseMessage response = null;
//                var contacts = _masterContactRepository.GetAll().Where(x=>x.contact_first_name!= null).Take(100).ToList();

//                var contactsVM = Mapper.Map<IEnumerable<tbl_master_contact>, IEnumerable<Models.Contact.ContactViewModel>>(contacts);
//                var user = User.Identity.Name;
//                var test = User.Identity.IsAuthenticated;

//                response = request.CreateResponse(HttpStatusCode.OK, contactsVM);

//                return response;
//            });
//        }
//        [HttpGet]
//        [Route("details/{id:int}")]
//        public HttpResponseMessage GetContactById(HttpRequestMessage request, int id)
//        {
//            return CreateHttpResponse(request, () =>
//            {
//                HttpResponseMessage response = null;
//                var contact = _masterContactRepository.GetSingle(id);

//                var contactVM = Mapper.Map<tbl_master_contact, ContactDetailViewModel>(contact);
//                foreach(var contactBrand in contact.tbl_master_contact_brands)
//                {
//                    contactVM.brands.Add(Mapper.Map<lu_brand, BrandViewModel>(contactBrand.lu_brand));
//                }

//                response = request.CreateResponse(HttpStatusCode.OK, contactVM);

//                return response;
//            });
//        }
//    }
//}
