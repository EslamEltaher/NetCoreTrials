using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreTrial1.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
