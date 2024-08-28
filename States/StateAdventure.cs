using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodedDungeon.Entities;

namespace CodedDungeon.States;

public class StateAdventure : State{


   public StateAdventure(Game game) : base(game){
         
   }

   public override void Update(){
      Hero hero = new();

      for (int i = 0; i < 200; i++){
         Monster monster = new();
         Entity[] Fighters = { hero, monster };
         Fight fight = new(Fighters);
      }
   }
}
