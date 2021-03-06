﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class tbl_master
    {
        public tbl_master()
        {
            tbl_io_details = new HashSet<tbl_io_detail>();
            tbl_master_contacts = new HashSet<tbl_master_contact>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int master_id { get; set; }

        public virtual ICollection<tbl_io_detail> tbl_io_details { get; set; }
        public virtual ICollection<tbl_master_contact> tbl_master_contacts { get; set; }





        public string contact_name { get; set; }
        public string company_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        public string zip4 { get; set; }
        public string carrier_route { get; set; }
        public string state_code { get; set; }
        public string county_numeric_code { get; set; }
        public string phone { get; set; }
        public string filler12 { get; set; }
        public string sic_code { get; set; }
        public string franchise_codes { get; set; }
        public string yp_ad_size { get; set; }
        public string filler16 { get; set; }
        public string pop_code { get; set; }
        public string individual_firm { get; set; }
        public string year_appeared { get; set; }
        public string new_add_dateYYMM { get; set; }
        public string contact_last_name { get; set; }
        public string contact_first_name { get; set; }
        public string contact_prof_title { get; set; }
        public string contact_title_code { get; set; }
        public string gender { get; set; }
        public string employee_size { get; set; }
        public string sales_vol { get; set; }
        public string industry_specific_code { get; set; }
        public string headquarter_branch_code { get; set; }
        public string key_code { get; set; }
        public string fax_phone { get; set; }
        public string office_size { get; set; }
        public string production_date { get; set; }
        public Nullable<int> abi_number { get; set; }
        public Nullable<int> subsidiary_number { get; set; }
        public Nullable<int> ultimate_parent_number { get; set; }
        public string primary_sic { get; set; }
        //public string secondary_sic__1 { get; set; }
        //public string secondary_sic__2 { get; set; }
        //public string secondary_sic__3 { get; set; }
        //public string secondary_sic__4 { get; set; }
        public string parent_employee_size { get; set; }
        public string parent_sales_volume { get; set; }
        public string public_private { get; set; }
        public string stock_exchange_code { get; set; }
        public string stock_exchange_symbol { get; set; }
        public string actual_employees { get; set; }
        public string parent_actual_employee_size { get; set; }
        public string secondary_address { get; set; }
        public string secondary_city { get; set; }
        public string secondary_state { get; set; }
        public string secondary_zip_code { get; set; }
        public string secondary_zip4 { get; set; }
        public string secondary_carrier_route { get; set; }
        public string estimated_sales_volume { get; set; }
        public string estimated_total_sales_volume { get; set; }
        public string employee_derivation_flag { get; set; }
        public Nullable<decimal> latitude_6_decimal { get; set; }
        public Nullable<decimal> longitude_6_decimal { get; set; }
        public string match_level { get; set; }
        public string delivery_point_bar_code { get; set; }
        public string wealth_code { get; set; }
        public string credit_code { get; set; }
        public string fortune_rank { get; set; }
        public string white_collar_code { get; set; }
        public string growing_company_code { get; set; }
        public string true_franchise_code { get; set; }
        public string work_at_home_code { get; set; }
        public string site_number { get; set; }
        public string foreign_parent { get; set; }
        public string ethnicity_code { get; set; }
        public string female_owned_business { get; set; }
        public string importexport { get; set; }
        public string government_segment { get; set; }
        public string call_status_code { get; set; }
        public string action_code { get; set; }
        public string book_number { get; set; }
        public string teleresearch_date { get; set; }
        public string yp_update_date { get; set; }
        public string yellow_page_code { get; set; }
        public string asset_flag { get; set; }
        public string msa_code { get; set; }
        public string transaction_code { get; set; }
        public string tertiary_address { get; set; }
        public string tertiary_city { get; set; }
        public string tertiary_state { get; set; }
        public string tertiary_zip_code { get; set; }
        public string tertiary_zip4 { get; set; }
        public string tertiary_carrier_route { get; set; }
        public string address2 { get; set; }
        public string country { get; set; }
        public Nullable<System.DateTime> update_new_dt { get; set; }
        public Nullable<System.DateTime> update_chg_dt { get; set; }
        public Nullable<System.DateTime> update_del_dt { get; set; }
        public int update_del { get; set; }
        public Nullable<System.DateTime> asc_chg_dt { get; set; }
        public string asc_deliver_code { get; set; }
        public string email { get; set; }
        public string url { get; set; }
        public int status { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public string magic_id { get; set; }
        public string salutation { get; set; }
        public string ext { get; set; }
        public int agency { get; set; }
        public string act_id { get; set; }
        public string act_list { get; set; }
        public string secondary_phone { get; set; }
        public int agency_status { get; set; }
        public Nullable<System.DateTime> agency_status_dt { get; set; }
        public string phone_extension { get; set; }
        public Nullable<int> agency_status_by { get; set; }
        public string bu_magic_id { get; set; }
        public string cell_phone { get; set; }
        public System.DateTime create_dt { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<int> referral_id { get; set; }
        public Nullable<int> account_source_id { get; set; }
        public string account_source_note { get; set; }
        public int account_type_id { get; set; }
        public string cell_mail { get; set; }
        public string delete_reason { get; set; }
        public string profile_desc { get; set; }
        public string url2 { get; set; }
        public string zoom_company_url { get; set; }
        public string company_detail_xml_url { get; set; }

        public virtual ICollection<tbl_io> tbl_io { get; set; }
    }
}
