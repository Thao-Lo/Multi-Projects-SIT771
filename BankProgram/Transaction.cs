public abstract class Transaction
{
    protected decimal _amount;
    private bool _executed = false;
    private bool _reversed = false;
    private DateTime _dateStamp;

    public abstract bool Success { get; } // read-only, no body
    public bool Executed => _executed; //read only, no setter

    public bool Reversed => _reversed;

    public DateTime DateStamp => _dateStamp;

    public Transaction(decimal amount)
    {
        _amount = amount;
    }

    public abstract void Print();

    public virtual void Execute()
    {
        if (_executed)
        {
            throw new Exception("Failed to execute the transaction");
        }
        _executed = true;
        _dateStamp = DateTime.Now;

    }
    public virtual void Rollback() //child class can either override it or not
    {
        if (_executed)
        {
            throw new Exception("Failed to execute the transaction");
        }
        if (_reversed)
        {
            throw new Exception("Transaction already reversed.");
        }
        
        _executed = true;
        _reversed = true;
        _dateStamp = DateTime.Now;

    }


}