using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LaunchPad.Infrastructure.Extensions
{
    public static class DatabaseConnection
    {
        // all params are optional
        public static void ChangeDatabase(
            this DbContext source,
            string dataSource = ""
           )
        /* this would be used if the
        *  connectionString name varied from 
        *  the base EF class name */
        {
            try
            {
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = source.GetType().Name;
                    

                //// add a reference to System.Configuration
                //var entityCnxStringBuilder = new EntityConnectionStringBuilder
                //    (System.Configuration.ConfigurationManager
                //        .ConnectionStrings[configNameEf].ConnectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder
                    (System.Configuration.ConfigurationManager
                        .ConnectionStrings[configNameEf].ConnectionString);

               
                if (!string.IsNullOrEmpty(dataSource))
                    sqlCnxStringBuilder.DataSource = dataSource;


                // now flip the properties that were changed
                source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                // set log item if required
            }
        }
    }
}