using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class ServiceRepository : ICRUDRepository<ServiceEntity>
    {
        private readonly ConsultorioDbContext _context;

        public ServiceRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceEntity> FindById(int id)
        {
            var servicoDb = await _context.Services.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (servicoDb is null)
            {
                throw new Exception("Id Não existe no banco de dados.");
            }
            return servicoDb;
        }

        public async Task<List<ServiceEntity>> FindByText(string query)
        {
            return await _context.Services
                .Where(m => EF.Functions.Like(m.Name, $"%{query}%") || EF.Functions.Like(m.Description, $"%{query}%"))
                .ToListAsync();
        }

        public async Task<List<ServiceEntity>> GetAll()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<ServiceEntity> Create(ServiceEntity create)
        {
            await _context.Services.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var serviceDb = await FindById(id);
                _context.Services.Remove(serviceDb);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ServiceEntity> Update(ServiceEntity update)
        {
            _context.Services.Update(update);
            await _context.SaveChangesAsync();
            return update;
        }
    }
}
