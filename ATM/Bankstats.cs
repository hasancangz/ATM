using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    static class Bankstats
    {
        static int withdraw=0;
        static int deposit = 0;

       

        public static void Amountofwithdrawing()
        {
            withdraw++;
        }
        public static void Amountofdepositing()
        {
            deposit++;
        }
        public static void TotalDeposit()
        {
            Console.WriteLine($"Total Depositing:{deposit}");
        }
        public static void TotalWithdrawing()
        {
            Console.WriteLine($"Total Withdrawing:{withdraw}");
        }
        public static void TotalProcess()
        {
            Console.WriteLine($"Total Process:{withdraw+deposit}");
        }



    }
}


