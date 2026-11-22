using National_Bank.Enums;


namespace National_Bank.Models
{
    internal class CustomerAccount
    {
        public int CustomerId {  get; set; }
        public Customer Customer { get; set; } = default!;
        public string AccountNumber { get; set; }
        public Account Account { get; set; } = default!;

        public OwnerShipType OwnerShipType { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public DateTime OwnershipStartDate {  get; set; }
    }
}
