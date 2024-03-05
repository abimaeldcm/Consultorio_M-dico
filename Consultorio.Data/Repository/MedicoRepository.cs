using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class MedicoRepository : ICRUDRepository<Medico>
    {
        private readonly ConsultorioDbContext _context;

        public async Task<Medico> BuscarPorId(int id)
        {
            return await _context.Medicos.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Medico>> BuscarPorTexto(string termoPesquisa)
        {
            return await _context.Medicos
                    .Where(m => EF.Functions.Like(m.Nome, $"%{termoPesquisa}%") ||
                        EF.Functions.Like(m.Sobrenome, $"%{termoPesquisa}%") ||
                        EF.Functions.Like(m.Telefone, $"%{termoPesquisa}%") ||
                        EF.Functions.Like(m.CPF, $"%{termoPesquisa}%") ||
                        EF.Functions.Like(m.Endereco, $"%{termoPesquisa}%"))
                    .ToListAsync();
        }

        public async Task<List<Medico>> BuscarTodos()
        {
            return await _context.Medicos.ToListAsync();
        }

        public async Task<Medico> Cadastrar(Medico cadastrar)
        {
            await _context.Medicos.AddAsync(cadastrar);
            await _context.SaveChangesAsync();

            return cadastrar;
        }

        public async Task<bool> Delete(int id)
        {
            var pacienteDb = await BuscarPorId(id);
            _context.Medicos.Remove(pacienteDb);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Medico> Editar(Medico editar)
        {
            _context.Medicos.Update(editar);
            await _context.SaveChangesAsync();
            return editar;
        }
    }
}
