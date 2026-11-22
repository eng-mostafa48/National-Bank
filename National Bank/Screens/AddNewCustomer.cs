using National_Bank.Contexts;
using National_Bank.Enums;
using National_Bank.Helpers;
using National_Bank.Models;


namespace National_Bank.Screens
{
    internal static class AddNewCustomer
    {
        public static void AddCustomer()
        {
            Console.Clear();

            using AppDbContext context = new AppDbContext();

            var Customer = ReadCustomerInfo();

            context.Customers.Add(Customer);
            int RowsAffected = context.SaveChanges();

            if(RowsAffected > 0 )
                Console.WriteLine($"Customer added successfully! ID: {Customer.Id}");
            else
                Console.WriteLine("Failed to add Customer.");

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }
        private static Customer ReadCustomerInfo()
        {
            Console.WriteLine("--- Add Customer ---");

            string fullName = ReadInputs.ReadString("Full Name: ");

            string nationalId = ReadInputs.ReadString("National ID: ");

            DateTime dateOfBirth = ReadInputs.ReadDate("Date of Birth (yyyy-MM-dd): ");

            string email = ReadInputs.ReadString("Email: ");

            string phoneNumber = ReadInputs.ReadString("Phone Number: ");

            string address = ReadInputs.ReadString("Address: ");

            Console.WriteLine("\nCustomer Type:");
            Console.WriteLine("1. Individual");
            Console.WriteLine("2. Business");

            int type = ReadInputs.ReadIntBetween("Choose Customer Type: ", 1, 2);

            return new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                CustomerType = (CustomerType)type
            };
        }

    }
}

