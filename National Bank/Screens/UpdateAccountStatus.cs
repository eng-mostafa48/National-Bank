

using National_Bank.Contexts;
using National_Bank.Enums;
using National_Bank.Helpers;

namespace National_Bank.Screens
{
    internal static class UpdateAccountStatus
    {
        public static void ShowUpdateAccountStatusScreen()
        {
            Console.Clear();
            using AppDbContext context = new AppDbContext();

            Console.WriteLine("--- Update Account Status ---");
            string AccountNumber = ReadInputs.ReadString("Account Number: ");
            int CustomerId = ReadInputs.ReadIntBetween("Customer Id: ", 1, int.MaxValue);

            Console.WriteLine("\nNewStatus:");
            Console.WriteLine("1.Active");
            Console.WriteLine("2.Closed");

            int Status = ReadInputs.ReadIntBetween("Choice: ", 1, 2);

            var Account = context.Accounts.FirstOrDefault(Acc=>Acc.AccountNumber == AccountNumber);
            var Customer = context.CustomerAccounts.FirstOrDefault(CA => CA.CustomerId == CustomerId);

            if (Account == null || Customer == null)
            {
                Console.WriteLine($"Couldn't find Account '{AccountNumber}' or Customer #{CustomerId}");
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(true);
                return;
            }

            Customer.AccountStatus = (AccountStatus)Status;
            context.SaveChanges();

            Console.WriteLine($"Status Updated to {Customer.AccountStatus.ToString()}");

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);

        }
    }
}
