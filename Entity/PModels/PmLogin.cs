using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.PModels;

public class PmLogin
{
    public string Email { get; set; }
    public string CryptedPassword { get; set; }
}
