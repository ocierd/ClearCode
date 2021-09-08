using System;
using Clear.CodeSample.Shared.Entities;
using Microsoft.EntityFrameworkCore;


namespace Clear.CodeSample.Persistence
{
    public class ClearContext : DbContext
    {
        private readonly string ConnectionString;

        public DbSet<Movie> Movie {get;set;}
        public DbSet<Category> Category {get;set;}

        public ClearContext()
        {
            ConnectionString = "Server=DESKFER;Database=ClearSampleDataBase;User ID=sa;Password=0704070488;Connection Timeout=30;pooling=true;max pool size=100;";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);


        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Movie>()
            .HasOne(m=>m.Category)
            .WithOne()
            .HasForeignKey<Movie>(m=>m.CategoryId);

            modelBuilder.Entity<Movie>()
            .HasOne(m=>m.Director)
            .WithOne()
            .HasForeignKey<Movie>(m=>m.DirectorId);
        }

            
    }
}
