using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Herb : Item
    {
        public string effect;
        public Herb(string name, string effect) : base(name)
        {
            this.effect = effect;
        }


        public static void UseRomarin(Enemy enemy)
        {
            if (enemy.GetDef() >= 20)
            {
                enemy.SetDef(enemy.GetDef() - 20);
            }
            else
            {
                enemy.SetDef(0);
            }
            Console.WriteLine("la défense de " + enemy.GetName() + " est réduite de 20!");
        }

        public static void UseThym(Enemy enemy)
        {
            if (enemy.GetAtt() >= 20)
            {
                enemy.SetAtt(enemy.GetAtt() - 20);
            }
            else
            {
                enemy.SetAtt(0);
            }
            Console.WriteLine("l'attaque de " + enemy.GetName() + " est réduite de 20!");
        }

        public static void UseCoriandre(Enemy enemy)
        {
            if (enemy.GetHp() >= 50)
            {
                enemy.SetHp(enemy.GetHp() - 50);
            }
            else
            {
                enemy.SetHp(1);
            }
            Console.WriteLine(enemy.GetName() + " a subi 50 points de dégats");
        }
    }
}
