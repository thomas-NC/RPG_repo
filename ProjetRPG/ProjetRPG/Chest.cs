using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Chest : Item
    {
        public List<Weapon> weapon = new List<Weapon>();
        public List<Herb> herb = new List<Herb>();
        public List<Spice> spice = new List<Spice>();

        public Chest(string name) : base(name)
        {
        }

        public string SetContent()
        {
            string typeContent = "";
            //on génère le contenu de facon random
            Random r = new Random(DateTime.Now.Millisecond);
            int choix = r.Next(1, 6);

            if (choix == 1 || choix == 2)
            {
                // 20% de chances de trouver une arme
                weapon.Add(Game.weapons[r.Next(0, Game.weapons.Length)]);
                return typeContent = "weapon";
            }
            else if (choix >= 3 && choix <= 5)
            {
                // 60% de chances de trouver (1 à 3) herbes et (1 à 3) épices
                for (int i = 0; i < r.Next(1, 4); i++)
                {
                    herb.Add(Game.herbs[r.Next(0, Game.herbs.Length)]);
                }
                for (int i = 0; i < r.Next(1, 4); i++)
                {
                    spice.Add(Game.spices[r.Next(0, Game.spices.Length)]);
                }
                return typeContent = "consommable";
            }
            return typeContent;
        }

        public void ShowContent()
        {
            foreach (Item item in weapon)
            {
                Console.WriteLine("Item --> " + item.GetName());
            }
            foreach (Item item in herb)
            {
                Console.WriteLine("Item --> " + item.GetName());
            }
            foreach (Item item in spice)
            {
                Console.WriteLine("Item --> " + item.GetName());
            }
        }
    }
}
