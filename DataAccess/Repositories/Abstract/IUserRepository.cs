using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract;

public interface IUserRepository : IGenericRepository<AppUser>
{
    public List<AppUser> GetUsersWithCities();
    public List<AppUser> GetUsersByCity(int CityId);
    public AppUser? GetUserByEmail(string Email);
}
