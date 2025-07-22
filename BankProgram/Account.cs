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
    public void Deposit(decimal amountToAdd)
    {
        _balance += amountToAdd;
    }
    public void Withdraw(decimal amountToWithdraw)
    {
        _balance -= amountToWithdraw;
    }

    public void Print()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Balance: {_balance}");
    }


}