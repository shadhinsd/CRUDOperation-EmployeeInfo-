using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Models;

namespace WebApplication3.ModelConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
	public void Configure(EntityTypeBuilder<Student> builder)
	{
		builder.ToTable(nameof(Student));
		builder.HasKey(x => x.Id);
		builder.Property(x=>x.Name).HasMaxLength(50);
		builder.Property(x=>x.Address).HasMaxLength(100);
		builder.Property(x=>x.Post).HasMaxLength(20);
		builder.Property(x=>x.Email).HasMaxLength(50);
		builder.Property(x=>x.Phone).HasMaxLength(20);
		builder.HasData(new Student 
		{ Id = 1, 
          Name="Juwel",
		  Address="Dinajpur",
		  Post="Internship",
		  Email="juwel@gmail.com",
		  Phone="01745264776"
		}
		);
	}
}
