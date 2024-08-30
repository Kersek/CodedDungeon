using CodedDungeon.Entities;

namespace CodedDungeon.States.Menus;

public class Pantheon : Menus { // main menu

   


   public Pantheon(Game game) : base(game) {

      title = "Pantheon";
      MenuOptions = new() {
         { "CREATE", 1 },
         { "LIST", 2 },
         { "DELETE", 3 },
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
               List();
            break;
         case 3:
            Console.WriteLine("delete a hero");
            break;
         case 4:
            Game.CurrentState = new MainMenu(Game);
            break;
         default:
            break;
      }
      Console.ReadKey(true);
   }


   public void List() {
      foreach (Hero hero in HeroesList) {
         Console.WriteLine(hero.ToString());
      }
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
