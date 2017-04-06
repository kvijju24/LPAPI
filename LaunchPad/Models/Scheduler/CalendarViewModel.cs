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

        public tbl_calendar ToEntity()
        {
            return new tbl_calendar
            {
                calendar_event_name = Title,
                calendar_start_time = Start,
                StartTimezone = StartTimezone,
                calendar_end_time = End,
                EndTimezone = EndTimezone,
                calendar_event_description = Description,
                RecurrenceRule = RecurrenceRule,
                RecurrenceException = RecurrenceException,
                calendar_rid = RecurrenceID,
                IsAllDay = IsAllDay
                
            };
        }
    }
}