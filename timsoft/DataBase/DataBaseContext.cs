using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using timsoft.entities;

namespace timsoft.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.EnableSensitiveDataLogging();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create default roles with migration
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    IdRole = 1,
                    RoleName = "Admin",

                },
                new Role()
                {
                    IdRole = 2,
                    RoleName = "RH",

                },
                 new Role()
                 {
                     IdRole = 3,
                     RoleName = "User",

                 }
                
            );
            modelBuilder.Entity<User>().HasMany<Invitation>(u => u.Invitations).WithOne(i => i.User);
           modelBuilder.Entity<Role>().HasMany<User>(r => r.Users).WithMany(u => u.Roles);
           modelBuilder.Entity<Type_Epreuve>().HasMany<Epreuve>(t => t.Epreuve).WithOne(e => e.Type_Epreuves);

           modelBuilder.Entity<UserEpreuve>().HasKey(ue => new { ue.IdUser, ue.IdEpreuve });
           modelBuilder.Entity<UserEpreuve>().HasOne<User>(ue => ue.User).WithMany(u => u.UserEpreuves);
           modelBuilder.Entity<UserEpreuve>().HasOne<Epreuve>(ue => ue.Epreuve).WithMany(e => e.UserEpreuves);
           
           modelBuilder.Entity<Reponse>().HasMany(R => R.Question).WithMany(R => R.Reponse).UsingEntity(j => j.ToTable("ReponseQuest"));

           modelBuilder.Entity<Epreuve>().HasMany(e => e.Question).WithMany(e => e.Epreuve).UsingEntity(j => j.ToTable("REpreuveQuest"));

           modelBuilder.Entity<User>().HasMany(u => u.Réclamation).WithMany(e => e.Users).UsingEntity(j => j.ToTable("UserReclam"));
        }

        public DbSet<Invitation> Invitation { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Epreuve> Epreuve { get; set; }
        public DbSet<Reponse> Reponse { get; set; }
        public DbSet<Réclamation> Réclamation { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Type_Epreuve> Type_Epreuve { get; set; }
        public DbSet<UserEpreuve> UserEpreuve { get; set;}






    }
}

