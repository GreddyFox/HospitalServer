using Microsoft.EntityFrameworkCore;

public class EducationContext : DbContext
    {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder); optionsBuilder.UseNpgsql(@"Host=localhost;Database=rksp1;Username=postgres;Password=bivt201")
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().Property(d => d.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Patient>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<MedicalFile>().Property(m => m.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Appointment>().Property(m => m.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Facility>().Property(m => m.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Appointment>().HasOne(f => f.AppDoc);
        modelBuilder.Entity<Appointment>().HasOne(f => f.AppPatient);
        modelBuilder.Entity<MedicalFile>().HasOne(f => f.Patient);


    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<MedicalFile> MedicalFiles { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Facility> Facilities { get; set; }



}

