//using LaunchPad.Entities.Domain;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace LaunchPad.Models.Scheduler
//{
//    public static class CalendarRepository
//    {
//        public static IList<CalendarViewModel> All()
//        {
//            //var result =  IList<CalendarViewModel>;

//            //if(result==null)
//            //{
//               var result = Unity.Work.Repository<tbl_calendar>().GetAll().ToList().Select(app => new CalendarViewModel
//                {
//                    TaskID = app.calendar_id,
//                    Title = app.calendar_event_name,
//                    Start = DateTime.SpecifyKind(app.calendar_start_time ?? DateTime.Now, DateTimeKind.Utc),
//                    End = DateTime.SpecifyKind(app.calendar_end_time ?? DateTime.Now, DateTimeKind.Utc),
//                    StartTimezone = app.StartTimezone,
//                    EndTimezone = app.StartTimezone,
//                    Description = app.calendar_event_description,
//                    IsAllDay = app.IsAllDay,
//                    RecurrenceRule = app.calendar_recurring,
//                  RecurrenceID = app.calendar_rid,
//                  RecurrenceException = app.RecurrenceException
//                    //OwnerID = app.Launchpad_ID
//                }).ToList();
//                //HttpContext.Current.Session["Calendar"] = result;
//            //}

//            return result;
//        }

//        public static CalendarViewModel One(Func<CalendarViewModel,bool> predicate)
//        {
//            return All().FirstOrDefault(predicate);
//        }

//        public static CalendarViewModel Insert(CalendarViewModel appointment)
//        {
//            if (appointment.TaskID == 0)
//            {
//                var entity = appointment.ToEntity();
//                Unity.Work.Repository<tbl_calendar>().Insert(entity);
//                Unity.Work.Repository<tbl_calendar>().Validate(entity);
//                Unity.Work.Save();
//                appointment.TaskID = entity.calendar_id;
//            }
//            return appointment;
//        }

//        //public static void Update(TaskViewModel task)
//        //{
//        //    if (!UpdateDatabase)
//        //    {
//        //        var target = One(e => e.TaskID == task.TaskID);

//        //        if (target != null)
//        //        {
//        //            target.Title = task.Title;
//        //            target.Description = task.Description;
//        //            target.IsAllDay = task.IsAllDay;
//        //            target.RecurrenceRule = task.RecurrenceRule;
//        //            target.RecurrenceException = task.RecurrenceException;
//        //            target.RecurrenceID = task.RecurrenceID;
//        //            target.OwnerID = task.OwnerID;
//        //            target.StartTimezone = task.StartTimezone;
//        //            target.EndTimezone = task.EndTimezone;
//        //            target.Start = task.Start;
//        //            target.End = task.End;
//        //        }
//        //    }
//        //    else
//        //    {
//        //        using (var db = new SampleEntities())
//        //        {
//        //            var entity = task.ToEntity();
//        //            db.Tasks.Attach(entity);
//        //            db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
//        //            db.SaveChanges();
//        //        }
//        //    }
//        //}

//        //public static void Delete(TaskViewModel task)
//        //{
//        //    if (!UpdateDatabase)
//        //    {
//        //        var target = One(p => p.TaskID == task.TaskID);
//        //        if (target != null)
//        //        {
//        //            All().Remove(target);

//        //            var recurrenceExceptions = All().Where(m => m.RecurrenceID == task.TaskID).ToList();

//        //            foreach (var recurrenceException in recurrenceExceptions)
//        //            {
//        //                All().Remove(recurrenceException);
//        //            }
//        //        }
//        //    }
//        //    else
//        //    {
//        //        using (var db = new SampleEntities())
//        //        {
//        //            var entity = task.ToEntity();
//        //            db.Tasks.Attach(entity);

//        //            var recurrenceExceptions = db.Tasks.Where(t => t.RecurrenceID == task.TaskID);

//        //            foreach (var recurrenceException in recurrenceExceptions)
//        //            {
//        //                db.Tasks.DeleteObject(recurrenceException);
//        //            }

//        //            db.Tasks.DeleteObject(entity);
//        //            db.SaveChanges();
//        //        }
//        //    }
//        //}
//    }

   
//}