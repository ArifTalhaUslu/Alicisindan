using BLL.Abstract;
using DataAccess;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete;

public class PurchaseService : IPurchaseService
{
    public bool SetProductToActive(int ProductId)
    {
        using (IUnitOfWork _unit = new UnitOfWork(new DataAccess.Context.AlicisindanDbContext()))
        {
            var Product = _unit.ProductRepository.GetProductWithAll(ProductId);
            Product.Sold = 0;
            
            return _unit.ProductRepository.Update(Product) > 0;
        }
    }

    public bool SoldProduct(int ProductId)
    {
        using (IUnitOfWork _unit = new UnitOfWork(new DataAccess.Context.AlicisindanDbContext()))
        {
            var Product = _unit.ProductRepository.GetProductWithAll(ProductId);
            Product.Sold = 1;

            return _unit.ProductRepository.Update(Product) > 0;
        }
    }
}
