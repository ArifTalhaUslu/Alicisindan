using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models;

public class AppUser : BaseEntity
{
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public City City { get; set; }
    public Wallet Wallet { get; set; }

}
