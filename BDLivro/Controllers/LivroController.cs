using Microsoft.AspNetCore.Mvc;
using BDLivro.Models;


namespace BDLivro.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILogger<LivroController> _livros;

        public LivroController(ILogger<LivroController> livros)
        {
            _livros = livros;
        }

        [HttpGet(Name = "GetLivros")]
        public IEnumerable<Livros> Get()
        {
            return (IEnumerable<Livros>)Enumerable.Range(1, 5).Select(index => new Livros
            {
                ID = 35,
                isbn = 1111111112,
                nomeLivro = "A saga do Leo",
                precoLivro = (decimal)15.99,
                AutorId = 32,
                //Autor = ""
            });
        }
    }
}

