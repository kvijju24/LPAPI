using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using LaunchPad.Entities.Domain;
using LaunchPad.Entities.Domain.Dummy;
using LaunchPad.Data.Infrastructure;

namespace LaunchPad.Data
{
    public class LPDataContext : DbContext, IDbContextInfra
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
        public DbSet<lu_login> lu_login { get; set; }
        public DbSet<lu_client> lu_client { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
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
            modelBuilder.Entity<lu_login>().ToTable("lu_login");
            modelBuilder.Entity<lu_client>().ToTable("lu_client");
            base.OnModelCreating(modelBuilder);
        }
    }
}
