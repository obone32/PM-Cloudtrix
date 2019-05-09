using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CloudtrixApp.Core.DataModel.Base;

namespace eLearningHub.Core.Interface.Base
{
    public interface IBaseRepository<T> : IDisposable where T : BaseModel
    {
        IQueryable<T> All();
        IQueryable<T> All(params Expression<Func<T, Object>>[] includeProperties);
        T Find(Int64 id);
        T Find(Int64 id, params Expression<Func<T, object>>[] includeProperties);
        void Remove(Int64 id);
        void Insert(T model);
        void Update(T model);

    }
}
