using Microsoft.EntityFrameworkCore;
using Lab14.Models;

namespace Lab14.Data
{
    public class EduManagerContext : DbContext
    {
        public DbSet<MonHoc> MonHocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Chú ý đoạn Server=localhost\MSSQLSERVER03
                optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER03;Database=EduManagerDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}