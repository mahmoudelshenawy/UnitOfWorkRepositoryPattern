using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Core.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetHighestPriceProducts();
    }
}
