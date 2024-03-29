using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookStore_WebApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStore_WebApi.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
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
        public async Task<string> Login(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);
            if (!result.Succeeded) return null;

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email , loginDto.Email) ,
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
            };

            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}