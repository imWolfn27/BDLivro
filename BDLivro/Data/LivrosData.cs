using BDLivro.Models;

namespace BDLivro.Data
{
    public class LivrosData
    {
        public static List<Livros> livrosList = new List<Livros>{
            new Livros{Id = 1, isbn = 1111111112, nomeLivro = "A saga do Leo", precoLivro = (decimal)15.99, AutorId = 1},

            new Livros{Id = 2, isbn = 1222222222, nomeLivro = "A saga do Touro", precoLivro = (decimal)20.00, AutorId = 2}
        };
    }
}
