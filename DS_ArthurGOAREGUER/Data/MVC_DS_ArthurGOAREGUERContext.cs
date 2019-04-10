using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DS_ArthurGOAREGUER.Models;

namespace DS_ArthurGOAREGUER.Models
{
    public class MVC_DS_ArthurGOAREGUERContext : DbContext
    {
        public MVC_DS_ArthurGOAREGUERContext (DbContextOptions<MVC_DS_ArthurGOAREGUERContext> options)
            : base(options)
        {
        }

        public DbSet<DS_ArthurGOAREGUER.Models.Championnat> Championnat { get; set; }

        public DbSet<DS_ArthurGOAREGUER.Models.Jeux> Jeux { get; set; }

        public DbSet<DS_ArthurGOAREGUER.Models.Organisation> Organisation { get; set; }

        public DbSet<DS_ArthurGOAREGUER.Models.Participant> Participant { get; set; }

        public DbSet<DS_ArthurGOAREGUER.Models.Personne> Personne { get; set; }

        public DbSet<DS_ArthurGOAREGUER.Models.Poste> Poste { get; set; }

        public DbSet<DS_ArthurGOAREGUER.Models.Resultat> Resultat { get; set; }

        public DbSet<DS_ArthurGOAREGUER.Models.Tournoi> Tournoi { get; set; }
    }
}
