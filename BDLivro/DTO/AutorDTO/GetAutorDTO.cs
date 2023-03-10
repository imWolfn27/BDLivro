using BDLivro.Models;

namespace BDLivro.DTO.AutorDTO
{
    public class GetAutorDTO
    {
        public int Id { get; set; }

        public string NomeAutor { get; set; }

        public GetAutorDTO(int id, string nomeautor)
        {
            Id = id;
            NomeAutor = nomeautor;
        }

    }
}
