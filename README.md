
# ATM Banking System

## Description

This project implements a simple ATM Banking System in C# where users can interact with their bank accounts by logging in, viewing statements, depositing money, and withdrawing money.
The application includes the following components:




- **BankAccountOperations**: Represents an individual bank account with features such as deposit, withdrawal, and displaying a transaction history.
- **BankAccountManager**: Manages the bank accounts and provides functionality to retrieve and add accounts.
- **TransactionsManager**: Handles user interaction, providing an ATM interface where users can log in and perform various transactions.
- **BankStatement**: A helper class to display formatted account statements.
- **IBankAccountManager**: is responsible for managing bank accounts
- **IBankAccountOperations**: defines the operations (such as deposits, withdrawals, and account statement generation) that can be performed on individual 
bank accounts.
  
## Features

- **Login**: Users can log in to their bank account by entering a valid account number and password.
- **Deposit and Withdrawal**: Users can deposit and withdraw money to/from their accounts.
- **Transaction History**: The system keeps track of all transactions made by the user (deposits/withdrawals).
- **Account Statement**: A formatted bank statement that shows the account holder's details, balance, interest rate, and transaction history.


## Setup

1. **Clone the repository**:
   git clone https://github.com/Gshrivastav1087/GautamShrivastav_Assignment03.git

3. **Open the project in Visual Studio or any other C# editor**.

4. **Run the application** by pressing `F5` or executing the project via terminal:


## How to Use

1. **Login**:
   - Enter your account number (default: account numbers from 100 to 1000 are pre-created).
   - Enter the password associated with the account (default: "assignment03").
  
2. **Perform Transactions**:
   - **Deposit**: Choose option `1` to deposit money into your account.
   - **Withdraw**: Choose option `2` to withdraw money from your account.
   - **View Statement**: Choose option `3` to view your account's statement, which includes balance and transaction history.
  
3. **Exit**:
   - Choose option `4` to exit the application.

## Example

1. **Login**:
   ```
   Enter Account Number: 100
   Enter Password: assignment03
   Account Verified!

   *** Bank Statement ***
   Account Holder: AccountHolder100
   Account Number: 100
   Balance: $100.00
   Interest Rate: 3%
   Transaction History:
   ```

2. **ATM Menu**:
   ```
   Select an option:
   1. Deposit Money
   2. Withdraw Money
   3. View Account Statement
   4. Exit ATM
   ```

3. **Account Statement**:
   ```
   *** Bank Statement ***
   Account Holder: AccountHolder100
   Account Number: 100
   Balance: $100.00
   Interest Rate: 3%
   Transaction History:
   Deposit of $100.00
   ```
