using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract;

public interface IProductService
{
    public Product GetProductById(int id);
    public List<Product> GetAllProducts();
    public List<Product> GetUsersProduct(int UserId);
    public List<Product> GetProductsByCategory(int CategoryId);
    public bool AddProduct(Product product);
    public bool UpdateProduct(Product product);
    public bool DeleteProduct(int id);
}
