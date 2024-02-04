using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Models;

namespace WebApplication3.ModelConfiguration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.ToTable(nameof(Employee));
		builder.HasKey(e => e.Id);
		builder.Property(e => e.Name).HasMaxLength(50);
		builder.Property(e => e.Email).HasMaxLength(50);
		//builder.Property(e => e.EmployeeId).HasMaxLength(5);
		//builder.Property(e => e.Salary);
		builder.Property(e => e.JobLocation).HasMaxLength(150);
	}
}
