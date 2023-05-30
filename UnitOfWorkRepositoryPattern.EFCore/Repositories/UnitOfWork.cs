using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        public IProductRepository Products { get; private set; }

        public IBaseRepository<Category> Categories { get; private set; }
        public IBaseRepository<Department> Departments { get; private set; }
        public IBaseRepository<Employee> Employees { get; private set; }

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Categories = new BaseRepository<Category>(_context);
            Departments = new BaseRepository<Department>(_context);
            Employees = new BaseRepository<Employee>(_context);
        }
        public async Task<int> Complete(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
