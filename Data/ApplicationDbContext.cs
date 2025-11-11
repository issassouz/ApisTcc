using Microsoft.EntityFrameworkCore;
using Apis.Models;

namespace ApisTcc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Aqui você adiciona os DbSets de cada model
        public DbSet<Dica> Dicas { get; set; }
        public DbSet<PontoTuristico> PontosTuristicos { get; set; }

    }
}
