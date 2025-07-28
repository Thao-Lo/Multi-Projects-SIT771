public class TransferTransaction
{
    Account _toAccount;
    Account _fromAccount;
    decimal _amount;
    DepositTransaction _theDeposit;
    WithdrawTransaction _theWithdraw;
    private bool _executed = false;
    private bool _reversed = false;

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
    {
        _fromAccount = fromAccount;
        _toAccount = toAccount;
        _amount = amount;
        _theWithdraw = new WithdrawTransaction(_fromAccount, _amount);
        _theDeposit = new DepositTransaction(_toAccount, _amount);
    }
    public bool Executed => _executed;
    public bool Success => _theDeposit.Success && _theWithdraw.Success;
    public bool Reversed => _reversed;

    public void Execute()   // Executes the transfer by withdrawing then depositing
    {
        if (_executed)
        {
            throw new Exception("Cannot execute this transaction as it has already executed successfully once.");
        }

        // Execute withdrawal first; only proceed to deposit if withdrawal succeeds.
        // If deposit fails, rollback the withdrawal 
        _theWithdraw.Execute();
        if (_theWithdraw.Success)
        {
            _theDeposit.Execute();
            if (!_theDeposit.Success)
            {
                _theWithdraw.Rollback();
                return;
            }
        }
        _executed = true;
    }

    public void Rollback()   // Rolls back both withdrawal and deposit if possible
    {
        if (!_executed)
        {
            throw new Exception("Failed to execute the transfer transaction");
        }
        if (_reversed)
        {
            throw new Exception("Transaction is already reversed.");
        }

        // If the overall transfer was successful, rollback both withdrawal and deposit (if needed),
        if (Success)
        {
            if (_theWithdraw.Success)
            {
                _theWithdraw.Rollback();
            }
            if (_theDeposit.Success)
            {
                _theDeposit.Rollback();
            }
            _reversed = true;

        }
    }
    public void Print()  // Prints a summary of the transfer and its sub-transactions
    {
        Console.WriteLine($"Transfer ${_amount} from {_fromAccount.Name}'s Account to {_toAccount.Name} Account");

        Console.Write("   ");
        _theWithdraw.Print();

        Console.Write("   ");
        _theDeposit.Print();
    }

}