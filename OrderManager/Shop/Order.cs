using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    /// <summary>
    /// Core class to receive inputs and processes the shopping cart
    /// </summary>
    public class Order
    {
        private List<ShoppingCart> shoppingCartList;
        private Store store;
        private CartProcessor cartProcessor;


        public Order(Store pStore)
        {
            shoppingCartList = new List<ShoppingCart>();
            cartProcessor = new CartProcessor(new MyTaxManager());
            this.store = pStore;

        }

        /// <summary>
        /// Creates and returns Shopping Cart, which to be populated with products
        /// </summary>
        /// <returns></returns>
        public ShoppingCart OpenCart()
        {
            ShoppingCart cart = new ShoppingCart();
            shoppingCartList.Add(cart);
            return cart;
        }

        /// <summary>
        /// Method to print inputed products in Shoping Cart.
        /// </summary>
        public void Preview()
        {
            //foreach (ShoppingCart shoppingCart in shoppingCartList)
            //{
            //    Printer.Print(shoppingCart);
            //}

            //convert to printable list
            List<IPrintable> printableCart = shoppingCartList.Cast<IPrintable>().ToList();

            Printer.PrintBatch(printableCart, "Shopping Basket");
        }


        /// <summary>
        /// Core method to Apply Taxes in Shopping cart and Print outputs
        /// </summary>
        public void ProcessOrder()
        {
            List<IPrintable> receiptList = new List<IPrintable>();

            foreach (ShoppingCart shoppingCart in shoppingCartList)
            {
                Receipt receipt = cartProcessor.ProcessCart(shoppingCart);

                //Printer.Print(receipt);
                receiptList.Add(receipt);
            }

            Printer.PrintBatch(receiptList, "Output");

        }


    }
}
