using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.EFCore.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public readonly IApplicationDbContext _context;

        public ProductRepository(IApplicationDbContext context) : base(context) {

            _context = context;
        }
        public Product GetHighestPriceProducts()
        {
            var Product = new Product();
            try
            {
                var query = _context.Set<Product>().FirstOrDefault(x => x.Id == 1);
                return query;
            }
            catch (Exception e)
            {
                return Product;
            }

        }
    }
}
