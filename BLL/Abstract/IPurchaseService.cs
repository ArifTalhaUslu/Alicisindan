using Entity.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract;

public interface IPurchaseService
{
    public bool SoldProduct(int ProductId); //Set the Sold prop = 1
    public bool SetProductToActive(int ProductId);//Set the Sold prop = 0
}
