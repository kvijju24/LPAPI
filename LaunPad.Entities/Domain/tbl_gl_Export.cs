using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class tbl_gl_export
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int gl_export_id { get; set; }

        public int gl_export_status { get; set; }
        public string gl_code { get; set; }
        public Nullable<decimal> gl_amount { get; set; }
        public Nullable<System.DateTime> trans_dt { get; set; }
        public string gl_type_desc { get; set; }
        public string receipt_type { get; set; }
        public Nullable<int> receipt_detail_id { get; set; }
        public Nullable<int> late_fee_id { get; set; }
        public Nullable<int> invoice_tax_id { get; set; }
        public Nullable<int> deferred_revenue_id { get; set; }
        public Nullable<int> io_detail_id { get; set; }
        public Nullable<int> bill_detail_id { get; set; }
        public Nullable<int> invoice_number { get; set; }
        public Nullable<int> agree_with { get; set; }
        public Nullable<int> master_id { get; set; }
        public string agree_with_name { get; set; }
        public string advertiser_name { get; set; }
        public Nullable<int> master_contact_id { get; set; }
        public string company_name { get; set; }
        public string billing_address { get; set; }
        public string billing_address2 { get; set; }
        public string billing_city { get; set; }
        public string billing_state { get; set; }
        public string billing_zip { get; set; }
        public string billing_country { get; set; }
        public string contact_name { get; set; }
        public string billing_email { get; set; }
        public string billing_phone { get; set; }
        public string billing_ext { get; set; }
        public string billing_fax { get; set; }
        public int status { get; set; }
        public int currency_id { get; set; }
        public string debit_credit { get; set; }
        public string gl_export_error { get; set; }
        public Nullable<System.DateTime> gl_export_dt { get; set; }
        public System.DateTime create_dt { get; set; }
        public Nullable<int> bank_id { get; set; }
        public string bank_name { get; set; }
        public Nullable<int> brand_id { get; set; }
        public string brand_desc { get; set; }
        public Nullable<int> pib_id { get; set; }
        public string pib_desc { get; set; }
        public Nullable<int> media_id { get; set; }
        public string media_title { get; set; }
        public Nullable<int> media_type_id { get; set; }
        public string media_type_desc { get; set; }
        public Nullable<int> media_group_id { get; set; }
        public string media_group_desc { get; set; }
        public Nullable<int> accounting_division_id { get; set; }
        public string accounting_division_desc { get; set; }
        public Nullable<int> ad_campaign_id { get; set; }
        public string ad_campaign_name { get; set; }
        public Nullable<int> project_id { get; set; }
        public string project_name { get; set; }
        public Nullable<int> sect_id { get; set; }
        public string sect_desc { get; set; }
        public string sect_gl_code { get; set; }
        public Nullable<int> edition_id { get; set; }
        public string edition_desc { get; set; }
        public string edition_gl_code { get; set; }
        public Nullable<int> ad_type_id { get; set; }
        public string ad_type_desc { get; set; }
        public string ad_type_gl_code { get; set; }
        public string project_external_id { get; set; }
        public string edition_external_id { get; set; }
        public string media_group_external_id { get; set; }
    }
}
