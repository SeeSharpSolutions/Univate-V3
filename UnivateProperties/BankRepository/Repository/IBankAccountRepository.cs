using BankRepository.Models;
using System.Collections.Generic;

namespace BankRepository.Repository
{
    public interface IBankAccountRepository
    {
        IEnumerable<BankAccount> GetBankAccounts();
        BankAccount GetBankAccountByID(int BankId);
        void InsertBankAccount(BankAccount BankAccount);
        void DeleteBankAccount(int BankAccountId);
        void UpdateBankAccount(BankAccount BankAccount);
        void Save();
    }
}
