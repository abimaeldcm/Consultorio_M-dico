using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class AtendimentoRepository : ICRUDRepository<Atendimento>
    {
        //Buscar pr período

        private readonly ConsultorioDbContext _context;

        public AtendimentoRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<Atendimento> BuscarPorId(int id)
        {
            return await _context.Atendimentos
                .Include(x => x.Paciente)
                .Include(x => x.Medico)
                .Include(x => x.Servico)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Atendimento>> BuscarPorTexto(string termoPesquisa)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Atendimento>> BuscarTodos()
        {
            return await _context.Atendimentos
                .Include(x => x.Paciente)
                .Include(x => x.Medico)
                .Include(x => x.Servico)
                .ToListAsync();
        }

        public async Task<Atendimento> Cadastrar(Atendimento cadastrar)
        {
            await _context.Atendimentos.AddAsync(cadastrar);
            await _context.SaveChangesAsync();

            return cadastrar;
        }

        public async Task<bool> Delete(int id)
        {
            var atendimentoDb = await BuscarPorId(id);
            _context.Atendimentos.Remove(atendimentoDb);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Atendimento> Editar(Atendimento editar)
        {
            _context.Atendimentos.Update(editar);
            await _context.SaveChangesAsync();

            return editar;
        }
    }
}
