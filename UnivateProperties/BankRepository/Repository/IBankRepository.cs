using BankRepository.Models;
using System.Collections.Generic;

namespace BankRepository.Repository
{
    public interface IBankRepository
    {
        IEnumerable<Bank> GetBanks();
        Bank GetBankByID(int BankId);
        void InsertBank(Bank Bank);
        void DeleteBank(int BankId);
        void UpdateBank(Bank Bank);
        void Save();
    }
}
