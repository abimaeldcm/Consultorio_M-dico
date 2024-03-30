using Consultorio.Application.Email;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data;

public class Worker : BackgroundService
{
    private readonly ISeedEmail _seedEmail;
    private readonly IServiceProvider _serviceProvider;

    public Worker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _seedEmail = serviceProvider.GetRequiredService<ISeedEmail>();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ConsultorioDbContext>();
                var consult = context.Consults.Where(x => x.Start == DateTime.Now.AddDays(1));
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
