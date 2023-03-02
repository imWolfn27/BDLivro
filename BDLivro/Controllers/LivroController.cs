using Microsoft.AspNetCore.Mvc;
using BDLivro.Models;
using BDLivro.Models.DTO;
using BDLivro.Data;

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
        public IEnumerable<LivrosDTO> Get()
        {
            if (LivrosContexto.livrosList.Any())
                return (IEnumerable<LivrosDTO>)NotFound();
            return LivrosContexto.livrosList;
        }

        [HttpPost]

        public Livros Add(livros)
        {
            Livros.CreateDate = DateTime.Now;
            _livros.Livros.Add(livros);
            bool issSaved = _livros.SaveChanges() > 0;
            if (issSaved)
            {
                return livros;
            }
            return null;
        }

        [HttpDelete(Name = "DeleteLivros")]

    }
}

