using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apis.Models;
using Microsoft.EntityFrameworkCore;

namespace Apis.Data
{
    public class AppDbContext : DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

         public DbSet<Dica> Dicas { get; set; }
        public DbSet<PontoTuristico> PontosTuristicos { get; set; }
    }
}