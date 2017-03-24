using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class tbl_io_detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int io_detail_id { get; set; }
        public int io_detail1_id { get; set; }

        public virtual tbl_io tbl_io { get; set; }
        public int io_id { get; set; }

        public Nullable<int> row_id { get; set; }

        public Nullable<int> pub_id { get; set; }
        public virtual lu_pub lu_pub { get; set; }

        public Nullable<int> sect_id { get; set; }
        public virtual lu_ad_sect lu_ad_sect { get; set; }

        public Nullable<int> adsize_id { get; set; }
        public virtual lu_adsize lu_adsize { get; set; }

        public Nullable<decimal> adsize_pages { get; set; }
        public string index_status { get; set; }
        public Nullable<int> clr_cde { get; set; }
        public Nullable<int> inst_num { get; set; }
        public Nullable<decimal> rate_card { get; set; }
        public Nullable<double> disc { get; set; }
        public Nullable<double> qty { get; set; }
        public Nullable<decimal> program_rate { get; set; }
        public Nullable<double> net_rate { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public string mod_type { get; set; }
        public string sls_type { get; set; }
        public string inst_seq { get; set; }
        public int auto_renewal { get; set; }
        public int cancel_status { get; set; }
        public Nullable<int> sls_adj_detail_id { get; set; }

        public Nullable<int> iss_id { get; set; }
        public virtual lu_iss lu_iss { get; set; }

        public Nullable<int> ad_shape_id { get; set; }
        public virtual lu_ad_shape lu_ad_shape { get; set; }

        public Nullable<int> program_pub_id { get; set; }
        public Nullable<int> camera_ready { get; set; }
        public Nullable<int> guarantee { get; set; }
        public Nullable<int> page_preference { get; set; }
        public Nullable<decimal> override_amount { get; set; }
        public Nullable<int> override_id { get; set; }
        public Nullable<int> bonus_id { get; set; }
        public string page_read { get; set; }
        public string page_range { get; set; }
        public int opp_toc { get; set; }
        public string page_number { get; set; }
        public int gp_discount { get; set; }
        public Nullable<decimal> gp_dollar { get; set; }
        public int p_discount { get; set; }
        public Nullable<decimal> p_dollar { get; set; }
        public Nullable<decimal> agency_discount { get; set; }
        public Nullable<int> ad_rate_id { get; set; }
        public int bonus_yn { get; set; }
        public int proof_req { get; set; }
        public Nullable<int> assigned_to { get; set; }
        public Nullable<int> job_ad_identifier { get; set; }

        public int status { get; set; }
        public virtual lu_io_status lu_io_status { get; set; }

        public int agency_discount_yn { get; set; }
        public Nullable<int> bill_to { get; set; }
        public Nullable<int> posted { get; set; }
        public Nullable<int> credit_disapprove_reason { get; set; }
        public Nullable<int> credit_accpt_by { get; set; }
        public Nullable<System.DateTime> credit_accpt_dt { get; set; }
        public int credit_accpt { get; set; }
        public Nullable<int> io_change_detail_id { get; set; }
        public int io_change_status { get; set; }
        public int pagination_req { get; set; }
        public Nullable<int> bill_register_id { get; set; }

        public int agree_with { get; set; }
        public virtual tbl_master tbl_master { get; set; }

        public int bill_plan_link { get; set; }
        public int trade_yn { get; set; }
        public double trade_amount { get; set; }
        public string trade_desc { get; set; }
        public int back_block { get; set; }
        public string reminder { get; set; }
        public string purchase_order { get; set; }
        public Nullable<int> edition_id { get; set; }
        public Nullable<int> freq_num { get; set; }

        public Nullable<int> ad_position_id { get; set; }
        public virtual lu_ad_position lu_ad_position { get; set; }

        public Nullable<int> brand_id { get; set; }
        public Nullable<int> pib_id { get; set; }
        public Nullable<int> qty_bu { get; set; }
        public Nullable<decimal> net_rate_bu { get; set; }
        public decimal trade_amount_bu { get; set; }
        public Nullable<int> io_trans_id { get; set; }
        public Nullable<int> ad_campaign_id { get; set; }
        public int block_io_desc { get; set; }
        public int block_io_price { get; set; }
        public int block_invoice_desc { get; set; }
        public int block_invoice_price { get; set; }
        public int cpm_base { get; set; }
        public Nullable<int> cpm_forecast { get; set; }
        public Nullable<int> cpm_actual { get; set; }
        public Nullable<decimal> cl1 { get; set; }
        public Nullable<decimal> cl2 { get; set; }
        public Nullable<decimal> cl3 { get; set; }
        public Nullable<decimal> cl4 { get; set; }
        public Nullable<decimal> cl5 { get; set; }
        public Nullable<decimal> cl6 { get; set; }
        public Nullable<decimal> cl7 { get; set; }
        public Nullable<decimal> cl8 { get; set; }
        public Nullable<decimal> cl9 { get; set; }
        public Nullable<decimal> cl10 { get; set; }
        public Nullable<decimal> cl11 { get; set; }
        public Nullable<decimal> cl12 { get; set; }
        public Nullable<decimal> cl13 { get; set; }
        public Nullable<decimal> cl14 { get; set; }
        public Nullable<decimal> cl15 { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }
        public Nullable<System.DateTime> end_dt { get; set; }
        public string production_note { get; set; }
        public Nullable<int> registration_item_id { get; set; }
        public string external_invoice { get; set; }
        public Nullable<System.DateTime> external_invoice_dt { get; set; }
        public Nullable<System.DateTime> external_trans_dt { get; set; }
        public Nullable<int> order_number { get; set; }
        public Nullable<int> show_id { get; set; }
        public string external_gl { get; set; }
        public string invoice_comment { get; set; }
        public Nullable<int> ad_coop_id { get; set; }
        public Nullable<int> production_master_contact_id { get; set; }
        public int currency_id { get; set; }
        public Nullable<int> currency_exchange_detail_id { get; set; }
        public Nullable<decimal> currency_exchange_detail_rate { get; set; }
        public Nullable<decimal> exchange_cash { get; set; }
        public Nullable<decimal> exchange_trade { get; set; }
        public Nullable<decimal> exchange_net { get; set; }
        public Nullable<int> reader_service_id { get; set; }
        public int media_currency_id { get; set; }
        public Nullable<int> project_id { get; set; }
        public Nullable<System.DateTime> credit_hold_release { get; set; }
        public Nullable<System.DateTime> reservation_dt { get; set; }
        public string external_id { get; set; }
        public Nullable<int> ad_inventory_id { get; set; }
    }
}
