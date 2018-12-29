using BoulderDash.Model.MoveableObjects;
using BoulderDash.Model.StaticObjects;
using BoulderDash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Controller
{
    public class Game
    {
        public Tile First { get; set; }
        public Tile Last { get; set; }
        public Tile[,] tiles { get; set; }
        LevelData levelData;

        public Game()
        {
            levelData = new LevelData();
        }

        public Tile[,] ReadLevel(int levelNumber)
        {
            char[,] chars = levelData.GetLevel(levelNumber);
            tiles = new Tile[levelData.Level_height, levelData.Level_width];

            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    switch (chars[y,x])
                    {
                        case 'R':
                            tiles[y, x] = new Tile(new Empty(new Rockford()));
                            break;
                        case 'M':
                            tiles[y, x] = new Tile(new Mud(null));
                            break;
                        case 'B':
                            tiles[y, x] = new Tile(new Empty(new Boulder()));
                            break;
                        case 'D':
                            tiles[y, x] = new Tile(new Empty(new Diamond()));
                            break;
                        case 'W':
                            tiles[y, x] = new Tile(new Wall(null));
                            break;
                        case 'S':
                            tiles[y, x] = new Tile(new SteelWall(null));
                            break;
                        case 'F':
                            tiles[y, x] = new Tile(new Empty(new Firefly()));
                            break;
                        case 'E':
                            tiles[y, x] = new Tile(new Exit(null));
                            break;
                        case 'H':
                            tiles[y, x] = new Tile(new Empty(new HardenedMud()));
                            break;
                        case 'T':
                            tiles[y, x] = new Tile(new Empty(new Explosive()));
                            break;
                        case ' ':
                            tiles[y, x] = new Tile(new Empty(null));
                            break;
                        default:
                            Console.WriteLine("Unknown tile at y: " + y + " x: " + x);
                            break;
                    }
                }             
            }
            CreateLinks(tiles);
            return tiles;
        }

        public void CreateLinks(Tile[,] tiles)
        {
            First = tiles[0, 0];
            Last = tiles[tiles.GetLength(0) - 1, tiles.GetLength(1) - 1];

            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    if (x + 1 != tiles.GetLength(1) && tiles[y, x + 1] != null)
                    {
                        tiles[y, x].Right = tiles[y, x + 1];
                        tiles[y, x + 1].Left = tiles[y, x];
                    }
                    if (y + 1 != tiles.GetLength(0) && tiles[y + 1, x] != null)
                    {
                        tiles[y, x].Down = tiles[y + 1, x];
                        tiles[y + 1, x].Up = tiles[y, x];
                    }
                }
            } 
        }
    }
}
