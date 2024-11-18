using FetchAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<EmployeeData> EmployeeDatas { get; set; }
    public DbSet<ApplicationFormModel> Applications { get; set; }

    public DbSet<Intern>Interns { get; set; }
    public DbSet<Fresher> Freshers { get; set; }
    public DbSet<Experience> Experiencer { get; set; }

}
