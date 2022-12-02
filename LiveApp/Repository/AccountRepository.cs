using LiveApp.Models;
using LiveApp.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserServices _userServices;

        

        public AccountRepository(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IUserServices userServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userServices = userServices;
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

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userServices.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
    }
}
