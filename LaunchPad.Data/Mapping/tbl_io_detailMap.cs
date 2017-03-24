using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LaunchPad.Entities.Domain;

namespace LaunchPad.Data.Mapping
{
    class tbl_io_detailMap : EntityTypeConfiguration<tbl_io_detail>
    {
        public tbl_io_detailMap()
        {
            HasRequired(s => s.tbl_master).WithMany(s => s.tbl_io_detail).HasForeignKey(s => s.agree_with);
            HasRequired(s => s.lu_io_status).WithMany(s => s.tbl_io_detail).HasForeignKey(s => s.status);
        }
    }
}
