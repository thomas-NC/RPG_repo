using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class EcolePate : HeroConstructor
    {
        public int energie = 100;
        public int petrissage = 5;

        public EcolePate(string classe, string name, int hp, int attack, int defense) : base(classe, name, hp, attack, defense)
        {
        }

        public override void StatsMenu()
        {
            base.StatsMenu();
            Console.WriteLine("ressource: energie(" + this.energie + ") and petrissage(" + this.petrissage + ")");
        }

        public override void SetBaseAttackList()
        {
            base.SetBaseAttackList();
            this.attackList.Add(AttackPate.malaxage);
            this.attackList.Add(AttackPate.etalage);
        }

        public override void SetBaseInventory()
        {
            base.SetBaseInventory();
            this.inventory.weaponList.Add(Weapon.rouleau);
        }
    }
}
