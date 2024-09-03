using CodedDungeon.Entities;

namespace CodedDungeon;

public class Gui { // menus, messages, alerts,..


   public static void DisplayMenu(string title, Dictionary<string, int> menuOptions, int cursorPos) {
      

      string titleplace = $"| **** {title.ToUpper()} **** |";
      string border = "x";
      for (int i = 1; i < titleplace.Length - 1; i++)
         border += "-";
      border += "x";

      Console.Clear();
      Console.WriteLine($"{border}\n{titleplace}\n{border}\n");

      string back = (title == "Coded Dungeon") ? back = "QUIT" : back = "BACK";

      string cursor = "o>";
       

        foreach (var option in menuOptions) {
         if (cursorPos == option.Value) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{cursor}{option.Key}");
            Console.ResetColor();
         }
         else
            Console.WriteLine($"  {option.Key}");
      }

      if (cursorPos == menuOptions.Count + 1) {
         Console.ForegroundColor = ConsoleColor.Cyan;
         Console.WriteLine($"{cursor}{back}");
         Console.ResetColor();
      }
      else
         Console.WriteLine($"  {back}");
   }


   public static void FightStats(Entity player, Entity monster) {
      Monster opponent = (Monster)monster;
      Hero hero = (Hero)player; // cast en peu importe le type que c ?
      Console.WriteLine("--------------------------------");
      Console.WriteLine("|          FIGHT STATS");
      Console.WriteLine("|");
      Console.WriteLine($"| {hero.Name} : {hero.Health}  |  {opponent.Name} : {opponent.Health}");
      Console.WriteLine($"| Remaining : {hero.RemainingExp}  |  Level : {hero.Level}  |  Exp : {hero.Experience}  |  Kills : {hero.KillCount}");
      Console.WriteLine("|");
      Console.WriteLine("--------------------------------");
   }


   public static void ShowVictory(Entity player, Entity monster) {
      Monster opponent = (Monster)monster;
      Hero hero = (Hero)player;
      Console.WriteLine($"{hero.Name} defeated {opponent.Name} and earned {opponent.ExpOrbs} experience.");
      Console.ReadKey(true);
   }

   public static void Alert(string message) {
      Console.ForegroundColor =  ConsoleColor.Yellow;
      Console.WriteLine($"-- {message} ! --");
      Console.ResetColor();
      Thread.Sleep(700);
   }

   public static void InGameMenu(Hero hero){
      Console.WriteLine($"{hero.Name} | {hero.Health}/{hero.MaxHealth} | " +
         $"(tab: Hero Stats) (escape: Main Menu) (h: help)");
   }


}