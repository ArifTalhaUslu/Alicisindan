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

public class CategoryService : ICategoryService
{
    public List<Category> GetCategories()
    {
        using (IUnitOfWork _unit = new UnitOfWork(new AlicisindanDbContext()))
        {
            return _unit.CategoryRepository.GetAll().ToList();
        }
    }
}
