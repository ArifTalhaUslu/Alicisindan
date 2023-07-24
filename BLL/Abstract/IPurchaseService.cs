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
    public bool Purchase(int ProductId);
    //public bool CreateRefundOffer(long ProductId);
}
