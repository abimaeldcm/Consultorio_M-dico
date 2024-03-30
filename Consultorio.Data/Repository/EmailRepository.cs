using Consultorio.Domain.Entity.Email;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Repository
{
    public class EmailRepository : ICRUDRepository<EmailEntity>
    {

        private readonly ConsultorioDbContext _context;

        public EmailRepository(ConsultorioDbContext context)
        {
            _context = context;
        }

        public async Task<EmailEntity> Create(EmailEntity create)
        {
            await _context.Emails.AddAsync(create);
            await _context.SaveChangesAsync();
            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var emailDb = await FindById(id);
                _context.Emails.Remove(emailDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a deleção!");
            }
        }

        public async Task<EmailEntity> FindById(int id)
        {
            return await _context.Emails
                            .AsNoTracking()
                            .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<EmailEntity>> FindByText(string query)
        {
            return null;
        }

        public async Task<List<EmailEntity>> GetAll()
        {
            var emailDb = await _context.Emails.ToListAsync();
            await _context.SaveChangesAsync();
            return emailDb;
        }

        public async Task<EmailEntity> Update(EmailEntity update)
        {
            var emailDb = FindById(update.Id);
            if (emailDb != null)
            {
                _context.Emails.Update(update);
                await _context.SaveChangesAsync();
                return update;
            }
            return null;

        }
    }
}
