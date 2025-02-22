using Microsoft.EntityFrameworkCore;
using TechLibrary.Api.Domain.Entities;

namespace TechLibrary.Api.Infraestructure.DataAccess;

public class TechLibraryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    private readonly string connectionString = "Data Source=C:\\Users\\cimol\\source\\TechLibraryDb.db";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString);
    }
}
