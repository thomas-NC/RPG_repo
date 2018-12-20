using System;
using System.Collections.Generic;

namespace ProjetRPG
{
    abstract class HeroConstructor : Entity
    {
        protected string classe;
        protected int hp;
        protected int att;
        protected int def;
        protected List<Attack> attackList = new List<Attack>();
        public Inventory inventory = new Inventory();
        public HeroConstructor(string name, string classe, int hp, int attack, int defense) : base(name)
        {
            this.classe = classe;
            this.hp = hp;
            this.att = attack;
            this.def = defense;
        }
        
        public HeroConstructor(int posX, int posY) : base(posX, posY)
        {
           
        }

        //getters setters
        public void SetHp(int hp)
        {
            this.hp = hp;
        }
        public int GetHp()
        {
            return this.hp;
        }

        public void SetAtt(int att)
        {
            this.att = att;
        }
        public int GetAtt()
        {
            return this.att;
        }

        public void SetDef(int def)
        {
            this.def = def;
        }
        public int GetDef()
        {
            return this.def;
        }

        public void SetClasse(string classe)
        {
            this.classe = classe;
        }
        public string GetClasse()
        {
            return classe;
        }

        #region creation personnage
        // fonction pour choisir la classe et le nom du personnage, puis le créer
        public static HeroConstructor CreateHero()
        {
            Console.WriteLine("Choissisez votre classe: ");
            Console.WriteLine("1) Ecole de la Cuisson\n" +
                "\nL'Ecole de l'illustre chef Etchebast, vous commencez avec une torche pour pouvoir bien flamber vos ennemis!!" +
                "\nVos attaques sont dévastatrices, mais votre défense n'est pas votre point fort.." +
                "\n\nHp: 200 | Att: 20 | Def: 0" +
                "\n Attaques: coup de poing | highkick | flambage | thermostat\n\n");
            Console.WriteLine("2) Ecole de la Découpe\n" +
                "\nL'Ecole de l'illustre chef Bocouse, vous commencez avec un couteau aiguisé et des techniques de découpe ultimes!!" +
                "\nVotre attaque et votre défense sont equilibrées, comme votre maitrîse des arts culinaires" +
                "\n\nHp: 200 | Att: 10 | Def: 10" +
                "\n Attaques: coup de poing | highkick | julienne | hachage\n\n");
            Console.WriteLine("3) Ecole de la Découpe\n" +
                "\nL'Ecole de l'illustre chef Marxo, vous commencez avecun rouleau a pâtisserie et un corps super musclé" +
                "\nA force de malaxer la pâte, vous avez développé une défense incroyable" +
                "\n\nHp: 200 | Att: 00 | Def: 20" +
                "\n Attaques: coup de poing | highkick | malaxer | étaler\n\n");
            while (true)
            {
                try
                {             
                    int i = int.Parse(Console.ReadLine());
                    switch (i)
                    {
                        case 1:                                                         
                            Console.WriteLine("Choississez un nom à votre héros(entre 2 et 15 caractères): ");
                            string name = Console.ReadLine();
                            while (name.Length <=1 || name.Length >= 15)
                            {
                                Console.WriteLine("nom trop court ou trop long, réessayez svp: ");
                                name = Console.ReadLine();
                            }
                            HeroConstructor heroCuisson = new EcoleCuisson(name, "Cuisson", 200, 20, 0);
                            heroCuisson.SetBaseAttackList();
                            heroCuisson.SetBaseInventory();
                            return heroCuisson;

                        case 2:
                            Console.WriteLine("Choississez un nom à votre héros: ");
                            string name2 = Console.ReadLine();
                            while (name2.Length <= 1 || name2.Length >= 15)
                            {
                                Console.WriteLine("nom trop court ou trop long, réessayez svp: ");
                                name2 = Console.ReadLine();
                            }
                            HeroConstructor heroDecoupe = new EcoleDecoupe(name2, "Découpe", 200, 10, 10);
                            heroDecoupe.SetBaseAttackList();
                            heroDecoupe.SetBaseInventory();
                            return heroDecoupe;

                        case 3:
                            Console.WriteLine("Choississez un nom à votre héros: ");
                            string name3 = Console.ReadLine();
                            while (name3.Length <= 1 || name3.Length >= 15)
                            {
                                Console.WriteLine("nom trop court ou trop long, réessayez svp: ");
                                name3 = Console.ReadLine();
                            }
                            HeroConstructor heroPate = new EcolePate(name3, "Pâte", 200, 10, 10);
                            heroPate.SetBaseAttackList();
                            heroPate.SetBaseInventory();
                            return heroPate;
                            
                    }
                    if (i > 3)
                    {
                        Console.WriteLine("entrez une valeur entre 1 et 3 svp: ");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("mauvaise entrée, réessayez svp");
                    Console.WriteLine("Choissisez votre classe: ");
                    Console.WriteLine("1- Ecole de la cuisson");
                    Console.WriteLine("2- Ecole de la découpe");
                    Console.WriteLine("3- Ecole de la pâte");
                }

            }

        }
        #endregion

        #region fonction de gestion des attaques

        //getter setter
        public List<Attack> GetAttacKList()
        {
            return this.attackList;
        }
        public void SetAttackList(Attack atk1, Attack atk2, Attack atk3, Attack atk4)
        {
            this.attackList.Add(atk1);
            this.attackList.Add(atk2);
            this.attackList.Add(atk3);
            this.attackList.Add(atk4);
        }
            //setter des attaques de base
        public virtual void SetBaseAttackList()
        {
            this.attackList.Add(Attack.punch);
            this.attackList.Add(Attack.kick);
        }

        //affichage des stats et des attaques
        public virtual void StatsMenu()
        {
            Console.WriteLine("\n-- Fiche des stats de votre héros --");
            Console.WriteLine("nom: " + this.name);
            Console.WriteLine("classe: " + this.classe);
            Console.WriteLine("hp: " + this.hp + " att: " + this.att + " def: " + this.def);
        }
        public virtual void AttackMenu()
        {
            Console.WriteLine("\n-- liste des attaques disponibles --");
            for (int i = 0; i < this.attackList.Count; i++)
            {
                Console.Write("\n" + (i + 1) + ") ");
                this.attackList[i].ShowAttack();
            }
                       
        }

            //menu du choix des attaques
        public Attack ChoixAttaqueHero()
        {
            while (true)
            {
                Console.WriteLine("\nchoix de l'attaque [1, 2, 3, 4]");
                try
                {
                    int i = int.Parse(Console.ReadLine());
                    switch (i)
                    {
                        case 1:
                            return attackList[0];
                        case 2:
                            return attackList[1];
                        case 3:
                            return attackList[2];
                        case 4:
                            return attackList[3];
                    }
                    if (i > 4)
                    {
                        Console.WriteLine("erreur, reessayez svp: ");
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("erreur, reessayez svp: ");
                }
                
            }
        }
        #endregion

        #region fonctions de gestion de l'inventaire
        public virtual void SetBaseInventory()
        {
            inventory.herbList.Add(Game.herbs[0]);
            inventory.spiceList.Add(Game.spices[0]);
        }

        public int FindItems(Item item)
        { 
            int compteur = 0;
            for (int i = 0; i < inventory.herbList.Count; i++)
            {
                if (item == inventory.herbList[i])
                {
                    compteur++;
                }
            }
            for (int i = 0; i < inventory.spiceList.Count; i++)
            {
                if (item == inventory.spiceList[i])
                {
                    compteur++;
                }
            }
            return compteur;
        }

        public void ShowAllInventory()
        {
            Console.WriteLine(" ---  Liste des Armes possédées  ---\n");
            if (inventory.weaponList == null) 
            {
                Console.WriteLine("pas d'arme dans l'inventaire");
            }
            else if (inventory.weaponList != null)
            {
                for (int i = 0; i < inventory.weaponList.Count; i++)
                {
                    Console.WriteLine("Arme n" + (i + 1) + "--> " + inventory.weaponList[i].GetName());
                    Console.WriteLine("\t Att-> " + inventory.weaponList[i].statAtt + " Def->" + inventory.weaponList[i].statDef + " Hp->" + inventory.weaponList[i].statHp);
                }
            }

            Console.WriteLine("\n ---  List des Epices possédées  --- \n");
            if (inventory.spiceList == null)
            {
                Console.WriteLine("pas d'epice dans l'inventaire");
            }
            else if (inventory.spiceList != null)
            {
                Console.WriteLine("Paprika x " + FindItems(Game.spices[0]) + " --> " + Game.spices[0].effect);
                Console.WriteLine("Canelle x " + FindItems(Game.spices[1]) + " --> " + Game.spices[1].effect);
                Console.WriteLine("Gingembre x " + FindItems(Game.spices[2]) + " --> " + Game.spices[2].effect);
            }

            Console.WriteLine("\n ---  Liste de Herbes possédées  --- \n");
            if (inventory.herbList == null)
            {
                Console.WriteLine("pas d'herbe dans l'inventaire");
            }
            else if (inventory.herbList != null)
            {
                Console.WriteLine("Thym x " + FindItems(Game.herbs[0]) + " --> " + Game.herbs[0].effect);
                Console.WriteLine("Romarin x " + FindItems(Game.herbs[1]) + " --> " + Game.herbs[1].effect);
                Console.WriteLine("Coriandre x " + FindItems(Game.herbs[2]) + " --> " + Game.herbs[2].effect);          
            }

            Console.WriteLine("\n ---  Liste des Ingrédients sacrés possédées  ---\n");
            if (inventory.ingredientList == null)
            {
                Console.WriteLine("inventaire vide");
            }
            else if (inventory.ingredientList != null)
            {
                for (int i = 0; i < inventory.ingredientList.Count; i++)
                {
                    Console.WriteLine("Ingrédient sacré n" + (i + 1) + "--> " + inventory.ingredientList[i].GetName());
                    Console.WriteLine("\nDescription: " + inventory.ingredientList[i].description);
                }
            }
        }

        public Spice ChoixSpice()
        {
            Spice empty = null;
            try
            {
                Console.WriteLine("-- Choisissez une épice --");
                Console.WriteLine("\t1) Paprika x " + FindItems(Game.spices[0]) + " --> " + Game.spices[0].effect);
                Console.WriteLine("\t2) Canelle x " + FindItems(Game.spices[1]) + " --> " + Game.spices[1].effect);
                Console.WriteLine("\t3) Gingembre x " + FindItems(Game.spices[2]) + " --> " + Game.spices[2].effect);
                Console.WriteLine("\t4) Retour au menu");
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        if (FindItems(Game.spices[0]) > 0)
                        {
                            inventory.spiceList.Remove(Game.spices[0]);
                            return Game.spices[0];
                        }
                        else
                        {
                            return empty;
                        }
                    case 2:
                        if (FindItems(Game.spices[1]) > 0)
                        {
                            inventory.spiceList.Remove(Game.spices[1]);
                            return Game.spices[1];
                        }
                        else
                        {
                            return empty;
                        }

                    case 3:
                        if (FindItems(Game.spices[2]) > 0)
                        {
                            inventory.spiceList.Remove(Game.spices[0]);
                            return Game.spices[2];
                        }
                        else
                        {
                            return empty;
                        }
                }
                if (i > 4)
                {
                    Console.WriteLine("erreur, reessayez svp: ");
                }
                

            }
            catch (Exception)
            {
                Console.WriteLine("erreur, reessayez svp: ");
            }
            return empty;
        }

        public Herb ChoixHerbs()
        {
            Herb empty = null;
            try
            {
                Console.WriteLine("-- Choisissez une herbe aromatique --");
                Console.WriteLine("\t1) Romarin x " + FindItems(Game.herbs[0]) + " --> " + Game.herbs[0].effect);
                Console.WriteLine("\t2) Thym x " + FindItems(Game.herbs[1]) + " --> " + Game.herbs[1].effect);
                Console.WriteLine("\t3) Coriandre x " + FindItems(Game.herbs[2]) + " --> " + Game.herbs[2].effect);
                Console.WriteLine("\t4) Retour au menu");
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        if (FindItems(Game.herbs[0]) > 0)
                        {
                            inventory.herbList.Remove(Game.herbs[0]);
                            return Game.herbs[0];
                        }
                        else
                        {
                            return empty;
                        }
                    case 2:
                        if (FindItems(Game.herbs[1]) > 0)
                        {
                            inventory.herbList.Remove(Game.herbs[1]);
                            return Game.herbs[1];
                        }
                        else
                        {
                            return empty;
                        }

                    case 3:
                        if (FindItems(Game.herbs[2]) > 0)
                        {
                            inventory.herbList.Remove(Game.herbs[2]);
                            return Game.herbs[2];
                        }
                        else
                        {
                            return empty;
                        }
                }
                if (i > 4)
                {
                    Console.WriteLine("erreur, reessayez svp: ");
                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("erreur, reessayez svp: ");
            }
            return empty;
        }
        #endregion

        //affichage de la fiche personnage
        public void FichePerso()
        {
            Console.WriteLine(" --------- Fiche Personnage --------- \n");
            Console.WriteLine(name + " de l'école de la " + classe);
            Console.WriteLine("Attaque --> " + att);
            Console.WriteLine("Défense --> " + def);
            Console.WriteLine("Hp --> " + hp + "\n");

            Console.WriteLine("--------- Liste des Attaques --------- \n");
            for (int i = 0; i < attackList.Count; i++)
            {
                attackList[i].ShowAttack();
            }
        }

    }
}
