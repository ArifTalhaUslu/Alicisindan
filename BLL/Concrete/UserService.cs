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

public class UserService : IUserService//aslodaoşıksdas GetUser(null);
{
    public bool SignUp(AppUser user)
    {
        throw new NotImplementedException();
    }

    public List<AppUser> GetUser(PmGetUser param)//Id Name Email
    {
        using (IUnitOfWork _unit = new UnitOfWork(new AlicisindanDbContext()))
        {
            var Users = _unit.UserRepository.GetAll().ToList();//All DbUsers

            if (param is not null)//Filtering Users
            {
                if (param.Id.HasValue)
                {
                    Users = Users.Where(x => x.Id == param.Id.Value).ToList();
                }
                if (!string.IsNullOrEmpty(param.Name))
                {
                    Users = Users.Where(x => x.Name.ToLower().Trim().Contains(param.Name.ToLower().Trim())).ToList();
                }
                if (!string.IsNullOrEmpty(param.Email))
                {
                    Users = Users.Where(x => x.Email.ToLower().Trim().Contains(param.Email.ToLower().Trim())).ToList();
                }
            }

            return Users;
        }
    }

}
