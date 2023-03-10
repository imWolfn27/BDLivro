using Microsoft.AspNetCore.Mvc;
using BDLivro.Models;
using BDLivro.Data;
using Microsoft.EntityFrameworkCore;
using BDLivro.DTO;
using BDLivro.DTO.LivrosDTO;
using BDLivro.DTO.AutorDTO;

namespace BDLivro.Controllers
{

    [Route("api/Livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivrosContexto _livros;

        public LivroController(LivrosContexto context)
        {
            _livros = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetLivrosDTO>>> GetLivro()
        {
            //Vai buscar as tables do GetAutorDTO e faz a transformação da entidade para construtor/construtoe para entidade
            var Books = await _livros.Livros.ToListAsync();
            var dtoLivros = Books.Select(t => new GetLivrosDTO(t.Id, t.isbn, t.nomeLivro, t.precoLivro, t.AutorId, t.Autor)).ToList();

            return dtoLivros;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Livros> GetLivrosID(int id)
        {
            var livro = _livros.Livros.Find(id);

            //if (autor == 0)
            //{
            //    return BadRequest();
            //}
            //var autor = AutorData.autorList.FirstOrDefault(u => u.Id == id);

            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost("CreateLivro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Livros>> CreateLivro(CreateLivDTO autor)
        {
            if (_livros.Livros == null)
            {
                return Problem("Entity set 'LivrosContexto.Autor' is null.");
            }
            var Entity = autor.toEntity();
            _livros.Livros.Add(Entity);
            await _livros.SaveChangesAsync();

            return CreatedAtAction("GetLivro", new { id = Entity.Id }, autor);
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            if (_livros.Livros == null)
            {
                return NotFound();
            }
            var livro = await _livros.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _livros.Livros.Remove(livro);
            await _livros.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateLivro(int isbn, [FromBody]UpdateLivroDTO Livupdate )
        {
            var livro = await _livros.Livros.FindAsync(isbn);
            if(isbn != Livupdate.isbn || Livupdate.isbn != 13 || Livupdate.precoLivro < 0 || Livupdate == null)
            {
                return BadRequest();
            }

            livro.isbn = Livupdate.isbn;
            livro.nomeLivro = Livupdate.nomeLivro;
            livro.precoLivro = Livupdate.precoLivro;
            livro.AutorId = Livupdate.AutorId;
            livro.Autor = Livupdate.Autor;
            _livros.Entry(livro).State = EntityState.Modified;

            try
            {
                _livros.Livros.Update(livro);
                await _livros.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(isbn))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool LivroExists(int id)
        {
            return (_livros.Livros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        //[HttpPatch("{ID: int}", Name = "UpdatePartialLivros")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult UpdatePartialLivros(int id, JsonPatchExtensions<LivroDTO> patchDTO)
        //{

        //}
    }
}