using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ballicon.API.Models
{
    public partial class BrightersContext : DbContext
    {
        public BrightersContext()
        {
        }

        public BrightersContext(DbContextOptions<BrightersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CleanerAvailability> CleanerAvailability { get; set; }
        public virtual DbSet<Cleaners> Cleaners { get; set; }
        public virtual DbSet<OrderDaysBooked> OrderDaysBooked { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-48BVHD5\\SQLEXPRESS;Database=Brighters;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CleanerAvailability>(entity =>
            {
                entity.Property(e => e.AvailableFrom).HasColumnType("datetime");

                entity.Property(e => e.AvailableTo).HasColumnType("datetime");

                entity.Property(e => e.Day)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cleaner)
                    .WithMany(p => p.CleanerAvailability)
                    .HasForeignKey(d => d.CleanerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CleanerAv__Clean__1F98B2C1");
            });

            modelBuilder.Entity<Cleaners>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cleaners)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cleaners__UserId__1CBC4616");
            });

            modelBuilder.Entity<OrderDaysBooked>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Day)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Cleaner)
                    .WithMany(p => p.OrderDaysBooked)
                    .HasForeignKey(d => d.CleanerId)
                    .HasConstraintName("FK__OrderDays__Clean__2739D489");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDaysBooked)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDays__Order__2645B050");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Days)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cleaner)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CleanerId)
                    .HasConstraintName("FK__Orders__CleanerI__236943A5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserId__22751F6C");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.KnownAs)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).HasMaxLength(1);

                entity.Property(e => e.PasswordSalt).HasMaxLength(1);
            });
        }
    }
}
