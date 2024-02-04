using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Models;

namespace WebApplication3.DatabaseContext;

public class ApplicationContext : DbContext
{

    public ApplicationContext(DbContextOptions<ApplicationContext> emp):base(emp)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
	}
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}
}
