using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class EspecialidadeRepository : ICRUDRepository<Especialidade>
    {
        private readonly ConsultorioDbContext _context;

        public EspecialidadeRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<Especialidade> BuscarPorId(int id)
        {
            return await _context.Especialidades.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Especialidade>> BuscarPorTexto(string termoPesquisa)
        {
            return await _context.Especialidades
                                .Where(m => EF.Functions.Like(m.EspecialidadeMedica, $"%{termoPesquisa}%"))
                                .ToListAsync();
        }

        public async Task<List<Especialidade>> BuscarTodos()
        {
            return await _context.Especialidades.ToListAsync();
        }

        public async Task<Especialidade> Cadastrar(Especialidade cadastrar)
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

        public async Task<Especialidade> Editar(Especialidade editar)
        {
            _context.Especialidades.Update(editar);
            await _context.SaveChangesAsync();

            return editar;
        }
    }
}
