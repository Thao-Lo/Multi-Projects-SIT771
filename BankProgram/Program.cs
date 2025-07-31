using System;

namespace BankProgram
{
    public enum MenuOption
    {
        Withdraw, Deposit, Transfer, Print, Quit //Withdraw: 0
    }
    public class Program
    {
        public static void Main()
        {
            //init two new accounts
            Account account = new Account("Zavis", 20000); //main account
            Account jackAccount = new Account("Jack", 1000);

            MenuOption userSelection = ReadUserOption(); //return user selection == enum value
            do //show option first 
            {
                switch (userSelection)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(account);
                        userSelection = ReadUserOption(); // show selection again
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(account);
                        userSelection = ReadUserOption();
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(account, jackAccount);
                        userSelection = ReadUserOption();
                        break;
                    case MenuOption.Print:
                        DoPrint(account);
                        userSelection = ReadUserOption();
                        break;

                    case MenuOption.Quit:
                        break;
                }
            } while (userSelection != MenuOption.Quit); //keep running until user select 5/Quit

            Console.WriteLine("Bye. ");
        }
        public static MenuOption ReadUserOption()
        {
            int option = -1;
            do
            {
                Console.WriteLine("Select 1 option [1-4]:");
                Console.WriteLine("1 - Withdraw");
                Console.WriteLine("2 - Deposit");
                Console.WriteLine("3 - Transfer");
                Console.WriteLine("4 - Print account Name & account Balance");
                Console.WriteLine("5 - Quit");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch //invalid number: out of range
                {
                    option = -1; //init option again
                }
            } while (option < 1 || option > 5);


            return (MenuOption)(option - 1); //enmum value start from 0           
        }

        private static void DoDeposit(Account account)
        {
            decimal amount = 0;
            bool isValidAmount = false;
            do
            {
                Console.Write("Enter the amount you want to Deposit: "); //prompt user input
                try
                {
                    amount = Convert.ToDecimal(Console.ReadLine()); //assign user input value
                }
                catch //invalid input
                {
                    amount = 0; //init amount agin
                }

                isValidAmount = account.isValidAmount(amount, MenuOption.Deposit); //validate amount to withdraw

                if (isValidAmount == false) //invalid amount
                {
                    Console.WriteLine("Invalid Amount. Try Again!!!");
                }

            } while (!isValidAmount);

            //create and execute deposit with main account and valid amount
            DepositTransaction depositTransaction = new DepositTransaction(account, amount);
            try
            {
                depositTransaction.Execute();
            }
            catch (Exception executeEx)
            {
                try
                {
                    depositTransaction.Rollback(); //attempt rollback if failed

                }
                catch (Exception rollbackEx)
                {
                    Console.WriteLine("Rollback failed: " + rollbackEx.Message);
                }
                Console.WriteLine("Execute failed: " + executeEx.Message);
            }
            finally
            {
                depositTransaction.Print(); //always Print result
                AddSpace(); //give space when finished each option
            }
        }
        private static void DoWithdraw(Account account)
        {
            decimal amount = 0;
            bool isValidAmount = false;
            do
            {
                Console.Write("Enter the amount you want to Withdraw: "); //prompt user input
                try
                {
                    amount = Convert.ToDecimal(Console.ReadLine()); //assign user input value
                }
                catch
                {
                    amount = 0;
                }
                isValidAmount = account.isValidAmount(amount, MenuOption.Withdraw);  //call Withdraw method in Account class

                if (isValidAmount == false) //invalid amount
                {
                    Console.WriteLine("Invalid Amount. Try Again!!!");
                }

            } while (!isValidAmount);

            //create and execute withdraw with main account and valid amount
            WithdrawTransaction withdrawTransaction = new WithdrawTransaction(account, amount);

            try
            {
                withdrawTransaction.Execute();
            }
            catch (Exception e)
            {
                try
                {
                    withdrawTransaction.Rollback(); //attempt rollback if failed
                }
                catch (Exception rollbackEx)
                {
                    Console.WriteLine("Rollback failed: " + rollbackEx.Message);
                }

                Console.WriteLine("Execute failed: " + e.Message);
            }
            finally
            {
                withdrawTransaction.Print(); //always print message
                AddSpace();
            }
        }
        private static void DoTransfer(Account fromAccount, Account toAccount) // handle transfer between two accounts
        {
            decimal amount = 0;
            bool isValidAmount = false;
            // Validate amount for withdrawal from main account
            do
            {
                Console.Write("Enter the amount you want to Transfer: "); //prompt user input
                try
                {
                    amount = Convert.ToDecimal(Console.ReadLine()); //assign user input value
                }
                catch //invalid input
                {
                    amount = 0; //init amount agin
                }

                isValidAmount = fromAccount.isValidAmount(amount, MenuOption.Withdraw); //validate amount to withdraw

                if (isValidAmount == false) //invalid amount
                {
                    Console.WriteLine("Invalid Amount. Try Again!!!");
                }

            } while (!isValidAmount);

            // Create and execute transfer transaction
            TransferTransaction transferTransaction = new TransferTransaction(fromAccount, toAccount, amount);
            try
            {
                transferTransaction.Execute();
            }
            catch (Exception executeEx)
            {
                try
                {
                    transferTransaction.Rollback(); //attempt rollback if failed

                }
                catch (Exception rollbackEx)
                {
                    Console.WriteLine("Rollback failed: " + rollbackEx.Message);
                }
                Console.WriteLine("Execute failed: " + executeEx.Message);
            }
            finally
            {
                transferTransaction.Print(); // Always print result
                AddSpace(); //give space when finished each option
            }
        }
        private static void DoPrint(Account account) //Print main account info
        {
            account.Print();
            AddSpace();
        }
        private static void AddSpace()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------");
        }
    }
}
