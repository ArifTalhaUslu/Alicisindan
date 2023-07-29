using BLL.Abstract;
using DataAccess;
using DataAccess.Context;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete;

public class ProductService : IProductService
{
    public bool AddProduct(Product product)
    {
        using (IUnitOfWork _unit = new UnitOfWork(new AlicisindanDbContext()))
        {
            product.Sold = 0;
            return _unit.ProductRepository.Add(product) > 0;
        }
    }

    public bool DeleteProduct(int id)
    {
        using (IUnitOfWork _unit = new UnitOfWork(new AlicisindanDbContext()))
        {
            return _unit.ProductRepository.Delete(id) > 0;
        }
    }

    public List<Product> GetAllProducts()
    {
        using (IUnitOfWork _unit = new UnitOfWork(new AlicisindanDbContext()))
        {
            return _unit.ProductRepository.GetAll().ToList();
        }
    }

    public Product GetProductById(int id)
    {
        using (IUnitOfWork _unit = new UnitOfWork(new AlicisindanDbContext()))
        {
            return _unit.ProductRepository.GetById(id);
        }
    }

    public List<Product> GetProductsByCategory(int CategoryId)
    {
        using (IUnitOfWork _unit = new UnitOfWork(new AlicisindanDbContext()))
        {
            return _unit.ProductRepository.GetListByExpression(x=>x.CategoryId == CategoryId);
        }
    }

    public List<Product> GetUsersProduct(int UserId)
    {
        using (IUnitOfWork _unit = new UnitOfWork(new AlicisindanDbContext()))
        {
           return _unit.ProductRepository.GetListByExpression(x=>x.OwnerId == UserId);
        }
    }

    public bool UpdateProduct(Product product)
    {
        using (IUnitOfWork _unit = new UnitOfWork(new AlicisindanDbContext()))
        {
            return _unit.ProductRepository.Update(product) > 0;
        }
    }
}
