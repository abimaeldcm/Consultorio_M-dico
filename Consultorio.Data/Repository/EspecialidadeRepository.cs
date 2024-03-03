using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class EspecialidadeRepository : ICRUD<Especialidade>
    {
        private readonly ConsultorioDbContext _context;

        public EspecialidadeRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public Task<Especialidade> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Especialidade>> BuscarPorTexto(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Especialidade>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<Especialidade> Cadastrar(Especialidade cadastrar)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Especialidade> Editar(Especialidade editar)
        {
            _context.Especialidades.Update(editar);
            await _context.SaveChangesAsync();

            return editar;
        }
    }
}
