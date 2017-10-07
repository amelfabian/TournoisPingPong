using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheMetier
{
    class Arbitre
    {
        public int num_arbitre { get; set; }
        public String nom_arbitre { get; set; }
        public String prenom_arbitre { get; set; }
        public int exp_arbitre { get; set; }

        public Arbitre()
        {

        }

        public Arbitre( Arbitre arbitre)
        {
            num_arbitre = arbitre.num_arbitre;
            nom_arbitre = arbitre.nom_arbitre;
            prenom_arbitre = arbitre.prenom_arbitre;
            exp_arbitre = arbitre.exp_arbitre;
        }

        public Arbitre(int Num_arbitre, string Nom_arbitre, string Prenom_arbitre, int Exp_arbitre)
        {
            num_arbitre = Num_arbitre;
            nom_arbitre = Nom_arbitre;
            prenom_arbitre = Prenom_arbitre;
            exp_arbitre = Exp_arbitre;
        }

    }
}
