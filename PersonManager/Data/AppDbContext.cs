using Microsoft.EntityFrameworkCore;
using PersonManager.Models;

namespace PersonManager.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
		{

		}

		public DbSet<Person> People	{ get; set; }
	}
}
