using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.Email;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Consultorio.Infra.Data
{
    public class ConsultorioDbContext : DbContext
    {
        public ConsultorioDbContext(DbContextOptions<ConsultorioDbContext> options) : base(options)
        {
        }

        public DbSet<Consult> Consults { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<EmailEntity> Emails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
