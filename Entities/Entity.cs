using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedDungeon.Entities;

public class Entity{

   private double _health;
   private double _maxHealth;
   private double _strenght;
   private double _defense;
   private double _exp;

   public string Name { get; set; }
   public double Health { get => _health; set => _health = Math.Round(value, 1); }
   public double MaxHealth { get => _maxHealth; set => _maxHealth = Math.Round(value, 1); }
   public double Strenght { get => _strenght; set => _strenght = Math.Round(value, 1); }
   public double Defense { get => _defense; set => _defense = Math.Round(value, 1); }
   public double Exp { get => _exp; set => _exp = Math.Round(value, 1); }

   public int KillCount { get; set; }
   public bool IsAlive { get; set; } = true;


   public Entity(){
   Health = MaxHealth;
   }

   public virtual void Attack(Entity enemy){
      enemy.LooseHP(this);
      if (enemy.Health == 0)
         KillCount++;
   }
   public void LooseHP(Entity enemy){
      Health -= enemy.Strenght;
      if (Health < 0){
         Health = 0;
         IsAlive = false;
      }
   }

}
