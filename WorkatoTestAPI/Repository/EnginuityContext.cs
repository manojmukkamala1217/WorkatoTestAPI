using Microsoft.EntityFrameworkCore;
using WorkatoTestAPI.Entites;

namespace WorkatoTestAPI.Repository
{
    public class EnginuityContext : DbContext
    {
        public EnginuityContext(DbContextOptions<EnginuityContext> options)
        : base(options)
        {

        }
        public DbSet<Seller>? Sellers { get; set; }
    }
}
