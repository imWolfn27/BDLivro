using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDLivro.Data;
using BDLivro.Models;

namespace BDLivro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorDTOesControllerTeste : ControllerBase
    {
        private readonly LivrosContexto _context;

        public AutorDTOesControllerTeste(LivrosContexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutor()
        {
          if (_context.Autor == null)
          {
              return NotFound();
          }
            return await _context.Autor.ToListAsync();
        }

        [HttpGet("{ID}", Name = "GetAutor" )]
        public async Task<ActionResult<Autor>> GetAutor(int ID)
        {
            if (ID == 0)
            {
                return BadRequest();
            }
            var autor = AutorData.autorList.FirstOrDefault(u => u.Id == ID);

            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutorDTO(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;

            try
            {
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

        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
          if (_context.Autor == null)
          {
              return Problem("Entity set 'LivrosContexto.Autor'  is null.");
          }
            _context.Autor.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutorDTO", new { id = autor.Id }, autor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id, Autor autor)
        {
            if (_context.Autor == null)
            {
                return NotFound();
            }
            var autorDTO = await _context.Autor.FindAsync(id);
            if (autorDTO == null)
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
