using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.OutputDTOs;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class UserRepository : ICRUDRepository<User> , ILoginRepository
    {
        private readonly ConsultorioDbContext _context;

        public UserRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<User> FindLogin(string name, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Name == name && x.Password == password);
        }

        public async Task<User> FindById(int id)
        {
            var servicoDb = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (servicoDb is null)
            {
                throw new Exception("Id Não existe no banco de dados.");
            }
            return servicoDb;
        }

        public async Task<List<User>> FindByText(string query)
        {
            return null;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Create(User create)
        {
            await _context.Users.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var UserDb = await FindById(id);
                _context.Users.Remove(UserDb);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<User> Update(User update)
        {
            _context.Users.Update(update);
            await _context.SaveChangesAsync();
            return update;
        }
    }
}
