using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankRepository.DBContext;
using BankRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace BankRepository.Repository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly BankContext _dbContext;

        public BankAccountRepository(BankContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteBankAccount(int BankAccountId)
        {
            var item = _dbContext.BankAccounts.Find(BankAccountId);
            _dbContext.BankAccounts.Remove(item);
            Save();
        }

        public BankAccount GetBankAccountByID(int BankAccountId)
        {
            return _dbContext.BankAccounts.Find(BankAccountId);
        }

        public IEnumerable<BankAccount> GetBankAccounts()
        {
            return _dbContext.BankAccounts.ToList();
        }

        public void InsertBankAccount(BankAccount BankAccount)
        {
            _dbContext.Add(BankAccount);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBankAccount(BankAccount BankAccount)
        {
            _dbContext.Entry(BankAccount).State = EntityState.Modified;
            Save();
        }
    }
}
