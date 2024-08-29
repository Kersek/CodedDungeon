using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedDungeon.Entities;

public class Monster : Entity {


   public Monster(){
      this.Name = "monster";
      Health = 50;
      Strenght = 5;
      ExpOrbs = 10; // calculer en fonction de sa puissance , etc
   }
}
