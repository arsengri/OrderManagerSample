using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    /// <summary>
    /// Class represents Receipt, which is a result of Shopping cart processing.
    /// </summary>
	public class Receipt : IPrintable
	{
		private List<IProduct> productList { get; set; }
        private double totalTax = 0.0;
        private double totalAmount = 0.0;

		public Receipt(List<IProduct> pProductList)
		{
			productList = pProductList;
			totalTax = CalcTotalTax();
            totalAmount = CalcTotalAmount();
		}

		private double CalcTotalTax()
		{
            double totalTax = 0.0;

			foreach (IProduct p in productList)
			{
                    totalTax += p.Tax * p.Quantity;
			}

			return totalTax;
		}

		private double CalcTotalAmount()
		{
			double totalAmount = 0.0;

			foreach (IProduct p in productList)
			{
				totalAmount += p.GetPriceWithTax() * p.Quantity;
			}

			return totalAmount;
		}


        public string PrintOut()
        {
            StringBuilder str = new StringBuilder();
           // str.AppendLine(new string('-', 35));

            foreach (var p in productList)
            {
                string row = string.Format("{0} {1} {2}"
                                            , p.Quantity
                                            , ((p.IsImported) ? "Imported " : string.Empty)
                                            + p.Name,
                                             Formater.Decimal2Digit(p.GetPriceWithTax())
                                             );

                str.AppendLine(row);
            }

            str.AppendLine(new string('-', 5));
            str.AppendFormat("Sales Tax: {0}\n", totalTax);
            str.AppendFormat("Total: {0}\n", totalAmount);
            str.AppendLine(new string('=', 35));

            return str.ToString();
        }

        public List<IProduct> GetProducts()
        {
            return productList;


        }

        public double GetTotalAmaunt()
        {
            return totalAmount;
        }

        public double GetTotalTax()
        {
            return totalTax;
        }
    }
}
