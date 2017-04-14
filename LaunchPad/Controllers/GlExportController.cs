using LaunchPad.Entities.Domain;
using LaunchPad.Models.Orders;
using LaunchPad.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Kendo.Mvc.Extensions;

namespace LaunchPad.Controllers
{
    public class GlExportController : ApiController
    {
        [Route("glexport")]
        [HttpGet]
        public List<tbl_gl_export> Get()
        {
            return Unity.Work.Repository<tbl_gl_export>().GetAll().Take(10).ToList();
        }

        // GET: api/GlExport/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GlExport
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GlExport/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GlExport/5
        public void Delete(int id)
        {
        }
    }
}
