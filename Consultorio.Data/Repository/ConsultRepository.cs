using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Consultorio.Infra.Data.Repository
{
    public class ConsultRepository : ICRUDRepository<Consult>
    {
        //Buscar pr período

        private readonly ConsultorioDbContext _context;

        public ConsultRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<Consult> FindById(int id)
        {
            return await _context.Consults
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .Include(x => x.Service)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Consult>> FindByText(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Consult>> GetAll()
        {
            return await _context.Consults
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .Include(x => x.Service)
                .ToListAsync();
        }

        public async Task<Consult> Create(Consult create)
        {
            await _context.Consults.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            var consutDb = await FindById(id);
            _context.Consults.Remove(consutDb);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Consult> Update(Consult update)
        {
            try
            {
                var existingConsult = await _context.Consults.FindAsync(update.Id);
                if (existingConsult == null)
                {
                    throw new ArgumentException("Consult not found.");
                }

                _context.Entry(existingConsult).CurrentValues.SetValues(update);
                await _context.SaveChangesAsync();

                return existingConsult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
