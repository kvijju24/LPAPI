using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class tbl_specad_upload
    {
        public tbl_specad_upload()
        {
            this.tbl_media_page_number = new HashSet<tbl_media_page_number>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int specad_upload_id { get; set; }
        public int specad_id { get; set; }
        public int created_by { get; set; }
        public Nullable<System.DateTime> created_dt { get; set; }
        public string spec_file { get; set; }
        public string spec_o_file { get; set; }
        public string spec_desc { get; set; }
        public int sequence_number { get; set; }
        public Nullable<System.DateTime> email_dt { get; set; }
        public string email_to { get; set; }
        public Nullable<int> email_sent_by { get; set; }
        public string track_line { get; set; }
        public int status { get; set; }
        public Nullable<int> status_by { get; set; }
        public Nullable<System.DateTime> status_dt { get; set; }
        public Nullable<int> filename_id { get; set; }

        public virtual ICollection<tbl_media_page_number> tbl_media_page_number { get; set; }
    }
}
