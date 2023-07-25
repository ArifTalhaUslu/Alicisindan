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

public class UserRepository : GenericRepository<AppUser>, IUserRepository
{
    public UserRepository(AlicisindanDbContext dbContext) : base(dbContext) { }
    public AlicisindanDbContext AlicisindanContext { get { return (AlicisindanDbContext)dbContext; } }

    public AppUser? GetUserByEmail(string Email)
    {
        using (AlicisindanContext)
        {
            return AlicisindanContext.Users.First(x=>x.Email.Equals(Email));
        }
    }
}
