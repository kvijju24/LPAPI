using LaunchPad.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchPad.Models.Scheduler
{
    public class CalendarViewModel
    : SchedulerEvent
    {
        public int TaskID { get; set; }
        public int? OwnerID { get; set; }

        public Appointment ToEntity()
        {
            return new Appointment
            {
                Subject = Title,
                Start = Start,
                StartTimeZone = StartTimezone,
                End = End,
                //EndTimezone = EndTimezone,
                Body = Description,
                Recurrence = RecurrenceRule,
               // RecurrenceException = RecurrenceException,
                //calendar_rid = RecurrenceID,
                IsAllDayEvent = IsAllDay,
                //Launchpad_ID = OwnerID,
                Sync_UserEmail="kvijju24@gmail.com"
                
            };
        }
    }
}