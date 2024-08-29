using CodedDungeon.States;
using CodedDungeon.States.Menus;

namespace CodedDungeon;

public class Game { // holds main loop and stores state 

   public State CurrentState { get; set; }

   private bool quitGame = false;

   public Game() {
      this.CurrentState = new StateMainMenu(this);
   }

   public void Run() {
      do {
         this.CurrentState.Update();
      } while (quitGame == false);
   }

   public void Quitting() {
      Console.WriteLine("You sure ?");
      quitGame = true;

   }
}