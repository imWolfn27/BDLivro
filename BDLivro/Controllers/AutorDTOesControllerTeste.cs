using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDLivro.Data;
using BDLivro.Models;
using BDLivro.DTO;
using BDLivro.DTO.AutorDTO;

namespace BDLivro.Controllers
{
    [Route("api/AutorDTOes")]
    [ApiController]
    public class AutorDTOesController : ControllerBase
    {
        private readonly LivrosContexto _context;

        public AutorDTOesController(LivrosContexto context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetAutorDTO>>> GetAutor()
        {
            //Vai buscar as tables do GetAutorDTO e faz a transformação da entidade para construtor/construtoe para entidade
            var Authors = await _context.Autor.ToListAsync();
            var dtoAuthors = Authors.Select(t => new GetAutorDTO(t.Id, t.NomeAutor)).ToList();
            
            return dtoAuthors;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Autor> GetAutor(int id)
        {
            var autor = _context.Autor.Find(id);

            //if (autor == 0)
            //{
            //    return BadRequest();
            //}
            //var autor = AutorData.autorList.FirstOrDefault(u => u.Id == id);

            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateAutor(int id, [FromBody]UpdateAutorDTO autorNome)
        {
            var autor = await _context.Autor.FindAsync(id);

            if (autor == null)
            {
                return BadRequest();
            }
            autor.NomeAutor = autorNome.NomeAutor;
            _context.Entry(autor).State = EntityState.Modified;

            try
            {
                _context.Autor.Update(autor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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

        [HttpPost("CreateAutor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Autor>> CreateAutor(CreateAutorDTO autor)
        {
          if (_context.Autor == null)
          {
              return Problem("Entity set 'LivrosContexto.Autor' is null.");
          }
            var Entity = autor.toEntity();
            _context.Autor.Add(Entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = Entity.Id }, autor);
        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            if (_context.Autor == null)
            {
                return NotFound();
            }
            var autor = await _context.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
                      
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutorExists(int id)
        {
            return (_context.Autor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
