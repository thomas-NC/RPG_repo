using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Map : MapLimits
    {
        
        public List<MapCase> cases = new List<MapCase>();
        
         

        public Map()
        {

        }

        public void AfficheMap()
        {
            for (int i = 0; i < cases.Count; i++)
            {
                cases[i].AfficheCase();
                if (cases[i].GetX() == abs - 1)
                {
                    Console.WriteLine();
                }
            }
        }

        //création de la map
        public void CreateMap()
        {
            int[,] grid = new int[abs, ord];
            for (int z = 0;  z < ord; z++)
            {
                for (int x = 0; x < abs; x++)
                {
                    int y = ord - z - 1;
                    MapCase point = new MapCase(x, y);
                    if (((x >= 1 && x <= 9) && (y >= 11 && y <= 14)) || ((x >= 1 && x <= 7) && y == 10) || (x == 10 && (y == 14 || y == 13)))
                    {
                        point.SetTerrain("foret");
                    }
                    else if (((x >= 11 && x <= 14) && (y >= 9 && y <= 14)) || (x == 10 && (y <= 12 && y >= 10)))
                    {
                        point.SetTerrain("montagne");
                    }
                    else if (((x >= 10 && x <= 14) && (y >= 1 && y <= 3)) || (x == 9 && (y == 1 || y == 2)) || (y == 4 && (x == 12 || x == 13 || x == 14)))
                    {
                        point.SetTerrain("ruine");
                    }
                    else if (((x >= 1 && x <= 5) && (y >= 5 && y <= 9)) || (x == 6 && (y == 7 || y == 8)) || (y == 4 && (x >= 1 && x <= 4)) || (y == 3 && (x == 1 || x == 2)))
                    {
                        point.SetTerrain("plaine");
                    }
                    else if (((x >= 1 && x <= 8) && (y >= 1 && y <= 2)) || (y == 3 && (x >= 3 && x <= 9)) || (y == 4 && (x == 5 || x == 6)))
                    {
                        point.SetTerrain("mer");
                    }
                    else
                    {
                        point.SetTerrain("desert");
                    }
                    
                    cases.Add(point);
                }
            }
        }

        public void FillMap(HeroConstructor hero, Enemy[] enemies)
        {
            //instanciation du héro
            for (int i = 0; i < cases.Count; i++)
            {
                if (cases[i].GetX() == 3 && cases[i].GetY() == 6)
                {
                    hero.posX = 3;
                    hero.posY = 6;
                    cases[i].SetHeroHere(true);
                }
                
                //instanciation des oigons
                else if(cases[i].GetX() == 1 && cases[i].GetY() == 4)
                {
                    cases[i].enemyHere = enemies[0];
                }
                else if (cases[i].GetX() == 2 && cases[i].GetY() == 7)
                {
                    cases[i].enemyHere = enemies[0];
                }
                else if (cases[i].GetX() == 5 && cases[i].GetY() == 5)
                {
                    cases[i].enemyHere = enemies[0];
                }

                //ajout des patates
                else if (cases[i].GetX() == 2 && cases[i].GetY() == 3)
                {
                    cases[i].enemyHere = enemies[1];
                }
                else if (cases[i].GetX() == 1 && cases[i].GetY() == 9)
                {
                    cases[i].enemyHere = enemies[1];
                }
                else if (cases[i].GetX() == 4 && cases[i].GetY() == 8)
                {
                    cases[i].enemyHere = enemies[1];
                }

                

                //ajout des coffres
                else if (cases[i].GetX() == 1 && cases[i].GetY() == 3)
                {
                    cases[i].chestHere = true;
                }
                else if (cases[i].GetX() == 2 && cases[i].GetY() == 8)
                {
                    cases[i].chestHere = true;
                }
                else if (cases[i].GetX() == 6 && cases[i].GetY() == 8)
                {
                    cases[i].chestHere = true;
                }
                

            }
            
        }

        public MapCase FindHero()
        {
            for (int i = 0; i < cases.Count; i++)
            {
                if (cases[i].GetHeroHere() == true )
                {
                    return cases[i];
                }
            }
            return null;
        }
        public MapCase FindCase(int x, int y)
        {
            for (int i = 0; i < cases.Count; i++)
            {
                if (cases[i].GetX() == x && cases[i].GetY() == y)
                {
                    return cases[i];
                }
            }
            return null;
        }

        public void SpawnBoss(string terrain, int posX, int posY, Enemy choixBoss, int conditionSpawn)
        {
            int spawnBoss = 1;
            for (int i = 0; i < cases.Count; i++)
            {
                if (cases[i].GetTerrain() ==terrain && cases[i].defeatedEnemy == true)
                {
                    spawnBoss++;
                }
                
            }
            if (spawnBoss >= conditionSpawn)
            {
                Console.WriteLine(choixBoss.GetName() + " est arrivé sur la map!!!");
                FindCase(posX, posY).bossHere = true;
                FindCase(posX, posY).enemyHere = choixBoss;
            }
        }

        //fonction appelée a chaque fois que le héros se déplace
        //lance également le combat si on va sur une case contenant un ennemi
        public void MovePlayer(HeroConstructor hero)
        {
            MapCase currentCase = FindHero();
            MapCase droite = FindCase(currentCase.GetX() + 1, currentCase.GetY());
            MapCase gauche = FindCase(currentCase.GetX() - 1, currentCase.GetY());
            MapCase bas = FindCase(currentCase.GetX(), currentCase.GetY() - 1);
            MapCase haut = FindCase(currentCase.GetX(), currentCase.GetY() + 1);

            ConsoleKeyInfo direction = Console.ReadKey();
            if (direction.KeyChar == 'z' && haut.GetY() <= 14)
            {
                currentCase.SetHeroHere(false);
                haut.SetHeroHere(true);
            }
            else if (direction.KeyChar == 'd' && droite.GetX() <= 14)
            {
                currentCase.SetHeroHere(false);
                droite.SetHeroHere(true);
            }
            else if (direction.KeyChar == 's' && bas.GetY() >= 1)
            {
                currentCase.SetHeroHere(false);
                bas.SetHeroHere(true);
            }
            else if (direction.KeyChar == 'q' && gauche.GetX() >= 1)
            {
                currentCase.SetHeroHere(false);
                gauche.SetHeroHere(true);
            }
        }
    }
}
