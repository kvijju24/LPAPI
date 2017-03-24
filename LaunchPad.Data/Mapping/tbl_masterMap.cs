using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LaunchPad.Entities.Domain;

namespace LaunchPad.Data.Mapping
{
    public class tbl_masterMap : EntityTypeConfiguration<tbl_master>
    {
        public tbl_masterMap()
        {
            ToTable("tbl_Master");
            HasKey(s => s.master_id).Property(s => s.master_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
