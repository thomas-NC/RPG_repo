using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class EcoleDecoupe : HeroConstructor
    {
        public int energie = 100;
        public int tranchant = 10;
        public EcoleDecoupe(string classe, string name, int hp, int attack, int defense) : base(classe, name, hp, attack, defense)
        {
        }

        public override void StatsMenu()
        {
            base.StatsMenu();
            Console.WriteLine("ressource: energie(" + this.energie + ") and tranchant(" + this.tranchant + ")");
        }

        public override void SetBaseAttackList()
        {
            base.SetBaseAttackList();
            this.attackList.Add(AttackDecoupe.julienne);
            this.attackList.Add(AttackDecoupe.hachage);
        }

        public override void SetBaseInventory()
        {
            base.SetBaseInventory();
            this.inventory.weaponList.Add(Weapon.couteau);
        }
    }
}
