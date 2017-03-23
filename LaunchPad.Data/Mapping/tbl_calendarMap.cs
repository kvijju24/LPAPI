using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LaunchPad.Entities.Domain;

namespace LaunchPad.Data.Mapping
{
    class tbl_calendarMap : EntityTypeConfiguration<tbl_calendar>
    {
        public tbl_calendarMap()
        {
            ToTable("tbl_calendar");
            HasKey(s => s.calendar_id).Property(s => s.calendar_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
