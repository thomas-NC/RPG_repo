﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class AttackPate : Attack
    {
        //ressources des attaques de pate
        public int coutEnergie;
        public int petrissage;

        public AttackPate(string name, int damage, string effect, int energie, int petrissage) : base(name, damage, effect)
        {
            coutEnergie = energie;
            this.petrissage = petrissage;
        }

        public void SetCoutEnergie(int coutEnergie)
        {
            this.coutEnergie = coutEnergie;
        }
        public int GetCoutEnergie()
        {
            return coutEnergie;
        }

        public void SetPetrissage(int petrissage)
        {
            this.petrissage = petrissage;
        }
        public int GetPetrissage()
        {
            return this.petrissage;
        }

        //liste des attaques de la pate
        public static AttackPate malaxage = new AttackPate("malaxage", 30, "inflige de faibles dégats ,mais augmente la défense", 25, 1);
        public static AttackPate etalage = new AttackPate("étalage", 150, "finisher, inflige des dégats en fonction du niveau de pétrissage", 50, 0);

        public override void ShowAttack()
        {
            base.ShowAttack();
            Console.WriteLine("cout: energie(" + this.coutEnergie + ")");
            Console.WriteLine("petrissage: " + this.petrissage);
        }

    }
}
