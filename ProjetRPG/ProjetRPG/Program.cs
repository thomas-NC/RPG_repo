using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Program
    {
        static void Main(string[] args)
        {

            //HeroConstructor hero = HeroConstructor.CreateHero();
            //Map map = new Map();
            //Enemy oignon = new Enemy("oignon", "legume", 150, 30);
            //oignon.SetAttackEnemy();
            //oignon.StatsMenuEnemy();
            //oignon.AttackMenuEnemy();
            //hero.SetBaseInventory();

            //hero.ShowAllInventory();
            Console.WriteLine(@"      _                          ____                          _     
     | | ___ _   _ _ __   ___   / ___|___  _ __ ___  _ __ ___ (_)___ 
  _  | |/ _ \ | | | '_ \ / _ \ | |   / _ \| '_ ` _ \| '_ ` _ \| / __|
 | |_| |  __/ |_| | | | |  __/ | |__| (_) | | | | | | | | | | | \__ \
  \___/ \___|\__,_|_| |_|\___|  \____\___/|_| |_| |_|_| |_| |_|_|___/
                                                                     ");
            Console.WriteLine(@"  ____             _                _              ____ _           __ 
 |  _ \  _____   _(_) ___ _ __   __| |_ __ __ _   / ___| |__   ___ / _|
 | | | |/ _ \ \ / / |/ _ \ '_ \ / _` | '__/ _` | | |   | '_ \ / _ \ |_ 
 | |_| |  __/\ V /| |  __/ | | | (_| | | | (_| | | |___| | | |  __/  _|
 |____/ \___| \_/ |_|\___|_| |_|\__,_|_|  \__,_|  \____|_| |_|\___|_|  
                                                                       ");
            AffichageTexte.AfficheTexte("Bienvenue dans le fabuleux monde Gourmet!! " +
                "\nDans cet univers, les ingrédients ont pris vie et ont chassé les humains des villages et des villes..." +
                "\nVous etes un jeune commis de cuisine issu d'une grande école de cuisine dont le chef à été tué par le terrible Boeuf de Kobe!" +
                "\nA vous de parcourir ce monde en quête de vengeance, d'aventure, ou simplement en quête de massacrer des oignons et patates géantes!!! \n\n");


            Game game = new Game();
            game.StartGameMenu();







            Console.ReadLine();

            
        }
    }
}
