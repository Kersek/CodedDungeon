using CodedDungeon.Entities;

namespace CodedDungeon.States.Menus;


/////// RENDRED LES TRUCS PRIVES ???

public abstract class Menus : State { // classe mère de mainmenu, panthéon et gameoptions


   public int cursorPos;
   public int selectedOption;

   public string title;
   public Dictionary<string, int> MenuOptions;


   public Menus(Game game) : base(game) { }


   public override void Update() { 

      do { // tant qu'un choix n'a été fait

         selectedOption = 0;

         Gui.DisplayMenu(title, MenuOptions, cursorPos);
         if ((title == "Pantheon" || title == "Coded Dungeon") && this.CurrentHero != null) { 
            Console.WriteLine($"{this.CurrentHero.Name} is ready to fight !");
            Console.WriteLine(CurrentHero.Position.ToString());
            }


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
            case ConsoleKey.NumPad0:
            case ConsoleKey.Tab:
               foreach (Hero hero in HeroesList) {
                  if (cursorPos == (HeroesList.IndexOf(hero)) + 1) {
                     
                  }                     
               }
               break;
            default:
               break;
         }

      } while (selectedOption == 0);
      SelectOption(); // celle des enfants
   }

   // en abstract pour que ce soit celle des enfants instancies qui soit appelée !?
   public abstract void SelectOption();
}
