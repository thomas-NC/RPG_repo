using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class AttackDecoupe : Attack
    {
        // ressource des attaques de découpe
        private int coutEnergie;
        private int coutTranchant;

        public AttackDecoupe(string name, int damage, string effect, int energie, int tranchant) : base(name, damage, effect)
        {
            coutEnergie = energie;
            coutTranchant = tranchant;
        }

        public void SetCoutEnergie(int coutEnergie)
        {
            this.coutEnergie = coutEnergie;
        }
        public int GetCoutEnergie()
        {
            return coutEnergie;
        }

        public void SetCoutTranchant(int coutTranchant)
        {
            this.coutTranchant = coutTranchant;
        }
        public int GetCoutTranchant()
        {
            return this.coutTranchant;
        }

        //liste attaques de l'ecole de la découpe
        public static AttackDecoupe julienne = new AttackDecoupe("julienne", 60, "Attaque qui frappe 3 fois, chaque nouvelle frappe inflige moitié moins de dégats(les 2 frappes supplémentaires ignorent l'armure)",25 ,3);
        public static AttackDecoupe hachage = new AttackDecoupe("hachage", 80, "Attaque basique de découpe, les dégats sont doublés si l'adversaire a < 50% hp", 40, 2);



        public override void ShowAttack()
        {
            base.ShowAttack();
            Console.WriteLine("-cout : " + this.coutEnergie + " energie and " + this.coutTranchant + " tranchant");
        }

        //at
        public static void DoJulienne(HeroConstructor hero, Enemy enemy)
        {
            Console.WriteLine(hero.GetName() + " a lancé l'attaque: " + julienne.GetName() + "!");
            int total = enemy.GetHp();
            enemy.SetHp(enemy.GetHp() - (julienne.GetDamage() + hero.GetAtt() - enemy.GetDef()));
            enemy.SetHp(enemy.GetHp() - (int)((julienne.GetDamage() + hero.GetAtt()) / 2));
            enemy.SetHp(enemy.GetHp() - (int)((julienne.GetDamage() + hero.GetAtt()) / 4));
            Console.WriteLine("Premier coup ... " + (julienne.GetDamage() + hero.GetAtt() - enemy.GetDef()));
            Console.WriteLine("Deuxième coup ..... " + (int)((julienne.GetDamage() + hero.GetAtt()) / 2));
            Console.WriteLine("Troisième coup ........ " + (int)((julienne.GetDamage() + hero.GetAtt()) / 4));
            Console.WriteLine("Total " + (total - enemy.GetHp()));
        }

        public static void DoHachage(HeroConstructor hero, Enemy enemy, int enemyMaxHp)
        {
            Console.WriteLine(hero.GetName() + " a lancé l'attaque: " + hachage.GetName() + "!");
            if (enemy.GetHp() <= enemyMaxHp / 2)
            {
                enemy.SetHp(enemy.GetHp() - ((hachage.GetDamage() + hero.GetAtt())*2 - enemy.GetDef()));
                Console.WriteLine("Execution!! " + ((hachage.GetDamage() + hero.GetAtt()) * 2));
            }
            else
            {
                Console.WriteLine("Pas d'execution, dommages normaux.." + (hachage.GetDamage() + hero.GetAtt()));
                enemy.SetHp(enemy.GetHp() - (hachage.GetDamage() + hero.GetAtt() - enemy.GetDef()));
            }
        }
    }
}
