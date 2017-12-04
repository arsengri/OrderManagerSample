using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager;

namespace OrderManagerTests.Shop
{
    [TestClass()]
    public class StoreTests
    {
        public static List<IProduct>  productList;
        public static Store store;

        [ClassInitialize]
        public static void init(TestContext context)
        {
            productList = new List<IProduct>()
            {
                new ExemptProduct("ExemptProduct"),
                new Product("Product")
                
            };

            store = new Store(productList);
            
        }

        [TestMethod]  
        public void PickProductTest()
        {           
                
            IProduct p1 = store.PickProduct("ExemptProduct", 1, 1, true);
            IProduct p2 = store.PickProduct("Product", 1, 1, true);


            Assert.IsTrue(p1.GetType() == typeof(ExemptProduct));
            Assert.IsTrue(p2.GetType() == typeof(Product));
            
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void PickWrongProductTest()
        {
          
            IProduct p1 = store.PickProduct("wrongname", 1, 1, true);
            
        }
    }
}
