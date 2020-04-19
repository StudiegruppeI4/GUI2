using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<RoomCheckedIn> RoomsCheckedIn { get; set; }
        public DbSet<Breakfast> Breakfasts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breakfast>()
                .HasData(
                    new Breakfast()
                    {
                        Id = 1,
                        Date = DateTime.Today,
                        Adults = 6,
                        Children = 10
                    }
                );

            modelBuilder.Entity<RoomCheckedIn>()
                .HasData(
                    new RoomCheckedIn()
                    {
                        Id = 1,
                        Date = DateTime.Today,
                        RoomNumber = 1,
                        Adults = 2,
                        Children = 2
                    },
                    new RoomCheckedIn()
                    {
                        Id = 2,
                        Date = DateTime.Today,
                        RoomNumber = 2,
                        Adults = 2,
                        Children = 4
                    },
                    new RoomCheckedIn()
                    {
                        Id = 3,
                        Date = DateTime.Today,
                        RoomNumber = 3,
                        Adults = 2,
                        Children = 4
                    }
                );
        }
    }
}
