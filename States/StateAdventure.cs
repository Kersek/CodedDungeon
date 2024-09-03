using CodedDungeon.Entities;
using CodedDungeon.States.Menus;

namespace CodedDungeon.States;

// Un thread pour le joueur et un pour les entités
public class StateAdventure : State { 

   public Hero hero;
   Monster mons;

   Thread PlayerThread;
   Thread MonsterThread;
   Random Random = new();
   private readonly object _lock = new object();

   public Map map { get; set; } = new();
   List<Entity> entitiesOnMap = new();
   
   bool IsRunning { get; set; } = true;
   bool LoopStop { get; set; } = true;


   public StateAdventure(Game game) : base(game) {

      PlayerThread = new Thread(HandleInput);
      MonsterThread = new Thread(MonsterMoving);
      hero = this.CurrentHero;
      mons = new();
      entitiesOnMap.Add(hero);
      entitiesOnMap.Add(mons);

      MonsterThread.Start();
      PlayerThread.Start();
   }

   // Maj état
    public override void Update() {
        lock (_lock) {
            map.GridInit(entitiesOnMap);
         Console.Clear();
         Gui.InGameMenu(this.CurrentHero);
            map.GridDisplay();
            if (hero.Position.ToString() == mons.Position.ToString())
            {
                
               Fight fight = new(hero,mons);
            }
            Thread.Sleep(100);
        }
    }

   // Déplacements et options joueur
   public void HandleInput() {
      
      do {
         ConsoleKey playerInput = Console.ReadKey(true).Key;
         lock (_lock) {
            switch (playerInput) {
               case ConsoleKey.Z:
               case ConsoleKey.UpArrow:
                  hero.Move(-1, 0,map.MapWidth,map.MapHeight);
                  break;
               case ConsoleKey.Q:
               case ConsoleKey.LeftArrow:
                  hero.Move(0, -1, map.MapWidth, map.MapHeight);
                  break;
               case ConsoleKey.S:
               case ConsoleKey.DownArrow:
                  hero.Move(1, 0, map.MapWidth, map.MapHeight);
                  break;
               case ConsoleKey.D:
               case ConsoleKey.RightArrow:
                  hero.Move(0, 1, map.MapWidth, map.MapHeight);
                  break;
               case ConsoleKey.Escape:
                  IsRunning = false;
                  break;
               case ConsoleKey.H:
                  // affiche aide sur la mission 
                  break;
               case ConsoleKey.Tab:
                  this.CurrentHero.Rest(); // stats inventaire
                  break;
               default:
                  break;
            }
         }
      } while (IsRunning == true);
      PlayerThread.Join(100);
      MonsterThread.Join(100);
      Game.CurrentHero = this.CurrentHero;
      Game.HeroesList = this.HeroesList;
      Game.CurrentState = new MainMenu(Game);
   }

   // Déplacements aléatoires d'un monstre
   public void MonsterMoving() {
      int dice = 0;
      do {
         Thread.Sleep(1000);
         dice = Random.Next(1, 6);
         lock (_lock) {
            switch (dice) {
               case 1:
                  mons.Move(-1, 0,map.MapWidth,map.MapHeight);
                  break;
               case 2:
                  mons.Move(0, -1, map.MapWidth, map.MapHeight);
                  break;
               case 3:
                  mons.Move(0, 1,map.MapWidth,map.MapHeight);
                  break;
               case 4:
                  mons.Move(1, 0,map.MapWidth,map.MapHeight);
                  break;
               case 5:
                  break;
               default:
                  break;
            }
         }
      } while (IsRunning == true);
      MonsterThread.Join(100);     
   }

}


