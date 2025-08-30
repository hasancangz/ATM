using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATM.BankAccount;

namespace ATM
{
    internal class DepositTransaction : ITransaction
    {   
        public int realamount { get; set; }
        public string kindofprocess { get; set; }
        public DateTime realtime{ get; set; }

        string kind = "Deposit";

        public void Execute(BankAccount account, int amount)
        {
            if (amount < 0)
            {
                throw new Exception_Class.RightAmount2();
            }

           DateTime now= DateTime.Now;
           
            account.Balance += amount;
            Bankstats.Amountofdepositing();
            realamount = amount;
            kindofprocess = kind;
            realtime = now;
            Console.WriteLine("--------------------");

            Console.WriteLine("Depositing Process was successfully");




        }
        

        public void ShowDetails()
        {

            Console.WriteLine($"{realamount} money was deposited to your account ");
            Console.WriteLine($"The kind of process:{kindofprocess}");
            Console.WriteLine($"The time of process:{realtime}");

        }





    }
}
