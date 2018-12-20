using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Weapon : Item
    {
        public int statAtt;
        public int statDef;
        public int statHp;
        public string ecole;

        public Weapon(string name, string ecole, int statAtt, int statDef, int statHp) : base(name)
        {
            this.ecole = ecole;
            this.statAtt = statAtt;
            this.statDef = statDef;
            this.statHp = statHp;
        }

        // Liste des Armes Cuisson
        public static Weapon torche = new Weapon("torche", "cuisson", 10, 0, 0);
        public static Weapon plancha = new Weapon("plancha", "cuisson", 20, 20, 20);

        // Liste des Armes Découpe
        public static Weapon couteau = new Weapon("couteau", "decoupe", 10, 0, 0);
        public static Weapon éplucheur = new Weapon("éplucheur", "decoupe", 20, 20, 20);

        // Liste des Armes Pate
        public static Weapon rouleau = new Weapon("rouleau", "pate", 10, 0, 0);
        public static Weapon emportepiece = new Weapon("emportepiece", "pate", 20, 20, 20);
    }
}
