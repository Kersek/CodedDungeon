using CodedDungeon.Entities;

namespace CodedDungeon;

public class Fight { // a pvp between 2 entities

   public Entity[] Fighters { get; set; }
   public int ExpGain { get; set; }

   public Fight(Entity[] _Fighters) {
      this.Fighters = _Fighters;
      Hero hero = (Hero)this.Fighters[0];
      Entity opponent = this.Fighters[1];
      Console.Clear();
      Gui.FightStats(Fighters);

      do {
         Console.ReadKey(true);
         hero.Attack(opponent);
         opponent.Attack(hero);
         Console.Clear();
         Gui.FightStats(Fighters);
      } while (hero.IsAlive == true && opponent.IsAlive == true);

      Console.WriteLine("Fight Over !");

      if (hero.IsAlive != true)
         return;
      else {
         Gui.ShowVictory(this.Fighters, opponent.ExpOrbs);
         hero.EarnExp(opponent);
      }
      Console.ReadKey(true);
   }
}