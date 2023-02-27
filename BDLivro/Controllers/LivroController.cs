using Microsoft.AspNetCore.Mvc;
using BDLivro.Models;


namespace BDLivro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Livros> GetLivros()
        {
            return new List<Livros>
            {
                new Livros {ID = 35,
                            isbn = 1111111112,
                            nomeLivro = "A saga do Leo",
                            precoLivro = (decimal)15.99,
                            Autor = 32},

                 new Livros {ID = 37, isbn = 1111111113, nomeLivro = "A saga do Leo",
                     precoLivro = (decimal)15.99, Autor = 34}
        
            };
        }
    }
}

