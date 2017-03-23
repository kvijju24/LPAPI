using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace LaunchPad.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);
        // IDomainObject GetById(System.Type type, int? id);

        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
       // void Delete(object id);
        void Delete(TEntity entity);
        //IOrderedQueryable<TEntity> AsQueryable<TEntity>();
        RepositoryQuery<TEntity> Query();
        DbEntityValidationResult Validate(TEntity entity);
    }
}
