using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutputDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Services
{
    public class UserService : ICRUDService<UserOutputDTO, UserInputDTO>, ILoginService
    {

        private readonly ICRUDRepository<User> _repository;
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public UserService(ICRUDRepository<User> repository, ILoginRepository loginRepository, IMapper mapper)
        {
            _repository = repository;
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<UserOutputDTO> FindLogin(string name, string password)
        {
            var UserDb =  await _loginRepository.FindLogin(name, password);
            UserOutputDTO UserMap = _mapper.Map<UserOutputDTO>(UserDb);
            return UserMap;
        }

        public async Task<UserOutputDTO> FindById(int id)
        {
            User UserDb = await _repository.FindById(id);
            UserOutputDTO UserMap = _mapper.Map<UserOutputDTO>(UserDb);
            return UserMap;
        }

        public async Task<List<UserOutputDTO>> FindByText(string query)
        {
            List<User> UserDb = await _repository.FindByText(query);
            List<UserOutputDTO> UserMap = _mapper.Map<List<UserOutputDTO>>(UserDb);
            return UserMap;
        }

        public async Task<List<UserOutputDTO>> GetAll()
        {
            List<User> UserDb = await _repository.GetAll();
            List<UserOutputDTO> UserMap = _mapper.Map<List<UserOutputDTO>>(UserDb);
            return UserMap;
        }

        public async Task<UserOutputDTO> Create(UserInputDTO create)
        {
            User UserCadastro = _mapper.Map<User>(create);
            User UserDb = await _repository.Create(UserCadastro);
            UserOutputDTO UserMap = _mapper.Map<UserOutputDTO>(UserDb);
            return UserMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<UserOutputDTO> Update(int id, UserInputDTO update)
        {
            User buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("User não localizado");
            }
            User UserUpdate = _mapper.Map<User>(update);
            UserUpdate.Id = id;
            User UserDb = await _repository.Update(UserUpdate);
            UserOutputDTO UserMap = _mapper.Map<UserOutputDTO>(UserDb);
            return UserMap;
        }
    }
}
