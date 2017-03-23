using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public partial class tbl_calendar
    {
        public int calendar_id { get; set; }
        public Nullable<System.DateTime> calendar_date { get; set; }
        public string calendar_event_name { get; set; }
        public string calendar_event_description { get; set; }
        public string calendar_event_type { get; set; }
        public string calendar_location { get; set; }
        public Nullable<System.DateTime> ocalendar_start_time { get; set; }
        public Nullable<System.DateTime> calendar_start_time { get; set; }
        public string calendar_stampm { get; set; }
        public Nullable<System.DateTime> ocalendar_end_time { get; set; }
        public Nullable<System.DateTime> calendar_end_time { get; set; }
        public string calendar_etampm { get; set; }
        public Nullable<decimal> calendar_price { get; set; }
        public string calendar_contact { get; set; }
        public string calendar_phone { get; set; }
        public string calendar_email { get; set; }
        public string calendar_website { get; set; }
        public string calendar_sku { get; set; }
        public string calendar_recurring { get; set; }
        public Nullable<int> calendar_rid { get; set; }
        public Nullable<int> calendar_emp_id { get; set; }
        public Nullable<int> calendar_reminder { get; set; }
        public string calendar_reminder_sel { get; set; }
        public string calendar_type { get; set; }
        public Nullable<int> calendar_ref_id { get; set; }
        public Nullable<int> act_id { get; set; }
        public Nullable<int> code_id { get; set; }
        public Nullable<int> ref_id { get; set; }
        public Nullable<int> proj_id { get; set; }
        public int reminder_sent { get; set; }
        public Nullable<System.DateTime> reminder_sent_date { get; set; }
        public Nullable<System.DateTime> reminder_date { get; set; }
        public Nullable<int> calendar_grp_id { get; set; }
        public string s_adsize { get; set; }
        public string s_frequency { get; set; }
        public string s_pres_result { get; set; }
        public Nullable<double> s_revenue { get; set; }
        public string s_type { get; set; }
        public Nullable<int> s_result { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public int status { get; set; }
        public int high_pri { get; set; }
        public Nullable<int> master_id { get; set; }
        public Nullable<int> old_master { get; set; }
        public int complete { get; set; }
        public int export { get; set; }
        public int read_only { get; set; }
        public Nullable<int> link_calendar_id { get; set; }
        public int rollover { get; set; }
        public Nullable<System.DateTime> rodate { get; set; }
        public int call_list { get; set; }
        public Nullable<int> master_contact_id { get; set; }
        public string calendar_color { get; set; }
        public Nullable<int> opportunity_id { get; set; }
        public Nullable<System.DateTime> reminder_utc { get; set; }
        public Nullable<long> Sync_Key { get; set; }
        public bool is_exchange { get; set; }
        public bool is_exchange_processed { get; set; }
        public bool is_calendar_processed { get; set; }
    }
}
