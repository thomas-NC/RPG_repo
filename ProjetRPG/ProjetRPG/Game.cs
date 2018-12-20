using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Game
    {
        public HeroConstructor hero;
        public Map map;

        //on crée la liste d'ennemis
        public static Enemy[] enemies = new Enemy[2] 
        {
            new EnemyLegume("oignon", "legume", 150, 30),
            new EnemyLegume("patate", "legume", 200, 20)
        };

        public static Ingredient[] reward = new Ingredient[1]
        {
            new Ingredient("chair sacrée du butternut", "Chair prélevée sur l'horrible Butturnet Pourri, étonnement elle n'est pas périmée, mais extrêmement tendre et savoureuse..")
        };

        public static Enemy[] boss = new Boss[1]
        {
            new Boss("Butternut pourri", "boss", 350, 20, reward[0])
        };

        public static Herb[] herbs = new Herb[3]
        {
            new Herb("romarin",  "Réduit la defense des ennemis"),
            new Herb("thym", "Réduit l'attaque des ennemis"),
            new Herb("coriandre", "inflige 50 points de dégats à l'ennemi (vous ne pouvez pas tuer l'ennemi avec cet objet)"),
            //new Herb("coriandre", "inflige directement des dégats à un ennemi"),
            //new Herb("ogkush", "pacifie votre ennemi pendant les 3 prochains tours")
        };

        public static Spice[] spices = new Spice[3]
        {
            new Spice("paprika", "augmente votre attaque"),
            new Spice("canelle", "augmente votre defense"),
            new Spice("gingembre", "vous soigne de 75hp")
        };

        public static Weapon[] weapons = new Weapon[5]
        {
            new Weapon("spatule", "any", 5, 5, 50),
            new Weapon("louche", "any", 15, 0, 50),
            new Weapon("rape", "any", 20, 0, 0),
            new Weapon("planche à découper", "any" , 0, 10, 100),
            new Weapon("siphon", "any", 30, 10, 50)
        };


        public void StartGame()
        {
            //on crée le hero, on lui donne un inventaire et une liste d'attaques
            hero = HeroConstructor.CreateHero();

            // on génère les attaques de chaque ennemi
            foreach  (Enemy enemy in enemies)
            {
                enemy.SetAttackEnemy();
            }
            foreach (Boss boss in boss)
            {
                boss.SetAttackEnemy();
            }

            //on crée la map et on spawn le joueur dedans
            map = new Map();
            map.CreateMap();
            map.FillMap(hero, enemies);
        }

        public void GameMenu()
        {
            Console.WriteLine(" ------- Menu de Jeu -------\n");
            Console.WriteLine("1) Move");
            Console.WriteLine("2) Inventaire");
            Console.WriteLine("3) Recettes");
            Console.WriteLine("4) Page Perso\n");
            Console.WriteLine("-----------------------------");
            try
            {
                var choix = Console.ReadKey();
                switch (choix.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Déplacez vous sur la map: ");
                        Console.WriteLine("\t haut -> z");
                        Console.WriteLine("\t bas -> s");
                        Console.WriteLine("\t droite -> d");
                        Console.WriteLine("\t gauche -> q");
                        map.MovePlayer(hero);
                        return;

                    case '2':
                    
                        Console.Clear();
                        hero.ShowAllInventory();
                        Console.ReadLine();
                        return;

                    case '4':
                        Console.Clear();
                        hero.FichePerso();
                        Console.ReadLine();
                        return;

                }
            }
            catch (Exception)
            {

                Console.WriteLine("Entrez un nombre entre 1 et 4 svp");
            }
            
        }

        public void NewFrame()
        {   
            MapCase currentCase = map.FindHero();
            if (currentCase.enemyHere != null)
            {
                Console.Clear();
                Console.WriteLine("\nCOMBAT!!!");
                Console.WriteLine("vs " + currentCase.enemyHere.GetName());
                bool result = Fight(hero, currentCase.enemyHere);
                if (result == true)
                {
                    if (map.FindHero().GetTerrain() == "plaine")
                    {
                        map.SpawnBoss("plaine", 4, 9, boss[0], 1);
                    }
                    currentCase.enemyHere = null;
                    currentCase.defeatedEnemy = true;
                }
                else if (result == false)
                {
                    Console.Clear();
                    Console.WriteLine("vous etes mort...");
                    hero.SetHp(100);
                }
            }
            else if (currentCase.chestHere == true )
            {
                Console.Clear();
                Chest chest = new Chest("coffre");
                Console.WriteLine("Vous avez trouvé un coffre!!!");
                Console.WriteLine("Voici son contenu: ");

                string content = chest.SetContent();
                chest.ShowContent();
                Console.ReadLine();
                if (content == "weapon")
                {
                    hero.inventory.weaponList.Add((Weapon)chest.weapon[0]);
                    hero.SetAtt(hero.GetAtt() + chest.weapon[0].statAtt);
                    hero.SetDef(hero.GetDef() + chest.weapon[0].statDef);
                    hero.SetHp(hero.GetHp() + chest.weapon[0].statHp);
                }
                else if (content == "consommable")
                {
                    for (int i = 0; i < chest.herb.Count; i++)
                    {
                        hero.inventory.herbList.Add(chest.herb[i]);
                    }
                    for (int i = 0; i < chest.spice.Count; i++)
                    {
                        hero.inventory.spiceList.Add(chest.spice[i]);
                    }
                }
                

                currentCase.chestHere = false;
                currentCase.openedChest = true;
            }
            else
            {
                Console.Clear();
                map.AfficheMap();
                GameMenu();
            }
            

        }

        #region partie combat
        public string FightMenu(Enemy enemy)
        {
            Console.WriteLine(" ------- Menu de Combat-------\n");
            Console.WriteLine("1) Attaquer");
            Console.WriteLine("2) Utiliser une herbe aromatique");
            Console.WriteLine("3) Utiliser une épice");
            Console.WriteLine("4) Infos ennemi");
            Console.WriteLine("-----------------------------");
            string option = "";
            try
            {
                int choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    case 1:
                        option = "attack";
                        return option;

                    case 2:
                        option = "herb";
                        return option;

                    case 3:
                        option = "spice";
                        return option;
                    case 4:
                        option = "infos";
                        return option;

                }
            }
            catch (Exception)
            {

                Console.WriteLine("Entrez un nombre entre 1 et 4 svp");
            }
            return option;
        }

        public bool Fight(HeroConstructor hero, Enemy enemy)
        {
            string option;
            bool tourJoueur = true;
            bool victoire;
            int enemyHpReset = enemy.GetHp();
            int enemyAttReset = enemy.GetAtt();
            int enemyDefReset = enemy.GetDef();
            int heroHpReset = hero.GetHp();
            int heroAttReset = hero.GetAtt();
            int heroDefReset = hero.GetDef();
            //début du combat

            while (true)
            {
                
                //tour de l'ennemi
                if (tourJoueur == false)
                {
                    
                    Attack atk = enemy.ChoixAttackEnemy();
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
                    
                    tourJoueur = true;
                }
                if (hero.GetHp() <= 0)
                {
                    Console.WriteLine("Vous vous etes fait tuer par " + enemy.GetName());
                    //on reset les stats du joueur et de l'ennemi
                    hero.SetHp(heroHpReset);
                    hero.SetAtt(heroAttReset);
                    hero.SetDef(heroDefReset);
                    enemy.SetHp(enemyHpReset);
                    enemy.SetAtt(enemyAttReset);
                    enemy.SetDef(enemyDefReset);
                    return victoire = false;
                }
                if (tourJoueur == true)
                
                {
                    Console.WriteLine("c'est votre tour!");
                    Console.WriteLine("Hp = " + hero.GetHp() + " /// Att = " + hero.GetAtt() + " /// Def = " + hero.GetDef());
                    option = FightMenu(enemy);
                    if (option == "attack")
                    {
                        hero.AttackMenu();
                        Attack atk = hero.ChoixAttaqueHero();

                        if (hero.GetClasse() == "Découpe" && atk == hero.GetAttacKList()[2])
                        {
                            Console.WriteLine(hero.GetName() + " a lancé l'attaque: " + atk.GetName() + "!");
                            int total = enemy.GetHp();
                            enemy.SetHp(enemy.GetHp() - (atk.GetDamage() + hero.GetAtt() - enemy.GetDef()));
                            enemy.SetHp(enemy.GetHp() - (int)((atk.GetDamage() + hero.GetAtt()) / 2));
                            enemy.SetHp(enemy.GetHp() - (int)((atk.GetDamage() + hero.GetAtt()) / 4));
                            Console.WriteLine("Premier coup ... " + (atk.GetDamage() + hero.GetAtt() - enemy.GetDef()));
                            Console.WriteLine("Deuxième coup ..... " + (int)((atk.GetDamage() + hero.GetAtt()) / 2));
                            Console.WriteLine("Troisième coup ........ " + (int)((atk.GetDamage() + hero.GetAtt()) / 4));
                            Console.WriteLine("Total " + (total - enemy.GetHp()));

                        }
                        else if (hero.GetClasse() == "Découpe" && atk == hero.GetAttacKList()[3])
                        {
                            Console.WriteLine(hero.GetName() + " a lancé l'attaque: " + atk.GetName() + "!");
                            if (enemy.GetHp() <= enemyHpReset/ 2)
                            {
                                enemy.SetHp(enemy.GetHp() - (atk.GetDamage() * 2 + hero.GetAtt() - enemy.GetDef()));
                                Console.WriteLine("Execution!! " + (atk.GetDamage() * 2));
                            }
                            else
                            {
                                Console.WriteLine("Pas d'execution, dommages normaux..");
                                enemy.SetHp(enemy.GetHp() - (atk.GetDamage() + hero.GetAtt() - enemy.GetDef()));
                            }
                        }
                        else if(atk == hero.GetAttacKList()[0] || atk == hero.GetAttacKList()[1])
                        {
                            Console.WriteLine(hero.GetName() + " a lancé l'attaque: " + atk.GetName() + "!");
                            enemy.SetHp(enemy.GetHp() - (atk.GetDamage() + hero.GetAtt() - enemy.GetDef()));
                            Console.WriteLine("vous avez tappé pour " + (atk.GetDamage() + hero.GetAtt()) + " - " + enemy.GetDef() + "armure = " + (atk.GetDamage() + hero.GetAtt() - enemy.GetDef()) + " dommages");
                        }

                        //if ((atk.GetDamage() + hero.GetAtt()) <= enemy.GetDef())
                        //{
                        //    Console.WriteLine(hero.GetName() + " a lancé l'attaque: " + atk.GetName() + "!");
                        //    Console.WriteLine("l'attaque à été complètement bloquée!!!");
                        //}
                        tourJoueur = false;

                    }
                    else if (option == "herb")
                    {
                        Herb herb = hero.ChoixHerbs();
                        if (herb != null)
                        {
                            Console.WriteLine(hero.GetName() + " a utilisé: " + herb.GetName() + "!");
                            if (herb == herbs[0])
                            {
                                if (enemy.GetDef() >= 20) 
                                {
                                    enemy.SetDef(enemy.GetDef() - 20);
                                }
                                else
                                {
                                    enemy.SetDef(0);
                                }
                                Console.WriteLine("la défense de " + enemy.GetName() + " est réduite de 20!");
                            }
                            else if (herb == herbs[1])
                            {
                                if (enemy.GetAtt() >= 20)
                                {
                                    enemy.SetAtt(enemy.GetAtt() - 20);
                                }
                                else
                                {
                                    enemy.SetAtt(0);
                                }
                                Console.WriteLine("l'attaque de " + enemy.GetName() + " est réduite de 20!");
                            }
                            else if (herb == herbs[2])
                            {
                                if (enemy.GetHp() >= 50)
                                {
                                    enemy.SetHp(enemy.GetHp() - 50);
                                }
                                else
                                {
                                    enemy.SetHp(1);
                                }
                                Console.WriteLine(enemy.GetName() + " a subi 50 points de dégats");
                            }
                        }
                        else
                        {
                            Console.WriteLine("vous n'en n'avez pas dans votre inventaire!!");
                        }
                        
                    }
                    else if (option == "spice")
                    {
                        Spice spice = hero.ChoixSpice();
                        if (spice != null)
                        {
                            Console.WriteLine(hero.GetName() + " a utilisé: " + spice.GetName() + "!");
                            if (spice == spices[0])
                            {
                                hero.SetAtt(hero.GetAtt() + 20);
                                Console.WriteLine("Votre attaque a augmenté de 20!");
                            }
                            else if (spice == spices[1])
                            {
                                hero.SetDef(hero.GetDef() + 20);
                                Console.WriteLine("Votre défense a augmenté de 20!");
                            }
                            else if (spice == spices[2])
                            {
                                if (hero.GetHp() + 50 <= heroHpReset)
                                {
                                    hero.SetHp(hero.GetHp() + 50);
                                }
                                else
                                {
                                    hero.SetHp(heroHpReset);
                                }
                                Console.WriteLine("Vous avez récupéré 50hp !!");
                            }
                        
                        }
                        else
                        {
                            Console.WriteLine("vous n'en n'avez pas dans votre inventaire!!");
                        }
                    }
                    else if (option == "infos")
                    {
                        enemy.StatsMenuEnemy();
                        enemy.AttackMenuEnemy();
                    }
                    
                    if (enemy.GetHp() > 0)
                    {
                        Console.WriteLine(enemy.GetName() + " a " + enemy.GetHp() + "hp");
                    }
                }
                if (enemy.GetHp() <= 0)
                {
                    Console.WriteLine(enemy.GetName() + " est mort!!");
                    //on reset les stats du joueur et de l'ennemi
                    hero.SetHp(heroHpReset);
                    hero.SetAtt(heroAttReset);
                    hero.SetDef(heroDefReset);
                    enemy.SetHp(enemyHpReset);
                    enemy.SetAtt(enemyAttReset);
                    enemy.SetDef(enemyDefReset);
                    if (enemy.GetTheType() == "boss")
                    {
                        hero.inventory.ingredientList.Add(enemy.reward);
                    }
                    Console.ReadLine();
                    return victoire = true;
                }
            }
        }
        #endregion
    }
}
