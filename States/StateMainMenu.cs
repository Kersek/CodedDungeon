using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedDungeon.States;
public class StateMainMenu : State{


   public string cursor = "o>";
   public int cursorPos = 1;
   public int selectedOption;

   Dictionary<string, int> mainMenuOptions = new() {
      { "PLAY", 1 },
      { "OPTIONS", 2 }
   };


   public StateMainMenu(Game game) : base(game){
      
   }



   //affiche le menu tant qu'un choix n'a été fait
   public override void Update(){

      do{

         selectedOption = 0;
         Console.Clear();

         foreach (var option in mainMenuOptions){

            if (cursorPos == option.Value){
               Console.ForegroundColor = ConsoleColor.Cyan;
               Console.WriteLine($"{cursor}{option.Key}");
               Console.ResetColor();
            }
            else
              Console.WriteLine($"  {option.Key}");
         }

         if (cursorPos == mainMenuOptions.Count + 1){
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{cursor}QUIT");
            Console.ResetColor();
         }
         else
            Console.WriteLine("  QUIT");

         ConsoleKey select = Console.ReadKey(true).Key;


         // controle curseur
         switch (select){
            case ConsoleKey.Z:
            case ConsoleKey.UpArrow:
               cursorPos -= 1;
               if (cursorPos == 0) { cursorPos = mainMenuOptions.Count + 1; }
               break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
               cursorPos += 1;
               if (cursorPos == mainMenuOptions.Count + 2) { cursorPos = 1; }
               break;
            case ConsoleKey.Enter:
               selectedOption = cursorPos;
               break;
            default:
               break;
         }

      } while (selectedOption == 0);


      // application du choix
      switch (selectedOption){
         case 1:
            Game.CurrentState = new StateAdventure(Game);
            break;
         case 2:
            Game.CurrentState = new StateAdventure(Game);
            break;
         case 3:
            Game.Quitting();
            break;
         default:
            break;
      }

   }

}
