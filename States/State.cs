﻿using CodedDungeon.Entities;

namespace CodedDungeon.States;

public abstract class State { // a part of the game

   public Game Game { get; set; }
   public State CurrentState { get; set; }

   public Hero? CurrentHero { get; set; }
   public List<Hero>? HeroesList { get; set; }

   public State(Game game) { // chaque nouvel état recoit les params de game
      this.Game = game;
      this.CurrentState = game.CurrentState;
      this.CurrentHero = this.Game.CurrentHero;
      this.HeroesList = this.Game.HeroesList;
   }

   public abstract void Update();
}
