using BoulderDash.Model;
using BoulderDash.Model.MoveableObjects;
using BoulderDash.Model.StaticObjects;
using BoulderDash.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoulderDash.Controller
{
    public class MainController
    {
        private int LevelLength = 150;
        private Thread thread;

        public Tile[,] tiles { get; set; }
        LevelData levelData;

        private OutputView outputView;
        Game game;

        public MainController()
        {
            outputView = new OutputView();
            levelData = new LevelData();
            game = new Game();
            ReadLevel(1);

            thread = new Thread(CountDown);
            thread.Start();
        }

        private void CountDown()
        {
            while (LevelLength > 0)
            {
                outputView.printLevel(game, LevelLength);
                Thread.Sleep(1000);
                LevelLength--;
            }
        }

        public Tile[,] ReadLevel(int levelNumber)
        {
            char[,] chars = levelData.GetLevel(levelNumber);
            tiles = new Tile[levelData.Level_height, levelData.Level_width];

            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    switch (chars[y, x])
                    {
                        case 'R':
                            tiles[y, x] = new Tile(new Empty(new Rockford(tiles[y,x])));
                            break;
                        case 'M':
                            tiles[y, x] = new Tile(new Mud(null));
                            break;
                        case 'B':
                            tiles[y, x] = new Tile(new Empty(new Boulder(tiles[y, x])));
                            break;
                        case 'D':
                            tiles[y, x] = new Tile(new Empty(new Diamond(tiles[y, x])));
                            break;
                        case 'W':
                            tiles[y, x] = new Tile(new Wall(null));
                            break;
                        case 'S':
                            tiles[y, x] = new Tile(new SteelWall(null));
                            break;
                        case 'F':
                            tiles[y, x] = new Tile(new Empty(new Firefly(tiles[y, x])));
                            break;
                        case 'E':
                            tiles[y, x] = new Tile(new Exit(null));
                            break;
                        case 'H':
                            tiles[y, x] = new Tile(new Empty(new HardenedMud(tiles[y, x])));
                            break;
                        case 'T':
                            tiles[y, x] = new Tile(new Empty(new Explosive(tiles[y, x])));
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
            game.First = tiles[0, 0];
            game.Last = tiles[tiles.GetLength(0) - 1, tiles.GetLength(1) - 1];

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
