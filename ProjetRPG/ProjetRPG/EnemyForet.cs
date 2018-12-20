using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class EnemyForet : Enemy
    {
        public EnemyForet(string name, string type, int hp, int att, int def, int xp) : base(name, type, hp, att, def, xp)
        {
        }

        //Liste des attaques spécifiques aux ennemis des plaines
        public static Attack ogm2 = new Attack("OGM 2", 0, "Augmente l'attaque");
        public static Attack doubleBaffe = new Attack("Double Baffe", 50, "double baffe dans la tronche!!");

        public override void SetAttackEnemy()
        {
            base.SetAttackEnemy();
            attackList.Add(ogm2);
            attackList.Add(doubleBaffe);
        }

        public static void DoOgm2(Enemy enemy)
        {
            Console.WriteLine(enemy.GetName() + " a lancé l'attaque: " + ogm2.GetName() + "!");
            enemy.SetAtt(enemy.GetAtt() + 50);
            Console.WriteLine(enemy.GetName() + " a boosté son attaque de 50!");
        }

        public static void DoDoubleBaffe(HeroConstructor hero, Enemy enemy)
        {
            Console.WriteLine(enemy.GetName() + " a lancé l'attaque: " + doubleBaffe.GetName() + "!");
            hero.SetHp(hero.GetHp() - (doubleBaffe.GetDamage() + enemy.GetAtt() - hero.GetDef()));
            hero.SetHp(hero.GetHp() - (doubleBaffe.GetDamage() + enemy.GetAtt() - hero.GetDef()));
            Console.WriteLine(enemy.GetName() + " vous a tappé pour " + (doubleBaffe.GetDamage() + enemy.GetAtt()) + " - " + hero.GetDef() + "armure = " + (doubleBaffe.GetDamage() + enemy.GetAtt() - hero.GetDef()) + " dommages x2!!");
            Console.WriteLine("il vous reste " + hero.GetHp() + " pvs");
        }
    }
}
