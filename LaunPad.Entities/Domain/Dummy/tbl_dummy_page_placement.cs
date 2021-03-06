﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain.Dummy
{
    public partial class tbl_dummy_page_placement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dummy_page_placement_id { get; set; }
        public int dummy_page_id { get; set; }
        public int media_page_number_id { get; set; }
        [ForeignKey("media_page_number_id")]
        public virtual tbl_media_page_number tbl_media_page_number { get; set; }
        public int x_position_start { get; set; }
        public int y_position_start { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> last_mod_dt { get; set; }
        public string last_mod_by { get; set; }

        public virtual tbl_dummy_page tbl_dummy_page { get; set; }
    }
}
