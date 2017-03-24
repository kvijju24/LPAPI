using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaunchPad.Entities.Domain
{
    public class lu_adsize
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int adsize_id { get; set; }
        public string adsize_abbrev { get; set; }
        public string adsize_desc { get; set; }
        public Nullable<decimal> inch { get; set; }
        public Nullable<int> columns { get; set; }
        public Nullable<int> row { get; set; }
        public Nullable<System.DateTime> adsize_create_dt { get; set; }
        public int status { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
        public int ad_type_id { get; set; }
        public string external_desc { get; set; }
        public decimal pg { get; set; }
        public decimal ct { get; set; }
    }
}
