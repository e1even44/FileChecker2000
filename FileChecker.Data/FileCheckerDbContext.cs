using FileChecker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileChecker.Data
{
    public class FileCheckerDbContext : DbContext
    {
        public DbSet<AppFile> AppFiles { get; set; }
        public DbSet<Scan> Scans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection string from visual studio integrated SQL Server => Initial Catalog = name of database
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FileCheckerDB;Integrated Security=True;Trust Server Certificate=False");
        }
    }
}
