using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class Printer
    {
        public static void Print(IPrintable pOutput)
        {

            Console.WriteLine(pOutput.PrintOut());
         
        }

        public static void PrintBatch(List<IPrintable> pBatch, string pSource)
        {
            int counter = 1;
            foreach(IPrintable r in pBatch)
            {
                Console.WriteLine(string.Format("{0} {1}:", pSource, counter));
                Print(r);

                counter++;
            }

            Console.WriteLine(new string('~', 35) );
            Console.WriteLine(new string('\n', 2));
        }
        
    }
}
