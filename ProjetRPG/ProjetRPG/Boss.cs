using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Boss : Enemy
    {
        public Boss(string name, string type, int hp, int def, Ingredient reward) : base(name, type, hp, def)
        {
            
        }

        public Attack ecrasement = new Attack("ecrasement", 100, "attaque de boss, inflige de gros dégats");
        public Attack coupBranche = new Attack("coup de branche", 75, "attaque de boss, inflige de bons dégats");
        public override void SetAttackEnemy()
        {
            attackList.Add(Attack.croc);
            attackList.Add(EnemyLegume.potager);
            attackList.Add(ecrasement);
        }

       
    }
}
