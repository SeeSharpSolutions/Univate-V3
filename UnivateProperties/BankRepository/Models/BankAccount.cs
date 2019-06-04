namespace BankRepository.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string AccountHolder { get; set; }
        public string BranhName { get; set; }
        public int BranchCode { get; set; }
        public string AccountNumber { get; set; }
        public Bank Bank { get; set; }
    }
}
