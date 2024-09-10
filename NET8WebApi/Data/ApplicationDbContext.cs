using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NET8WebApi.Models;

namespace NET8WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Share> Shares { get; set; }

        public  List<Share> GetSharesFromStoredProcedureWithParams(string st)
        {
            var param = new SqlParameter("@St", st ?? (object)DBNull.Value);
            return  Shares.FromSqlRaw("EXEC dbo.GetAllShares @St", param).ToList();
        }
    }
}
