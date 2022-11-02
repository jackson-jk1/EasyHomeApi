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
        public DbSet<UserPreferenceModel> UserPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>(new UserMap().Configure);
            modelBuilder.Entity<ImmobileModel>(new ImmobileMap().Configure);
            modelBuilder.Entity<UserPreferenceModel>(new UserPreferenceMap().Configure);
        }
    }
}
