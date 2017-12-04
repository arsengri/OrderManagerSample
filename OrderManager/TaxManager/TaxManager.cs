
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    /// <summary>
    /// Apply taxes for a Product, according to specific logic
    /// </summary>
    public class MyTaxManager : ITaxManager
    {

        /// <summary>
        /// Applays taxes
        /// </summary>
        /// <param name="pProduct">Product to be taxed</param>
        /// <returns></returns>
        public IProduct ApplyTax(IProduct pProduct)
        {
            double tax = 0;

            tax = CalcBaseTax(pProduct.Price, pProduct.GetTaxRate());

            if (pProduct.IsImported)
            {
                //tax += CalcImportDutyTax(pProduct.Price + tax);

                //Seems the imported tax is calculated on product net price
                tax += CalcImportDutyTax(pProduct.Price);
            }

            // Round to Nearest 0.05
            //  p.Tax = Formater.Round005(tax);

            pProduct.Tax = tax;

            return pProduct;
        }
      

        private double CalcBaseTax(double pPrice, double pTax)
        {
            double tax = pPrice * pTax;            
            return Formater.Round005(tax);
        }

        private double CalcImportDutyTax(double pPrice)
        {
            double tax = pPrice * Taxes.ImportDutyTax;
            return Formater.Round005(tax);
        }

        
    }
    }
