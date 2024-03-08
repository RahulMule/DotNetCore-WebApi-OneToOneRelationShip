using DotNetCore_WebApi_OneToOneRelationShip.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_WebApi_OneToOneRelationShip.Data
{
	public class EmployeeContext : DbContext
	{
		public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
		{
		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Passport> Passport { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.HasOne(e => e.Passport)
				.WithOne(p => p.Employee)
				.HasForeignKey<Passport>(p => p.EmployeeId)
				.IsRequired();
				
		}
	}
}
