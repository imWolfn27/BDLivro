using Microsoft.AspNetCore.Mvc;
using BDLivro.Models;
using BDLivro.Data;

namespace BDLivro.Controllers
{

    [Route("api/Livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILogger<LivroController> _livros;

        public LivroController(ILogger<LivroController> livros)
        {
            _livros = livros;
        }

        [HttpGet(Name = "GetLivros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Livros>> GetLivros()
        {
            return Ok(LivrosData.livrosList);
        }

        [HttpGet("{ID:int}", Name = "GetLivrosID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Livros> GetLivro(int ID)
        {
            if(ID == 0)
            {
                return BadRequest();
            }
            var livro = LivrosData.livrosList.FirstOrDefault(u => u.ID == ID);

            if(livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost(Name = "CreateLivros")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Livros> CreateLivros([FromBody]Livros livros)
        {

            if (LivrosData.livrosList.FirstOrDefault(u => u.isbn == livros.isbn) != null)
            {
                ModelState.AddModelError("ErroLivroRepetido", "Já existe este Livro!!");
                return BadRequest(ModelState);
            }

            if (livros == null)
            {
                return BadRequest(livros);
            }

            if (livros.ID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            livros.ID = LivrosData.livrosList.OrderByDescending(u => u.ID).FirstOrDefault().ID + 1;
            LivrosData.livrosList.Add(livros);

            return CreatedAtRoute("GetLivrosID", new { ID = livros.ID }, livros);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{ID:int}", Name = "DeleteLivros")]
        
        public IActionResult DeleteLivros(int ID)
        {
            if(ID == 0)
            {
                return BadRequest();
            }

            var livros = LivrosData.livrosList.FirstOrDefault(u => u.ID == ID);
            if(livros == null)
            {
                return NotFound();
            }
            LivrosData.livrosList.Remove(livros);
            return NoContent();
        }

        [HttpPut("{ID:int}", Name = "UpdateLivros")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateLivros(int ID, [FromBody]Livros livros)
        {
            if(livros == null || ID != livros.ID )

            { return BadRequest(); }

            var livro = LivrosData.livrosList.FirstOrDefault(u => u.ID == ID);

            livro.ID = livros.ID;
            livro.isbn = livros.isbn;
            livro.nomeLivro = livros.nomeLivro;
            livro.precoLivro = livros.precoLivro;
            livro.AutorId = livros.AutorId;
            livro.Autor = livros.Autor;

            return NoContent();
        }

        //[HttpPatch("{ID: int}", Name = "UpdatePartialLivros")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult UpdatePartialLivros(int id, JsonPatchExtensions<LivroDTO> patchDTO)
        //{

        //}
    }
}