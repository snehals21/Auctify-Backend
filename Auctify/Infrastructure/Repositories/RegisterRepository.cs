using Application.DTOs;
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

        public async Task<RegisterDTO> Register(RegisterDTO registerModel)
        {

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
