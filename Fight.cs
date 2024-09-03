using CodedDungeon.Entities;

namespace CodedDungeon;

public class Fight { // a pvp between 2 entities

    public Entity[] Fighters { get; set; }
   public int ExpGain { get; set; }

   public Fight(Entity player, Entity enemy) {
        Hero hero = (Hero)player;
        
      Console.Clear();
      Gui.FightStats(player, enemy);

      do {
         Console.ReadKey(true);
         hero.Attack(enemy);
            enemy.Attack(hero);
         Console.Clear();
         Gui.FightStats(player, enemy);
      } while (hero.IsAlive == true && enemy.IsAlive == true);

      Console.WriteLine("Fight Over !");

      if (hero.IsAlive != true)
         return;
      else {
         Gui.ShowVictory(player, enemy);
         hero.EarnExp(enemy);
      }
      Console.ReadKey(true);
   }
}