using CodedDungeon.Entities;

namespace CodedDungeon;

public class Map { // 

   // width doit etre plus grand
   public int MapWidth { get; set; } = 40;  // = j = y
   public int MapHeight { get; set; } = 10; // = i = x


   public char[,] grid;


   public Map() {
      grid = new char[MapHeight, MapWidth];
   }


   public void GridInit(List<Entity> entitiesOnMap) {

      // tout couvrir de point
      for (int i = 0; i < MapHeight; i++) {
         for (int j = 0; j < MapWidth; j++) {
            grid[i, j] = '.';
         }
      }


      Dictionary<(int, int), char> entitesPos = new();

      foreach (Entity entity in entitiesOnMap) {
         int x = entity.Position.X;
         int y = entity.Position.Y;
         entitesPos[(x, y)] = entity.symbolOnMap;
      }

      foreach (var position in entitesPos) {
         int x = position.Key.Item1;
         int y = position.Key.Item2;
         grid[x, y] = position.Value;
      }
   }


   public void GridDisplay() {
      
      for (int i = 0; i < MapHeight; i++) {
         for (int j = 0; j < MapWidth; j++)
            Console.Write(grid[i, j]);
         Console.WriteLine("");
      }
   }




}
