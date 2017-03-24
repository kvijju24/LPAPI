using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class tbl_io_detail1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int io_detail1_id { get; set; }
        public Nullable<int> io_id { get; set; }
        public int status { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<int> ad_rate_id { get; set; }
        public Nullable<double> qty { get; set; }
        public Nullable<int> inst_num { get; set; }
        public Nullable<int> freq_num { get; set; }
        public int trade_yn { get; set; }
        public Nullable<int> iss_id { get; set; }
        public Nullable<int> agency_discount_yn { get; set; }
        public string sls_type { get; set; }
        public int io_detail_id_yn { get; set; }
        public int geo { get; set; }
        public int demo { get; set; }
        public int gdp { get; set; }
        public Nullable<int> qty_bu { get; set; }

        public virtual tbl_io tbl_io { get; set; }
    }
}
