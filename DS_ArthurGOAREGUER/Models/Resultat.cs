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
        public int ChampionnatId { get; set; }
        public virtual Championnat Championnat { get; set; }

        [DisplayName("Personne 1")]
        public int Personne1Id { get; set; }
        public virtual Personne Personne1 { get; set; }

        [DisplayName("Personne 2")]
        public int Personne2Id { get; set; }
        public virtual Personne Personne2 { get; set; }

        public int Score1 { get; set; }

        public int Score2 { get; set; }

        [DataType(DataType.Date), Required]
        public string DateDebut { get; set; }
    }
}
