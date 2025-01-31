namespace Bank;

public class BankAccount
{
    public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
    public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

    private string customerName;
    public string CustomerName
    {
        get { return customerName; }
    }

    private double balance;
    public double Balance
    {
        get { return balance; }
    }

    public BankAccount()
    {
        customerName = "Unknown";
        balance = 0;
    }

    public BankAccount(string customerName, double balance)
    {
        this.customerName = customerName;
        this.balance = balance;
    }

    /// <summary>
    /// 직불카드를 사용하여 출금하는 메서드
    /// </summary>
    /// <param name="amount"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Debit(double amount)
    {
        if (amount > balance)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
        }

        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountLessThanZeroMessage);
        }
        balance -= amount;
    }

    public void Creit(double amount)
    {
        if (amount >= 0)
        {
            balance += amount;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }
    }
}
