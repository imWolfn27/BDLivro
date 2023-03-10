using BDLivro.Models;
using DryIoc.ImTools;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;

namespace BDLivro.Data
{
    public class LivrosContexto : DbContext
    {
        public LivrosContexto(DbContextOptions<LivrosContexto>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livros>().HasIndex(b => b.isbn).IsUnique();
            modelBuilder.Entity<Livros>().HasOne(b => b.Autor).WithMany(b => b.Livros).HasForeignKey(b => b.AutorId);
            modelBuilder.Entity<Autor>().HasIndex(b => b.Id).IsUnique();
            //    modelBuilder.Entity<Livros>().Property<bool>("Apagado");
            //    modelBuilder.Entity<Livros>().HasQueryFilter(a => EF.Property<bool>(a, "Apagado") == false);

        }
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Autor> Autor { get; set; }
    }
}
