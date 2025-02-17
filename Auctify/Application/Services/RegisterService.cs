using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class RegisterService
    {
        private readonly IRegister _repository;

        public RegisterService(IRegister repository)
        {
            _repository = repository;
        }

        public async Task<RegisterEntity> Register(RegisterEntity registerEntity)
        {
            return await _repository.Register(registerEntity);
        }

    }
}
