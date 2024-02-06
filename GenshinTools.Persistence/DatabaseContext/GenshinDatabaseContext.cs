using GenshinTools.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GenshinTools.Persistence.DatabaseContext; 
public class GenshinDatabaseContext : DbContext {
    public GenshinDatabaseContext(DbContextOptions<GenshinDatabaseContext> options) : base(options)
    {

    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<UserCharacter> UserCharacters { get; set; }
    public DbSet<UserWeapon> UserWeapons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenshinDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
