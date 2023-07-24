using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models;

public class Product : BaseEntity
{
    public AppUser Owner { get; set; }
    public Category Category { get; set; }
    public float Price { get; set; }
    public int Sold { get; set; } //0:False, 1:True
    public string Header { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
}
