using BDLivro.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BDLivro.Models
{
    public class Autor
    {
        
        public int Id { get; set; } 

        
        public string NomeAutor { get; set; }

        public ICollection<Livros> Livros { get; set; }


        //[DefaultValue(false)]
        //public bool Apagado { get; set; }

        //public void AutorApagado()
        //{
        //    this.Apagado = true;
        //}
    }
}