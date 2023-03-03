using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDLivro.Models.DTO
{
    public class LivrosDTO
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(11)]
        public int isbn { get; set; }

        [Required]
        [MaxLength(30)]
        public string? nomeLivro { get; set; }

        public decimal precoLivro { get; set; }
        [System.ComponentModel.DataAnnotations.Range(0, 999999, ErrorMessage = "O valor têm que ser superior ou igual que 0!!")]
        [Column(TypeName = "decimal(6, 2)")]

        public int AutorId { get; set; }

        public Autor Autor { get; set; }


    }
}