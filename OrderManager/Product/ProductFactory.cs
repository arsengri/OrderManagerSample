using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class ProductFactory : IProductFactory
    {
        public virtual Product CreateProduct(string pName, double pPrice,  int pQuanity, bool pIsImported)
        {
            return new Product(pName, pPrice, pQuanity, pIsImported);
        }

    }
   
}
