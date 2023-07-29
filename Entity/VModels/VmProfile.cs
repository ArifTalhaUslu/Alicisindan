using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.VModels;

public class VmProfile
{
    public AppUser ProfileOwner { get; set; }
    public List<Category> Categories { get; set; }
    public List<Product> Products { get; set; }
    public bool isUserAuthorizedForThisPage { get; set; }
}
