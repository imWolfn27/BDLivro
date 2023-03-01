using BDLivro.Models;
using Microsoft.EntityFrameworkCore;

namespace BDLivro.Data
{
    public class LivrosContexto : DbContext
    {
        public DbSet<Livros> Livros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LENOVOESTAGIO\SQLEXPRESS;Initial Catalog=BDLivro;Integrated Security=True;
            Connect Timeout=30;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livros>().HasIndex(b => b.isbn).IsUnique();
            modelBuilder.Entity<Livros>().Property<bool>("Apagado");
            modelBuilder.Entity<Livros>().HasQueryFilter(a => EF.Property<bool>(a, "Apagado") == false);

        }
    }
}
