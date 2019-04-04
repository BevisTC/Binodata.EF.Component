using Binodata.EF.Repo.ErrorHandle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binodata.EF.Repo.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// db context
        /// </summary>
        private readonly DbContext _context;

        /// <summary>
        /// 
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        private Hashtable _repositories;

        public EFUnitOfWork(DbContext dbContext)
        {
            this._context = dbContext;
        }

        /// <summary>
        /// 記憶體 拋棄
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Create Generic Repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IGenericRepository<T> GetGenericRepository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(EFGenericRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }

        /// <summary>
        /// save changes
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var getFullMessage = string.Join("; ", entityError);
                var exceptionMessage = string.Concat(ex.Message, "errors are: ", getFullMessage);

                throw new UnitOfWorkException(exceptionMessage, ex);
            }
            catch (Exception e)
            {
                throw new UnitOfWorkException("Database access working fail through Entity Framework by EFUnitOfWork", e);
            }

        }

        /// <summary>
        /// 回收物件
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ClearRepositories();
                    DisposeDbContext();
                }
            }

            _disposed = true;
        }

        private void ClearRepositories()
        {
            if (_repositories != null)
            {
                _repositories.Clear();
                _repositories = null;
            }
        }

        private void DisposeDbContext()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
