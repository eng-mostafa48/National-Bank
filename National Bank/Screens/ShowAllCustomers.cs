using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using National_Bank.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Bank.Screens
{
    internal static class ShowAllCustomers
    {
        public static void ShowAllCustomersScreen()
        {
            Console.Clear();
            using AppDbContext context = new AppDbContext();
            Console.WriteLine("--- List Customers ---");

            var Res = context.Customers.AsNoTracking().Join(context.CustomerAccounts,
                C => C.Id, CA => CA.CustomerId, (C, CA) => new { C, CA }).Join(context.Accounts.Include(Acc=>Acc.CreatedAtBranch),
                X => X.CA.AccountNumber, Acc => Acc.AccountNumber, (x, account) => new
                {
                    Customer = x.CA.Customer,
                    CustomerAccount = x.CA,
                    Account = account
                });

            foreach (var x in Res)
            {
                Console.WriteLine($"#{x.Customer.Id} {x.Customer.FullName} ({x.Customer.CustomerType.ToString()})");
                Console.WriteLine($"{x.Account.AccountNumber} {x.Account.AccountType}, " +
                    $"Balance {x.Account.CurrentBalance} {x.CustomerAccount.OwnerShipType}" + 
                      $"{x.CustomerAccount.AccountStatus} @ {x.Account.CreatedAtBranch?.Name}");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }
    }
}
