using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DS_ArthurGOAREGUER.Models
{
    public class Tournoi
    {
        public int Id { get; set; }

        [StringLength(150, MinimumLength = 2), Required(ErrorMessage = "Le nom du tournoi doit contenir au minimum 2 caractères.")]
        public string Nom { get; set; }

        [StringLength(250, MinimumLength = 2), Required(ErrorMessage = "La description du tournoi doit contenir au minimum 2 caractères.")]
        public string Description { get; set; }

        [StringLength(50, MinimumLength = 2), Required(ErrorMessage = "Le lieu du tournoi doit contenir au minimum 2 caractères.")]
        public string Lieux { get; set; }
    }
}
