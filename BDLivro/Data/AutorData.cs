using BDLivro.Models;

namespace BDLivro.Data
{
    public class AutorData
    {
        public static List<Autor> autorList = new List<Autor>
        {
            new Autor {Id = 1, NomeAutor = "João"},
            new Autor {Id = 2, NomeAutor = "José"}
        };
    }
}
