using National_Bank.Enums;


namespace National_Bank.Models
{
    internal class Transaction
    {
        public string TransactionNumber {  get; set; }

        public DateTime TransactionDate { get; set; }
        public decimal Amount {  get; set; }
        public TransactionType TransactionType { get; set; }
        public string Note {  get; set; }

        public String AccountNumber { get; set; }
        public Account Account { get; set; } = default!;
    }
}
