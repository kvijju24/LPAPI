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

namespace LaunchPad.Controllers
{
    //[RoutePrefix("Master")]
    public class MasterController : ApiController
    {
        private ESEntities db = new ESEntities();
        //public MasterController(ESEntities es)
        //{
        //    db = es;
        //}

        [Route("master")]
        [HttpGet]
        public List<MasterData> GetMaster()
        {
            var returnset = new List<MasterData>();
            var result= db.tbl_Master.Take(10);
            foreach(var row in result)
            {
                returnset.Add(ConvertToView(row));
            }
            return returnset;
        }
        public MasterData ConvertToView(tbl_Master row)
        {
            var data = new MasterData();
            data.CompanyName = row.company_name;
            data.Address = row.address + row.address2;
            data.City = row.city;
            data.State = row.state;
            data.Zip = row.zip_code;
            data.Country = row.country;
            data.Phone = row.phone;
            data.ContactFirstName = row.contact_first_name;
            data.ContactLastName = row.contact_last_name;
            data.Email = row.email;
            data.URL = row.url;
            return data;
        }
        // GET: api/Master/5
        [ResponseType(typeof(tbl_Master))]
        public IHttpActionResult GetMaster(int id)
        {
            tbl_Master tbl_Master = db.tbl_Master.Find(id);
            if (tbl_Master == null)
            {
                return NotFound();
            }

            return Ok(tbl_Master);
        }

        // PUT: api/Master/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaster(int id, tbl_Master tbl_Master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Master.master_id)
            {
                return BadRequest();
            }

            db.Entry(tbl_Master).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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
        [ResponseType(typeof(tbl_Master))]
        public IHttpActionResult PostMaster(tbl_Master tbl_Master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Master.Add(tbl_Master);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Master.master_id }, tbl_Master);
        }

        // DELETE: api/Master/5
        [ResponseType(typeof(tbl_Master))]
        public IHttpActionResult DeleteMaster(int id)
        {
            tbl_Master tbl_Master = db.tbl_Master.Find(id);
            if (tbl_Master == null)
            {
                return NotFound();
            }

            db.tbl_Master.Remove(tbl_Master);
            db.SaveChanges();

            return Ok(tbl_Master);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_MasterExists(int id)
        {
            return db.tbl_Master.Count(e => e.master_id == id) > 0;
        }
    }
}