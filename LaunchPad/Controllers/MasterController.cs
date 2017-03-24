﻿using System;
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

        [Route("master")]
        [HttpGet]
        //public DataSourceResult GetMaster([ModelBinder(BinderType = typeof(JsonBodyModelBinder<RecordCollection>))]DataSourceRequest recordCollection)
        public Kendo.Mvc.UI.DataSourceResult GetMaster([ModelBinder(typeof(ModelBinders.DataSourceRequestModelBinder))] Kendo.Mvc.UI.DataSourceRequest request)
        {

            var result = Unity.Work.Repository<tbl_master>().GetAll().ToDataSourceResult(request, master => new
            {
                CompanyName = master.company_name,
                Address = master.address + master.address2,
                City = master.city,
                State = master.state,
                Zip = master.zip_code,
                Country = master.country,
                Phone = master.phone,
                ContactFirstName = master.contact_first_name,
                ContactLastName = master.contact_last_name,
                Email = master.email,
                URL = "Test"
            });

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