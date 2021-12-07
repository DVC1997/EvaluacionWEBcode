using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaUteq.DAL
{
    public class LibrosDto
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public string Editorial { get; set; }
        [Required]
        public string Paginas { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime anioEdicion { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}