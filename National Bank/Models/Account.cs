using National_Bank.Enums;


namespace National_Bank.Models
{
    internal class Account
    {
        public string AccountNumber {  get; set; }

        public decimal CurrentBalance {  get; set; }

        public AccountType AccountType { get; set; }

        public DateTime OpeningDate { get; set; }

        public string CreatedAtBranchCode {  get; set; }
        public Branch CreatedAtBranch { get; set; } = default!;

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<CustomerAccount> AccountCustomers { get; set; } = new List<CustomerAccount>();
    }
}
