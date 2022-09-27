
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

/// <summary>
/// Class used to inject dbcontext from a separate class library
/// </summary>
public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepoContext>
{
    public RepoContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var builder = new DbContextOptionsBuilder<RepoContext>()
            .UseSqlServer(config
            .GetConnectionString("sqlConnection"),
            b => b.MigrationsAssembly("CardGame")
            );

        return new RepoContext(builder.Options);
    }
}
