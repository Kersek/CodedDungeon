namespace CodedDungeon.States.Menus;


public abstract class Menus : State { /////// RENDRED LES TRUCS PRIVES


   public int cursorPos;
   public int selectedOption;

   public string title;
   public Dictionary<string, int> MenuOptions;


   public Menus(Game game) : base(game) { }


   public override void Update() {

      do { // tant qu'un choix n'a été fait

         selectedOption = 0;

         Gui.DisplayMenu(title, MenuOptions, cursorPos);

         ConsoleKey select = Console.ReadKey(true).Key;

         // controle curseur
         switch (select) {
            case ConsoleKey.Z:
            case ConsoleKey.UpArrow:
               cursorPos -= 1;
               if (cursorPos == 0) { cursorPos = MenuOptions.Count + 1; }
               break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
               cursorPos += 1;
               if (cursorPos == MenuOptions.Count + 2) { cursorPos = 1; }
               break;
            case ConsoleKey.Enter:
               selectedOption = cursorPos;
               break;
            default:
               break;
         }

      } while (selectedOption == 0);
      SelectOption(); // celle des enfants
   }

   public abstract void SelectOption();
}
