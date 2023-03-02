namespace BDLivro.Models.DTO
{
    public class LivrosDTO
    {
        public int ID { get; set; }
        public int isbn { get; set; }

        public string? nomeLivro { get; set; }

        public decimal precoLivro { get; set; }

        public int AutorId { get; set; }

        public Autor Autor { get; set; }


    }
}
