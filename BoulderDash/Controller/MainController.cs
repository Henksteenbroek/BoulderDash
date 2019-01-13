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
        public Tile[,] tiles { get; set; }

        private int LevelLength = 150;
        private bool GameOver;
        private bool GameWon;
        private Thread CountDownThread;
        private bool AllDiamondsCollected;


        public Game Game  {get; set; }
        public InputView InputView { get; set; }
        public OutputView OutputView { get; set; }
        public LevelData LevelData { get; set; }


        public MainController()
        {
            OutputView = new OutputView();
            InputView = new InputView();
            LevelData = new LevelData();
            Game = new Game();
            StartUp();

            GameOver = false;
            GameWon = false;

            CountDownThread = new Thread(CountDown);
            CountDownThread.Start();

            OutputView.printLevel(Game, LevelLength);
            StartGame();
        }

        private void StartGame()
        {
            foreach (var item in Game.moveableObjects)
            {
                Game.tempList.Add(item);
            }
            while (!GameOver)
            {
                if (CheckDeath())
                    break;

                CollectedAllDiamonds();
                Game.Rockford.move(InputView.readInput());
                OutputView.printLevel(Game, LevelLength);

                if (CheckWin())
                    break;

                Game.moveableObjects.Clear();
                foreach (var item in Game.tempList)
                {
                    Game.moveableObjects.Add(item);
                }

                foreach (var item in Game.moveableObjects)
                {
                    item.move();
                }
                OutputView.printLevel(Game, LevelLength);
            }

            GameIsOver();
            ResetGame();
        }

        private bool CheckDeath()
        {
            if (Game.Rockford == null)
            {
                GameOver = true;
                return true;
            }

            return false;
        }

        private bool CheckWin()
        {
            if (Game.Rockford.Location == Game.Exit.Location)
            {
                GameOver = true;
                GameWon = true;
                return true;
            }
            return false;
        }

        private void CollectedAllDiamonds()
        {
            if (Game.tempList.Count == 0)
                AllDiamondsCollected = true;

            foreach (var item in Game.tempList)
            {
                if (item.GivesPoints)
                {
                    AllDiamondsCollected = false;
                    break;
                }
                else
                {
                    AllDiamondsCollected = true;
                }
            }

            if (AllDiamondsCollected)
                Game.Exit.IsActive = true;
        }

        private void ResetGame()
        {
            OutputView = new OutputView();
            InputView = new InputView();
            LevelData = new LevelData();
            Game = new Game();

            int i;
            while ((i = InputView.readLevelInput()) == 0)
            {
            }

            ReadLevel(i);

            LevelLength = 150;
            CountDownThread = new Thread(CountDown);
            OutputView.printLevel(Game, LevelLength);
            GameOver = false;
            GameWon = false;
            CountDownThread.Start();
            StartGame();
        }

        private void CountDown()
        {
            while (!GameOver)
            {
                Thread.Sleep(1000);
                LevelLength--;
            }
        }

        private void StartUp()
        {
            OutputView.ShowStartScreen();
            int i;
            while ((i = InputView.readLevelInput()) == 0)
            {
            }
            ReadLevel(i);
        }

        private void GameIsOver()
        {
            if (!GameWon)
            {
                OutputView.ShowGameOverScreen();
            }
            else
            {
                if (LevelLength <= 0)
                {
                    OutputView.ShowGameWon(Game, false);
                }
                else
                {
                    for (int i = 0; i < LevelLength; i++)
                    {
                        Game.AmountOfPoints += 10;
                    }
                    OutputView.ShowGameWon(Game, true);
                }
            }
        }

        public Tile[,] ReadLevel(int levelNumber)
        {
            char[,] chars = LevelData.GetLevel(levelNumber);
            tiles = new Tile[LevelData.Level_height, LevelData.Level_width];

            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    switch (chars[y, x])
                    {
                        case 'R':
                            Rockford r = new Rockford(Game);
                            Game.Rockford = r;
                            tiles[y, x] = new Tile(new Empty(r));
                            tiles[y, x].StaticObject.moveableObject = Game.Rockford;
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            break;
                        case 'M':
                            tiles[y, x] = new Tile(new Mud(null));
                            break;
                        case 'B':
                            Boulder b = new Boulder(Game);
                            tiles[y, x] = new Tile(new Empty(b));
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            Game.moveableObjects.Add(b);
                            break;
                        case 'D':
                            Diamond d = new Diamond(Game);
                            tiles[y, x] = new Tile(new Empty(d));
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            Game.moveableObjects.Add(d);
                            break;
                        case 'W':
                            tiles[y, x] = new Tile(new Wall(null));
                            break;
                        case 'S':
                            tiles[y, x] = new Tile(new SteelWall(null));
                            break;
                        case 'F':
                            Firefly f = new Firefly(Game);
                            tiles[y, x] = new Tile(new Empty(f));
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            Game.moveableObjects.Add(f);
                            break;
                        case 'E':
                            Exit ex = new Exit(null);
                            Game.Exit = ex;
                            tiles[y, x] = new Tile(ex);
                            Game.Exit.Location = tiles[y, x];
                            break;
                        case 'H':
                            HardenedMud h = new HardenedMud(Game);
                            tiles[y, x] = new Tile(new Empty(h));
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            Game.moveableObjects.Add(h);
                            break;
                        case 'T':
                            TNT e = new TNT(Game);
                            tiles[y, x] = new Tile(new Empty(e));
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            Game.moveableObjects.Add(e);
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
            Game.First = tiles[0, 0];
            Game.Last = tiles[tiles.GetLength(0) - 1, tiles.GetLength(1) - 1];

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
