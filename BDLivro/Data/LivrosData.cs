using BDLivro.Models.DTO;

namespace BDLivro.Data
{
    public class LivrosData
    {
        public static List<LivrosDTO> livrosList = new List<LivrosDTO>{
            new LivrosDTO{ID = 1, isbn = 1111111112, nomeLivro = "A saga do Leo", precoLivro = (decimal)15.99, AutorId = 1},

            new LivrosDTO{ID = 2, isbn = 1222222222, nomeLivro = "A saga do Touro", precoLivro = (decimal)20.00, AutorId = 2}
        };
    }
}
