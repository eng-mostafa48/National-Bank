

using National_Bank.Contexts;
using National_Bank.Enums;
using National_Bank.Helpers;
using National_Bank.Models;

namespace National_Bank.Screens
{
    internal static class OpenAccount
    {
        public static void ShowOpenAccountScreen()
        {
            Console.Clear();
            Console.WriteLine("--- Open Account ---");

            Account NewAccount;
            string AccountNumber = ReadInputs.ReadString("AccountNumber: ");

            Console.WriteLine("\nAccount Type:");
            Console.WriteLine("1. Saving");
            Console.WriteLine("2. Current");
            Console.WriteLine("3. Business");

            int type = ReadInputs.ReadIntBetween("Choice: ", 1, 3);
            decimal balance;

            while (true)
            {
                Console.Write("Balance: ");

                if (decimal.TryParse(Console.ReadLine(), out balance) && balance >= 0)
                    break;

                Console.WriteLine("Invalid balance! Enter a non-negative number.");
            }

            string BranchCode = ReadInputs.ReadString("Branch Code: ");
            int CustomerId = ReadInputs.ReadIntBetween("Customer Id: ", 1, int.MaxValue);

            Console.WriteLine("\nOwnership Role:");
            Console.WriteLine("1. Primary");
            Console.WriteLine("2. Coholder");

            int Role = ReadInputs.ReadIntBetween("Choice: ", 1, 2);

            using AppDbContext db = new AppDbContext();
            
            Console.WriteLine($"Validating Branch '{BranchCode}' and Customer #{CustomerId}");
            var Branch = db.Branches.Any(b=>b.Code == BranchCode);
            var Customer = db.Customers.Any(c=>c.Id == CustomerId);

            if (!Branch || !Customer)
            {
                Console.WriteLine("Branch or Customer doesn't exist!");

            }
            else
            {
                NewAccount = new Account()
                {
                    AccountNumber = AccountNumber,
                    AccountType = (AccountType)type,
                    CreatedAtBranchCode = BranchCode,
                    CurrentBalance = balance,
                    OpeningDate = DateTime.Now
                };

                NewAccount.AccountCustomers.Add(
                    new CustomerAccount
                    {
                        CustomerId = CustomerId,
                        AccountNumber = AccountNumber,
                        OwnershipStartDate = DateTime.Now,
                        OwnerShipType = (OwnerShipType)Role,
                        AccountStatus = AccountStatus.Active
                    });

                db.Accounts.Add(NewAccount);
                db.SaveChanges();
                Console.WriteLine($"Account '{NewAccount.AccountNumber}' Created and linked to Customer #{CustomerId}");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);

        }

       
    }
}
