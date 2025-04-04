using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TpAPIRest_Controladores.Models.Entities;

namespace TpAPIRestControladores.Models.Entities;

public class VetContext : DbContext
{
    public VetContext(DbContextOptions<VetContext> options)
    : base(options)
    {
    }

    public DbSet<Animals> Animals { get; set; } = null!;
    public DbSet<Attentions> Attentions { get; set; } = null!;
    public DbSet<Owners> Owners { get; set; } = null!;

}