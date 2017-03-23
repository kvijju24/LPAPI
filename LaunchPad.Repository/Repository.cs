using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Validation;
using LaunchPad.Data;

namespace LaunchPad.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private static readonly Object lockObject = new Object();
        internal IDbContext Context;

        internal IDbSet<TEntity> DbSet;

        public Repository(IDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }
        public virtual TEntity Insert(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            if (entity == null)
                throw new ArgumentException("Cannot update a null entity.");
            var entry = Context.Entry(entity);
            if (entry != null)
                entry.State = EntityState.Modified; // This should attach entity
        }

        public DbEntityValidationResult Validate(TEntity entity)
        {
            return Context.Entry(entity).GetValidationResult();
        }

        //public virtual void Delete(object id)
        //{
        //    var entity = DbSet.Find(id);
        //    var objectState = entity as IObjectState;
        //    if (objectState != null)
        //        objectState.State = ObjectState.Deleted;
        //    Delete(entity);
        //}

        public virtual void Delete(TEntity entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

        public virtual RepositoryQuery<TEntity> Query()
        {
            var repositoryGetFluentHelper =
                new RepositoryQuery<TEntity>(this);

            return repositoryGetFluentHelper;
        }

        internal IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
        List<Expression<Func<TEntity, object>>>
            includeProperties = null,
        int? page = null,
        int? pageSize = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (includeProperties != null)
                includeProperties.ForEach(i => { query = query.Include(i); });

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (page != null && pageSize != null)
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            return query;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Context != null)
                {
                    this.Context.Dispose();
                    this.Context = null;
                }
            }
        }
    }
}
