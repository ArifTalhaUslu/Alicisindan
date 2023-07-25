using BLL.Abstract;
using DataAccess;
using DataAccess.Context;
using Entity.Models;
using Entity.PModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete;

public class LoginService : ILoginService 
{
    public AppUser? Login(PmLogin param)
    {
        using (IUnitOfWork _unit = new UnitOfWork(new AlicisindanDbContext()))
        {

            var User = _unit.UserRepository.GetUserByEmail(param.Email);

            if (User is not null && User.Password.Equals(param.CryptedPassword))
            {
                return User;
            }
            return null;
        }
    }
}
