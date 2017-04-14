using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using LaunchPad.Entities.Domain;

namespace LaunchPad.Data
{
    public class LPDataContext : DbContext, IDbContext
    {
        static LPDataContext()
        {
            Database.SetInitializer<LPDataContext>(null);
        }
        public LPDataContext()
            : base("Name=LPDataContext")
        {
        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            modelBuilder.Entity<lu_emp>().ToTable("lu_emp");
            modelBuilder.Entity<lu_ad_position>().ToTable("lu_ad_position");
            modelBuilder.Entity<lu_ad_sect>().ToTable("lu_ad_sect");
            modelBuilder.Entity<lu_ad_shape>().ToTable("lu_ad_shape");
            modelBuilder.Entity<lu_adsize>().ToTable("lu_adsize");
            modelBuilder.Entity<lu_iss>().ToTable("lu_iss");
            modelBuilder.Entity<lu_io_status>().ToTable("lu_io_status");
            modelBuilder.Entity<lu_pub>().ToTable("lu_pub");
            modelBuilder.Entity<tbl_calendar>().ToTable("tbl_calendar");
            modelBuilder.Entity<tbl_io>().ToTable("tbl_io");
            modelBuilder.Entity<tbl_io_detail>().ToTable("tbl_io_detail");
            modelBuilder.Entity<tbl_io_detail1>().ToTable("tbl_io_detail1");
            modelBuilder.Entity<tbl_master>().ToTable("tbl_master");
            modelBuilder.Entity<tbl_gl_export>().ToTable("tbl_gl_export");



            base.OnModelCreating(modelBuilder);
        }
    }
}
