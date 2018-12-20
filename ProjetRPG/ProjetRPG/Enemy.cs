using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Enemy : Entity
    {
        public Ingredient reward;
        protected int hp;
        protected int def;
        protected int att;
        protected string type;
        public int xp;
        public List<Attack> attackList = new List<Attack>();

        public Enemy(string name, string type, int hp, int att, int def, int xp) : base(name)
        {
            this.type = type;
            this.hp = hp;
            this.att = att;
            this.def = def;
            this.xp = xp;
        }

        public Enemy(int posX, int posY) : base(posX, posY)
        {

        }

        
        public void SetReward(Ingredient reward)
        {
            this.reward = reward;
        }
        public Ingredient GetReward()
        {
            return reward;
        }

        public void SetTheType(string type)
        {
            this.type = type;
        }
        public string GetTheType()
        {
            return type;
        }
        public void SetHp(int hp)
        {
            this.hp = hp;
        }
        public int GetHp()
        {
            return this.hp;
        }

        public void SetDef(int def)
        {
            this.def = def;
        }
        public int GetDef()
        {
            return this.def;
        }

        public void SetAtt(int att)
        {
            this.att = att;
        }
        public int GetAtt()
        {
            return this.att;
        }

        public virtual void SetAttackEnemy()
        {
            attackList.Add(Attack.griffe);
            attackList.Add(Attack.croc);
        }

        public virtual void StatsMenuEnemy()
        {
            Console.WriteLine("\n-- Fiche des stats du monstre --");
            Console.WriteLine("nom: " + name);
            Console.WriteLine("type: " + type);
            Console.WriteLine("hp: " + hp + " att: " + att + " def: " + def);
            Console.WriteLine("xp --> +" + xp);
        }

        public virtual void AttackMenuEnemy()
        {
            Console.WriteLine("\n-- liste des attaques disponibles --");
            for (int i = 0; i < attackList.Count; i++)
            {
                Console.Write("\n" + (i + 1) + ") ");
                attackList[i].ShowAttack();
            }

        }

        public virtual Attack ChoixAttackEnemy()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int choix = r.Next(0, attackList.Count);
            return attackList[choix];
        }

        public static void DoBasicAttack(Attack atk, HeroConstructor hero, Enemy enemy)
        {
            if (atk.GetDamage() <= hero.GetDef())
            {
                Console.WriteLine(enemy.GetName() + " a lancé l'attaque: " + atk.GetName() + "!");
                Console.WriteLine("l'attaque à été complètement bloquée!!!");
            }
            else
            {
                Console.WriteLine(enemy.GetName() + " a lancé l'attaque: " + atk.GetName() + "!");
                hero.SetHp(hero.GetHp() - (atk.GetDamage() + enemy.GetAtt() - hero.GetDef()));
                Console.WriteLine(enemy.GetName() + " vous a tappé pour " + (atk.GetDamage() + enemy.GetAtt()) + " - " + hero.GetDef() + "armure = " + (atk.GetDamage() + enemy.GetAtt() - hero.GetDef()) + " dommages");
                Console.WriteLine("il vous reste " + hero.GetHp() + " pvs");
            }
        }

    }
}
