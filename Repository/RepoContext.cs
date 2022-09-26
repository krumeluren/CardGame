using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Config;

namespace Repository;

public class RepoContext : DbContext
{
    public RepoContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CardConfig());
    }
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardHistory> CardHistories { get; set; }
    public DbSet<Player> Players { get; set; }
}
