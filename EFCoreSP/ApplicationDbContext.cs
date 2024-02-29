using EFCoreSP.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSP
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
