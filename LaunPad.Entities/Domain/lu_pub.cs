using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaunchPad.Entities.Domain
{
    public class lu_pub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pub_id { get; set; }
        public string pub { get; set; }
        public string pub_desc { get; set; }
        public Nullable<int> loc_cde { get; set; }
        public string edt { get; set; }
        public Nullable<int> grp_id { get; set; }
        public string phone_800 { get; set; }
        public string local_phone { get; set; }
        public string fax_phone { get; set; }
        public string deadline_dt { get; set; }
        public Nullable<System.DateTime> deadline_tm { get; set; }
        public Nullable<int> yrs_pub { get; set; }
        public Nullable<int> issue_per_year { get; set; }
        public Nullable<decimal> agency_discount { get; set; }
        public Nullable<int> division_id { get; set; }
        public string logo_name { get; set; }
        public int book_per_box { get; set; }
        public Nullable<int> autoday { get; set; }
        public int status { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
        public string gl_code { get; set; }
        public string reg_inv_template { get; set; }
        public string statement_template { get; set; }
        public int email_pro_hub { get; set; }
        public string ar_glcode { get; set; }
        public int pub_type_id { get; set; }
        public string trade_revenue_gl { get; set; }
        public int comp_list_limit { get; set; }
        public Nullable<int> graphic_artist { get; set; }
        public decimal pg_size { get; set; }
        public decimal inch_size { get; set; }
        public decimal ct_size { get; set; }
        public Nullable<int> media_group_id { get; set; }
        public int production_run_sheet_type { get; set; }
        public string unapplied_gl { get; set; }
        public Nullable<int> media_sales_tax_id { get; set; }
        public Nullable<int> city_sales_tax_id { get; set; }
        public Nullable<int> county_sales_tax_id { get; set; }
        public Nullable<int> state_sales_tax_id { get; set; }
        public Nullable<int> country_sales_tax_id { get; set; }
        public int start_end_dt { get; set; }
        public int run_date { get; set; }
        public int inventory_block_cust_accp { get; set; }
        public string classified_image_path { get; set; }
        public int classified_image_ad_index { get; set; }
        public string unapplied_reserve_gl { get; set; }
        public string prepay_reserve_gl { get; set; }
        public string late_fee_revenue_gl { get; set; }
        public string media_memo_code { get; set; }
        public int media_currency_id { get; set; }
        public string agency_gl1 { get; set; }
        public string agency_gl2 { get; set; }
        public string sales_tax_gl { get; set; }
        public string trans_dt { get; set; }
        public string deferred_gl { get; set; }
        public int reservation_day { get; set; }
        public int po_upload_approval { get; set; }
        public int block_combined { get; set; }
    }
}
