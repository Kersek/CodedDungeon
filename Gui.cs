using CodedDungeon.Entities;

namespace CodedDungeon;

public class Gui {
   public Entity[]? Fighters { get; set; }

   public static void FightStats(Entity[] Fighters) {
      string opponent = Fighters[1].GetType().ToString().Substring(13).ToUpper();
      Hero hero = (Hero)Fighters[0];
      Console.WriteLine("--------------------------------");
      Console.WriteLine("|          FIGHT STATS");
      Console.WriteLine("|");
      Console.WriteLine($"| {hero.Name} : {hero.Health}  |  {opponent} : {Fighters[1].Health}");
      Console.WriteLine($"| Remaining : {hero.RemainingExp}  |  Level : {hero.Level}  |  Exp : {hero.Experience}  |  Kills : {hero.KillCount}");
      Console.WriteLine("|");
      Console.WriteLine("--------------------------------");
   }

   public static void ShowVictory(Entity[] Fighters, double ExpGain) {
      string opponent = Fighters[1].GetType().ToString().Substring(13).ToUpper();
      Hero hero = (Hero)Fighters[0];
      Console.WriteLine($"{hero.Name} defeated {opponent} and earned {ExpGain} experience.");
   }
}
