using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class EspecialidadeRepository : ICRUDRepository<Speciality>
    {
        private readonly ConsultorioDbContext _context;

        public EspecialidadeRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<Speciality> FindById(int id)
        {
            return await _context.Speciality.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Speciality>> FindByText(string query)
        {
            return await _context.Speciality
                                .Where(m => EF.Functions.Like(m.MedicalSpeciality, $"%{query}%"))
                                .ToListAsync();
        }

        public async Task<List<Speciality>> GetAll()
        {
            return await _context.Speciality.ToListAsync();
        }

        public async Task<Speciality> Create(Speciality create)
        {
            await _context.Speciality.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var especialidadeDb = await FindById(id);
                _context.Speciality.Remove(especialidadeDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a deleção!");
            }
        }

        public async Task<Speciality> Update(Speciality update)
        {
            _context.Speciality.Update(update);
            await _context.SaveChangesAsync();

            return update;
        }
    }
}
