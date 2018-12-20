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
        public static AttackCuisson flambage = new AttackCuisson("flambage", 100, "attaque de cuisson basique, avec une chance d'enflammer l'ennemi", 25);
        public static AttackCuisson thermostat = new AttackCuisson("thermostat", 50, "attaque ultime de la cuisson a feu fort", 30);


        public override void ShowAttack()
        {
            base.ShowAttack();
            Console.WriteLine("-cout : " + this.coutGaz + "gaz");
        }

    }
}
