using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public partial class tbl_master_contact_brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int master_contact_brand_id { get; set; }
        public int master_contact_id { get; set; }
        [ForeignKey("master_contact_id")]
        public virtual tbl_master_contact tbl_master_contact { get; set; }
        public int brand_id { get; set; }
        public System.DateTime create_dt { get; set; }
        public int create_by { get; set; }
        public int master_id { get; set; }
        [ForeignKey("brand_id")]
        public virtual lu_brand lu_brand { get; set; }
    }
}
