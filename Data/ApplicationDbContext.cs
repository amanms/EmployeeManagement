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
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }


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

            modelBuilder.Entity<Employee>()
                .Property(e=>e.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false);

            modelBuilder.Entity<EmployeeRole>()
                .Property(e => e.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false);

            modelBuilder.Entity<EmployeeDepartment>()
                .HasIndex(ed=> new {ed.EmployeeId,ed.DepartmentId})
                .IsUnique();

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne(ed=>ed.Employee)
                .WithMany(e=>e.EmployeeDepartments)
                .HasForeignKey(ed=>ed.EmployeeId);

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne(ed => ed.Department)
                .WithMany(d => d.EmployeeDepartments)
                .HasForeignKey(ed => ed.DepartmentId);

            modelBuilder.Entity<EmployeeDepartment>()
                .Property(ed => ed.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Department>()
                .Property(ed => ed.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
