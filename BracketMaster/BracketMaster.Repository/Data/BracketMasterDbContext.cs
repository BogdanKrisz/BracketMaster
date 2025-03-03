﻿using BracketMaster.Models;
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
        public DbSet<BeerpongTournamentPlayer> BeerpongTournaments_BeerpongPlayers { get; set; }

        public DbSet<PreliminarySystem> PreliminarySystems { get; set; }
        public DbSet<KnockoutSystem> KnockoutSystems { get; set; }

        public DbSet<BeerpongPlayer> BeerpongPlayers { get; set; }
        public DbSet<BeerpongMatch> BeerpongMatches { get; set; }
        public DbSet<BeerpongTournament> BeerpongTournaments { get; set; }

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
            modelBuilder.Entity<Match>().UseTpcMappingStrategy();

            // kapcsolatok
            modelBuilder.Entity<Tournament>()
            .HasOne(t => t.KnockoutSystem)
            .WithMany()                         // Ha egy KnockoutSystem-et több torna is használhat
            .HasForeignKey(t => t.KnockoutSystemId)
            .OnDelete(DeleteBehavior.Restrict); // Ne törölje a KnockoutSystem-et, ha van rá hivatkozás

            modelBuilder.Entity<Tournament>()
            .HasOne(t => t.PreliminarySystem)
            .WithMany()                         
            .HasForeignKey(t => t.PreliminarySystemId)
            .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Tournament>(x => x
            .HasMany(t => t.Matches)
            .WithOne(m => m.Tournament)
            .HasForeignKey(m => m.TournamentId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Tournament>(x => x
            .HasMany(t => t.Players)
            .WithOne(p => p.Tournament)
            .HasForeignKey(p => p.TournamentId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Match>(x => x
            .HasOne(m => m.Home)
            .WithMany(p => p.HomeMatches)
            .HasForeignKey(m => m.HomeId)
            .OnDelete(DeleteBehavior.Restrict));

            modelBuilder.Entity<Match>(x => x
            .HasOne(m => m.Away)
            .WithMany(p => p.AwayMatches)
            .HasForeignKey(m => m.AwayId)
            .OnDelete(DeleteBehavior.Restrict));
        }
    }
}
