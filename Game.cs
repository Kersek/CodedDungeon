using CodedDungeon.Entities;
using CodedDungeon.States;
using CodedDungeon.States.Menus;

namespace CodedDungeon;

public class Game { // holds main loop and stores state 

   public State CurrentState { get; set; }

   public Hero? CurrentHero { get; set; }

   public List<Hero> HeroesList { get; set; } = new();

   private bool quitGame = false;

   public Game() {
      this.CurrentState = new MainMenu(this);
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