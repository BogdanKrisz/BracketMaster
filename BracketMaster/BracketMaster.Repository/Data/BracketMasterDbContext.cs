using BracketMaster.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public class BracketMasterDbContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<BeerpongOvertimeType> BeerpongOvertimeTypes { get; set; }
        public DbSet<PreliminarySystem> PreliminarySystems { get; set; }
        public DbSet<KnockoutSystem> KnockoutSystems { get; set; }

        public DbSet<BeerpongPlayer> BeerpongPlayers { get; set; }
        public DbSet<BeerpongMatch> BeerpongMatches { get; set; }
        public DbSet<BeerpongTournament> BeerpongTournaments { get; set; }
        public DbSet<BeerpongGroup> BeerpongGroups { get; set; }

        public BracketMasterDbContext()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=BracketMasterDb;AttachDbFilename=P:\\Projects\\c#\\BracketMaster\\BracketMaster\\BracketMaster.Repository\\Database\\BracketMasterDb.mdf;Integrated Security=True;MultipleActiveResultSets=True")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TCP Mapping beállítása az osztályokra -> minden leszármazottnak saját táblája van
            modelBuilder.Entity<Tournament>().UseTpcMappingStrategy();
            modelBuilder.Entity<Player>().UseTpcMappingStrategy();


            // Owner
            modelBuilder.Entity<Owner>(entity => 
            {
                entity.ToTable("Owners");

                entity.Property(o => o.Username)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(o => o.PasswordHashed)
                    .IsRequired();

                entity.Property(o => o.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(24);

                entity.Property(o => o.PasswordIterationCount)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(o => o.Email)
                    .IsRequired();

                // owner -> refreshToken
                entity
                    .HasOne(o => o.RefreshToken)
                    .WithOne(rf => rf.Owner)
                    .HasForeignKey<RefreshToken>(rf => rf.OwnerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // owner -> tournament
                entity
                    .HasMany(o => o.Tournaments)
                    .WithOne(t => t.Owner)
                    .HasForeignKey(t => t.OwnerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // RefreshToken
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshTokens");

                entity.Property(r => r.Token)
                    .IsRequired();

                entity.Property(rt => rt.Expiration)
                    .IsRequired();
            });

            // Groups
            modelBuilder.Entity<Group>(entity =>
            {
                entity.UseTpcMappingStrategy();

                entity.Property(g => g.Name)
                    .IsRequired();

                entity.Property(g => g.TournamentId)
                    .IsRequired();

                // Group -> Players
                entity
                .HasMany(g => g.Players)
                .WithOne(p => p.Group)
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            });
                

            // Beerpong Groups
            modelBuilder.Entity<BeerpongGroup>(entity =>
            {
                entity.ToTable("BeerpongGroups");
            });


            // Match
            modelBuilder.Entity<Match>(entity =>
            {
                entity.UseTpcMappingStrategy();

                entity.Property(m => m.TournamentId)
                    .IsRequired();

                entity.Property(g => g.Round)
                    .IsRequired();

                entity.Property(g => g.HomeId)
                    .IsRequired();

                entity.Property(g => g.AwayId)
                    .IsRequired();

                // Match -> Group
                entity
                    .HasOne(m => m.Group)
                    .WithMany(g => g.Matches)
                    .HasForeignKey(m => m.GroupId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Match -> HomeMatches
                entity
                    .HasOne(m => m.Home)
                    .WithMany(p => p.HomeMatches)
                    .HasForeignKey(m => m.HomeId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Match -> AwayMathes
                entity
                    .HasOne(m => m.Away)
                    .WithMany(p => p.AwayMatches)
                    .HasForeignKey(m => m.AwayId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Match -> Winner
                entity
                    .HasOne(m => m.Winner)
                    .WithMany()
                    .HasForeignKey(m => m.WinnerId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            // Beerpong Matches
            modelBuilder.Entity<BeerpongMatch>(entity =>
            {
                entity.ToTable("BeerpongMatches");
            });

            // Tournament
            modelBuilder.Entity<Tournament>(entity =>
            {
                // Tournament -> Preliminary
                entity
                    .HasOne(t => t.PreliminarySystem)
                    .WithMany()
                    .HasForeignKey(t => t.PreliminarySystemId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Tournament -> Knockout
                entity
                    .HasOne(t => t.KnockoutSystem)
                    .WithMany()
                    .HasForeignKey(t => t.KnockoutSystemId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Tournament -> Matches
                entity
                    .HasMany(t => t.Matches)
                    .WithOne(m => m.Tournament)
                    .HasForeignKey(m => m.TournamentId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Tournament -> Players
                entity
                    .HasMany(t => t.Players)
                    .WithOne(p => p.Tournament)
                    .HasForeignKey(p => p.TournamentId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Tournament -> Groups
                entity
                    .HasMany(t => t.Groups)
                    .WithOne(g => g.Tournament)
                    .HasForeignKey(g => g.TournamentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Beerpong Tournament
            modelBuilder.Entity<BeerpongTournament>(entity =>
            {
                entity.ToTable("BeerpongTournaments");

                // Tournament -> BeerpongTournamentOvertimeType
                entity 
                    .HasOne(t => t.BeerpongOvertimeType)
                    .WithMany()
                    .HasForeignKey(t => t.BeerpongOvertimeTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            // Beerpong Overtime Type
            modelBuilder.Entity<BeerpongOvertimeType>(entity =>
            {
                entity.ToTable("BeerpongOvertimeTypes");

                entity.Property(k => k.Name)
                    .IsRequired();
            });

            // Preliminary System
            modelBuilder.Entity<PreliminarySystem>(entity =>
            {
                entity.ToTable("PreliminarySystems");

                entity.Property(k => k.Name)
                    .IsRequired();
            });

            // Knockout System
            modelBuilder.Entity<KnockoutSystem>(entity =>
            {
                entity.ToTable("KnockoutSystems");

                entity.Property(k => k.Name)
                    .IsRequired();
            });
        }
    }
}
