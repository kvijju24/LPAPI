using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LaunchPad.Data;
using LaunchPad.Models;
using LaunchPad.Entities.Domain;
using LaunchPad.ModelBinders;
using System.Web.Http.ModelBinding;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace LaunchPad.Controllers
{
    //[RoutePrefix("Master")]
    public class MasterController : ApiController
    {
        //private ESEntities db = new ESEntities();
        //public MasterController(ESEntities es)
        //{
        //    db = es;
        //}
        public class CityView
        {
            public string City { get; set; }
            public string State { get; set; }
            public DateTime DateCreated { get; set; }
        }
        [Route("master")]
        [HttpGet]
        //public DataSourceResult GetMaster([ModelBinder(BinderType = typeof(JsonBodyModelBinder<RecordCollection>))]DataSourceRequest recordCollection)
        public Kendo.Mvc.UI.DataSourceResult GetMaster([ModelBinder(typeof(ModelBinders.DataSourceRequestModelBinder))] Kendo.Mvc.UI.DataSourceRequest request)
        {

            var result = Unity.Work.Repository<tbl_master>().GetAll().ToDataSourceResult(request, master => new
            {
                company_name = master.company_name,
                address = master.address + master.address2,
                City = master.city,
                State = master.state,
                Zip = master.zip_code,
                Country = master.country,
                Phone = master.phone,
                contact_first_name = master.contact_first_name,
                contact_last_name = master.contact_last_name,
                Email = master.email,
                URL = master.url
            });

            return result;
        }
        [Route("getcontact")]
        [HttpGet]
        //public DataSourceResult GetMaster([ModelBinder(BinderType = typeof(JsonBodyModelBinder<RecordCollection>))]DataSourceRequest recordCollection)
        public List<ContactViewModel> GetMasterContact()
        {
            using (LPDataContext context = new LPDataContext())
            {
                var result = context.tbl_master.Where(n => n.contact_first_name != null).Where(a => a.contact_first_name != " " && a.contact_first_name.Contains("Ge")).OrderBy(x => x.contact_first_name).Take(100).Select(master => new ContactViewModel
                {
                    contact_first_name = master.contact_first_name,
                    contact_last_name = master.contact_last_name,
                    Email = master.email,
                    URL = master.url,
                }).ToList();

                return result;
            }
        }
        [Route("City")]
        [HttpGet]
        public CityView GetCityView(string state)
        {

            var result = Unity.Work.Repository<tbl_master>().GetAll().Where(x=>x.state == state).Select( master => new CityView
            {
               City = master.city,
               State = master.state,
               DateCreated = master.create_dt
            }).First();

            return result;
        }

        // GET: api/Master/5
        [ResponseType(typeof(tbl_master))]
        public IHttpActionResult GetMaster(int id)
        {
            tbl_master tbl_Master = Unity.Work.Repository<tbl_master>().GetById(id);
            if (tbl_Master == null)
            {
                return NotFound();
            }

            return Ok(tbl_Master);
        }

        // PUT: api/Master/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaster(int id, tbl_master tbl_Master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Master.master_id)
            {
                return BadRequest();
            }

            Unity.Work.Repository<tbl_master>().Update(tbl_Master);

            try
            {
                Unity.Work.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_MasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Master
        [ResponseType(typeof(tbl_master))]
        public IHttpActionResult PostMaster(tbl_master tbl_Master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Unity.Work.Repository<tbl_master>().Insert(tbl_Master);
            Unity.Work.Save();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Master.master_id }, tbl_Master);
        }

        // DELETE: api/Master/5
        [ResponseType(typeof(tbl_master))]
        public IHttpActionResult DeleteMaster(int id)
        {
            tbl_master tbl_Master = Unity.Work.Repository<tbl_master>().GetById(id);
            if (tbl_Master == null)
            {
                return NotFound();
            }

            Unity.Work.Repository<tbl_master>().Delete(tbl_Master);
            Unity.Work.Save();

            return Ok(tbl_Master);
        }

        private bool tbl_MasterExists(int id)
        {
            return Unity.Work.Repository<tbl_master>().GetAll().Count(e => e.master_id == id) > 0;
        }
    }
}