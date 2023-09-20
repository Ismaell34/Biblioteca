using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario {get; set;}
        public string nome {get; set;}
        public int nivel { get; set; }
        public string user {get; set;}
        public string senha {get; set;}
      
    }
}