namespace CodedDungeon.States.Menus;

public class StateMainMenu : StateMenus { // main menu




   public StateMainMenu(Game game) : base(game) {
      title = "Coded Dungeon";
      mainMenuOptions = new() {
         { "PLAY", 1 },
         { "PANTHEON", 2 }
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
            Game.CurrentState = new StateAdventure(Game);
         break;
         case 2:
            Game.CurrentState = new Pantheon(Game); // Pantheon state 
         break;
         case 3:
            Game.Quitting();
         break;
         default:
         break;
      }

   }

}
