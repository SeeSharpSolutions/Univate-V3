using BankRepository.DBContext;
using BankRepository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BankRepository.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly BankContext _dbContext;

        public BankRepository(BankContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Bank> GetBanks()
        {
            return _dbContext.Banks.ToList();
        }

        public void DeleteBank(int BankId)
        {
            var item = _dbContext.Banks.Find(BankId);
            _dbContext.Banks.Remove(item);
            Save();
        }

        public Bank GetBankByID(int BankId)
        {
            return _dbContext.Banks.Find(BankId);
        }        

        public void InsertBank(Bank Bank)
        {
            _dbContext.Add(Bank);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBank(Bank Bank)
        {
            _dbContext.Entry(Bank).State = EntityState.Modified;
            Save();
        }
    }
}
