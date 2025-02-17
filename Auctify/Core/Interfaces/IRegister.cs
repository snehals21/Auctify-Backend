using Application.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRegister
    {
        Task<RegisterDTO> Register(RegisterDTO registerModel);

    }
}
