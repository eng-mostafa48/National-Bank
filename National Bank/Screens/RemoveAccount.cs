using National_Bank.Contexts;
using National_Bank.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Bank.Screens
{
    internal static class RemoveAccount
    {
        public static void ShowRemoveAccountScreen()
        {
            Console.Clear();
            using AppDbContext context = new AppDbContext();

            Console.WriteLine("--- Remove Account From Customer ---");
            string AccountNumber = ReadInputs.ReadString("Account Number: ");
            int CustomerId = ReadInputs.ReadIntBetween("Customer Id: ", 1, int.MaxValue);

            var customerAccount = context.CustomerAccounts
                .FirstOrDefault(ca =>
                    ca.CustomerId == CustomerId &&
                    ca.AccountNumber == AccountNumber);

            if (customerAccount == null)
            {
                Console.WriteLine("This account is not associated with this customer.");
                Console.WriteLine("\n\nPress any key to return to the menu...");
                Console.ReadKey(true);
                return;
            }


            context.CustomerAccounts.Remove(customerAccount);
            context.SaveChanges();
            Console.WriteLine("Ownership link Deleted.");

            var customerWithThisAccount = context.CustomerAccounts
               .Where(ca => ca.AccountNumber == AccountNumber);

            if (!customerWithThisAccount.Any())
            {
                var Account = context.Accounts.FirstOrDefault(Acc => Acc.AccountNumber == AccountNumber);
                if (Account != null)
                {
                    context.Accounts.Remove(Account);
                    context.SaveChanges();
                    Console.WriteLine($"That was the last Owner - Account '{AccountNumber}' also deleted");
                }   
            }

            Console.WriteLine("\n\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }
    }
}
