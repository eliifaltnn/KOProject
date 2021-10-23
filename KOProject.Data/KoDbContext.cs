using KOProject.Data.Entity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace KOProject.Data
{
    public class KoDbContext : DbContext
    {
        public KoDbContext(DbContextOptions<KoDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = @"C:\Code\KOProject\KOProject.Data\KoAppDatabase.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            
            optionsBuilder.UseSqlite(connection);
        }
    }
}
