using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Boss : Enemy
    {
        public Boss(string name, string type, int hp, int att, int def,int xp, Ingredient reward) : base(name, type, hp, att, def, xp)
        {
            this.reward = reward;
        }

        public static Attack ecrasement = new Attack("ecrasement", 100, "attaque de boss, inflige de gros dégats");
        public static Attack coupBranche = new Attack("coup de branche", 75, "attaque de boss, inflige de bons dégats");
        public static Attack spores = new Attack("spores toxiques", 80, "attaque de la truffe toxique, ignore la défense et réduit l'attaque du héros");

        public override void SetAttackEnemy()
        {
            if (type == "bossplaine")
            {
                attackList.Add(Attack.croc);
                attackList.Add(EnemyPlaine.potager);
                attackList.Add(ecrasement);
            }
            else if (type == "bossforet")
            {
                attackList.Add(Attack.croc);
                attackList.Add(ecrasement);
                attackList.Add(EnemyForet.doubleBaffe);
                attackList.Add(spores);
            }
            
        }

        public static void DoSpores(HeroConstructor hero, Enemy enemy)
        {
            Console.WriteLine(enemy.GetName() + " a lancé l'attaque: " + spores.GetName() + "!");
            hero.SetHp(hero.GetHp() - (spores.GetDamage() + enemy.GetAtt()));
            Console.WriteLine(enemy.GetName() + " vous a tappé pour " + (spores.GetDamage() + enemy.GetAtt()) + " - 0 armure = " + (spores.GetDamage() + enemy.GetAtt()) + " dommages");
            hero.SetAtt(hero.GetAtt() - 10);
            Console.WriteLine("votre attaque diminue de 10");
        }
       
    }
}
