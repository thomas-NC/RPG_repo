using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class MapCase : MapLimits
    {
        private int x;
        private int y;
        private string terrain;
        private bool heroHere = false;
        public Enemy enemyHere = null;
        public bool defeatedEnemy = false;
        public bool chestHere = false;
        public bool openedChest = false;
        public bool bossHere = false;

        public MapCase(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //getters setters
        public void SetX(int x)
        {
            this.x = x;
        }
        public int GetX()
        {
            return this.x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }
        public int GetY()
        {
            return this.y;
        }
        
        public void SetTerrain(string terrain)
        {
            this.terrain = terrain;
        }
        public string GetTerrain()
        {
            return this.terrain;
        }

        public void SetHeroHere(bool heroHere)
        {
            this.heroHere = heroHere;
        }
        public bool GetHeroHere()
        {
            return this.heroHere;
        }

        public void AfficheCase()
        {
            
            if (x == 0 && y == 0)
            {
                Console.Write("╚");
            }
            else if (x == 0 && y == (ord - 1))
            {
                Console.Write("╔");
            }
            else if (x == abs - 1 && y == 0)
            {
                Console.Write("╝");
            }
            else if (x == abs-1 && y == ord-1)
            {
                Console.Write("╗");
            }
            else if((x == 0 || x == abs-1) && (y > 0 && y < ord))
            {
                Console.Write("║");
            }
            else if((x > 0 && x < abs) && (y == 0 || y == ord -1))
            {
                Console.Write("═══");
            }

            else if(terrain == "foret" && heroHere == false &&(defeatedEnemy == false && openedChest == false && bossHere == false))
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("<^>");
            }
            else if (terrain == "montagne" && heroHere == false && (defeatedEnemy == false && openedChest == false && bossHere == false))
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write(@"/^\");
            }
            else if(terrain == "plaine" && heroHere == false && (defeatedEnemy == false && openedChest == false && bossHere == false))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(", '");
            }
            else if(terrain == "desert" && heroHere == false && (defeatedEnemy == false && openedChest == false && bossHere == false))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ~ ");
            }
            else if (terrain == "ruine" && heroHere == false && (defeatedEnemy == false && openedChest == false && bossHere == false))
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write("|▓|");
            }
            else if (terrain == "mer" && heroHere == false && (defeatedEnemy == false && openedChest == false && bossHere == false))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write(" ~ ");
            }

            //if (enemyHere != null && heroHere == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.BackgroundColor = ConsoleColor.Red;
            //    Console.Write("[X]");
            //}

            if (heroHere == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("[H]");
            }
            else if(defeatedEnemy == true && heroHere == false && bossHere == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("(X)");
            }
            else if (defeatedEnemy == true && heroHere == false && bossHere == true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("(X)");
            }
            else if (openedChest == true && heroHere == false)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("(O)");
            }
            else if (heroHere == false && bossHere == true && defeatedEnemy == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("[B]");
            }
            Console.ResetColor();

        }
    }
}
