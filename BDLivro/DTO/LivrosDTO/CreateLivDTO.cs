using BDLivro.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDLivro.DTO.LivrosDTO
{
    public class CreateLivDTO
    {
        public int Id { get; set; }

        [Required]
        public int isbn { get; set; }

        [Required]
        public string nomeLivro { get; set; }

        [Range(0, 999999, ErrorMessage = "O valor têm que ser superior ou igual que 0!!")]
        [Column(TypeName = "decimal(6, 2)")]
        [Required]
        public decimal precoLivro { get; set; }

        public int AutorId { get; set; }

        public Autor Autor { get; set; }
        public Livros toEntity()
        {
            return new Livros() { isbn = isbn };
        }
    }
}
