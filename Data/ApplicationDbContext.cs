using EmployeeManagement.Model.Entitties;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRole> EmployeesRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //create Employee , Role and EmployeeRole

            modelBuilder.Entity<EmployeeRole>()
                .HasIndex(er => new { er.EmployeeId, er.RoleId })  // prevent dunplicate entry
                .IsUnique();

            modelBuilder.Entity<EmployeeRole>()
                .HasOne(er => er.Employee)
                .WithMany(e => e.EmployeeRoles)
                .HasForeignKey(er => er.EmployeeId);

            modelBuilder.Entity<EmployeeRole>()
                .HasOne(er => er.Role)
                .WithMany(e => e.EmployeeRoles)
                .HasForeignKey(er => er.RoleId);
        }
    }
}
