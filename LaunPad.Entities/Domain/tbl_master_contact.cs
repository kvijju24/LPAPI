using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class tbl_master_contact
    {
        public tbl_master_contact()
        {
            tbl_master_contact_brands = new HashSet<tbl_master_contact_brand>();
            tbl_master_contact_medias = new HashSet<tbl_master_contact_media>();
        }
        public virtual ICollection<tbl_master_contact_brand> tbl_master_contact_brands { get; set; }
        public virtual ICollection<tbl_master_contact_media> tbl_master_contact_medias { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int master_contact_id { get; set; }
        public string company_name { get; set; }
        public string contact_name { get; set; }
        public string contact_first_name { get; set; }
        public string contact_last_name { get; set; }
        public string salutation { get; set; }
        public string gender { get; set; }
        public string contact_title_code { get; set; }
        public string contact_title { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string phone_extension { get; set; }
        public string fax { get; set; }
        public string email_address { get; set; }
        public string cell_phone { get; set; }
        public string secondary_phone { get; set; }
        public string cell_mail { get; set; }
        public int sales { get; set; }
        public int production { get; set; }
        public int credit { get; set; }
        public int payable { get; set; }
        public int sales_influencer { get; set; }
        public int decision_maker { get; set; }
        public int billing { get; set; }
        public int primary_contact { get; set; }
        public int status { get; set; }
        public Nullable<int> create_by { get; set; }
        public System.DateTime create_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public string notes { get; set; }
        public Nullable<int> master_id { get; set; }
        [ForeignKey("master_id")]
        public virtual tbl_master tbl_master { get; set; }

        public Nullable<int> old_master { get; set; }
        public string photo_filename { get; set; }
        public string ein { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public int ein_ssn { get; set; }
        public int editorial { get; set; }
        public int email_optout { get; set; }
        public int fax_optout { get; set; }
        public int mail_optout { get; set; }
        public int qualified_to_hire { get; set; }
        public int w9_approved { get; set; }
        public int w2_approved { get; set; }
        public string external_id { get; set; }
        public string external_contact_id { get; set; }
        public Nullable<int> zoom_person_id { get; set; }
        public int currency_id { get; set; }
        public string linkedin { get; set; }
        public Nullable<int> import_id { get; set; }
    }
}
