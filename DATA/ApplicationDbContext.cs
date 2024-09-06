using Backend_Developer_test.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Developer_test.DATA
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // การกำหนดความสัมพันธ์ระหว่าง Order และ OrderItem
            modelBuilder.Entity<Employee>().ToTable("EmployeeTable");
            //modelBuilder.Entity<Postmarker>().HasKey(m => m.Id);
            modelBuilder.Entity<Employee>().HasKey(m => m.EmpNo);
            modelBuilder.Entity<Employee>().Property(m => m.FirstName).IsRequired();
            modelBuilder.Entity<Employee>().Property(m => m.LastName).IsRequired();
            modelBuilder.Entity<Employee>().Property(m => m.Designation).IsRequired();
            modelBuilder.Entity<Employee>().Property(m => m.HireDate).IsRequired();
            modelBuilder.Entity<Employee>().Property(m => m.Salary).HasColumnType("float").IsRequired(); // Ensure the type matches the DB
            modelBuilder.Entity<Employee>().Property(m => m.Comm);
            modelBuilder.Entity<Employee>().Property(m => m.DeptNo).IsRequired(); 
        }
    }
}
