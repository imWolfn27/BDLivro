using BDLivro.Models.DTO;

namespace BDLivro.Data
{
    public class AutorData
    {
        public static List<AutorDTO> autorList = new List<AutorDTO>
        {
            new AutorDTO {Id = 1, NomeAutor = "João" },
            new AutorDTO {Id = 2, NomeAutor = "José" }
        };
    }
}
