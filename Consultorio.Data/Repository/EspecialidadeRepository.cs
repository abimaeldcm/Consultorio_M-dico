using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class EspecialidadeRepository : ICRUDRepository<Specialty>
    {
        private readonly ConsultorioDbContext _context;

        public EspecialidadeRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<Specialty> FindById(int id)
        {
            return await _context.Specialty.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Specialty>> FindByText(string query)
        {
            return await _context.Specialty
                                .Where(m => EF.Functions.Like(m.MedicalSpecialty, $"%{query}%"))
                                .ToListAsync();
        }

        public async Task<List<Specialty>> GetAll()
        {
            return await _context.Specialty.ToListAsync();
        }

        public async Task<Specialty> Create(Specialty create)
        {
            await _context.Specialty.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var especialidadeDb = await FindById(id);
                _context.Specialty.Remove(especialidadeDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a deleção!");
            }
        }

        public async Task<Specialty> Update(Specialty update)
        {
            _context.Specialty.Update(update);
            await _context.SaveChangesAsync();

            return update;
        }
    }
}
