using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain.Dummy
{
    public partial class tbl_dummy_folio
    {
        public tbl_dummy_folio()
        {
            this.tbl_dummy_page = new HashSet<tbl_dummy_page>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dummy_folio_id { get; set; }
        public Nullable<int> dummy_page_dimension_id { get; set; }
        public Nullable<int> total_page { get; set; }
        public Nullable<int> start_page_number { get; set; }
        public Nullable<int> iss_id { get; set; }
        public Nullable<int> page_sequence { get; set; }
        public Nullable<bool> is_deleted { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> last_mod_dt { get; set; }
        public string last_mod_by { get; set; }

        public virtual lu_dummy_page_dimension lu_dummy_page_dimension { get; set; }
        public virtual ICollection<tbl_dummy_page> tbl_dummy_page { get; set; }
    }
}
