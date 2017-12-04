using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    /// <summary>
    /// Container of products to be processed in Order
    /// </summary>
	public class ShoppingCart : IPrintable
	{
        private List<IProduct> productList;

		public ShoppingCart()
		{
			productList = new List<IProduct>();
		}

        public ShoppingCart(List<IProduct> pProductList)
        {
            productList = pProductList;
        }

        public void AddItem(IProduct pProduct)
		{
			productList.Add(pProduct);
		}

		public List<IProduct> GetProductsList()
		{
			return productList;
		}

             
        public string PrintOut()
        {
            StringBuilder str = new StringBuilder();
           
            foreach (var p in productList)
            {
                string row = string.Format("{0} {1} {2}"
                                            , p.Quantity
                                            , ((p.IsImported) ? "Imported " : string.Empty)
                                            + p.Name,
                                             Formater.Decimal2Digit(p.Price)
                                             );
                                             
                str.AppendLine(row);
            }

            str.AppendLine(new string('*', 35));
            return str.ToString();
        }

    }
}
