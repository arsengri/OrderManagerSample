using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    class Program
    {
        
        static void Main(string[] args)
        {
		    //Init Store 
            Store store = new Store();
            
            //Init Order manager 
            Order order = new Order(store);

            // Create inputs 
            ShoppingCart cart1 = order.OpenCart();
            cart1.AddItem(store.PickProduct(SKU.Book, 12.49, 1, false));
            cart1.AddItem(store.PickProduct(SKU.MusicCD, 14.99, 1, false));
            cart1.AddItem(store.PickProduct(SKU.ChocolateBar, 0.85, 1, false));

            ShoppingCart cart2 = order.OpenCart();
            cart2.AddItem(store.PickProduct(SKU.ChocolateBox, 10.00, 1, true));
            cart2.AddItem(store.PickProduct(SKU.PerfumeBottle, 47.50, 1, true));

            ShoppingCart cart3 = order.OpenCart();
            cart3.AddItem(store.PickProduct(SKU.PerfumeBottle, 27.99, 1, true));
            cart3.AddItem(store.PickProduct(SKU.PerfumeBottle, 18.99, 1, false));
            cart3.AddItem(store.PickProduct(SKU.HeadachePills, 9.75, 1, false));
            cart3.AddItem(store.PickProduct(SKU.ChocolateBox, 11.25, 1, true));
            // End of inputs


            // Print Inputs preview on Console
            order.Preview();

            // Procced with Checkout and print resut
            order.ProcessOrder();
            

            // Wait Enter to clsoe window
            Console.WriteLine(
                    new string('\n', 4)
                    + "Press Enter to exit...");
			Console.ReadLine();
        }
    }
}
