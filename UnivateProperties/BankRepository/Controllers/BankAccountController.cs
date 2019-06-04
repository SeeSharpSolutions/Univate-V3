using BankRepository.Models;
using BankRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace BankRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountRepository _Repo;

        public BankAccountController(IBankAccountRepository repo)
        {
            _Repo = repo;
        }

        [HttpGet]
        public IActionResult GetBankAccount()
        {
            var BankAccounts = _Repo.GetBankAccounts();
            return new OkObjectResult(BankAccounts);
        }

        [HttpGet("{id}", Name = "GetBankAccount")]
        public IActionResult GetBankAccount(int id)
        {
            var BankAccount = _Repo.GetBankAccountByID(id);
            return new OkObjectResult(BankAccount);
        }

        [HttpPost]
        public IActionResult PostBankAccount([FromBody] BankAccount BankAccount)
        {
            using (var scope = new TransactionScope())
            {
                _Repo.InsertBankAccount(BankAccount);
                scope.Complete();
                return CreatedAtAction(nameof(BankAccount), new { id = BankAccount.Id }, BankAccount);
            }

        }

        [HttpPut("{id}")]
        public IActionResult PutBankAccount(int id, [FromBody] BankAccount BankAccount)
        {
            if (BankAccount != null)
            {
                using (var scope = new TransactionScope())
                {
                    _Repo.UpdateBankAccount(BankAccount);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBankAccount(int id)
        {
            _Repo.DeleteBankAccount(id);
            return new OkResult();
        }
    }
}
