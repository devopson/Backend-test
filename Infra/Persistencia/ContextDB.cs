using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Persistencia
{
    public class ContextDB : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public ContextDB() : base()
        {
        }

        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }
    }
}
