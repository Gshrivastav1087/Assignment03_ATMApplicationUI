public class BankAccountManager : IBankAccountManager
{
    private List<IBankAccountOperations> accounts;

    public BankAccountManager()
    {
        accounts = new List<IBankAccountOperations>();

        for (int i = 100; i <= 1000; i++)
        {
            accounts.Add(new BankAccountOperations(i, 100, $"IamRandomUser{i}", 0.03, "assignment03"));
        }
    }

    public IBankAccountOperations RetrieveAccount(int accountNumber)
    {
        // Debug log to check account retrieval
        Console.WriteLine($"Attempting to retrieve account for account number: {accountNumber}");

        // Use LINQ to find the account
        var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

        if (account == null)
        {
            // Debug log if account is not found
            Console.WriteLine($"Account with number {accountNumber} not found.");
        }
        else
        {
            // Debug log if account is found
            Console.WriteLine($"Account with number {accountNumber} found: {account.AccountHolderName}");
        }

        return account;
    }

    public void AddAccount(IBankAccountOperations account)
    {
        accounts.Add(account);
    }
}
