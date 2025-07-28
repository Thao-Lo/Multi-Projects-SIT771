public class DepositTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _executed = false;
    private bool _success = false;
    private bool _reversed = false;

    public DepositTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }
    public bool Executed => _executed; //read only, no setter
    public bool Success => _success;
    public bool Reversed => _reversed;

   
    public void Execute()  // Executes the deposit transaction
    {
        if (_executed)
        {
             // Prevent duplicate execution
            throw new Exception("Cannot execute this transaction as it has already executed successfully once.");
        }
        _executed = true;

          // Attempt to deposit into the account; store whether it succeeded
        _success = _account.Deposit(_amount);
    }
    public void Rollback()   // Rolls back the transaction by withdrawing the deposited amount
    {
        // 
        if (!_executed) // Can't rollback if transaction hasn't been executed
        {
            throw new Exception("Failed to execute the transaction");
        }
        if (_reversed)  // Prevent multiple rollbacks
        {
            throw new Exception("Transaction is already reversed.");
        }
        if (_success) // Only withdraw if deposit actually happened
        {
            _reversed = true;
            _success = _account.Withdraw(_amount);  // reverse the deposit
        }
        else
        {
             // Rollback not possible if deposit was never successful
            throw new Exception("Cannot rollback, please contact the bank");
        }
    }
    public void Print()  // Print transaction result summary
    {
        if (_success && !_reversed)
        {
            Console.WriteLine($"Successfully deposit ${_amount}");
        }
        else if (_reversed)
        {
            Console.WriteLine("Something wrong, your deposit is reversed.");
        }
        else
        {
            Console.WriteLine($"Something wrong, cannot deposit ${_amount} to your account");

        }
    }
}