using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class tbl_io_detail_run_date
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int detail_run_date_id { get; set; }
        public Nullable<int> io_detail_id { get; set; }
        public Nullable<System.DateTime> run_date { get; set; }
        public int status { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
    }
}
