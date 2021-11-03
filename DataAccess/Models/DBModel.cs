using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DataAccess.Models
{
    public partial class DbModel : DbContext
    {
        public DbModel()
        {
        }

        public DbModel(DbContextOptions<DbModel> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BotHistory> BotHistories { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BankUrl)
                    .HasMaxLength(500)
                    .HasColumnName("BankURL");
            });

            modelBuilder.Entity<BotHistory>(entity =>
            {
                entity.ToTable("BotHistory");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_Currencies_1");

                entity.Property(e => e.Code).HasMaxLength(3);
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasIndex(e => e.FromCurrency, "IX_Rates_FromCurrency");

                entity.HasIndex(e => e.ToCurrency, "IX_Rates_ToCurrency");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuyValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FromCurrency)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.SellValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ToCurrency)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rates_Banks");

                entity.HasOne(d => d.FromCurrencyNavigation)
                    .WithMany(p => p.RateFromCurrencyNavigations)
                    .HasForeignKey(d => d.FromCurrency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rates_Currencies");

                entity.HasOne(d => d.ToCurrencyNavigation)
                    .WithMany(p => p.RateToCurrencyNavigations)
                    .HasForeignKey(d => d.ToCurrency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rates_Currencies1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
