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

        public async Task<Specialty> BuscarPorId(int id)
        {
            return await _context.Especialidades.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Specialty>> BuscarPorTexto(string termoPesquisa)
        {
            return await _context.Especialidades
                                .Where(m => EF.Functions.Like(m.EspecialidadeMedica, $"%{termoPesquisa}%"))
                                .ToListAsync();
        }

        public async Task<List<Specialty>> BuscarTodos()
        {
            return await _context.Especialidades.ToListAsync();
        }

        public async Task<Specialty> Cadastrar(Specialty cadastrar)
        {
            await _context.Especialidades.AddAsync(cadastrar);
            await _context.SaveChangesAsync();

            return cadastrar;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var especialidadeDb = await BuscarPorId(id);
                _context.Especialidades.Remove(especialidadeDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a deleção!");
            }
        }

        public async Task<Specialty> Editar(Specialty editar)
        {
            _context.Especialidades.Update(editar);
            await _context.SaveChangesAsync();

            return editar;
        }
    }
}
