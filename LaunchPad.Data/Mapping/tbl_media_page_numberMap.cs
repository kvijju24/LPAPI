//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.ModelConfiguration;
//using LaunchPad.Entities.Domain;

//namespace LaunchPad.Data.Mapping
//{
//    class tbl_media_page_numberMap : EntityTypeConfiguration<tbl_media_page_number>
//    {
//        public tbl_media_page_numberMap()
//        {
//            HasRequired(s => s.lu_ad_clr).WithMany(s => s.tbl_media_page_number).HasForeignKey(s => s.clr_cde);
//        }
//    }
//}
