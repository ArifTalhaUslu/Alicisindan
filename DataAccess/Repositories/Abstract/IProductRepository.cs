using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract;

public interface IProductRepository :IGenericRepository<Product>
{
    Product GetProductWithAll(int id);
    List<Product> GetProductsWithAll();
}
