using Microsoft.AspNetCore.Mvc;
using BDLivro.Models.DTO;
using BDLivro.Data;

namespace BDLivro.Controllers
{

    [Route("api/LivroAPI")]
    [ApiController]
    public class LivroAPIController : ControllerBase
    {
        private readonly ApplicationBuilder _db;
        public LivroAPIController(ApplicationBuilder db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetLivros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<LivrosDTO>> GetLivros()
        {
            return Ok(_db.Livros.ToList());
        }

        [HttpGet("{ID:int}", Name = "GetLivrosID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LivrosDTO> GetLivro(int ID)
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
        public ActionResult<LivrosDTO> CreateLivros([FromBody]LivrosDTO livrosDTO)
        {

            if (LivrosData.livrosList.FirstOrDefault(u => u.isbn == livrosDTO.isbn) != null)
            {
                ModelState.AddModelError("ErroLivroRepetido", "Já existe este Livro!!");
                return BadRequest(ModelState);
            }

            if (livrosDTO == null)
            {
                return BadRequest(livrosDTO);
            }

            if (livrosDTO.ID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            livrosDTO.ID = LivrosData.livrosList.OrderByDescending(u => u.ID).FirstOrDefault().ID + 1;
            LivrosData.livrosList.Add(livrosDTO);

            return CreatedAtRoute("GetLivrosID", new { ID = livrosDTO.ID }, livrosDTO);
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

        public IActionResult UpdateLivros(int ID, [FromBody] LivrosDTO livrosDTO)
        {
            if (livrosDTO == null || ID != livrosDTO.ID)
            { return BadRequest(); }

            var livros = LivrosData.livrosList.FirstOrDefault(u => u.ID == ID);

            livros.ID = livrosDTO.ID;
            livros.isbn = livrosDTO.isbn;
            livros.nomeLivro = livrosDTO.nomeLivro;
            livros.precoLivro = livrosDTO.precoLivro;
            livros.AutorId = livrosDTO.AutorId;
            livros.Autor = livrosDTO.Autor;

            return NoContent();
        }
    }
}