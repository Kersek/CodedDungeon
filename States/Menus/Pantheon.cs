﻿using CodedDungeon.Entities;

namespace CodedDungeon.States.Menus;

public class Pantheon : Menus { // Heroes management
   
   


   public Pantheon(Game game) : base(game) {

      title = "Pantheon";
      MenuOptions = new() {
         { "CREATE Hero", 1 },
         { "SELECT Hero", 2 },
         { "DELETE Hero", 3 },
      };
      cursorPos = 1;
   }


   public override void SelectOption() {
      switch (selectedOption) {
         case 1:
            CreateHero();
            break;
         case 2:
            if (HeroesList.Count == 0)
               Console.WriteLine("NO HERO");
            else
               SelectHero();
            break;
         case 3:
            Console.WriteLine("delete a hero");
            break;
         case 4:
            Game.CurrentHero = this.CurrentHero;
            Game.HeroesList = this.HeroesList;
            Game.CurrentState = new MainMenu(Game);
            break;
         default:
            break;
      }
      
   }



   public void SelectHero() {

      cursorPos = 1;

      Dictionary<string,int> HeroesDico = new();
      int i = 0;
      foreach (Hero hero in HeroesList)
         HeroesDico.Add(hero.ToString(),++i);

      do { // tant qu'un choix n'a été fait

         selectedOption = 0;
         
         Gui.DisplayMenu("Heroes", HeroesDico, cursorPos);

         ConsoleKey select = Console.ReadKey(true).Key;

         // controle curseur
         switch (select) {
            case ConsoleKey.Z:
            case ConsoleKey.UpArrow:
               cursorPos -= 1;
               if (cursorPos == 0) { cursorPos = HeroesList.Count + 1; }
               break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
               cursorPos += 1;
               if (cursorPos == HeroesList.Count + 2) { cursorPos = 1; }
               break;
            case ConsoleKey.Enter:
               selectedOption = cursorPos;
               break;
            case ConsoleKey.Escape:
               Game.CurrentHero = this.CurrentHero;
               Game.HeroesList = this.HeroesList;
               Game.CurrentState = new Pantheon(Game); // Pantheon state 
               break;
            default:
               break;
         }

         foreach (Hero hero in HeroesList) {
            if (selectedOption == (HeroesList.IndexOf(hero))+1) {
               Console.WriteLine($"{hero.Name} selected !");
               this.CurrentHero = hero;
            }
         }

      } while (selectedOption == 0);

   }

   public void CreateHero() { // verifs inputs    ////creer differents genre de heros
      Console.WriteLine("Name ?");
      string name = Console.ReadLine();
      Hero hero = new Hero(name);
      HeroesList.Add(hero);
      Console.WriteLine($"{hero.Name} arises...");
      Console.WriteLine("New Hero created !");
   }


}
