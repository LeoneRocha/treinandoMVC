using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_FastFood.Models
{
    public class NaturalidadeCidade
    {
        public NaturalidadeCidade()
        {
            this.Pessoas = new List<Pessoa>();
               
        }
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }

    }
}