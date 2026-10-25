using Microsoft.EntityFrameworkCore;

namespace Lab15.Models
{
    public class EduManagerContext : DbContext
    {
        public DbSet<MonHoc> MonHocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Chuỗi kết nối đúng với server của bạn
                optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER03;Database=EduManagerDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}