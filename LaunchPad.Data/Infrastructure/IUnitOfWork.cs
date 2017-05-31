using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Data.Infrastructure
{
    //public interface IUnitOfWork
    //{
    //    void Commit();
    //    //void ChangeDatabase(EntityConnectionStringBuilder connection, string initialCatalog = "");
    //}
    public interface IUnitOfWork<U> where U : DbContext, IDbContextInfra, IDisposable
    {
        void ChangeDataBaseName(SqlConnectionStringBuilder connection);
        void Commit();
    }
}
