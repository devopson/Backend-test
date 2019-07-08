using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra
{
    public class BackendContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public BackendContext() : base()
        { }

        public BackendContext(DbContextOptions<BackendContext> options) : base(options)
        { }
    }
}
