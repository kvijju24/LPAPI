using LaunchPad.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchPad.Models.Scheduler
{
    public static class CalendarRepository
    {
        public static IList<CalendarViewModel> All()
        {
            //var result =  IList<CalendarViewModel>;

            //if(result==null)
            //{
               var result = Unity.Work.Repository<Appointment>().GetAll().ToList().Select(app => new CalendarViewModel
                {
                    TaskID = app.Native_ID,
                    Title = app.Subject,
                    Start = DateTime.SpecifyKind(app.Start, DateTimeKind.Utc),
                    End = DateTime.SpecifyKind(app.End, DateTimeKind.Utc),
                    StartTimezone = app.StartTimeZone,
                    EndTimezone = app.StartTimeZone,
                   Description = app.Body,
                    IsAllDay = app.IsAllDayEvent,
                    RecurrenceRule = app.Recurrence,
                    // RecurrenceID = app.RecurrenceID,
                    //OwnerID = app.Launchpad_ID
                }).ToList();
                //HttpContext.Current.Session["Calendar"] = result;
            //}

            return result;
        }

        public static CalendarViewModel One(Func<CalendarViewModel,bool> predicate)
        {
            return All().FirstOrDefault(predicate);
        }

        public static CalendarViewModel Insert(CalendarViewModel appointment)
        {
            if (appointment.TaskID == 0)
            {
                var entity = appointment.ToEntity();
                Unity.Work.Repository<Appointment>().Insert(entity);
                Unity.Work.Save();
                appointment.TaskID = entity.Native_ID;
            }
            return appointment;
        }
    }

   
}