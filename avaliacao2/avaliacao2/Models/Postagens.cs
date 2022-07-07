using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;


namespace avaliacao2.Models
{
    public class Postagens
    {

        [Key]
        public int idPost { get; set; }

        [Required]
        public String Titulo { get; set; }


        [Required]
        public String Descricao { get; set; }

        [Required]
        public DateTime DataPostagem { get; set; }




    }
}
