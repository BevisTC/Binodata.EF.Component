using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binodata.EF.Repo.UnitOfWork
{
    public static class EFUnitOfWorkFactory
    {
        /// <summary>
        /// Get Entity framework unit of work
        /// </summary>
        /// <typeparam name="Context"></typeparam>
        /// <returns></returns>
        public static IUnitOfWork GetUnitOfWork<Context>() where Context : DbContext, new()
        {
            return new EFUnitOfWork(new Context());
        }
    }
}
