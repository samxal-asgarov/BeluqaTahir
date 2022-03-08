using BeluqaTahir.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeluqaTahir.Domain.Model.ViewModels
{
    public class ShopViewModel
    {
        public List<ProductTypes> productTypes { get; set; }
        public List<Product> Products { get; set; }
    }
}
