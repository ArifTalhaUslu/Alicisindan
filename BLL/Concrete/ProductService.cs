using BLL.Abstract;
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
        throw new NotImplementedException();
    }

    public bool DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetProductsByCategory(int CategoryId)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetUsersProduct(int UserId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
