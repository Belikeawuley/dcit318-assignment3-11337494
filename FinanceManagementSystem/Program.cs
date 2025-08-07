public record Transaction(int Id, DateTime Date, decimal Amount, string Category);

public interface ITransactionProcessor
{
    void Process(Transaction transaction);
}

public class BankTransferProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Bank Transfer: Amount = {transaction.Amount}, Category = {transaction.Category}");
    }
}

public class MobileMoneyProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Mobile Money: Amount = {transaction.Amount}, Category = {transaction.Category}");
    }
}

public class CryptoWalletProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Crypto Wallet: Amount = {transaction.Amount}, Category = {transaction.Category}");
    }
}

public class Account
{
    public string AccountNumber { get; }
    protected decimal Balance { get; set; }  

    public Account(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public virtual void ApplyTransaction(Transaction transaction)
    {
        Balance -= transaction.Amount;
    }
}

public sealed class SavingsAccount : Account
{
    public SavingsAccount(string accountNumber, decimal initialBalance) : base(accountNumber, initialBalance) { }

    public override void ApplyTransaction(Transaction transaction)
    {
        if (transaction.Amount > Balance)
            Console.WriteLine("Insufficient funds!");
        else
        {
            base.ApplyTransaction(transaction);
            Console.WriteLine($"New Balance: {Balance}");
        }
    }
}

public class FinanceApp
{
    private List<Transaction> _transactions = new List<Transaction>();

    public void Run()
    {
        var savingsAccount = new SavingsAccount("ACC123456", 1000m);

        var transaction1 = new Transaction(1, DateTime.Now, 200m, "Groceries");
        var transaction2 = new Transaction(2, DateTime.Now, 150m, "Utilities");
        var transaction3 = new Transaction(3, DateTime.Now, 800m, "Entertainment");

        ITransactionProcessor mobileMoney = new MobileMoneyProcessor();
        mobileMoney.Process(transaction1);
        savingsAccount.ApplyTransaction(transaction1);
        _transactions.Add(transaction1);

        ITransactionProcessor bankTransfer = new BankTransferProcessor();
        bankTransfer.Process(transaction2);
        savingsAccount.ApplyTransaction(transaction2);
        _transactions.Add(transaction2);

        ITransactionProcessor cryptoWallet = new CryptoWalletProcessor();
        cryptoWallet.Process(transaction3);
        savingsAccount.ApplyTransaction(transaction3);
        _transactions.Add(transaction3);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var app = new FinanceApp();
        app.Run();
    }
}
