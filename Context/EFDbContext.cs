using DocPatient.Models.DBModel;
using Microsoft.EntityFrameworkCore;

namespace DocPatient.Context
{
    public class EFDbContext : DbContext
    {
        const string connectionString = "Server=127.0.0.1; User ID=root; Password=; Database=docpatient";
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }

        public DbSet<DocDetail> DocDetail { get; set; }

        public DbSet<DocPatients> DocPatients { get; set; }

        public DbSet<PatientDetail> PatientDetails { get; set; }

        public DbSet<PatientAllergies> PatientAllergies { get; set; }

        public DbSet<PatientMedications> PatientMedications { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
