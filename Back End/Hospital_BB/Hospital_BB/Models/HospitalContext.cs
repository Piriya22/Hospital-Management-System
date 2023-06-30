using Microsoft.EntityFrameworkCore;

namespace Hospital_BB.Models
{
    public class HospitalContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Doctors> Doctors { get; set; }

        public DbSet<Patients> Patients { get; set; }   

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }
    }
}
