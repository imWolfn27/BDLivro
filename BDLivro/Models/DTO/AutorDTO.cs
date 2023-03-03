using System.ComponentModel.DataAnnotations;

namespace BDLivro.Models.DTO
{
    public class AutorDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? NomeAutor { get; set; }

        public ICollection<LivrosDTO> LivroDTO { get; set; }
    }
}