using System.Threading.Tasks;
using BookStore_WebApi.Data;
using Microsoft.AspNetCore.Identity;

namespace BookStore_WebApi.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                Email = signUpDto.Email,
                UserName = signUpDto.Email
            };
            return await _userManager.CreateAsync(user, signUpDto.Password);
        }
    }
}