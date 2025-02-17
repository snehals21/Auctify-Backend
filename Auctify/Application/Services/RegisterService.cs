using Application.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class RegisterService
    {
        private readonly IRegister _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterService(IRegister repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;

        }


        public async Task<RegisterDTO> Register(RegisterDTO registerModel)
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
            return await _repository.Register(registerModel);
        }

    }
}
