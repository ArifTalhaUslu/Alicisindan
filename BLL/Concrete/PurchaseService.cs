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
    public List<Wallet>? GetAllWallets()
    {
        using (IUnitOfWork _unit = new UnitOfWork(new DataAccess.Context.AlicisindanDbContext()))
        {
            return _unit.WalletRepository.GetListByExpression(w=>w.Balance > 0);
        }
    }


    public bool Purchase(int ProductId)
    {
        using (IUnitOfWork _unit = new UnitOfWork(new DataAccess.Context.AlicisindanDbContext()))
        {
            var Product = _unit.ProductRepository.GetProductWithAll(ProductId);
            Product.Sold = 1;
            return _unit.ProductRepository.Update(Product) > 0;
        }
    } 
}
