using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain.Dummy
{
    public partial class lu_dummy_page_dimension
    {
        public lu_dummy_page_dimension()
        {
            this.tbl_dummy_folio = new HashSet<tbl_dummy_folio>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dummy_page_dimension_id { get; set; }
        public Nullable<int> pub_id { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public string measurement { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public string create_by { get; set; }

        public virtual ICollection<tbl_dummy_folio> tbl_dummy_folio { get; set; }
    }
}
