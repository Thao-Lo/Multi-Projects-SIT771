using BankProgram;

public class Account
{
    private string _name;
    private decimal _balance;

    //constructor
    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;
    }

    // name: getter
    public string Name
    {
        get { return _name; }
    }

    // -- METHODS --
    public bool Deposit(decimal amountToDeposit)
    {
        if (amountToDeposit > 0) //valid amount
        {
            _balance += amountToDeposit; // update balance 
            return true;
        }
        return false; //deposit amount < 0

    }
    public bool Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw > _balance || amountToWithdraw < 0)
        {
            return false;
        }
        else //valid amount
        {
            _balance -= amountToWithdraw; // update balance 
            return true;
        }
    }

    //Validates whether the given amount is acceptable for the specified transaction type (Withdraw or Deposit)
    public bool isValidAmount(decimal amountToWithdraw, MenuOption option)
    {
        //Check if user want to withdraw money
        if (option == MenuOption.Withdraw)
        {
            if (amountToWithdraw <= _balance && amountToWithdraw > 0)
            {
                return true; // Withdrawal is valid
            }
            else
            {
                return false; 
            }
        }
        //Check if user want to deposit money
        if (option == MenuOption.Deposit && amountToWithdraw > 0)
        {
            return true; // Deposit is valid
        }
        else
        {
            return false;
        }
    }

    public void Print()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Balance: {_balance}");
    }


}