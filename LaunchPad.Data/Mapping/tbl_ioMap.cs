using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LaunchPad.Entities.Domain;

namespace LaunchPad.Data.Mapping
{ 
    //public class tbl_ioMap : EntityTypeConfiguration<tbl_io>
    //{
    //    public tbl_ioMap()
    //    {
    //        ToTable("tbl_io");
    //        HasKey(s => s.io_id).Property(s => s.io_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    //        //HasRequired(s => s.tbl_master).WithMany(s => s.tbl_io).HasForeignKey(s => s.master_id);
    //    }
    //}
}
