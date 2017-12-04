using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    /// <summary>
    /// Class to emulate the Store or warehouse. 
    /// Creates initial products catalog and also have functions to return products
    /// </summary>
    public class Store
    {
        private List<IProduct> list;

        public Store()
        {
            list = new List<IProduct>();
            init();
        }

        public Store(List<IProduct> pProductList)
        {
            list = pProductList;
        }

        private void init()
        {
            list.Add(new Product(SKU.MusicCD));
            list.Add(new Product(SKU.PerfumeBottle));

            list.Add(new ExemptProduct(SKU.HeadachePills));
            list.Add(new ExemptProduct(SKU.Book));
            list.Add(new ExemptProduct(SKU.ChocolateBar));
            list.Add(new ExemptProduct(SKU.ChocolateBox));

        }

        /// <summary>
        /// Return Product from catalog , if exists
        /// </summary>
        /// <param name="pName">Name of porduct, use SKU class to pass correct name</param>
        /// <param name="pPrice"></param>
        /// <param name="pQuantity"></param>
        /// <param name="pIsImported"></param>
        /// <returns></returns>
        public IProduct PickProduct(string pName, double pPrice, int pQuantity, bool pIsImported)
        {
			var item = list.FirstOrDefault(f => f.Name == pName);
            
            if (item == null){
                throw new KeyNotFoundException("Product not found");
            }

            var product = item.GetFactory().CreateProduct(pName, pPrice, pQuantity, pIsImported);

            return product;
        }

      


    }


    public class SKU
    {
        public static string Book = "Book";
        public static string MusicCD = "Music CD";
        public static string ChocolateBar = "Chocolate Bar";
        public static string ChocolateBox = "Box of Chocolates";
        public static string PerfumeBottle = "Bottle of Perfume";
        public static string HeadachePills = "Packet of Headache Pills";
    }
}
