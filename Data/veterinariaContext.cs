using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Veterinaria.Models;

namespace veterinaria.Data
{
    public class veterinariaContext : DbContext
    {
        public veterinariaContext(DbContextOptions<veterinariaContext> options)
            : base(options)
        { }

        public DbSet<Mascota> Mascotas { get; set; }
    }
}
