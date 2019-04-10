using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DS_ArthurGOAREGUER.Models
{
    public class Participant
    {
        public int Id { get; set; }
        [DisplayName("Championnat")]
        public int ChampionnatId { get; set; }
        public virtual Championnat Championnat { get; set; }
        [DisplayName("Personne")]
        public int PersonneId { get; set; }
        public virtual Personne Personne { get; set; }
        [StringLength(150, MinimumLength = 2), Required(ErrorMessage = "Le nom de l'équipe doit contenir au minimum 2 caractères.")]
        public string Equipe { get; set; }
    }
}
