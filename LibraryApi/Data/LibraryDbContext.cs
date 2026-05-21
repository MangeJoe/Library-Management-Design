using LibraryApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions options):base(options)
        {

        }

        //each table has a list of entities
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Manager> Manager { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Librarian>().ToTable("Librarian");
            modelBuilder.Entity<Manager>().ToTable("Manager");

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
