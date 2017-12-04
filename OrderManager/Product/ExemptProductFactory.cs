using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class ExemptProductFactory : ProductFactory
    {
        public override Product CreateProduct(string pName, double pPrice, int pQuanity, bool pIsImported)
        {
            return new ExemptProduct(pName, pPrice, pQuanity, pIsImported);
        }
    }
}
