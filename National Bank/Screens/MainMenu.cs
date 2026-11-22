using National_Bank.Helpers;


namespace National_Bank.Screens
{
    internal static class MainMenu
    {
        public static void ShowMainMenu()
        {
            Console.Clear();

            Console.WriteLine("=========================================================");
            Console.WriteLine("\t\tNational Bank Management System");
            Console.WriteLine("=========================================================");
            Console.WriteLine("\t1) Add a new Customer.");
            Console.WriteLine("\t2) Open a new Account for a Customer.");
            Console.WriteLine("\t3) Update Account Status (Active / Closed).");
            Console.WriteLine("\t4) Remove an Account from a Customer.");
            Console.WriteLine("\t5) List All Customers (With Accounts).");
            Console.WriteLine("\t0) Exit.");
            Console.WriteLine("---------------------------------------------------------");

            int Choice = ReadInputs.ReadIntBetween("Enter Choice: ", 0, 5);

            switch (Choice)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    AddNewCustomer.AddCustomer();
                    ShowMainMenu();
                    break;
                case 2:
                    OpenAccount.ShowOpenAccountScreen();
                    ShowMainMenu();
                    break;
                case 3:
                    UpdateAccountStatus.ShowUpdateAccountStatusScreen();
                    ShowMainMenu();
                    break;
                case 4:
                    RemoveAccount.ShowRemoveAccountScreen();
                    ShowMainMenu();
                    break;
                case 5:
                    ShowAllCustomers.ShowAllCustomersScreen();
                    ShowMainMenu();
                    break;
            }
        }
    }
}
