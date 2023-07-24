using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;

public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
{
    public WalletRepository(AlicisindanDbContext dbContext) : base(dbContext) { }
    public AlicisindanDbContext AlicisindanContext { get { return (AlicisindanDbContext)dbContext; } }
}
