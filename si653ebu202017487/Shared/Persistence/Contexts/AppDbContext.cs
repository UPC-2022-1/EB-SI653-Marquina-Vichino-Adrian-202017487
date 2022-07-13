using Microsoft.EntityFrameworkCore;

using si653ebu202017487.API.MagnetArt.Painting.Domain.Models;
using si653ebu202017487.API.MagnetArt.Training.Domain.Models;
using si653ebu202017487.API.Shared.Extensions;

namespace si653ebu202017487.API.Shared.Persistence.Contexts;
public class AppDbContext : DbContext {

	public DbSet<Author> Authors { get; set; }
	public DbSet<Provider> Providers { get; set; }

	public AppDbContext(DbContextOptions options) : base(options) {
	}


	protected override void OnModelCreating(ModelBuilder builder) {
		base.OnModelCreating(builder);

		builder.Entity<Author>().ToTable("Authors");
		builder.Entity<Author>().HasKey(p => p.Id);
		builder.Entity<Author>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
		builder.Entity<Author>().Property(p => p.firstName).IsRequired();
		builder.Entity<Author>().Property(p => p.lastName).IsRequired();
		builder.Entity<Author>().Property(p => p.nickname).IsRequired();
		builder.Entity<Author>().Property(p => p.photoUrl);		

		builder.Entity<Provider>().ToTable("Providers");
		builder.Entity<Provider>().HasKey(p => p.Id);
		builder.Entity<Provider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
		builder.Entity<Provider>().Property(p => p.name).IsRequired();
		builder.Entity<Provider>().Property(p => p.apiUrl);
		builder.Entity<Provider>().Property(p => p.keyRequired).HasDefaultValue(false);
		builder.Entity<Provider>().Property(p => p.apiKey);

		builder.UseSnakeCaseNamingConvention();
	}
}