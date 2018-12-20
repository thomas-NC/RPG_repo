using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetRPG
{
    class Game
    {
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public HeroConstructor hero;
        public Map map;

        //on crée la liste d'ennemis
        public static Enemy[] enemies = new Enemy[4]
        {
            new EnemyPlaine("Oignon géant", "plaine", 150, 10, 30, 30),
            new EnemyPlaine("Patate géante", "plaine", 200, 10, 20, 40),
            new EnemyForet("Champigon mutant", "foret", 500, 10, 50, 100),
            new EnemyForet("Tomate désechée", "foret", 400, 40, 20, 100)
        };

        public static Ingredient[] reward = new Ingredient[2]
        {
            new Ingredient("chair sacrée du Potiron", "Chair prélevée sur l'horrible Potiron Pourri, étonnement elle n'est pas périmée, mais extrêmement tendre et savoureuse.."),
            new Ingredient("morceau de truffe dorée", "Morceau prélevé sur la monstrueuse Truffe toxique, son odeur suffirait à faire s'évanouir la plus robuste des personnes..")
        };

        public static Enemy[] boss = new Boss[2]
        {
            new Boss("Potiron pourri", "bossplaine", 350, 20, 20, 200, reward[0]),
            new Boss("Truffe toxique", "bossforet", 1000, 20, 20, 500, reward[1])
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
        
        //public void SaveGame()
        //{
        //    string heroinfo = (hero.GetName());
                
        //        using (StreamWriter outputFile = new StreamWriter(docPath + @"/TestFolder.txt", true))
        //        {
        //            outputFile.WriteLine("a");
        //        }
        //}

        public void StartGameMenu()
        {
            while (true)
            {
                Console.WriteLine("------ Menu ------");
                Console.WriteLine("1) Lancer la partie ");
                Console.WriteLine("2) Lancer une sauvegarde(en developpement)");
                Console.WriteLine("3) à propos ");
                try
                {
                    int choix = int.Parse(Console.ReadLine());
                    switch (choix)
                    {
                        case 1:
                            StartGame();
                            return;

                        case 2:
                            return;

                        case 3:
                            Console.WriteLine("Projet entièrement réalisé par Thomas Nguyen Cong,");
                            Console.WriteLine("N'hésitez pas à me contacter à l'adresse mail thomas.nguyencong@ynov.com pour toute information");
                            StartGameMenu();
                            return;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("erreur lors de l'entrée, réessayez svp");
                }
            }
        }

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

            GameRun();
        }

        public void GameMenu()
        {
            Console.WriteLine(" ------- Menu de Jeu -------\n");
            Console.WriteLine("1) Move");
            Console.WriteLine("2) Inventaire");
            Console.WriteLine("3) Page Perso");
            Console.WriteLine("4) Créer une sauvegarde\n");
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

                    case '3':
                        Console.Clear();
                        hero.FichePerso();
                        Console.ReadLine();
                        return;

                    case '4':
                        Console.WriteLine();
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
                    else if (map.FindHero().GetTerrain() == "foret")
                    {
                        map.SpawnBoss("foret", 4, 12, boss[1], 1);
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
                    hero.inventory.weaponList.Add(chest.weapon[0]);
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

        public void GameRun()
        {
            while (hero.inventory.ingredientList.Count < 7)
            {
                NewFrame();
            }
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
                    
                    if (enemy.GetTheType() == "plaine" && atk == enemy.attackList[2])
                    {
                        EnemyPlaine.DoOgm(enemy);
                    }
                    else if (enemy.GetTheType() == "plaine" && atk == enemy.attackList[3])
                    {
                        EnemyPlaine.DoPotager(hero, enemy);
                    }
                    else if (enemy.GetTheType() == "foret" && atk == enemy.attackList[2])
                    {
                        EnemyForet.DoOgm2(enemy);
                    }
                    else if (enemy.GetTheType() == "foret" && atk == enemy.attackList[3])
                    {
                        EnemyForet.DoDoubleBaffe(hero, enemy);
                    }
                    else if (enemy.GetTheType() == "bossPlaine")
                    {
                        Enemy.DoBasicAttack(atk, hero, enemy);
                    }
                    else if (enemy.GetTheType() == "bossforet" && atk == enemy.attackList[0] || atk == enemy.attackList[1])
                    {
                        Enemy.DoBasicAttack(atk, hero, enemy);
                    }
                    else if (enemy.GetTheType() == "bossforet" && atk == enemy.attackList[2])
                    {
                        EnemyForet.DoDoubleBaffe(hero, enemy);
                    }
                    else if (enemy.GetTheType() == "bossforet" && atk == enemy.attackList[3])
                    {
                        Boss.DoSpores(hero, enemy);
                    }
                    else if (atk == enemy.attackList[0] || atk == enemy.attackList[1])
                    {
                        Enemy.DoBasicAttack(atk, hero, enemy);
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
                            AttackDecoupe.DoJulienne(hero, enemy);
                        }
                        else if (hero.GetClasse() == "Découpe" && atk == hero.GetAttacKList()[3])
                        {
                            AttackDecoupe.DoHachage(hero, enemy, enemyHpReset);
                        }
                        else if (hero.GetClasse() == "Cuisson" && atk == hero.GetAttacKList()[2])
                        {
                            AttackCuisson.DoFlambage(hero, enemy);
                        }
                        else if (hero.GetClasse() == "Cuisson" && atk == hero.GetAttacKList()[3])
                        {
                            AttackCuisson.DoPyrolise(hero, enemy);
                        }
                        else if (hero.GetClasse() == "Pâte" && atk == hero.GetAttacKList()[2])
                        {
                            AttackPate.DoMalaxage(hero, enemy);
                        }
                        else if (hero.GetClasse() == "Pâte" && atk == hero.GetAttacKList()[3])
                        {
                            AttackPate.DoEtalage(hero, enemy);
                        }
                        else if (atk == hero.GetAttacKList()[0] || atk == hero.GetAttacKList()[1])
                        {
                            Attack.DoBasicAttack(atk, hero, enemy);
                        }

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
                                Herb.UseRomarin(enemy);
                            }
                            else if (herb == herbs[1])
                            {
                                Herb.UseThym(enemy);
                            }
                            else if (herb == herbs[2])
                            {
                                Herb.UseCoriandre(enemy);
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
                                Spice.UsePaprika(hero);
                            }
                            else if (spice == spices[1])
                            {
                                Spice.UseCanelle(hero);
                            }
                            else if (spice == spices[2])
                            {
                                Spice.UseGingembre(hero, heroHpReset);
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
                    //on reset les stats du joueur et de l'ennemis
                    hero.SetHp(heroHpReset);
                    hero.SetAtt(heroAttReset);
                    hero.SetDef(heroDefReset);
                    enemy.SetHp(enemyHpReset);
                    enemy.SetAtt(enemyAttReset);
                    enemy.SetDef(enemyDefReset);

                    if (hero.getXp() + enemy.xp >= hero.getNextLvl())
                    {
                        Console.WriteLine("Vous avez gagné un niveau!!");
                        Console.WriteLine(hero.GetName() + " passe niveau " + (hero.getLvl() + 1) + "!!!");
                        Console.WriteLine("Hp --> +100 | Att --> +10 | Def --> +10");
                        hero.SetXp(enemy.xp - (hero.getNextLvl() - hero.getXp()));
                        hero.SetLvl(hero.getLvl() + 1);
                        hero.SetNextLvl(hero.getNextLvl() * 2 + 50);
                        hero.SetHp(hero.GetHp() + 100);
                        hero.SetAtt(hero.GetAtt() + 10);
                        hero.SetDef(hero.GetDef() + 10);
                    }
                    else if (hero.getXp() + enemy.xp < hero.getNextLvl())
                    {
                        hero.SetXp(hero.getXp() + enemy.xp);
                    }

                    if (enemy.GetTheType() == "bossplaine" || enemy.GetTheType() == "bossforet" || enemy.GetTheType() == "bossmer" || enemy.GetTheType() == "bossdesert" || enemy.GetTheType() == "bossmontagne" || enemy.GetTheType() == "bossruine")
                    {
                        Console.WriteLine("Vous avez gagné \"" + enemy.reward.GetName() + "\"!!!");
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
