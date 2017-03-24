using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaunchPad.Entities.Domain
{
    public class lu_io_status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int io_status_id { get; set; }

        public virtual ICollection<tbl_io_detail> tbl_io_detail { get; set; }


        public string io_status { get; set; }
        public string io_status_desc { get; set; }
        public int io_view { get; set; }
        public int io_edit { get; set; }
        public int io_delete { get; set; }
        public int io_change { get; set; }
        public int io_sls_adj { get; set; }
        public int io_invoice { get; set; }
        public int io_report { get; set; }
        public int io_pull { get; set; }
        public int io_rundate { get; set; }
        public int io_sold { get; set; }
        public int status { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
    }
}
