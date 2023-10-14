using BandsWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BandsWebAPI.DbContexts
{
    public class BandsContext : DbContext
    {
        public DbSet<Band> Bands { get; set; } 
        public DbSet<Album> Albums { get; set; } 
        public DbSet<Description> Descriptions { get; set; } 
        public DbSet<Musician> Musicians { get; set; } 
        //public DbSet<MusicianBands> MusicianBands { get; set; }
        public BandsContext(DbContextOptions<BandsContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Musician>().HasData(
            //     new Musician
            //     {
            //         MusicianId = 1,
            //         Name = "Maynard James Keenan",
            //         Role = "Vocal",
            //     },
            //     new Musician
            //     {
            //         MusicianId = 2,
            //         Name = "Mark Barney Greenway",
            //         Role = "Vocal",
            //     }
            //     );

            //modelBuilder.Entity<MusicianBands>().HasData(
            //     new MusicianBands { MusicianBandsId = 1, BandId = 1, MusicianId = 1 },
            //     new MusicianBands { MusicianBandsId = 2, BandId = 2, MusicianId = 2 }
            //    );

            //modelBuilder.Entity<Band>().HasData(
            //    new Band { BandId = 1, Name = "Tool", DateOfFoundation = 1990, IsActive = false },
            //    new Band { BandId = 2, Name = "Napalm Death", DateOfFoundation = 1981, IsActive = false });

            //modelBuilder.Entity<Album>().HasData(
            //    new Album { AlbumId = 1, Title = "Opiate", DateOfRelease = 1992, BandId = 1 },
            //    new Album { AlbumId = 2, Title = "Harmony Corruption", DateOfRelease = 1990, BandId = 2 });

            //modelBuilder.Entity<Description>().HasData(
            //    new Description { BandId = 1, Genres = "Alternative metal", DescriptionId = 1 },
            //     new Description { BandId = 2, Genres = "Death metal", DescriptionId = 2 }
            //     );

            base.OnModelCreating(modelBuilder);
        }
    }
}

