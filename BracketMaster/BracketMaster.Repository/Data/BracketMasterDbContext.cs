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
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        public BracketMasterDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=P:\\Projects\\c#\\BracketMaster\\BracketMaster\\BracketMaster.Repository\\Database\\BracketMasterDb.mdf;Integrated Security=True;MultipleActiveResultSets=True")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // kapcsolatok
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
            .WithMany(p => p.Matches)
            .HasForeignKey(m => m.HomeId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Match>(x => x
            .HasOne(m => m.Away)
            .WithMany(p => p.Matches)
            .HasForeignKey(m => m.AwayId)
            .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
