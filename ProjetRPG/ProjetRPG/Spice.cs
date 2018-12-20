using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Spice : Item
    {
        public string effect;
        public Spice(string name, string effect) : base(name)
        {
            this.effect = effect;
        }
        
        public static void UsePaprika(HeroConstructor hero)
        {
            hero.SetAtt(hero.GetAtt() + 20);
            Console.WriteLine("Votre attaque a augmenté de 20!");
        }

        public static void UseCanelle(HeroConstructor hero)
        {
            hero.SetDef(hero.GetDef() + 20);
            Console.WriteLine("Votre défense a augmenté de 20!");
        }
        public static void UseGingembre(HeroConstructor hero, int heroMaxHp)
        {
            if (hero.GetHp() + 50 <= heroMaxHp)
            {
                hero.SetHp(hero.GetHp() + 50);
            }
            else
            {
                hero.SetHp(heroMaxHp);
            }
            Console.WriteLine("Vous avez récupéré 50hp !!");
        }
    }
}
