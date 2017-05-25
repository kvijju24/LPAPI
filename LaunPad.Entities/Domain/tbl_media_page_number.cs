using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class tbl_media_page_number
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int media_page_number { get; set; }
        public Nullable<int> io_detail_id { get; set; }
        public Nullable<int> pub_id { get; set; }
        public virtual lu_pub lu_pub { get; set; }
        public Nullable<int> iss_id { get; set; }
        public virtual lu_iss lu_iss { get; set; }
        public string page_desc { get; set; }
        public Nullable<int> page_number { get; set; }
        public int status { get; set; }
        public Nullable<int> pib_id { get; set; }
        public Nullable<int> brand_id { get; set; }
        public Nullable<int> specad_upload_id { get; set; }
        public Nullable<int> edition_id { get; set; }
        public Nullable<int> sect_id { get; set; }
        public virtual lu_ad_sect lu_ad_sect { get; set; }
        public Nullable<int> adsize_id { get; set; }
         public virtual lu_adsize lu_adsize { get; set; }
        public Nullable<int> ad_shape_id { get; set; }
        public virtual lu_ad_shape lu_ad_shape { get; set; }
        public Nullable<int> clr_cde { get; set; }
        public Nullable<int> ad_position_id { get; set; }
        public virtual lu_ad_position lu_ad_position { get; set; }
        public Nullable<int> master_id { get; set; }
        public virtual tbl_master tbl_master { get; set; }
        public Nullable<int> broadcast_program_detail_id { get; set; }
        public Nullable<System.DateTime> start_time { get; set; }
        public Nullable<decimal> ad_length { get; set; }
        public Nullable<System.DateTime> email_dt { get; set; }
        public string email_to { get; set; }
        public Nullable<int> email_sent_by { get; set; }
        public string track_line { get; set; }
        public Nullable<int> pu_media_page_number { get; set; }
        public Nullable<int> broadcast_upload_id { get; set; }
        public Nullable<int> broadcast_program_detail_ad_position_id { get; set; }
        public Nullable<int> broadcast_schedule_id { get; set; }
        public Nullable<System.DateTime> pagination_export { get; set; }
        public string dropbox_filename { get; set; }
        public string dropbox_filename_import { get; set; }
        public Nullable<int> project_id { get; set; }
        public string click_thru { get; set; }
        public string digital_ad_server { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }
        public Nullable<System.DateTime> end_dt { get; set; }
        public Nullable<int> detail_run_date_id { get; set; }
        public virtual tbl_io_detail_run_date tbl_io_detail_run_date { get; set; }
        [ForeignKey("clr_cde")]
        public virtual lu_ad_clr lu_ad_clr { get; set; }
        public virtual lu_brand lu_brand { get; set; }
        public virtual lu_edition lu_edition { get; set; }
        public virtual lu_pib lu_pib { get; set; }
        public virtual tbl_specad_upload tbl_specad_upload { get; set; }
    }
}
