using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;

namespace veterinaria.Data
{
    public class veterinariaContext : IdentityDbContext
    {
        public veterinariaContext(DbContextOptions<veterinariaContext> options)
            : base(options)
        {
        }

        public DbSet<Mascota> Mascotas { get; set; }
    }
}
