using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DS_ArthurGOAREGUER.Models
{
    public class Personne
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2), Required(ErrorMessage = "Le prénom doit contenir au minimum 2 caractères.")]
        public string Prenom { get; set; }
        [StringLength(50, MinimumLength = 2), Required(ErrorMessage = "Le nom doit contenir au minimum 2 caractères.")]
        public string Nom { get; set; }
        [StringLength(50, MinimumLength = 2), Required(ErrorMessage = "Le pseudo doit contenir au minimum 2 caractères.")]
        public string Pseudo { get; set; }
        [StringLength(150, MinimumLength = 2), Required(ErrorMessage = "L'adresse mail doit contenir au minimum 2 caractères.")]
        public string Email { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DateNaissance { get; set; }

        [StringLength(1, MinimumLength = 1), Required]
        public string Sexe { get; set; }
        public virtual string PrenomNom
        {
            get
            {
                return Prenom + ' ' + Nom;
            }
        }
    }
}
