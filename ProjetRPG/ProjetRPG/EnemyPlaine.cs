using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class EnemyPlaine : Enemy
    {
        public EnemyPlaine(string name, string type, int hp, int att, int def, int xp) : base(name, type, hp, att, def, xp)
        {
        }

        //Liste des attaques spécifiques aux ennemis des plaines
        public static Attack ogm = new Attack("OGM", 0, "Augmente l'attaque");
        public static Attack potager = new Attack("Force du Potager", 75, "puissante attaque des légumes");

        public override void SetAttackEnemy()
        {
            base.SetAttackEnemy();
            attackList.Add(ogm);
            attackList.Add(potager);
        }

        public static void DoOgm(Enemy enemy)
        {
            Console.WriteLine(enemy.GetName() + " a lancé l'attaque: " + ogm.GetName() + "!");
            enemy.SetAtt(enemy.GetAtt() + 30);
            Console.WriteLine(enemy.GetName() + " a boosté son attaque de 30!");
        }

        public static void DoPotager(HeroConstructor hero, Enemy enemy)
        {
            Console.WriteLine(enemy.GetName() + " a lancé l'attaque: " + potager.GetName() + "!");
            hero.SetHp(hero.GetHp() - (potager.GetDamage() + enemy.GetAtt() - hero.GetDef()));
            Console.WriteLine(enemy.GetName() + " vous a tappé pour " + (potager.GetDamage() + enemy.GetAtt()) + " - " + hero.GetDef() + "armure = " + (potager.GetDamage() + enemy.GetAtt() - hero.GetDef()) + " dommages");
            Console.WriteLine("il vous reste " + hero.GetHp() + " pvs");
        }
        

    }

}