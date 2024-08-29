using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedDungeon;

public class Map{ // 

   // width doit etre plus grand
   public int MapWidth { get; set; } = 40;
   
   public int MapHeight { get; set; } = 10;


   public char[,] grid;


   public Dictionary<string, char> symbols = new() {
      {"Grass",'.' },
      {"Hero",'H' },
      {"Monster",'M' }
   };


    public Map(){
      grid = new char[MapHeight, MapWidth];
    }


   public void GridInit() {
      for (int i = 0; i < MapHeight; i++) {
         for (int j = 0; j < MapWidth; j++) {
            grid[i, j] = '.';
         }
      }
   }


   public void GridDisplay() {
      for (int i = 0; i < MapHeight; i++) {

         for (int j = 0; j < MapWidth; j++) {
            Console.Write(grid[i,j]);
         }
         Console.WriteLine("");
      }
      Console.ReadKey(true);
   }




}
