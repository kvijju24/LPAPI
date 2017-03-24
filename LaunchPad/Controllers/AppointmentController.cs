using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LaunchPad.Entities.Domain;
using LaunchPad.Data;
using LaunchPad.Models.Scheduler;
using System.Web.Http.Results;
using LaunchPad.Results;
using System.Web.Helpers;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LaunchPad.Controllers
{
    public class AppointmentController : ApiController
    {
        [Route("Appointment")]
        [HttpGet]
        public List<CalendarViewModel> Index()
        {
            //return this.Jsonp();
            return CalendarRepository.All().ToList();
        }
        public List<tbl_calendar> GetAppointmentCode()
        {
            var returnset = new List<Appointment>();
            //return db.Sync_Appointments.Take(1).ToList();            //return returnset;
            var result= Unity.Work.Repository<tbl_calendar>().GetAll().ToList();
            //foreach(var app in result)
            //{
            //    var x = app.End;
            //}
            return result;
        }
        [Route("Appointment")]
        [HttpPost]
        public List<CalendarViewModel> PostAppointment(HttpRequestMessage request)
        {
            var rawData = request.Content.ReadAsStringAsync().Result;
            var calendarViewModels = JsonConvert.DeserializeObject<List<CalendarViewModel>>(rawData);
            var results = new List<CalendarViewModel>();
            foreach (var app in calendarViewModels)
            {
                //calendarViewModels = CalendarRepository.Insert(calendarViewModels);
                results.Add(CalendarRepository.Insert(app));
            }

            //var response = Request.CreateResponse<CalendarViewModel>(HttpStatusCode.Created, calendarViewModel);
            //return calendarViewModels;
            return results;
        }
    }
}
