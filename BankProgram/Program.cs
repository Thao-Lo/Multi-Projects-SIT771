using System;
using SplashKitSDK;

namespace BankProgram
{
    public class Program
    {
        public static void Main()
        {   
            //1st account
            Account account = new Account("Jake Account", 200000);
            account.Print();
            account.Deposit(2000);
            account.Print();
            account.Withdraw(150000);
            account.Print();

            Console.WriteLine(); // break line 
            
            // my account
            Account zavisAccount = new Account("Zavis Account", 1500.15m);
            zavisAccount.Print();
            zavisAccount.Deposit(15.5m);
            zavisAccount.Print();
            zavisAccount.Withdraw(215.31m);
            zavisAccount.Print();
            zavisAccount.Deposit(15000.5m);
            zavisAccount.Print();
        }
    }
}
