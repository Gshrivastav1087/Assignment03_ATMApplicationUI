public interface IBankAccountOperations
{
    int AccountNumber { get; }
    string AccountHolderName { get; }
    double Balance { get; }
    double InterestRate { get; }
    string Password { get; }

    void DepositMoney(double amount);
    void WithdrawMoney(double amount);
    void CalculateInterest(); 
    void DisplayStatement();
    IEnumerable<string> GetTransactionHistory();

}
