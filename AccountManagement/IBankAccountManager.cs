public interface IBankAccountManager
{
    IBankAccountOperations RetrieveAccount(int accountNumber);
    void AddAccount(IBankAccountOperations account);
}
