using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MonsterClickerAPI.Enumfolder;
using System.Diagnostics;
using System.Net.Sockets;
using MonsterClickerAPI.Models;
using System.Reflection.Emit;

namespace MonsterClickerAPI.Data
{
    public class DataContext: IdentityUserContext<AppUser>
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_connectionString);


            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Seeder seed = new Seeder();


            builder.Entity<UserStats>().Navigation(x => x.User).AutoInclude();

            builder.Entity<PlayerStats>().Navigation(x => x.User).AutoInclude();

            builder.Entity<PlayerInventory>().Navigation(x => x.PlayerStats).AutoInclude();
            builder.Entity<PlayerInventory>().Navigation(x => x.Item).AutoInclude();

            builder.Entity<MonsterItemTable>().Navigation(x => x.Monster).AutoInclude();
            builder.Entity<MonsterItemTable>().Navigation(x => x.Item).AutoInclude();


            builder.Entity<Item>().HasData(seed.Items);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<MonsterItemTable> MonsterItemTable { get; set; }
        public DbSet<MonsterStats> MonsterStats { get; set; }
        public DbSet<PlayerInventory> PlayerInventories { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; }
        public DbSet<User> UsersTemp { get; set; }
        public DbSet<UserStats> UserStats { get; set; }
    }
}
