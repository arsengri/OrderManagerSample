using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class ExemptProduct : Product
    {
        public ExemptProduct() : base()
        {
        }

        public ExemptProduct(string pName) : base(pName)
        {

        }

        public ExemptProduct(string pName, double pPrice, int pQuanity, bool pIsImported)
            : base(pName, pPrice, pQuanity, pIsImported)
        {

        }

        public override IProductFactory GetFactory()
        {
            return new ExemptProductFactory();
        }

        public override double GetTaxRate()
        {
            return Taxes.NoTax;
        }

    }
}
