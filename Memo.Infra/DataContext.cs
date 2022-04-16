using Memo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Memo.Infra;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
        modelBuilder.Entity<User>()
                    .Property(e => e.Id)
                    .HasDefaultValueSql("gen_random_uuid()");
    }

    public DbSet<User> Users { get; set; }
}
