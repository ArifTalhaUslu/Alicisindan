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

public class WalletProcessRepository : GenericRepository<WalletProcess>, IWalletProcessRepository
{
    public WalletProcessRepository(AlicisindanDbContext dbContext) : base(dbContext) { }
    public AlicisindanDbContext AlicisindanContext { get { return (AlicisindanDbContext)dbContext; } }
}
