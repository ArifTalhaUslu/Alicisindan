using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IWalletRepository WalletRepository { get; }
    IWalletProcessRepository WalletProcessRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    ICityRepository CityRepository { get; }
    IProductRepository ProductRepository { get; }
    int Complete();
}
