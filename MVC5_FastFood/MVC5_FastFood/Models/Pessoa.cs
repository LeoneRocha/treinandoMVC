using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_FastFood.Models
{
    public class Pessoa
    {
        [Key]
        [Required]
        public int Codigo { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required] 
        [ForeignKey("NaturalidadeCidade")]
        public int NaturalidadeId { get; set; }

        [ForeignKey("NaturalidadeCidadeId")]
        public NaturalidadeCidade Naturalidade { get; set; }

    }

  
}