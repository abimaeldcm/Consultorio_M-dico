using Consultorio.Application.Email;
using Consultorio.Domain.Entity.Email;
using Consultorio.Infra.Data;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Consultorio.Application.Services.WorkService
{
    public class Worker : BackgroundService
    {
        private readonly ISeedEmail _seedEmail;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ISeedEmail seedEmail, IServiceProvider serviceProvider)
        {
            _seedEmail = seedEmail;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ConsultorioDbContext>();
                    var emailRepository = scope.ServiceProvider.GetRequiredService<ICRUDRepository<EmailEntity>>();
                    var consult = context.Consults
                        .Include(x => x.Patient)
                        .Include(x => x.Doctor)
                        .Include(x => x.Service)
                        .Where(x => x.Start <= DateTime.Now.AddDays(1) && x.Start >= DateTime.Now)
                        .AsNoTracking()
                        .ToList();

                    foreach (var item in consult)
                    {
                        //Seed E-mail
                        var emailDb = await emailRepository.FindById(1);
                        var emailSubject = emailDb.Title
                            .Replace("{{1}}", item.Service.Name);
                        var emailBody = emailDb.Body
                            .Replace("{{1}}", item.Patient.Name)
                            .Replace("{{2}}", item.Start.Date.ToString("dd/MM/yyyy"))
                            .Replace("{{3}}", item.Start.ToString("HH:mm"));

                        //var resultado = await _seedEmail.Seed(item.Patient.Email, emailSubject, emailBody);
                    }

                }
                await Task.Delay(86400000, stoppingToken);
            }
        }
    }

}
