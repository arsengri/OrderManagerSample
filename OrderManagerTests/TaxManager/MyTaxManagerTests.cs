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
    public class MyTaxManagerTests
    {

        ITaxManager mng;  
        [TestInitialize]
        public void TestInit()
        {
            mng = new MyTaxManager();

        }
        [TestMethod()]
        public void ApplyBaseTaxForProductTest()
        {
            IProduct p = new Product("testproduct", 12.49, 1, false);           
            p =  mng.ApplyTax(p);

            Assert.AreEqual(1.25, p.Tax);

           
        }

        [TestMethod()]
        public void ApplyBaseTaxForExemptProductTest()
        {
            IProduct p = new ExemptProduct("testproduct", 12.49, 1, false);
            p = mng.ApplyTax(p);

            Assert.AreEqual(0.0, p.Tax);


        }

        [TestMethod()]
        public void ApplyFullTaxTest()
        {
            IProduct p = new Product("testproduct", 12.49, 1, true);
            p = mng.ApplyTax(p);

            Assert.AreEqual(1.249+0.624, p.Tax, 0.05);


        }



    }
}