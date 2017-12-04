using System;
using System.Globalization;

namespace OrderManager
{
    public class Formater
    {
        //Round to nearerst 0.005
        public static double Round005(double pValue)
        {
            return Math.Round(pValue * 20) / 20; ;
        }

        //Show 2 digits always
        public static string Decimal2Digit(double pValue)
        {
           
            return pValue.ToString("N2");


        }

    }

   


  

}
