using Microsoft.AspNetCore.Mvc;
using BDLivro.Data;
using BDLivro.Models.DTO;

namespace BDLivro.Controllers
{
    [Route("api/AutorAPI")]
    [ApiController]
    public class AutorAPIController : ControllerBase
    {
        private readonly ApplicationBuilder _db;

        public AutorAPIController(ApplicationBuilder db)
        {
            _db = db;
        }    

        [HttpGet(Name = "GetAutor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<AutorDTO>> GetAutor()
        {
            return Ok(AutorData.autorList);
        }

        [HttpGet("{ID:int}", Name = "GetAutorID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AutorDTO> GetAutor(int ID)
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

        [HttpPost(Name = "CreateAutor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AutorDTO> CreateAutor([FromBody] AutorDTO autorDTO)
        {

            if (AutorData.autorList.FirstOrDefault(u => u.Id == autorDTO.Id) != null)
            {
                ModelState.AddModelError("ErroAutorRepetido", "Já existe este Autor!!");
                return BadRequest(ModelState);
            }

            if (autorDTO == null)
            {
                return BadRequest(autorDTO);
            }

            if (autorDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            autorDTO.Id = AutorData.autorList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            AutorData.autorList.Add(autorDTO);

            return CreatedAtRoute("GetAutorID", new { ID = autorDTO.Id }, autorDTO);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{ID:int}", Name = "DeleteAutor")]

        public IActionResult DeleteAutor(int ID)
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
            AutorData.autorList.Remove(autor);
            return NoContent();
        }

        [HttpPut("{ID:int}", Name = "UpdateAutor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateAutor(int ID, [FromBody] AutorDTO autorDTO)
        {
            if (autorDTO == null || ID != autorDTO.Id)
            { return BadRequest(); }

            var autor = AutorData.autorList.FirstOrDefault(u => u.Id == ID);

            autor.Id = autorDTO.Id;
            autor.NomeAutor = autorDTO.NomeAutor;
           
            return NoContent();
        }
    }
}