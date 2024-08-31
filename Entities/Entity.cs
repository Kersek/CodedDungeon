namespace CodedDungeon.Entities;

public class Entity { // something that interacts 

   private double _health;
   private double _maxHealth;
   private double _strenght;
   private double _defense;
   private double _expOrbs;

   private Position position;

   public string Name { get; set; }
   public double Health { get => _health; set => _health = Math.Round(value, 1); }
   public double MaxHealth { get => _maxHealth; set => _maxHealth = Math.Round(value, 1); }
   public double Strenght { get => _strenght; set => _strenght = Math.Round(value, 1); }
   public double Defense { get => _defense; set => _defense = Math.Round(value, 1); }
   public double ExpOrbs { get => _expOrbs; set => _expOrbs = Math.Round(value, 1); }

   public int KillCount { get; set; }
   public bool IsAlive { get; set; }


   public Position Position {
      get { return position; }
      set { position = value; }
   }



   public Entity() {
      Health = MaxHealth;
      IsAlive = true;
   }

   public virtual void Attack(Entity enemy) {
      enemy.LooseHP(this.Strenght);
      if (enemy.Health == 0)
         KillCount++;
   }
   public void LooseHP(double damage) {
      Health -= damage;
      if (Health < 0) {
         Health = 0;
         IsAlive = false;
      }
   }

}
