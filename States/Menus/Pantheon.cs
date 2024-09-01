using CodedDungeon.Entities;

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
               Gui.Alert("No Hero created");
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



   public void SelectHero() { // Sous forme de menu TODO surbrillance currentH , rouge temp pour delete

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
            case ConsoleKey.NumPad0:
            case ConsoleKey.Tab:

               break;
            default:
               break;
         }

         foreach (Hero hero in HeroesList) {
            if (selectedOption == (HeroesList.IndexOf(hero))+1) {
               this.CurrentHero = hero;
               hero.IsCurrent = true;
               Gui.Alert($"{hero.Name} selected");
            }
            else
               hero.IsCurrent = false;
         }

      } while (selectedOption == 0);

   }

   public void CreateHero() { // verifs inputs    ////creer differents genre de heros
      Console.WriteLine("Name ?");
      string name = Console.ReadLine();
      Hero hero = new Hero(name);
      HeroesList.Add(hero);
      Gui.Alert($"Hero {hero.Name} created");
   }


}
