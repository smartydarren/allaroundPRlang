using Microsoft.EntityFrameworkCore;
using webapiLearn.Entities;

namespace webapiLearn.Data;

public class GamesStoreContext : DbContext
{
  public GamesStoreContext(DbContextOptions<GamesStoreContext> options) : base(options)
  {
  }

  public DbSet<Game> Games => Set<Game>();
  public DbSet<Genre> Genres => Set<Genre>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Genre>().HasData(
      new Genre { Id = 1, Name = "Shooter" },
      new Genre { Id = 2, Name = "RPG" },
      new Genre { Id = 3, Name = "Puzzle" },
      new Genre { Id = 4, Name = "Sports" },
      new Genre { Id = 5, Name = "Fighting" }
    );
  }
}