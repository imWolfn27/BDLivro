using BDLivro.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BDLivro.DTO.LivrosDTO
{
    public class GetLivrosDTO
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

        public GetLivrosDTO(int id, int Isbn, string nomelivro, decimal precolivro, int autorid, Autor autor)
        {
            Id = id;
            isbn = Isbn;
            nomeLivro = nomelivro;
            precoLivro = precolivro;
            AutorId = autorid;
            Autor = autor;
        }
    }
}
