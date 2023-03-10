using BDLivro.Models;

namespace BDLivro.DTO.AutorDTO
{
    public class CreateAutorDTO
    {
        public int Id { get; set; }

        public string NomeAutor { get; set; }

        public Autor toEntity()
        {
            return new Autor() { NomeAutor = NomeAutor };
        }
    }
}
