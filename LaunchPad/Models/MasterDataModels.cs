using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaunchPad.Data;

namespace LaunchPad.Models
{
    public class MasterData
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double? Zip { get; set; }
        public string Country { get; set; }
        public double? Phone { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }

        public MasterData ConvertToView(tbl_Master row)
        {
            var data = new MasterData();
            data.CompanyName = row.company_name;
            data.Address = row.address + row.address2;
            data.City = row.city;
            data.State = row.state;
            data.Zip = row.zip_code;
            data.Country = row.country;
            data.Phone = row.phone;
            data.ContactFirstName = row.contact_first_name;
            data.ContactLastName = row.contact_last_name;
            data.Email = row.email;
            data.URL = row.url;
            return data;
        }

    }
}