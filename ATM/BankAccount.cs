using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class BankAccount
    {

       


        private int balance = 0;
        private string ownerName;
        private Card card;
        
      
        public int Balance
        {

            get { return balance; }

            set
            {
                balance = value;  
            }
        }
        public string OwnerName
        {

            get { return ownerName; }

            set
            {
                ownerName = value;  
            }
        }

        public int cardPIN
        {
            get
            {
                return card.PIN;
            }
            set
            {
                card.PIN = value;
            }
        }



        private class Card
        {
            private int pın;
            private string cardNumber;
            private DateTime expiryDate;
            public int PIN
            {

                get { return pın; }

                set
                {
                    pın = value;
                }
            }
            public string CardNumber
            {

               get
                {
                    string originalcard=cardNumber.ToString();
                    return originalcard.Substring(0, 3) + "************";

                }

                set
                {
                    cardNumber = value;
                }
            }
            public DateTime ExpiryDate
            {

                get { return expiryDate; }

                set
                {
                    expiryDate = value;
                }
            }

            public Card(int pıny,string card,DateTime expirt)
            {
                PIN = pıny;
                CardNumber = card;
                ExpiryDate = expirt;
            }


        }

        public BankAccount(string name, int EnrtyPın,string CardNmbr,DateTime Expirtdate)
        {
         ownerName=name;
            card=new Card(EnrtyPın,CardNmbr,Expirtdate);


        }

       
        public  void ShowInfo()
        {
            Console.WriteLine($"Owner name:{OwnerName}");
            Console.WriteLine($"Your Card Number:{card.CardNumber}");
            Console.WriteLine($"Expirty Date:{card.ExpiryDate}");
            Console.WriteLine($"Your Current Balance:{Balance}");
         
            Bankstats.TotalWithdrawing();
            Bankstats.TotalDeposit();
            Bankstats.TotalProcess();


        }
       public static void WaitAndClear()
        {
            Console.WriteLine("\nPress any key to try again...");
            Console.ReadKey();
            Console.Clear();

        }
        
        public interface ITransaction
        {
            void Execute(BankAccount account, int amount);
           
            void ShowDetails();



        }
     

    }
}
