namespace CodedDungeon.States;

public class State { // a part of the game

   public Game Game { get; set; }
   public State CurrentState { get; set; }

   public State(Game game) { this.Game = game; this.CurrentState = Game.CurrentState; }

   public virtual void Update() { }
}
