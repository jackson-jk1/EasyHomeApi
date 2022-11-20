using Data.Mapping;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ImmobileModel> Immobiles { get ; set; }
        public DbSet<PoloModel> Polos { get; set; }
        public DbSet<BairroModel> Bairros { get; set; }
        public DbSet<BairrosPoloModel> BairrosPolo { get; set; }
        public DbSet<UserPreferenceModel> UserPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>(new UserMap().Configure);
            modelBuilder.Entity<ImmobileModel>(new ImmobileMap().Configure);
            modelBuilder.Entity<UserPreferenceModel>(new UserPreferenceMap().Configure);
            modelBuilder.Entity<BairroModel>(new BairroMap().Configure);
            modelBuilder.Entity<PoloModel>(new PoloMap().Configure);
            modelBuilder.Entity<BairrosPoloModel>(new BairrosPoloMap().Configure);
        }
    }
}
