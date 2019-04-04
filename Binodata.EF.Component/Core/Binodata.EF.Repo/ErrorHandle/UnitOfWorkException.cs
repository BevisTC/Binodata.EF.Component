using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binodata.EF.Repo.ErrorHandle
{
    public class UnitOfWorkException : Exception
    {
        /// <summary>
        /// 例外建構
        /// </summary>
        public UnitOfWorkException() : base()
        {

        }

        public UnitOfWorkException(string message) : base(message)
        {

        }

        public UnitOfWorkException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
