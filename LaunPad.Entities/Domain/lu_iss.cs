using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaunchPad.Entities.Domain
{
    public class lu_iss
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int iss_id { get; set; }
        public int pub_id { get; set; }
        public virtual lu_pub lu_pub { get; set; }
        public string issue_pub_code { get; set; }
        public string issue_pub_description { get; set; }
        public int yr { get; set; }
        public int mth { get; set; }
        public System.DateTime fiscal_dt { get; set; }
        public System.DateTime iss_dt { get; set; }
        public int mail_status { get; set; }
        public Nullable<int> control_grp { get; set; }
        public Nullable<System.DateTime> pay_dt { get; set; }
        public Nullable<int> vol { get; set; }
        public Nullable<int> iss_num { get; set; }
        public Nullable<decimal> net_rev { get; set; }
        public Nullable<decimal> credit { get; set; }
        public Nullable<decimal> bad_debt { get; set; }
        public Nullable<decimal> royality { get; set; }
        public int status { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
        public int iss_closed { get; set; }
        public Nullable<int> last_year_id { get; set; }
        public Nullable<int> payroll_deadline_id { get; set; }
        public Nullable<System.DateTime> trans_dt { get; set; }
    }
}
