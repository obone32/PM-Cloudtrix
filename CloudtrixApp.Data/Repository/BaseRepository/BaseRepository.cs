using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using eLearningHub.Core.Interface.Base;
using CloudtrixApp.Data.AppDbContext;
using CloudtrixApp.Core.DataModel.Base;

namespace eLearningHub.Data.Repository.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {

        private readonly CloudtrixDbContext _dbContext;
        private DbSet<T> _innerDbSet;  
        public BaseRepository()
        {
            _dbContext = new CloudtrixDbContext();
            _innerDbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> All()
        {
            return _innerDbSet.Where(x => !x.IsDelete);
        }
        public IQueryable<T> All(params Expression<Func<T, object>>[] includeProperties)
        {

            return includeProperties == null
                ? All()
              : includeProperties.Aggregate(All(), (current, includeProperty) => current.Include(includeProperty));
        }
        public T Find(long id)
        {
            return All().FirstOrDefault(x => x.Id == id);
        }
        public T Find(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            return All(includeProperties).FirstOrDefault(x => x.Id == id);
        }
        public void Remove(long id)
        {
            var entity = Find(id);
            _innerDbSet.Remove(entity);
            Save();
        }
        public void Insert(T model)
        {
            model.CreateDate = DateTime.UtcNow;
            model.UpdateDate = DateTime.UtcNow;
            _dbContext.Entry(model).State = EntityState.Added;
            _innerDbSet.Add(model);
            Save();
        }
        public void Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            _dbContext.Configuration.ValidateOnSaveEnabled = false;
            Save();
            _dbContext.Configuration.ValidateOnSaveEnabled = true;
        }
        private void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _innerDbSet = null;
            _dbContext.Dispose();
        }
    }
}
