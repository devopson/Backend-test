using Microsoft.EntityFrameworkCore;

namespace Backend_test.Models
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options){}

        public DbSet<Pessoa> Pessoas{get; set;}
    }
}