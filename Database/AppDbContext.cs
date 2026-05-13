using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Entities;
using HealthcareAPI.Database;

namespace HealthcareAPI.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
    }
}
