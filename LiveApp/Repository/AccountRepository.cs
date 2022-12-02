using LiveApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserManager<ApplicationUser> _userManager { get; }

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUserModel)
        {
            return await _userManager.CreateAsync(
                    new ApplicationUser()
                    {
                        FirstName = signUpUserModel.FirstName,
                        LastName = signUpUserModel.LastName,
                        DateOfBirth = signUpUserModel.DateOfBirth,
                        Email = signUpUserModel.Email,
                        UserName = signUpUserModel.Email
                    },
                    signUpUserModel.Password
                );
        }

        public async Task<SignInResult> PasswordSignInAsync(LogInModel logInModel)
        {
            return await _signInManager.PasswordSignInAsync(
                    logInModel.Email, 
                    logInModel.Password, 
                    logInModel.RememberMe, 
                    false
                );
        }
    }
}
