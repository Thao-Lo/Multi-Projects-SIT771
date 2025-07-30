public class WithdrawTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _executed = false;
    private bool _success = false;
    private bool _reversed = false;

    public WithdrawTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public bool Executed
    {
        get
        {
            return _executed;
        }
    } //perform transaction
    public bool Success => _success; //cleanner way to write read only, no setter, an expression-bodied property
    public bool Reversed => _reversed; 

    public void Execute() // Executes the withdrawal 
    {
        if (_executed)
        {
            throw new Exception("Cannot execute this transaction as it has already executed successfully once.");
        }
        _executed = true;
        _success = _account.Withdraw(_amount); //withdraw
    }
    public void Rollback()  // Reverses the transaction by depositing the amount back if it was successful
    {       
        if (!_executed)  // Can't rollback if transaction hasn't been executed
        {
            throw new Exception("Failed to execute the transaction");
        }
        if (_reversed)  // Prevent multiple rollbacks
        {
            throw new Exception("Transaction is already reversed.");
        }
        if (_success) // Only rollback if withdraw actually happened
        {
            _reversed = true;
            _success = _account.Deposit(_amount); //rollback
        }
        else
        {
            throw new Exception("Cannot rollback, please contact the bank");
        }
    }
    public void Print()
    {
        if (_success && !_reversed)
        {
            Console.WriteLine($"Successfully withdraw ${_amount}");
        }
        else if (_reversed)
        {
            Console.WriteLine("Something wrong, your withdraw is reversed.");
        }
        else
        {
            Console.WriteLine($"Something wrong, cannot withdraw ${_amount} from your account");

        }
    }

}