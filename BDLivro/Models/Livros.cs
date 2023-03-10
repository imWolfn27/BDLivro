using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BDLivro.Models
{
    public class Livros
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int isbn { get; set; }

        [Required]
        public string? nomeLivro { get; set; }

        [System.ComponentModel.DataAnnotations.Range(0, 999999, ErrorMessage = "O valor têm que ser superior ou igual que 0!!")]
        [Column(TypeName = "decimal(6, 2)")]
        [Required]
        public decimal precoLivro { get; set; }

        [Required]
        [ForeignKey("Autor")]
        public int AutorId { get; set; }

        public Autor Autor { get; set; } = null!;

        
        //[DefaultValue(false)]
        //public bool Apagado { get; set; }

        //public void LivroApagado()
        //{
        //    this.Apagado = true;
        //}
    }
}