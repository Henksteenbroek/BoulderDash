﻿using BoulderDash.Model;
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
        private bool GameOver;
        private bool GameWon;
        private Thread CountDownThread;
        private bool AllDiamondsCollected;

        public Tile[,] tiles { get; set; }
        LevelData levelData;

        private OutputView outputView;
        private InputView inputView;
        Game game;

        public MainController()
        {
            outputView = new OutputView();
            inputView = new InputView();
            levelData = new LevelData();
            game = new Game();
            StartUp();

            GameOver = false;
            GameWon = false;

            CountDownThread = new Thread(CountDown);
            CountDownThread.Start();

            outputView.printLevel(game, LevelLength);
            StartGame();
        }

        private void StartGame()
        {
            foreach (var item in game.moveableObjects)
            {
                game.tempList.Add(item);
            }
            while (!GameOver)
            {
                if(CheckDeath())
                    break;

                CollectedAllDiamonds();
                game.Rockford.move(inputView.readInput());
                outputView.printLevel(game, LevelLength);

                if (CheckWin())
                    break;

                game.moveableObjects.Clear();
                foreach (var item in game.tempList)
                {
                    game.moveableObjects.Add(item);
                }

                foreach (var item in game.moveableObjects)
                {
                    item.move();
                }
                outputView.printLevel(game, LevelLength);
            }

            GameIsOver();
            ResetGame();
        }

        private bool CheckDeath()
        {
            if (game.Rockford == null)
            {
                GameOver = true;
                return true;
            }

            return false;
        }

        private bool CheckWin()
        {
            if (game.Rockford.Location == game.Exit.Location)
            {
                GameOver = true;
                GameWon = true;
                return true;
            }
            return false;
        }

        private void CollectedAllDiamonds()
        {
            if (game.tempList.Count == 0)
                AllDiamondsCollected = true;

            foreach (var item in game.tempList)
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
                game.Exit.IsActive = true;
        }

        private void ResetGame()
        {
            outputView = new OutputView();
            inputView = new InputView();
            levelData = new LevelData();
            game = new Game();

            int i;
            while ((i = inputView.readLevelInput()) == 0)
            {
            }

            ReadLevel(i);

            LevelLength = 150;
            CountDownThread = new Thread(CountDown);
            outputView.printLevel(game, LevelLength);
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
            outputView.ShowStartScreen();
            int i;
            while ((i = inputView.readLevelInput()) == 0)
            {
            }
            ReadLevel(i);
        }

        private void GameIsOver()
        {
            if (!GameWon)
            {
                outputView.ShowGameOverScreen();
            }
            else
            {
                if (LevelLength <= 0)
                {
                    outputView.ShowGameWon(game, false);
                }
                else
                {
                    for (int i = 0; i < LevelLength; i++)
                    {
                        game.AmountOfPoints += 10;
                    }
                    outputView.ShowGameWon(game, true);
                }
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
                            Rockford r = new Rockford(game);
                            game.Rockford = r;
                            tiles[y, x] = new Tile(new Empty(r));
                            tiles[y, x].StaticObject.moveableObject = game.Rockford;
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            break;
                        case 'M':
                            tiles[y, x] = new Tile(new Mud(null));
                            break;
                        case 'B':
                            Boulder b = new Boulder(game);
                            tiles[y, x] = new Tile(new Empty(b));
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            game.moveableObjects.Add(b);
                            break;
                        case 'D':
                            Diamond d = new Diamond(game);
                            tiles[y, x] = new Tile(new Empty(d));
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            game.moveableObjects.Add(d);
                            break;
                        case 'W':
                            tiles[y, x] = new Tile(new Wall(null));
                            break;
                        case 'S':
                            tiles[y, x] = new Tile(new SteelWall(null));
                            break;
                        case 'F':
                            Firefly f = new Firefly(game);
                            tiles[y, x] = new Tile(new Empty(f));
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            game.moveableObjects.Add(f);
                            break;
                        case 'E':
                            Exit ex = new Exit(null);
                            game.Exit = ex;
                            tiles[y, x] = new Tile(ex);
                            game.Exit.Location = tiles[y, x];
                            break;
                        case 'H':
                            HardenedMud h = new HardenedMud(game);
                            tiles[y, x] = new Tile(new Empty(h));
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            game.moveableObjects.Add(h);
                            break;
                        case 'T':
                            TNT e = new TNT(game);
                            tiles[y, x] = new Tile(new Empty(e));
                            tiles[y, x].StaticObject.moveableObject.Location = tiles[y, x];
                            game.moveableObjects.Add(e);
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
