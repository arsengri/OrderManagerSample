using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{

    /// <summary>
    /// This class contains main functions to porcess products in shopping cart. i.e apply taxes.
    /// </summary>
	public class CartProcessor
	{
		
		private List<IProduct> productList;
        private ITaxManager taxMng;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="pTaxManager"> TaxManager to be used in tax calculations</param>
        public CartProcessor(ITaxManager pTaxManager)
		{
            taxMng = pTaxManager;
        }

        /// <summary>
        /// Function apply taxes or each product in shopping cart
        /// </summary>
        /// <param name="pCart">Shopping cart to be processed</param>
		//public void ProcessCart(ShoppingCart pCart)
		//{
		//	productList = pCart.GetProductsList();

		//	foreach (IProduct p in productList)
		//	{
  //              taxMng.ApplyTax(p);
                
		//	}
		//}

        public Receipt ProcessCart(ShoppingCart pCart)
        {
            productList = pCart.GetProductsList();

            foreach (IProduct p in productList)
            {
                taxMng.ApplyTax(p);

            }

            return new Receipt(productList);
        }

        /// <summary>
        /// Returns Receipt with porcessed (taxed) Products
        /// </summary>
        /// <returns></returns>
		public Receipt GetReceipt()
        {
            return new Receipt(productList);
			
		}

		

	}

	







	

	
}
