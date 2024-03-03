using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class PacienteRepository : ICRUD<Paciente>
    {
        private readonly ConsultorioDbContext _context;

        public PacienteRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente> BuscarPorId(int id)
        {
            return await _context.Pacientes.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Paciente>> BuscarPorTexto(string termoPesquisa)
        {
            return await _context.Pacientes
                            .Where(m => EF.Functions.Like(m.Nome, $"%{termoPesquisa}%") || 
                                EF.Functions.Like(m.Sobrenome, $"%{termoPesquisa}%") || 
                                EF.Functions.Like(m.Telefone, $"%{termoPesquisa}%") ||
                                EF.Functions.Like(m.CPF, $"%{termoPesquisa}%") ||
                                EF.Functions.Like(m.Endereco, $"%{termoPesquisa}%")) 
                            .ToListAsync();
        }

        public async Task<List<Paciente>> BuscarTodos()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> Cadastrar(Paciente cadastrar)
        {
            await _context.Pacientes.AddAsync(cadastrar);
            await _context.SaveChangesAsync();

            return cadastrar;
        }

        public async Task<bool> Delete(int id)
        {
            var pacienteDb = await BuscarPorId(id);
            _context.Pacientes.Remove(pacienteDb);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Paciente> Editar(Paciente editar)
        {
            _context.Pacientes.Update(editar);
            await _context.SaveChangesAsync();
            return editar;
        }
    }
}
