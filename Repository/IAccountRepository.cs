using System.Threading.Tasks;
using BookStore_WebApi.Data;
using Microsoft.AspNetCore.Identity;

namespace BookStore_WebApi.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignUpDto signUpDto);
        Task<string> Login(LoginDto loginDto);
    }
}