using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain.Dummy
{
    public partial class tbl_dummy_page
    {
        public tbl_dummy_page()
        {
            this.tbl_dummy_page_placement = new HashSet<tbl_dummy_page_placement>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dummy_page_id { get; set; }
        public Nullable<int> dummy_folio_id { get; set; }
        public string page_name { get; set; }
        public Nullable<int> page_number { get; set; }
        public string page_note { get; set; }
        public string page_status { get; set; }
        public Nullable<bool> is_deleted { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> last_mod_dt { get; set; }
        public string last_mod_by { get; set; }

        public virtual tbl_dummy_folio tbl_dummy_folio { get; set; }
        public virtual ICollection<tbl_dummy_page_placement> tbl_dummy_page_placement { get; set; }
    }
}
