using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Shared.Entities;

namespace CDatos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Animals> Animals { get; set; } = null!;
        public DbSet<Attentions> Attentions { get; set; } = null!;
        public DbSet<Owners> Owners { get; set; } = null!;
        public DbSet<Shared.Entities.AnimalsDTO> AnimalsDTO { get; set; } = default!;
        public DbSet<Shared.Entities.AttentionsDTO> AttentionsDTO { get; set; } = default!;
        public DbSet<Shared.Entities.OwnersDTO> OwnersDTO { get; set; } = default!;

    }
}
