using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public partial class lu_edition
    {
        public lu_edition()
        {
            this.tbl_media_page_number = new HashSet<tbl_media_page_number>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int edition_id { get; set; }
        public Nullable<int> pub_id { get; set; }
        public string edition_desc { get; set; }
        public string shortname { get; set; }
        public Nullable<int> rate_base { get; set; }
        public Nullable<int> copies { get; set; }
        public int primary_ed { get; set; }
        public int status { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
        public string gl_code { get; set; }
        public string external_id { get; set; }

        public virtual ICollection<tbl_media_page_number> tbl_media_page_number { get; set; }
    }
}
