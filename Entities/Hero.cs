using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedDungeon.Entities
{
    public class Hero : Entity
    {

        private double _experience;
        private double _remainingExp;
        private double _level;


        public double Experience { get => _experience; set => _experience = Math.Round(value, 1); }
        public double RemainingExp { get => _remainingExp; set => _remainingExp = Math.Round(value, 1); }
        public double Level { get => _level; set => _level = Math.Round(value, 1); }




        public Hero()
        {
            Name = "Herow";
            MaxHealth = 120;
            Health = MaxHealth;
            Strenght = 20;
            KillCount = 0;
            Experience = 10;
            Level = 1;
            RemainingExp = Experience * 1.2 * (Level * .4);
        }

        public override void Attack(Entity enemy)
        {
            enemy.LooseHP(this);
            if (enemy.Health == 0)
            {
                Console.WriteLine($"{Name} heals {Math.Round(Health * .1)} HP");
                Health += Health * .1;
                KillCount++;
            }
        }

        public void EarnExp(Entity opponent)
        {
            Experience += opponent.Exp;
            if (Experience >= RemainingExp)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Level++;
            RemainingExp = Experience / 2 * 1.2 * (Level * .4);
            MaxHealth += MaxHealth * 0.1;
            Health = MaxHealth;
            Console.WriteLine("le heros monte de niveau !");
            Console.WriteLine($"LEVEL : {Level}   Remaining : {RemainingExp}");
        }
    }
}
