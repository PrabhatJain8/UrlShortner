using Microsoft.EntityFrameworkCore;

namespace UrlShortner
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options):base(options)
		{

		}
		public DbSet<UrlShort> UrlShorts { get; set; }
	}
}
