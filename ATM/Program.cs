using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BankAccount account = Manager.Account();
            if (account == null)
            {
                
                Console.WriteLine("Your card is blocked");
                Console.WriteLine("--------------------");
                return;
            }
            Console.Clear();
            Manager.Menu(account);
           

        }
    }
}
