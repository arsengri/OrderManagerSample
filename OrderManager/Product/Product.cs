using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class Product : IProduct
    {
        public bool IsImported { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public int Quantity { get; set;}
        public Product()
        {
        }

        public Product(string pName)
		{
            Name = pName;
            Price = 0;
            Tax = 0;
        }

        public Product(string pName, double pPrice, int pQuantity, bool pIsImported)
        {
            Name = pName;
            Price = pPrice;
            Quantity = pQuantity;
            IsImported = pIsImported;
            
           
        }


        public double GetPriceWithTax()
        {
            return Price + Tax;
        }
        public virtual IProductFactory GetFactory()
        {
             return new ProductFactory();
        }

        public virtual double GetTaxRate() {

            return Taxes.SalesTax;
        }


    }

   
}
