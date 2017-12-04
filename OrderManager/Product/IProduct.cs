using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        double Tax { get; set; }
        int Quantity { get; set; }
        bool IsImported { get; set; }

        double GetPriceWithTax();

        double GetTaxRate();

        IProductFactory GetFactory();
    }
}
