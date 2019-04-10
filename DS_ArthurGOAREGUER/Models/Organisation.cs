using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DS_ArthurGOAREGUER.Models
{
    public class Organisation
    {
        public int Id { get; set; }

        [DisplayName("Tournoi")]
        public int TournoiId { get; set; }
        public virtual Tournoi Tournoi { get; set; }

        [DisplayName("Personne")]
        public int PersonneId { get; set; }
        public virtual Personne Personne { get; set; }

        [DisplayName("Poste")]
        public int PosteId { get; set; }
        public virtual Poste Poste { get; set; }

    }
}
