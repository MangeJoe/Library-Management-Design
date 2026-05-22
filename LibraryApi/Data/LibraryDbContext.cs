using LibraryApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{
    public class LibraryDbContext:DbContext
    {
        //DbContext options contains configurations/settings for database
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        //each table has a list of entities
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Manager> Managers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Telling EF Core to use separate tables for these derived classes
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Librarian>().ToTable("Librarian");
            modelBuilder.Entity<Manager>().ToTable("Manager");

            //changing the column names for UserIDs to user_Id
            modelBuilder.Entity<Member>()
                .Property(m => m.UserID)
                .HasColumnName("user_Id");

            modelBuilder.Entity<Librarian>()
                .Property(l => l.UserID)
                .HasColumnName("user_Id");


            modelBuilder.Entity<Manager>()
                .Property(m => m.UserID)
                .HasColumnName("user_Id");
        }
    }
}
