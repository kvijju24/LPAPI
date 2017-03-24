using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class tbl_io
    {
        public tbl_io()
        {
            this.tbl_io_detail1 = new HashSet<tbl_io_detail1>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int io_id { get; set; }
        public Nullable<System.DateTime> io_create_dt { get; set; }
        public Nullable<int> emp_id { get; set; }
        public Nullable<int> grp_id { get; set; }
        public string io_user_nm { get; set; }
        public Nullable<decimal> net_value { get; set; }
        public string conditions { get; set; }
        public string mgr_apprv_nm { get; set; }
        public Nullable<System.DateTime> mgr_apprv_dt { get; set; }
        public Nullable<System.DateTime> est_cls_dt { get; set; }
        public Nullable<int> fc_prob { get; set; }
        public int status { get; set; }
        public Nullable<System.DateTime> status_dt { get; set; }
        public Nullable<int> status_emp_id { get; set; }
        public string cust_accp_status { get; set; }
        public string cust_accp_by { get; set; }
        public Nullable<System.DateTime> cust_accp_dt { get; set; }
        public string sig_nm { get; set; }
        public string sig_title { get; set; }
        public Nullable<System.DateTime> sig_dt { get; set; }
        public string agnc_nm { get; set; }
        public string agnc_addr { get; set; }
        public string agnc_title { get; set; }
        public Nullable<System.DateTime> agnc_dt { get; set; }
        public string mgr_disapprove_reason { get; set; }
        public string sls_type { get; set; }
        public int master_id { get; set; }
        public Nullable<System.DateTime> time_stamp { get; set; }
        public int agnc_discount { get; set; }
        public Nullable<int> bill_to { get; set; }
        public Nullable<int> master_contact_id { get; set; }
        public int tearsheet { get; set; }
        public Nullable<int> ts_qty { get; set; }
        public Nullable<int> magic_contract_number { get; set; }
        public Nullable<int> old_master { get; set; }
        public Nullable<int> agree_with { get; set; }
        public Nullable<int> agency_id { get; set; }
        public string add_comments { get; set; }
        public Nullable<int> sold_by { get; set; }
        public Nullable<decimal> org_net_value { get; set; }
        public Nullable<int> opportunity_id { get; set; }
        public Nullable<int> restricted_io_print { get; set; }
        public int web_opt_out { get; set; }
        public int print_opt_out { get; set; }
        public string import_id { get; set; }

        public virtual ICollection<tbl_io_detail1> tbl_io_detail1 { get; set; }
        public virtual ICollection<tbl_io_detail> tbl_io_detail { get; set; }
        public virtual tbl_master tbl_master { get; set; }
    }
}
