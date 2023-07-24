using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AlicisindanDbContext dbContext) : base(dbContext){}
    public AlicisindanDbContext AlicisindanContext { get { return (AlicisindanDbContext)dbContext; } } 

    public List<Product> GetProductsWithAll()
    {
        using (AlicisindanContext)
        {
            return AlicisindanContext.Products
                .Include(x=>x.Category)
                .Include(x => x.Owner).ThenInclude(p => p.City).ToList();
        }
    }

    public Product GetProductWithAll(int id)
    {
        using (AlicisindanContext)
        {
            return AlicisindanContext.Products
                .Include(x => x.Category)
                .Include(x => x.Owner).ThenInclude(p => p.City).First(x=>x.Id == id);
        }
    }
}
