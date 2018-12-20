using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class AttackCuisson : Attack
    {
        //ressource des attaques de cuisson
        private int coutGaz;

        public AttackCuisson(string name, int damage, string effect, int cout) : base(name, damage, effect)
        {
            this.coutGaz = cout;
        }

        public void SetCoutGaz(int coutGaz)
        {
            this.coutGaz = coutGaz;
        }
        public int GetCoutGaz()
        {
            return this.coutGaz;
        }


        // Liste des attaques cuisson
        public static AttackCuisson flambage = new AttackCuisson("flambage", 50, "Attaque de base de la cuisson, inflige de faibles dégats et augmente l'attaque du héros", 25);
        public static AttackCuisson pyrolise = new AttackCuisson("pyrolise", 150, "attaque ultime de la cuisson a feu fort, à 25% de chances de rater", 30);


        public override void ShowAttack()
        {
            base.ShowAttack();
            Console.WriteLine("-cout : " + this.coutGaz + "gaz");
        }

        public static void DoFlambage(HeroConstructor hero, Enemy enemy)
        {
            Console.WriteLine(hero.GetName() + " a lancé l'attaque: " + flambage.GetName() + "!");
            enemy.SetHp(enemy.GetHp()-(flambage.GetDamage()+ hero.GetAtt() - enemy.GetDef()));
            hero.SetAtt(hero.GetAtt() + 25);
            Console.WriteLine("Vous avez infligé " + (flambage.GetDamage() + hero.GetAtt() - enemy.GetDef()) + " et augmenté votre de 25!!");
        }

        public static void DoPyrolise(HeroConstructor hero, Enemy enemy)
        {
            Console.WriteLine("Vous a lancé l'attaque: " + pyrolise.GetName() + "!");
            Random r = new Random(DateTime.Now.Millisecond);
            int alea = r.Next(1, 5);
            if (alea == 1)
            {
                Console.WriteLine("Surchauffe!! l'attaque à raté..");
            }
            else if (alea > 1)
            {
                enemy.SetHp(enemy.GetHp() - (pyrolise.GetDamage() + hero.GetAtt() - enemy.GetDef()));
                Console.WriteLine("Réussite! vous avez tappé pour " + (pyrolise.GetDamage() + hero.GetAtt()) + " - " + enemy.GetDef() + "armure = " + (pyrolise.GetDamage() + hero.GetAtt() - enemy.GetDef()) + " dommages");
            }
        }

    }
}
