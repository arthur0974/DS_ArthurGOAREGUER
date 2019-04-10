using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DS_ArthurGOAREGUER.Models
{
    public class Poste
    {
        public int Id { get; set; }

        [StringLength(150, MinimumLength = 2), Required(ErrorMessage = "Le nom du poste doit contenir au minimum 2 caractères.")]
        public string Nom { get; set; }
    }
}
