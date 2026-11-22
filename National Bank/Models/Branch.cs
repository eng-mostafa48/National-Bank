

namespace National_Bank.Models
{
    internal class Branch
    {
        public string Code {  get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }


        public int ManagerId { get; set; }
        public Manager Manager { get; set; } = default!;


        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
