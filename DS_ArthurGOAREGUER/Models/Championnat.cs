using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DS_ArthurGOAREGUER.Models
{
    public class Championnat
    {
        public int Id { get; set; }

        [DisplayName("Tournoi")]
        [Required(ErrorMessage = "Veuillez sélectionner un tournoi.")]
        public int TournoiId { get; set; }
        public virtual Tournoi Tournoi { get; set; }

        [DisplayName("Jeu")]
        [Required(ErrorMessage = "Veuillez sélectionner un jeu.")]
        public int JeuxId { get; set; }
        public virtual Jeux Jeux { get; set; }

        [StringLength(50, MinimumLength = 2), Required(ErrorMessage = "Le nom du championnat doit contenir au minimum 2 caractères.")]
        public string Nom { get; set; }
    }
}
