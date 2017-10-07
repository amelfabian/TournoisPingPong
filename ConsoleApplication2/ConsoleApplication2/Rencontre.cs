using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheMetier
{
    class Rencontre
    {
        public int num_rencontre { get; set; }
        public string position { get; set; }
        public string resultat { get; set; }
        public Arbitre fk_arbitre { get; set; }
        public Joueur fk_j1 { get; set; }
        public Joueur fk_j2 { get; set; }
        public Joueur fk_v { get; set; }
        public TablePingPong fk_table { get; set; }

        public Rencontre()
        {

        }

        public Rencontre(Rencontre rencontre)
        {
            num_rencontre = rencontre.num_rencontre;
            position = rencontre.position;
            resultat = rencontre.resultat;
            fk_arbitre = rencontre.fk_arbitre;
            fk_j1 = rencontre.fk_j1;
            fk_j2 = rencontre.fk_j2;
            fk_v = rencontre.fk_v;
            fk_table = rencontre.fk_table;
        }

        public Rencontre(int Num_rencontre, string Position, string Resultat)
        {
            num_rencontre = Num_rencontre;
            position = Position;
            resultat = Resultat;
     
        }
    }
}
