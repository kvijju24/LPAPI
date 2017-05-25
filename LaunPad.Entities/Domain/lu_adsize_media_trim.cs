using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class lu_adsize_media_trim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int adsize_media_trim_id { get; set; }
        public int adsize_trim_id { get; set; }
        public virtual lu_adsize_trim lu_adsize_trim { get; set; }
        public int adsize_id { get; set; }
        public int pub_id { get; set; }
    }
}
