using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Tests
{
    [TestClass()]
    public class CartProcessorTests
    {

        public CartProcessor cartProc;


        [TestInitialize]
        public void TestInit()
        {
            cartProc = new CartProcessor(new MyTaxManager()); 
        }

        [TestMethod()]
        public void ProcessCartAccuracyTest()
        {
            
            List<IProduct> productList = new List<IProduct>()
            {
                new ExemptProduct("ExemptProduct", 10, 2, false),
                new ExemptProduct("ExemptProduct", 10, 1, false)

            };
           Receipt r =  cartProc.ProcessCart(new ShoppingCart(productList));

            Assert.IsTrue(r.GetTotalTax() == 0);
            Assert.IsTrue(r.GetTotalAmaunt() == 30);
        }

        [TestMethod()]
        public  void ProcessMixedCartAccuracyTest()
        {

            List<IProduct> pList = new List<IProduct>()
            {
                new ExemptProduct("ExemptProduct", 10, 1, false),
                new Product("Product", 10, 2, false)

            };
            Receipt r = cartProc.ProcessCart(new ShoppingCart(pList));

          
            Assert.IsTrue(r.GetTotalTax() == 2.0);
            Assert.IsTrue(r.GetTotalAmaunt() == 32.0);
        }
        
        [TestMethod]
        public void ProcessMixedImportedCartAccuracyTest()
        {

            List<IProduct> pList = new List<IProduct>()
            {
                new ExemptProduct("ExemptProduct", 10, 1, false),
                new Product("Product", 10, 2, true)

            };
            Receipt r = cartProc.ProcessCart(new ShoppingCart(pList));


            Assert.IsTrue(r.GetTotalTax() == 3.0);
            Assert.IsTrue(r.GetTotalAmaunt() == 33.0);
        }

        [TestMethod]
        public void ProcessMixedImportedCartAccuracyTest2()
        {

     
            List<IProduct> pList = new List<IProduct>()
            {
                new ExemptProduct("ExemptProduct", 10, 1, true),
                new Product("Product", 10, 2, false)

            };
            Receipt r = cartProc.ProcessCart(new ShoppingCart(pList));


            Assert.IsTrue(r.GetTotalTax() == 2.5);
            Assert.IsTrue(r.GetTotalAmaunt() == 32.5);
        }
    }
}