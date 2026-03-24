using Microsoft.EntityFrameworkCore;
using MyBookCollection.Data.Entities;

namespace MyBookCollection.Data.Contexts;

public class DataContext : DbContext
{
    private readonly string? _dbPath;
    public DbSet<BookEntity> Books { get; set; }

    public DataContext(string dbPath)
    {
        _dbPath = dbPath;
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!string.IsNullOrEmpty(_dbPath))
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }
    }
}
