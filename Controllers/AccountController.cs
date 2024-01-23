using System.Linq;
using System.Threading.Tasks;
using BookStore_WebApi.Data;
using BookStore_WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_WebApi.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;


        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignUpDto signUpDto)
        {
            var result = await _accountRepository.SignUp(signUpDto);
            if (result.Succeeded) return Ok();
            return BadRequest(result.Errors.Select(x => x.Description).ToList());
        }
    }
}