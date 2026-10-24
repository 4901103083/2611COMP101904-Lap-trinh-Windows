using Microsoft.Data.SqlClient;

namespace Lab12.DAL
{
    public class Database
    {
        // Dựa vào ảnh SSMS bạn gửi lúc nãy, tên Server của bạn là localhost\MSSQLSERVER03
        public static string ConnectionString = @"Server=localhost\MSSQLSERVER03;Database=QLSinhVienLab12;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}