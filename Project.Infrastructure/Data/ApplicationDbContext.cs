using Microsoft.EntityFrameworkCore;
using Project.Application.Data;
using Project.Domain.Models;

namespace Project.Infrastructure.Data;

public class ApplicationDbContext : DbContext , IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<ShowTime> ShowTimes { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        EntityConfigurations(modelBuilder);

        Seeding(modelBuilder);
    }

    private static void EntityConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(r => r.Id); // Primary Key
            entity.Property(r => r.Name).IsRequired().HasMaxLength(255); // Required and Max Length

            entity.HasMany(r => r.ShowTimes)
                .WithOne(st => st.Room)
                .HasForeignKey(st => st.RoomId)
                .OnDelete(DeleteBehavior.Restrict); // Disable Cascade Delete

            entity.HasMany(r => r.Seats)
                .WithOne(s => s.Room)
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.Restrict); // Disable Cascade Delete
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(m => m.Id); // Primary Key
            entity.Property(m => m.Title).IsRequired().HasMaxLength(255); // Required and Max Length
            entity.Property(m => m.PosterUrl).IsRequired().HasMaxLength(500); // Required and Max Length

            entity.HasMany(m => m.ShowTimes)
                .WithOne(st => st.Movie)
                .HasForeignKey(st => st.MovieId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade Delete
        });

        modelBuilder.Entity<ShowTime>(entity =>
        {
            entity.HasKey(st => st.Id); // Primary Key
            entity.Property(st => st.StartTime).IsRequired(); // Required
            entity.Property(st => st.EndTime).IsRequired(); // Required

            entity.HasOne(st => st.Movie)
                .WithMany(m => m.ShowTimes)
                .HasForeignKey(st => st.MovieId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade Delete

            entity.HasOne(st => st.Room)
                .WithMany(r => r.ShowTimes)
                .HasForeignKey(st => st.RoomId)
                .OnDelete(DeleteBehavior.Restrict); // Disable Cascade Delete
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(s => s.Id); // Primary Key
            entity.Property(s => s.Row).IsRequired(); // Required
            entity.Property(s => s.Number).IsRequired(); // Required
            entity.Property(s => s.IsBooked).HasDefaultValue(false); // Default Value

            entity.HasOne(s => s.Room)
                .WithMany(r => r.Seats)
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.Restrict); // Disable Cascade Delete
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(b => b.Id); // Primary Key
            entity.Property(b => b.UserId).IsRequired(); // Required
            entity.Property(b => b.BookedAt).HasDefaultValueSql("GETUTCDATE()"); // Default Value

            entity.HasOne(b => b.ShowTime)
                .WithMany()
                .HasForeignKey(b => b.ShowTimeId)
                .OnDelete(DeleteBehavior.Restrict); // Disable Cascade Delete

            entity.HasOne(b => b.Seat)
                .WithMany()
                .HasForeignKey(b => b.SeatId)
                .OnDelete(DeleteBehavior.Restrict); // Disable Cascade Delete
        });
    }

    private static void Seeding(ModelBuilder modelBuilder)
    {
        var room1 = new Room { Id = 1, Name = "Orange Room" };
        var room2 = new Room { Id = 2, Name = "Blue Room" };
        var room3 = new Room { Id = 3, Name = "Red Room" };
        var movie1 = new Movie { Id = 1, Title = "La La Land", PosterUrl = "https://movie.com/Lalaland.jpg" };
        var movie2 = new Movie { Id = 2, Title = "Inception", PosterUrl = "https://movie.com/Inception.jpg" };
        var movie3 = new Movie { Id = 3, Title = "Titanic", PosterUrl = "https://movie.com/Titanic.jpg" };
        var showtime1 = new ShowTime
        {
            Id = 1,
            MovieId = 1,
            RoomId = 1,
            StartTime = DateTime.UtcNow.AddHours(2),
            EndTime = DateTime.UtcNow.AddHours(4)
        };

        var showtime2 = new ShowTime
        {
            Id = 2,
            MovieId = 2,
            RoomId = 2,
            StartTime = DateTime.UtcNow.AddHours(3),
            EndTime = DateTime.UtcNow.AddHours(5)
        };

        var showtime3 = new ShowTime
        {
            Id = 3,
            MovieId = 3,
            RoomId = 3,
            StartTime = DateTime.UtcNow.AddHours(4),
            EndTime = DateTime.UtcNow.AddHours(6)
        };

        List<Seat> seats = new();
        int rows = 10;
        int seatsPerRow = 8;
        int globalSeatId = 1;

        foreach (var room in new[] { room1, room2, room3 })
        {
            var id = 1;
            for (int r = 1; r <= rows; r++)
            {
                for (int s = 1; s <= seatsPerRow; s++)
                {
                    seats.Add(new Seat
                    {
                        Id = globalSeatId++,
                        Row = r,
                        Number = s,
                        RoomId = room.Id,

                        IsBooked = false // Default state
                    });
                }
            }
        }

        modelBuilder.Entity<Room>().HasData(room1, room2, room3);
        modelBuilder.Entity<Movie>().HasData(movie1, movie2, movie3);
        modelBuilder.Entity<ShowTime>().HasData(showtime1, showtime2, showtime3);
        modelBuilder.Entity<Seat>().HasData(seats);
    }
}