using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class DoctorRepository : ICRUDRepository<Doctor>
    {
        private readonly ConsultorioDbContext _context;

        public DoctorRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> FindById(int id)
        {
            return await _context.Doctors.AsNoTracking().Include(x => x.Speciality).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Doctor>> FindByText(string query)
        {
            return await _context.Doctors
                    .Where(m => EF.Functions.Like(m.Name, $"%{query}%") ||
                        EF.Functions.Like(m.LastName, $"%{query}%") ||
                        EF.Functions.Like(m.PhoneNumber, $"%{query}%") ||
                        EF.Functions.Like(m.CPF, $"%{query}%") ||
                        EF.Functions.Like(m.Address, $"%{query}%"))
                    .ToListAsync();
        }

        public async Task<List<Doctor>> GetAll()
        {
            try
            {
                return await _context.Doctors.Include(x => x.Speciality).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Doctor> Create(Doctor create)
        {
            await _context.Doctors.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var patientDb = await FindById(id);
                _context.Doctors.Remove(patientDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a deleção!");
            }

        }

        public async Task<Doctor> Update(Doctor update)
        {
            _context.Doctors.Update(update);
            await _context.SaveChangesAsync();
            return update;
        }
    }
}
