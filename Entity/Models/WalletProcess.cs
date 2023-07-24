using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models;

public class WalletProcess : BaseEntity
{
    public float Amount { get; set; }
    public DateTime DateOfProcess { get; set; }
    public string TypeOfProcess { get; set; }
}


public enum TypeOfProcess
{
    Sell,
    Buy,
    Deposit
}
