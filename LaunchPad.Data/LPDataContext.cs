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
            base.OnModelCreating(modelBuilder);
        }
    }
}
