using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class EcoleCuisson : HeroConstructor
    {
        public int gaz = 200;
        public EcoleCuisson(string classe, string name, int hp, int attack, int defense) : base(classe, name, hp, attack, defense)
        {
        }

        //affichage des stats du héros cuisson
        public override void StatsMenu()
        {
            base.StatsMenu();
            Console.WriteLine("ressource: gaz(" + this.gaz + ")");
        }

        //ajout des attaques cuisson lors de la création du personnage
        public override void SetBaseAttackList()
        {
            base.SetBaseAttackList();
            this.attackList.Add(AttackCuisson.flambage);
            this.attackList.Add(AttackCuisson.thermostat);
        }

        public override void SetBaseInventory()
        {
            base.SetBaseInventory();
            this.inventory.weaponList.Add(Weapon.torche);
        }
    }
}
