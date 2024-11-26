using Microsoft.EntityFrameworkCore;
using Tril_3.Models;

namespace Tril_3.Data
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
