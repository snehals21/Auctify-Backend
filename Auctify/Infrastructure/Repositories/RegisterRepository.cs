using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public class RegisterRepository : IRegister
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterEntity> Register(RegisterEntity registerModel)
        {
            if (registerModel == null
                || string.IsNullOrEmpty(registerModel.FullName)
                || string.IsNullOrEmpty(registerModel.Email)
                || string.IsNullOrEmpty(registerModel.Password))
            {
                throw new InvalidOperationException("Please enter valid data.");
            }

            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                throw new InvalidOperationException("Password and Confirm Password must be same!");
            }

            var existingUser = await _userManager.FindByEmailAsync(registerModel.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email ID already registered..");
            }

            var user = new ApplicationUser
            {
                FullName = registerModel.FullName,
                Email = registerModel.Email,
                UserName = registerModel.Email,
            };


            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("User with this email ID already registered.");
            }

            return registerModel;
        }
    }
}
