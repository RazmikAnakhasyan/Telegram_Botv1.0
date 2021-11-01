using Microsoft.EntityFrameworkCore;
using Shared.Models.Banks;
using Shared.Models.Currency;
using Shared.Models.Rates;
using Shared.Models.BotHistory;

namespace CodeFirst.Models
{
    public class DBModel:DbContext
    {
        public DBModel()
        {

        }
        public DBModel(DbContextOptions<DBModel> options)
           : base(options)
        {
        }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Rates> Rates { get; set; }
        public DbSet<ModelBanks> Banks { get; set; }
        public DbSet<BotHistoryModel> BotHistory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Currency>
                (_ => { 
                    _.Property(_c => _c.ID).IsRequired().ValueGeneratedOnAdd();
                    _.Property(_c => _c.Code).IsRequired().HasMaxLength(3);
                    _.Property(_c => _c.Code).HasMaxLength(50);
                }) ;
            modelBuilder.Entity<Currency>().HasKey(_ => _.ID);

            modelBuilder.Entity < ModelBanks>
             (_ => {
                 _.Property(_b => _b.ID).IsRequired().ValueGeneratedOnAdd();
                 _.Property(_b => _b.BankName).IsRequired().HasMaxLength(50);
                 _.Property(_b => _b.BankURL).HasMaxLength(500);
             });
            modelBuilder.Entity<ModelBanks>().HasKey(_ => _.ID);


            foreach (var prop in typeof(Rates).GetProperties())
            {
                modelBuilder
                    .Entity<Rates>()
                    .Property(prop.Name)
                    .IsRequired();
            }
            modelBuilder.Entity<Rates>
                (_ => {
                    _.Property(_r => _r.ID).ValueGeneratedOnAdd();
                    _.Property(_r => _r.FromCurrency).HasMaxLength(3);
                    _.Property(_r => _r.ToCurrency).HasMaxLength(3);
                    _.Property(_r => _r.LastUpdated).HasColumnType("datetime2");
                });

            modelBuilder.Entity<Rates>().HasKey(_ => _.ID);
            modelBuilder.Entity<Rates>().HasIndex(_ => _.FromCurrency);
            modelBuilder.Entity<Rates>().HasIndex(_ => _.ToCurrency);

            //modelBuilder.Entity<Bank>().HasMany(_ => _.Rates)
            //    .WithOne(_ => _.Bank);

            //modelBuilder.Entity<Rate>().HasOne(_ => _.FromCurrency);
            //modelBuilder.Entity<Rate>().HasOne(_ => _.ToCurrency);


            modelBuilder.Entity<BotHistoryModel>
            (_ => {
                _.Property(_b => _b.ID).IsRequired().ValueGeneratedOnAdd();
                _.Property(_b => _b.Date).IsRequired().HasColumnType("datetime2");

            });
            modelBuilder.Entity<BotHistoryModel>().HasKey(_ => _.ID);
        }
    }
}
