//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.ModelConfiguration;
//using LaunchPad.Entities.Domain;

//namespace LaunchPad.Data.Mapping
//{
//    public class AppointmentMap : EntityTypeConfiguration<Appointment>
//    {
//        public AppointmentMap()
//        {
//            ToTable("Sync_Appointments");
//            HasKey(s => s.Native_ID).Property(s => s.Native_ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
//        }
//    }
//}
