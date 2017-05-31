using LaunchPad.Entities.Domain.Dummy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class lu_adsize_trim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int adsize_trim_id { get; set; }
        public string adsize_trim_desc { get; set; }
        public Nullable<double> page_equivalence { get; set; }
        public Nullable<double> height { get; set; }
        public Nullable<double> width { get; set; }
        public string ad_dimension { get; set; }
        public Nullable<int> ad_dimension_type_id { get; set; }
        public string bleed { get; set; }
        public string non_bleed { get; set; }
        public string live { get; set; }
        public string gutter { get; set; }
        public Nullable<int> ad_shape_id { get; set; }
        public virtual lu_ad_shape lu_ad_shape { get; set; }
        public Nullable<int> dummy_coordinate_id { get; set; }
        [ForeignKey("dummy_coordinate_id")]
        public virtual lu_dummy_coordinate lu_dummy_coordinate { get; set; }
    }
}
