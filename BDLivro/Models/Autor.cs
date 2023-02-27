using BDLivro.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BDLivro.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string? NomeAutor { get; set; }

        public ICollection<Livros> Livro { get; set; }

        [DefaultValue(false)]
        public bool Apagado { get; set; }

        public void AutorApagado()
        {
            this.Apagado = true;
        }

        public static implicit operator Autor(int v)
        {
            throw new NotImplementedException();
        }
    }
}
