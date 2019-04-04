using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binodata.EF.Repo.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IGenericRepository<T> GetGenericRepository<T>() where T : class;

        /// <summary>
        /// 最後完成 Commit
        /// </summary>
        void Save();
    }
}
