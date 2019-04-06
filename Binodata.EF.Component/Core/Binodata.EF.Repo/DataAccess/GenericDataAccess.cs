using Binodata.EF.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Binodata.EF.Repo.DataAccess
{
    public class GenericDataAccess<T> : IGenericDataAccess<T>, IDisposable where T : class
    {
        protected IGenericRepository<T> repo;

        protected IUnitOfWork unitOfWork;

        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="unitOfWork"></param>
        public GenericDataAccess(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repo = unitOfWork.GetGenericRepository<T>();
        }

        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="unitOfWork"></param>
        public GenericDataAccess(IUnitOfWork unitOfWork, IGenericRepository<T> repo)
        {
            this.unitOfWork = unitOfWork;
            this.repo = repo;
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="t"></param>
        public void Add(T t)
        {
            repo.Add(t);
            unitOfWork.Save();
        }


        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="listT"></param>
        public void Add(List<T> listT)
        {
            foreach (var item in listT)
            {
                repo.Add(item);
            }
            unitOfWork.Save();
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="t"></param>
        public void Update(T t)
        {
            repo.Edit(t);
            unitOfWork.Save();
        }

        /// <summary>
        /// 更新批次資料
        /// </summary>
        /// <param name="listT"></param>
        public void Update(List<T> listT)
        {
            foreach (var item in listT)
            {
                repo.Edit(item);
            }
            unitOfWork.Save();
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="t"></param>
        public void Delete(T t)
        {
            repo.Delete(t);
            unitOfWork.Save();
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="t"></param>
        public void Delete(List<T> listT)
        {
            foreach (var item in listT)
            {
                repo.Delete(item);
            }
            unitOfWork.Save();
        }

        /// <summary>
        /// 搜尋查找條件
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public IQueryable<T> QueryByCondition(Expression<Func<T, bool>> expr)
        {
            return repo.FindBy(expr);
        }

        /// <summary>
        /// 記憶體回收
        /// </summary>
        public void Dispose()
        {
            if (unitOfWork != null)
            {
                unitOfWork.Dispose();
            }
        }
    }
}
