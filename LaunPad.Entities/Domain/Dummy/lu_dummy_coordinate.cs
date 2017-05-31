using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain.Dummy
{
    public class lu_dummy_coordinate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dummy_coordinate_id { get; set; }
        public Nullable<int> height { get; set; }
        public Nullable<int> width { get; set; }
        public string color { get; set; }
        public string dummy_desc { get; set; }
        public string icon_image { get; set; }
        public Nullable<int> dummy_type { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> last_mod_dt { get; set; }
        public string last_mod_by { get; set; }
    }
}
