using BankRepository.Models;
using BankRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace BankRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankRepository _Repo;

        public BankController(IBankRepository repo)
        {
            _Repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var banks = _Repo.GetBanks();
            return new OkObjectResult(banks);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var bank = _Repo.GetBankByID(id);
            return new OkObjectResult(bank);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Bank bank)
        {
            using (var scope = new TransactionScope())
            {
                _Repo.InsertBank(bank);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = bank.Id }, bank);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Bank bank)
        {
            if (bank != null)
            {
                using (var scope = new TransactionScope())
                {
                    _Repo.UpdateBank(bank);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _Repo.DeleteBank(id);
            return new OkResult();
        } 
    }
}
