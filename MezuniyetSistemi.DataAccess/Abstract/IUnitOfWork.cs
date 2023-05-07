using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IUserProfileRepository Profiles { get; }
        int Save();
    }
}
