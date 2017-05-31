using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class lu_client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int client_id { get; set; }
        public string client_name { get; set; }
        public string client_contact_first_name { get; set; }
        public string client_contact_last_name { get; set; }
        public string client_contact_title { get; set; }
        public string client_salutation { get; set; }
        public string client_phone { get; set; }
        public string client_fax { get; set; }
        public string client_contact_email { get; set; }
        public string client_address { get; set; }
        public string client_address2 { get; set; }
        public string client_city { get; set; }
        public string client_state { get; set; }
        public string client_zip_code { get; set; }
        public string client_zip4 { get; set; }
        public string client_country { get; set; }
        public string dsn { get; set; }
        public string db { get; set; }
        public string client_domain { get; set; }
        public int client_logo { get; set; }
        public int status { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
        public System.Guid client_auto_id { get; set; }
        public Nullable<int> master_id { get; set; }
        public string gateway_domain { get; set; }
        public string gateway_dsn { get; set; }
        public string gateway_name { get; set; }
        public string gateway_username { get; set; }
        public string gateway_password { get; set; }
        public string gateway_login { get; set; }
        public string gateway_widget_domain { get; set; }
        public string file_server { get; set; }
    }
}
