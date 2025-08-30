using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATM.BankAccount;

namespace ATM
{
    internal class WithdrawTransaction : ITransaction
    {
        public int realamount { get; set; }
        public string kindofprocess { get; set; }
        public DateTime realtime { get; set; }
        string kind = "Withdraw";
        public void Execute(BankAccount account,int amount)
        {
            

    
            if (amount > account.Balance)
            {
                throw new Exception_Class.RightAmount();
            }
            DateTime now = DateTime.Now;

            account.Balance -= amount;
            Bankstats.Amountofwithdrawing();
            realamount = amount;
            kindofprocess = kind;
           realtime= now;
            Console.WriteLine("--------------------");
            Console.WriteLine("Withdrawing Process was successfully");

        }

       

        public void ShowDetails()
        {

            
            Console.WriteLine($"{realamount} money was withdrawed from your account ");
            Console.WriteLine($"The kind of process:{kindofprocess}");
            Console.WriteLine($"The time of process:{realtime}");
        }


    }
}
