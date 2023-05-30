using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<Department> Departments { get; }
        Task<int> Complete(CancellationToken cancellationToken);
    }
}
