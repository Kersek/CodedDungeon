using CodedDungeon.Entities;
using CodedDungeon.States;
using CodedDungeon.States.Menus;

namespace CodedDungeon;

public class Game { // boucle principale de jeu + transfere les params d'un état a l'autre 

   public State CurrentState { get; set; }
   public Hero? CurrentHero { get; set; }
   public List<Hero>? HeroesList { get; set; } = new();

   private bool quitGame = false;

   public Game() {
      Console.CursorVisible = false;
      this.CurrentState = new MainMenu(this); // quand on lance le jeu, on lance le menu principal
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