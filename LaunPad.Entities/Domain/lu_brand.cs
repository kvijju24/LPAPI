using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class lu_brand
    {
        public lu_brand()
        {
            this.tbl_media_page_number = new HashSet<tbl_media_page_number>();
            this.tbl_master_contact_brand = new HashSet<tbl_master_contact_brand>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int brand_id { get; set; }
        public string brand_desc { get; set; }
        public int status { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }

        public virtual ICollection<tbl_media_page_number> tbl_media_page_number { get; set; }
        public virtual ICollection<tbl_master_contact_brand> tbl_master_contact_brand { get; set; }
    }
}
