using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Gotcha.Models
{
    public partial class GotchaData : DbContext
    {
        public GotchaData()
            : base("name=GotchaData")
        {
        }

        public virtual DbSet<accountType> accountTypes { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Spel> Spels { get; set; }
        public virtual DbSet<Speler> Spelers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<accountType>()
                .Property(e => e.accountname)
                .IsUnicode(false);

            modelBuilder.Entity<Contract>()
                .Property(e => e.alias)
                .IsUnicode(false);

            modelBuilder.Entity<Spel>()
                .Property(e => e.gameName)
                .IsUnicode(false);

            modelBuilder.Entity<Spel>()
                .Property(e => e.safeZone)
                .IsUnicode(false);

            modelBuilder.Entity<Spel>()
                .HasMany(e => e.Spelers)
                .WithMany(e => e.Spels)
                .Map(m => m.ToTable("SpelersSpel").MapLeftKey("gameID").MapRightKey("playerID"));

            modelBuilder.Entity<Speler>()
                .Property(e => e.accountType)
                .IsUnicode(false);

            modelBuilder.Entity<Speler>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Speler>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Speler>()
                .Property(e => e.alias)
                .IsUnicode(false);

            modelBuilder.Entity<Speler>()
                .Property(e => e.schoolClass)
                .IsUnicode(false);
        }
    }
}
