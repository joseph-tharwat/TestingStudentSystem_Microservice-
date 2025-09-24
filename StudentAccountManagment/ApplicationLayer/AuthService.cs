using Microsoft.AspNetCore.Identity;
using StudentAccountManagment.Infrastructure;
using StudentAccountManagment.Shared;

namespace StudentAccountManagment.ApplicationLayer
{
    public class AuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task Login(LoginUser loginUser)
        {
            var user = await userManager.FindByEmailAsync(loginUser.Email);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var result = await signInManager.PasswordSignInAsync(user, loginUser.Password, false, false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid credentials");
            }
        }

        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }

        public async Task Register(RegisterUser registerUser)
        {
            var existedUser = await userManager.FindByEmailAsync(registerUser.Email);
            if (existedUser != null)
            {
                throw new Exception("Email already existed.");
            }

            var user = new ApplicationUser() 
            {
                UserName= registerUser.Name,
                Email= registerUser.Email
            };

            var result = await userManager.CreateAsync(user, registerUser.Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(",",result.Errors.Select(e=>e.Description)));
            }

            await signInManager.SignInAsync(user, false);
        }
    }
}
