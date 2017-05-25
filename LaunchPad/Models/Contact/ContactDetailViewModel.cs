using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchPad.Models.Contact
{
    public class ContactDetailViewModel
    {
        public ContactDetailViewModel()
        {
            brands = new List<BrandViewModel>();
        }
        public int master_contact_id { get; set; }
        public string company_name { get; set; }
        //public string contact_name { get; set; }
        public string contact_first_name { get; set; }
        public string contact_last_name { get; set; }
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
        public Nullable<System.DateTime> dob { get; set; }
        public string notes { get; set; }
        public int sales { get; set; }
        public int production { get; set; }
        public int credit { get; set; }
        public int payable { get; set; }
        public int sales_influencer { get; set; }
        public int decision_maker { get; set; }
        public int billing { get; set; }
        public int primary_contact { get; set; }
        public int email_optout { get; set; }
        public int fax_optout { get; set; }
        public int mail_optout { get; set; }
        public Nullable<int> master_id { get; set; }
        public string photo_filename { get; set; }
        public string linkedin { get; set; }
        public List<BrandViewModel> brands { get; set; }


    }
}