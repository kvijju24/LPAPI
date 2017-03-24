using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace LaunchPad.Data
{
    public class ClientDataContext : DbContext, IDbContext
    {
        static ClientDataContext()
        {
            Database.SetInitializer<ClientDataContext>(null);
        }
        public ClientDataContext()
            : base("Name=ClientDataContext")
        {
        }
        //private ClientDataContext(DbConnection connectionString, bool contextOwnsConnection = true) : base(connectionString, contextOwnsConnection)
        //{

        //}
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
        //public static ClientDataContext CreateEntitiesForSpecificDatabaseName(string databaseName, bool contextOwnsConnection = true)
        //{
        //    //Initialize the SqlConnectionStringBuilder
        //    SqlConnectionStringBuilder sqlConnectionBuilder = new SqlConnectionStringBuilder();
        //    sqlConnectionBuilder.DataSource = @"localhost\sqlexpress";
        //    sqlConnectionBuilder.InitialCatalog = databaseName;
        //    sqlConnectionBuilder.IntegratedSecurity = true;
        //    sqlConnectionBuilder.MultipleActiveResultSets = true;
        //    string sqlConnectionString = sqlConnectionBuilder.ConnectionString;

        //    //Initialize the EntityConnectionStringBuilder
        //    EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
        //    entityBuilder.Provider = "System.Data.SqlClient";
        //    entityBuilder.ProviderConnectionString = sqlConnectionString;

        //    //Set the Metadata location.
        //    entityBuilder.Metadata = @"res://*/DataAccess.EncounterModel.EncounterModel.csdl|res://*/DataAccess.EncounterModel.EncounterModel.ssdl|res://*/DataAccess.EncounterModel.EncounterModel.msl";

        //    //Create entity connection
        //    EntityConnection connection = new EntityConnection(entityBuilder.ConnectionString);

        //    return new ClientDataContext(connection);
        //}
    }
}
