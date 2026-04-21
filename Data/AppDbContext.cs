using Microsoft.EntityFrameworkCore;
using Sprintra.Models;

namespace Sprintra.Data {
  internal class AppDbContext : DbContext {
    // Ovde definišeš tabele
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlServer(@"Server=DESKTOP-RUAM7G4\SQLEXPRESS;Database=Sprintra;Trusted_Connection=True;TrustServerCertificate=True;",
          x => x.MigrationsAssembly("Sprintra")
                .MigrationsHistoryTable("__EFMigrationsHistory", "system")
      );
    }
  }
}
