using CodedDungeon.Entities;

namespace CodedDungeon;

public class Gui { // menus, messages, alerts,..


   public static void DisplayMenu(string title, Dictionary<string, int> menuOptions, int cursorPos) {
      string cursor = "o>";
      Console.Clear();

      string titleplace = $"| **** {title.ToUpper()} **** |";
      string border = "x";
      for (int i = 1; i < titleplace.Length - 1; i++)
         border += "-";
      border += "x";

      Console.WriteLine($"{border}\n{titleplace}\n{border}\n");

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
         Console.WriteLine($"{cursor}QUIT");
         Console.ResetColor();
      }
      else
         Console.WriteLine("  QUIT");
   }


   public static void FightStats(Entity[] Fighters) {
      Monster opponent = (Monster)Fighters[1];
      Hero hero = (Hero)Fighters[0]; // cast en peu importe le type que c ?
      Console.WriteLine("--------------------------------");
      Console.WriteLine("|          FIGHT STATS");
      Console.WriteLine("|");
      Console.WriteLine($"| {hero.Name} : {hero.Health}  |  {opponent.Name} : {opponent.Health}");
      Console.WriteLine($"| Remaining : {hero.RemainingExp}  |  Level : {hero.Level}  |  Exp : {hero.Experience}  |  Kills : {hero.KillCount}");
      Console.WriteLine("|");
      Console.WriteLine("--------------------------------");
   }


   public static void ShowVictory(Entity[] Fighters, double ExpGain) {
      Monster opponent = (Monster)Fighters[1];
      Hero hero = (Hero)Fighters[0];
      Console.WriteLine($"{hero.Name} defeated {opponent.Name} and earned {ExpGain} experience.");
      Console.ReadKey(true);
   }

   public static void Alert(string message) {
      Console.ForegroundColor =  ConsoleColor.Yellow;
      Console.WriteLine($"-- {message} ! --");
      Console.ResetColor();
      Thread.Sleep(700);
   }




}