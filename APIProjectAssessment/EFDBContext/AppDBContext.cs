using APIProjectAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProjectAssessment.EFDBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDBContext()
        {
        }

        public DbSet<DataDetailModel> dataDetails { get; set; }

    }
}
