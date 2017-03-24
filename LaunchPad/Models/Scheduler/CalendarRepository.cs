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
               var result = Unity.ClientData.Repository<Appointment>().GetAll().ToList().Select(app => new CalendarViewModel
                {
                    TaskID = app.Native_ID,
                    Title = app.Subject,
                    Start = DateTime.SpecifyKind(app.Start ?? DateTime.Now, DateTimeKind.Utc),
                    End = DateTime.SpecifyKind(app.End?? DateTime.Now, DateTimeKind.Utc),
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
                Unity.ClientData.Repository<Appointment>().Insert(entity);
                Unity.ClientData.Save();
                appointment.TaskID = entity.Native_ID;
            }
            return appointment;
        }

        //public static void Update(TaskViewModel task)
        //{
        //    if (!UpdateDatabase)
        //    {
        //        var target = One(e => e.TaskID == task.TaskID);

        //        if (target != null)
        //        {
        //            target.Title = task.Title;
        //            target.Description = task.Description;
        //            target.IsAllDay = task.IsAllDay;
        //            target.RecurrenceRule = task.RecurrenceRule;
        //            target.RecurrenceException = task.RecurrenceException;
        //            target.RecurrenceID = task.RecurrenceID;
        //            target.OwnerID = task.OwnerID;
        //            target.StartTimezone = task.StartTimezone;
        //            target.EndTimezone = task.EndTimezone;
        //            target.Start = task.Start;
        //            target.End = task.End;
        //        }
        //    }
        //    else
        //    {
        //        using (var db = new SampleEntities())
        //        {
        //            var entity = task.ToEntity();
        //            db.Tasks.Attach(entity);
        //            db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        //            db.SaveChanges();
        //        }
        //    }
        //}

        //public static void Delete(TaskViewModel task)
        //{
        //    if (!UpdateDatabase)
        //    {
        //        var target = One(p => p.TaskID == task.TaskID);
        //        if (target != null)
        //        {
        //            All().Remove(target);

        //            var recurrenceExceptions = All().Where(m => m.RecurrenceID == task.TaskID).ToList();

        //            foreach (var recurrenceException in recurrenceExceptions)
        //            {
        //                All().Remove(recurrenceException);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        using (var db = new SampleEntities())
        //        {
        //            var entity = task.ToEntity();
        //            db.Tasks.Attach(entity);

        //            var recurrenceExceptions = db.Tasks.Where(t => t.RecurrenceID == task.TaskID);

        //            foreach (var recurrenceException in recurrenceExceptions)
        //            {
        //                db.Tasks.DeleteObject(recurrenceException);
        //            }

        //            db.Tasks.DeleteObject(entity);
        //            db.SaveChanges();
        //        }
        //    }
        //}
    }

   
}