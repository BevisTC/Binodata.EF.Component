using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Binodata.EF.Repo.DataAccess
{
    public interface IGenericDataAccess<T> : IDisposable
    {
        void Add(T t);

        void Add(List<T> listT);

        void Update(T t);

        void Update(List<T> listT);

        void Delete(T t);

        void Delete(List<T> listT);

        IQueryable<T> QueryByCondition(Expression<Func<T, bool>> expr);
    }
}
