using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Attack
    {

        // Attaques communes du héros
        public static Attack punch = new Attack("coup de poing", 50, "coup basique qui inflige de petits dégats");
        public static Attack kick = new Attack("coup de pied", 75, "coup basique qui inflige des dégats, mais a une chance de rater");
        public static Attack header = new Attack("le coup de boule de Zizou", 999, "one shot les ennemis italiens");

        // Attaques des monstres
        public static Attack griffe = new Attack("griffe", 30, "coup de griffe");
        public static Attack croc = new Attack("croc", 50, "croquage violent et sauvage");

        protected string name;
        protected int damage;
        protected string effect;

        public Attack(string name, int damage, string effect)
        {
            this.name = name;
            this.damage = damage;
            this.effect = effect;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }
        public int GetDamage()
        {
            return this.damage;
        }

        public void SetEffect(string effect)
        {
            this.effect = effect;
        }
        public string GetEffect()
        {
            return this.effect;
        }

        public virtual void ShowAttack()
        {
            Console.WriteLine("\n-Attack name: " + this.name);
            Console.WriteLine("-damage: " + this.damage);
            Console.WriteLine("-effect: " + this.effect);

        }
        
        public static void DoBasicAttack(Attack atk, HeroConstructor hero, Enemy enemy)
        {
            if ((atk.GetDamage() + hero.GetAtt()) <= enemy.GetDef())
            {
                Console.WriteLine(hero.GetName() + " a lancé l'attaque: " + atk.GetName() + "!");
                Console.WriteLine("l'attaque à été complètement bloquée!!!");
            }
            else
            {
                Console.WriteLine(hero.GetName() + " a lancé l'attaque: " + atk.GetName() + "!");
                enemy.SetHp(enemy.GetHp() - (atk.GetDamage() + hero.GetAtt() - enemy.GetDef()));
                Console.WriteLine("vous avez tappé pour " + (atk.GetDamage() + hero.GetAtt()) + " - " + enemy.GetDef() + "armure = " + (atk.GetDamage() + hero.GetAtt() - enemy.GetDef()) + " dommages");
            }
        }


    }
}
