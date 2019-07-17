using Microsoft.EntityFrameworkCore;

namespace AgendaWebApi.Models
{
    public class AgendaDetailContext : DbContext
    {
        public AgendaDetailContext(DbContextOptions<AgendaDetailContext> options) : base(options)
        {

        }

        public DbSet<AgendaDetail> AgendaDetails { get; set; }
    }
}
