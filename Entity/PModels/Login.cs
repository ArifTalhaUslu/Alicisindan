using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.PModels;

public class Login
{
    public string Email { get; set; }
    public string CryptedPassword { get; set; }
}
