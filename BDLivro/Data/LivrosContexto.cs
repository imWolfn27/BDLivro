using BDLivro.Models;
using BDLivro.Models.DTO;
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

        public static List<LivrosDTO> livrosList = new List<LivrosDTO>{
            new LivrosDTO{
                ID = 35,
                isbn = 1111111112,
                nomeLivro = "A saga do Leo",
                precoLivro = (decimal)15.99,
                AutorId = 32,
                //Autor = ""
            },

            new LivrosDTO{
                ID = 34,
                isbn = 1222222222,
                nomeLivro = "A saga do Touro",
                precoLivro = (decimal)20.00,
                AutorId = 2,
                //Autor = ""
            }
        };
    }
}
