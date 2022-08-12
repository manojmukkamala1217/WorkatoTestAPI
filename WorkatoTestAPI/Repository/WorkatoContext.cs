using Microsoft.EntityFrameworkCore;
using WorkatoTestAPI.Entites;

namespace WorkatoTestAPI.Repository
{
    public class WorkatoContext : DbContext
    {
        public  WorkatoContext(DbContextOptions<WorkatoContext> options)
        : base(options)
        {

        }
        public DbSet<Seller>? Sellers { get; set; }
    }
}
