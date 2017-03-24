using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class Appointment
    {
        public int Native_ID { get; set; }
        public string Sync_UserEmail {get;set;}
        public Nullable<bool> IsMeeting { get; set; }
        public Nullable<bool> IsCancelled { get; set; }
        public Nullable<bool> IsRecurring { get; set; }
        public string Recurrence { get; set; }
        public string FirstOccurrence { get; set; }
        public string LastOccurrence { get; set; }
        public string StartTimeZone { get; set; }
        public System.DateTime? Start { get; set; }
        public System.DateTime? End { get; set; }
        public Nullable<bool> IsAllDayEvent { get; set; }
        public string Location { get; set; }
        public string Sensitivity { get; set; }
        public string AppointmentType { get; set; }
        public Nullable<int> AppointmentState { get; set; }
        public string LastModifiedName { get; set; }
        public string MyResponseType { get; set; }
        public Nullable<int> ReminderMinutesBeforeStart { get; set; }
        public string Organizer { get; set; }
        public string RequiredAttendees { get; set; }
        public string OptionalAttendees { get; set; }
        public Nullable<int> Duration { get; set; }
        public string TimeZone { get; set; }
        public string ICalUid { get; set; }
        public string Id { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string Categories { get; set; }
        public string Importance { get; set; }
        public Nullable<System.DateTime> DateTimeCreated { get; set; }
        public Nullable<System.DateTime> LastModifiedTime { get; set; }
        public string UniqueBody { get; set; }
        public byte[] StoreEntryId { get; set; }
        public string TextBody { get; set; }
        public Nullable<int> Launchpad_ID { get; set; }
    }
}
