namespace CodedDungeon.States.Menus;

public class Pantheon : StateMenus { // main menu




   public Pantheon(Game game) : base(game) {
      title = "Pantheon";
      mainMenuOptions = new() {
         { "CREATE", 1 },
         { "MODIFY", 2 },
         { "DELETE", 3 },
      };
      cursorPos = 1;
   }

   //actualise le menu 
   public override void Update() {

      do { // tant qu'un choix n'a été fait

         selectedOption = 0;

         Gui.DisplayMenu(title, mainMenuOptions, cursorPos);

         ConsoleKey select = Console.ReadKey(true).Key;

         // controle curseur
         switch (select) {
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
      switch (selectedOption) {
         case 1:
            Console.WriteLine("heros créé !");
            Console.ReadKey(true);
            break;
         case 2:
            Console.WriteLine("heros modofoé");
            Console.ReadKey(true);
            break;
         case 3:
            Console.WriteLine("heros supprimé");
            Console.ReadKey(true);
            break;
         case 4:
            Game.CurrentState = new StateMainMenu(Game);
            break;
         default:
            break;
      }

   }

}
