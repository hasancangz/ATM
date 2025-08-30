using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ATM.BankAccount;

namespace ATM
{
    static class Manager
    {

        public static string Name()
        {
           
            while (true)
            {
                string name;
                try
                {
                    Console.Write("Please enter your name:");
                    name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException("Please dont leave empty your name"); }
                    foreach (char c in name)
                    {
                        if (!char.IsLetter(c))
                        {
                            throw new ArgumentException("Please enter your name with just letters");
                        }
                    }
                    return name;
                }



                catch (Exception_Class ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Message:{ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Original Message:{ex.InnerException.Message}");

                    }


                }
                BankAccount.WaitAndClear();

            }
            
        }


        public static BankAccount Account()
        {
            string realname = Name();
            int attempt = 0;
            while (attempt<3)
            {
                try
                {
                  Random random = new Random();
                    Console.Write("Please creative a 4-digit PIN:");
                    string pın = Console.ReadLine();
                    if (pın.Length != 4) { throw new Exception_Class.RightForm(); }
                    if (string.IsNullOrEmpty(pın)) { throw new ArgumentNullException("Please dont leave empty your PIN"); }
                    int realpın = int.Parse(pın);
                    DateTime end = new DateTime(2030, 8, 12);
                    string number = "";
                    for (int i = 0; i < 14; i++)
                    {
                        number += random.Next(0, 10);
                    }


                    return new BankAccount(realname, realpın,number,end);
                   

                }

                catch (Exception_Class ex)

                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("--------------------");
                    attempt++;
                    Console.WriteLine($"You have {3 - attempt} attempt to enter your account");
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"Message:{ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Original Message:{ex.InnerException.Message}");

                    }
                   attempt++;
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"You have {3 - attempt} attempt to enter your account");

                }
                if (attempt == 3)
                {
                    
                    return null;
                }
                BankAccount.WaitAndClear();

            }

            return null;
        }
        public static int ChangePIN(BankAccount tryaccount2)
        {
            try
            {
                Console.Write("Please enter current PIN:");
                string oldpın = Console.ReadLine();
                if (string.IsNullOrEmpty(oldpın)) { throw new ArgumentNullException("Please don leave empty old pın"); }
                if (oldpın.Length != 4) { throw new Exception_Class.RightForm(); }
                int realoldpın = int.Parse(oldpın);
               
                if (realoldpın != tryaccount2.cardPIN)
                {
                    throw new Exception_Class.RightPIN();


                }
                Console.Write("Please enter new PIN:");
                string newpın = Console.ReadLine();
                if (string.IsNullOrEmpty(newpın)) { throw new ArgumentNullException("Please don leave empty old pın"); }
                if (newpın.Length != 4) { throw new Exception_Class.RightForm(); }
                int realnewpın = int.Parse(newpın);
                tryaccount2.cardPIN = realnewpın;
                Console.WriteLine("--------------------");
                Console.WriteLine("Your PIN was changed succesfully");
                int a = realnewpın;

                BankAccount.WaitAndClear();
                return a;
            }

            catch (Exception_Class ex)
            {
                Console.WriteLine($"Message:{ex.Message}");
                BankAccount.WaitAndClear();
                return 0;



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message:{ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Original Message: {ex.InnerException.Message}");
                }

                BankAccount.WaitAndClear();
                return 0;
            

            }


        }

        public static void ConfirmPIN(BankAccount tryaccount1)
        {
            int attempt = 0;
            while (attempt < 3)
            {
                try
                {
                    Console.Write("Please confirm your PIN:");
                    string pın1 = Console.ReadLine();
                    if (string.IsNullOrEmpty(pın1)) { throw new ArgumentNullException("Please dont leave empty PIN"); }
                    if (pın1.Length != 4) { throw new Exception_Class.RightForm(); }
                    int realp = int.Parse(pın1);
                    if (tryaccount1.cardPIN != realp) { throw new Exception_Class.RightPIN(); }


                    break;
                }
                catch (Exception_Class ex)

                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("--------------------");
                    attempt++;
                    Console.WriteLine($"You have {3 - attempt} attempt to enter your account");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"Message:{ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Original Message:{ex.InnerException.Message}");

                    }
                    attempt++;
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"You have {3 - attempt} attempt to enter your account");

                }

                if (attempt == 3)
                {
                    Console.WriteLine("Your card is blocked");
                    Environment.Exit(0);
                }
                BankAccount.WaitAndClear();
            }

        }












        public static void Menu(BankAccount tryaccount)
        {
           Manager.ConfirmPIN(tryaccount);


            List<ITransaction> list = new List<ITransaction>();
            bool devam = true;
            while (devam)
            {

               

               

                Console.Clear();
                int realoption;
                Console.WriteLine("1.Showing your personal info and balance");
                Console.WriteLine("2.Depositing Money");
                Console.WriteLine("3.Checking Money");
                Console.WriteLine("4.Showing past action");
                Console.WriteLine("5.Changing your password");
                Console.WriteLine("6.Exit");
                Console.Write("Chosse the option you want to do:");
                string option = Console.ReadLine();

                try
                {
                    if (string.IsNullOrEmpty(option)) { throw new ArgumentNullException("Please dont leave empty option"); }
                     realoption = int.Parse(option);
                    if (realoption < 0 || realoption > 6) { throw new Exception_Class.RightRange(); }



                }
                catch (Exception_Class ex)
                {
                    Console.WriteLine($"Message:{ex.Message}");
                    BankAccount.WaitAndClear();
                    continue;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Message:{ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Original Message: {ex.InnerException.Message}");
                    }

                    BankAccount.WaitAndClear();
                    continue;
                }
                Console.Clear ();

                switch (realoption)
                {
                    case 1:
                        Console.WriteLine("--------------------");
                        tryaccount.ShowInfo();
                        Console.WriteLine("--------------------");
                        BankAccount.WaitAndClear();
                        break;

                    case 2:
                      while (true)
                        {
                                DepositTransaction deposit = new DepositTransaction();

                            int realmoneyamount;
                            Console.WriteLine("Please enter the money amount that you want to deposit:");
                            string moneyamount = Console.ReadLine();
                            try
                            {
                                
                                if (string.IsNullOrEmpty(moneyamount)) { throw new ArgumentNullException("Please dont leave money amount"); }
                                realmoneyamount = int.Parse(moneyamount);

                                deposit.Execute(tryaccount, realmoneyamount);
                                Console.WriteLine("--------------------");
                               
                               
                                
                                list.Add(deposit);
                               
                                BankAccount.WaitAndClear();
                                break;

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Message:{ex.Message}");
                                BankAccount.WaitAndClear();

                            }

                        }
                      break;

                        case 3:
                        WithdrawTransaction withdraw = new WithdrawTransaction();

                        int realmoneyamount2;
                        Console.WriteLine("Please enter the money amount that you want to withdraw:");
                        string moneyamount1 = Console.ReadLine();
                        try
                        {
                         
                            if (string.IsNullOrEmpty(moneyamount1)) { throw new ArgumentNullException("Please dont leave money amount"); }
                            realmoneyamount2 = int.Parse(moneyamount1);
                            
                           withdraw.Execute(tryaccount, realmoneyamount2);
                            Console.WriteLine("--------------------");
                          
                          
                           
                       

                            list.Add(withdraw);
                            
                            
                            BankAccount.WaitAndClear();
                            break;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Message:{ex.Message}");
                            BankAccount.WaitAndClear();

                        }

                        break ;

                        case 4:
                        foreach (ITransaction a in list)
                        {
                            a.ShowDetails();
                            Console.WriteLine("--------------------");
                         
                        }
                        BankAccount.WaitAndClear();
                        break;

                        case 5:
                        int aa=Manager.ChangePIN(tryaccount);
                        if (aa == 0)
                        {
                            break;

                        }
                        
                        Manager.ConfirmPIN(tryaccount);
                        break;


                    case 6:
                        devam = false;
                        break ;

                    default:
                        Console.WriteLine("You did error process || please enter again");
                        BankAccount.WaitAndClear();
                        break;






                }



            }












        }
          







        


    }
}
