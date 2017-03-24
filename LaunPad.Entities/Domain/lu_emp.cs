using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    [Table("lu_emp")]
    public class lu_emp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int emp_id { get; set; }
        public string emp_nm { get; set; }
        public string emp_first_nm { get; set; }
        public string emp_last_nm { get; set; }
        public string user_nm { get; set; }
        public string pword { get; set; }
        public string emp_ssn { get; set; }
        public string emp_num { get; set; }
        public string ext_num { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> asgn_dt { get; set; }
        public string emp_title { get; set; }
        public Nullable<decimal> comm_base { get; set; }
        public Nullable<int> emp_type_id { get; set; }
        public Nullable<int> grp_id { get; set; }
        public Nullable<int> title_id { get; set; }
        public Nullable<int> office_id { get; set; }
        public int employment_type_id { get; set; }
        public Nullable<System.DateTime> hire_dt { get; set; }
        public string external_id { get; set; }
        public string color_scheme_id { get; set; }
        public int login_id { get; set; }
        public Nullable<decimal> salary { get; set; }
        public string gl_code { get; set; }
        public string payroll_dept { get; set; }
        public int photo { get; set; }
        public string photo_filename { get; set; }
        public int act_emp { get; set; }
        public Nullable<System.DateTime> last_login { get; set; }
        public string home_left_col { get; set; }
        public string home_right_col { get; set; }
        public int admin_contact { get; set; }
        public int status { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
        public string cell_phone { get; set; }
        public int sl_filter { get; set; }
        public int signature_file { get; set; }
        public string signature_filename { get; set; }
        public string cell_mail { get; set; }
        public int no_display { get; set; }
        public Nullable<decimal> fixed_comm { get; set; }
        public int note_view { get; set; }
        public string personal_did { get; set; }
        public string personal_fax { get; set; }
        public int email_log_view { get; set; }
        public string esign_email { get; set; }
        public int sp_view { get; set; }
        public int helpdesk { get; set; }
        public string email_password { get; set; }
        public string ServiceUrl { get; set; }
        public int search_pref_id { get; set; }
        public int search_pref_swc { get; set; }
        public Nullable<int> time_zone_id { get; set; }
        public Nullable<bool> sync_email_setup { get; set; }
    }
}
