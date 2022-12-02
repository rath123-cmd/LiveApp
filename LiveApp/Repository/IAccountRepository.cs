using LiveApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LiveApp.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUserModel);
        Task<SignInResult> PasswordSignInAsync(LogInModel logInModel);
    }
}