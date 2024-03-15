using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class ServiceRepository : ICRUDRepository<ServiceEntity>
    {
        private readonly ConsultorioDbContext _context;

        public ServiceRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceEntity> BuscarPorId(int id)
        {
            var servicoDb = await _context.Servicos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (servicoDb is null)
            {
                throw new Exception("Id Não existe no banco de dados.");
            }
            return servicoDb;
        }

        public async Task<List<ServiceEntity>> BuscarPorTexto(string termoPesquisa)
        {
            return await _context.Servicos
                .Where(m => EF.Functions.Like(m.Nome, $"%{termoPesquisa}%") || EF.Functions.Like(m.Descricao, $"%{termoPesquisa}%"))
                .ToListAsync();
        }

        public async Task<List<ServiceEntity>> BuscarTodos()
        {
            return await _context.Servicos.ToListAsync();
        }

        public async Task<ServiceEntity> Cadastrar(ServiceEntity cadastrar)
        {
            await _context.Servicos.AddAsync(cadastrar);
            await _context.SaveChangesAsync();

            return cadastrar;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var servicoDb = await BuscarPorId(id);
                _context.Servicos.Remove(servicoDb);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ServiceEntity> Editar(ServiceEntity editar)
        {
            _context.Servicos.Update(editar);
            await _context.SaveChangesAsync();
            return editar;
        }
    }
}
