using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class EnemyLegume : Enemy
    {
        public EnemyLegume(string name, string type, int hp, int def) : base(name, type, hp, def)
        {
        }

        //Liste des attaques spécifiques aux légumes
        public static Attack ogm = new Attack("OGM", 0, "Augmente l'attaque");
        public static Attack potager = new Attack("Force du Potager", 75, "puissante attaque des légumes");

        public override void SetAttackEnemy()
        {
            base.SetAttackEnemy();
            attackList.Add(ogm);
            attackList.Add(potager);
        }
        

    }

}