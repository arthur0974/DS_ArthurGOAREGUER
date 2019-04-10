using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DS_ArthurGOAREGUER.Models
{
    public class Resultat
    {
        public int Id { get; set; }

        [DisplayName("Championnat")]
        [Required(ErrorMessage = "Veuillez sélectionner un championnat.")]
        public int ChampionnatId { get; set; }
        public virtual Championnat Championnat { get; set; }

        [DisplayName("Joueur 1")]
        [Required(ErrorMessage = "Veuillez sélectionner le joueur 1.")]
        public int Personne1Id { get; set; }
        public virtual Personne Personne1 { get; set; }

        [DisplayName("Joueur 2")]
        [Required(ErrorMessage = "Veuillez sélectionner le joueur 2.")]
        public int Personne2Id { get; set; }
        public virtual Personne Personne2 { get; set; }

        [DisplayName("Score Joueur 1")]
        public int Score1 { get; set; }

        [DisplayName("Score Joueur 2")]
        public int Score2 { get; set; }

        [DisplayName("Date du championnat")]
        [DataType(DataType.Date), Required]
        public DateTime DateDebut { get; set; }
    }
}
