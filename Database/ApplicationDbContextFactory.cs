using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using l4.Data;

namespace l5.Database
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<DbConnection>
    {
        public DbConnection CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbConnection>();
            optionsBuilder.UseSqlServer("Server=127.0.0.1\\SQLSERVER2022;Database=Library2;User id=sa; Password=12345; TrustServerCertificate=true;");

            return new DbConnection(optionsBuilder.Options);
        }
    }
}
