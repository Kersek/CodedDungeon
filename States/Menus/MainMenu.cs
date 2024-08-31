using CodedDungeon.Entities;

namespace CodedDungeon.States.Menus;

public class MainMenu : Menus { // main menu


   public MainMenu(Game game) : base(game) {
      title = "Coded Dungeon";
      MenuOptions = new() {
         { "PLAY", 1 },
         { "PANTHEON", 2 }
      };
      cursorPos = 1;
   }



   public override void SelectOption() {
      switch (selectedOption) {
         case 1:
            if (this.CurrentHero != null) {
               Game.CurrentHero = this.CurrentHero;
               Game.HeroesList = this.HeroesList;
               Game.CurrentState = new StateAdventure(Game);
            }
            else
               Gui.Alert("You must select a Hero first");
            break;
         case 2:
            Game.CurrentHero = this.CurrentHero;
            Game.HeroesList = this.HeroesList;
            Game.CurrentState = new Pantheon(Game); // Pantheon state 
            break;
         case 3:
            Game.Quitting();
            break;
         default:
            break;
      }
   }
}
