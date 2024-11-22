public class TransactionsManager
{
    private IBankAccountManager bank;

    public TransactionsManager(IBankAccountManager bank)
    {
        this.bank = bank;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the ATM Application!");
        Console.WriteLine("Please enter your account number and password to Login.");

        bool isLoggedIn = false;

        while (!isLoggedIn)
        {
            Console.Write("Enter Account Number: ");
            int accountNumber;

            if (!int.TryParse(Console.ReadLine(), out accountNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid account number.");
                continue;
            }

            IBankAccountOperations account = bank.RetrieveAccount(accountNumber);
            if (account != null)
            {
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                if (account.Password == password)
                {
                    Console.WriteLine("Account Verified!");
                    BankStatement.DisplayStatement(account);
                    AccountMenu(account);  // Show the account menu for further operations
                    isLoggedIn = true;
                }
                else
                {
                    Console.WriteLine("Invalid Password. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Account Not Found. Please try again.");
            }
        }
    }

    private void AccountMenu(IBankAccountOperations account)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Deposit Money");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. View Account Statement");
            Console.WriteLine("4. Exit ATM");

            Console.Write("Please select an option: ");
            string choice = Console.ReadLine();

            // Simulate the passage of time for each operation (1 second = 1 month)
            account.CalculateInterest();  // Apply interest before every operation

            switch (choice)
            {
                case "1":
                    Console.Write("Enter deposit amount: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    account.DepositMoney(depositAmount);
                    Console.WriteLine($"Deposited {depositAmount:C}");
                    break;
                case "2":
                    Console.Write("Enter withdrawal amount: ");
                    double withdrawAmount = double.Parse(Console.ReadLine());
                    account.WithdrawMoney(withdrawAmount);
                    Console.WriteLine($"Withdrew {withdrawAmount:C}");
                    break;
                case "3":
                    BankStatement.DisplayStatement(account);  // Modified to call BankStatement class
                    break;
                case "4":
                    Console.WriteLine("Exiting application.");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}
