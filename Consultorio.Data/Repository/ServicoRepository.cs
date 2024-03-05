using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class ServicoRepository : ICRUDRepository<Servico>
    {
        private readonly ConsultorioDbContext _context;

        public ServicoRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public Task<Servico> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Servico>> BuscarPorTexto(string termoPesquisa)
        {
            return await _context.Servicos
                .Where(m => EF.Functions.Like(m.Nome, $"%{termoPesquisa}%") || EF.Functions.Like(m.Descricao, $"%{termoPesquisa}%"))
                .ToListAsync();
        }

        public Task<List<Servico>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<Servico> Cadastrar(Servico cadastrar)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Servico> Editar(Servico editar)
        {
            throw new NotImplementedException();
        }
    }
}
