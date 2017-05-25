using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class tbl_master_contact_media
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int master_contact_media_id { get; set; }
        public int pub_id { get; set; }
        [ForeignKey("pub_id")]
        public virtual lu_pub lu_pub { get; set; }
        public int master_contact_id { get; set; }
        [ForeignKey("master_contact_id")]
        public virtual tbl_master_contact tbl_master_contact { get; set; }
        public System.DateTime create_dt { get; set; }
        public int create_by { get; set; }
    }
}
