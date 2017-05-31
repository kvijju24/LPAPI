using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Data.Infrastructure
{
    //public class UnitOfWork : IUnitOfWork
    //{
    //    private readonly IDbFactory dbFactory;
    //    private ClientDataContext dbContext;
    //    public UnitOfWork(IDbFactory dbFactory)
    //    {
    //        this.dbFactory = dbFactory;
    //    }
    //    public ClientDataContext DbContext
    //    {
    //        get { return dbContext ?? (dbContext = dbFactory.Init()); }
    //    }
    //    public void Commit()
    //    {
    //        DbContext.Commit();
    //    }
    //}

    public class UnitOfWork<TContext> : Disposable, IUnitOfWork<TContext>
       where TContext : DbContext, IDbContextInfra, new()
    {
        private readonly IDbFactory<TContext> dbFactory;
        private TContext dbContext;
        public UnitOfWork(IDbFactory<TContext> dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public TContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }
        public void Commit()
        {
            DbContext.Commit();
        }
        public void ChangeDataBaseName(SqlConnectionStringBuilder connection)
        {
            DbContext.Database.Connection.ConnectionString
                   = connection.ConnectionString;
        }
    }
}
