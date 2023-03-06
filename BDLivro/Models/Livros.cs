using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDLivro.Models
{
    public class Livros
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int isbn { get; set; }

        [Required]
        public string? nomeLivro { get; set; }

        [Required]
        public decimal precoLivro { get; set; }

        [System.ComponentModel.DataAnnotations.Range(0, 999999, ErrorMessage = "O valor têm que ser superior ou igual que 0!!")]
        [Column(TypeName = "decimal(6, 2)")]

        public int AutorId { get; set; }

        public Autor Autor { get; set; }


        //[DefaultValue(false)]
        //public bool Apagado { get; set; }

        //public void LivroApagado()
        //{
        //    this.Apagado = true;
        //}
    }
}