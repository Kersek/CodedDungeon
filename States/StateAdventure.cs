﻿using CodedDungeon.Entities;

namespace CodedDungeon.States;

public class StateAdventure : State { // Central state of the game

   public Map map { get; set; } = new();

   Hero hero = this.CurrentHero;

   public StateAdventure(Game game) : base(game) {
      map.GridInit();
      map.GridDisplay();
   }

   public override void Update() {

      

      for (int i = 0; i < 200; i++) {
         Monster monster = new();
         Entity[] Fighters = { hero, monster };
         Fight fight = new(Fighters);
      }
   }
}
