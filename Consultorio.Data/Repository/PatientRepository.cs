using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class PatientRepository : ICRUDRepository<Patient>
    {
        private readonly ConsultorioDbContext _context;

        public PatientRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> FindById(int id)
        {
            return await _context.Patients.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Patient>> FindByText(string termoPesquisa)
        {
            return await _context.Patients
                            .Where(m => EF.Functions.Like(m.Name, $"%{termoPesquisa}%") ||
                                EF.Functions.Like(m.LastName, $"%{termoPesquisa}%") ||
                                EF.Functions.Like(m.PhoneNumber, $"%{termoPesquisa}%") ||
                                EF.Functions.Like(m.CPF, $"%{termoPesquisa}%") ||
                                EF.Functions.Like(m.Address, $"%{termoPesquisa}%"))
                            .ToListAsync();
        }

        public async Task<List<Patient>> GetAll()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> Create(Patient create)
        {
            await _context.Patients.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var PatientDb = await FindById(id);
                _context.Patients.Remove(PatientDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a deleção!");
            }

        }

        public async Task<Patient> Update(Patient update)
        {
            _context.Patients.Update(update);
            await _context.SaveChangesAsync();
            return update;
        }
    }
}
