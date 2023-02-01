using Hermes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Database
{
    public class HermesContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public HermesContext(DbContextOptions<HermesContext> options)
            : base(options)
        {
        }

    }
}