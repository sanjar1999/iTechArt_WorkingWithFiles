using DAL.Models;
using Microsoft.EntityFrameworkCore;
#pragma warning disable

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext( DbContextOptions<ApplicationContext> options ) : base( options ) { }

        public ApplicationContext() { }

        public DbSet<Excel> Excel { get; set; }
        public DbSet<CSV> CSV { get; set; }
    }
}
