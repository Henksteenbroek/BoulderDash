using BoulderDash.Controller;
using BoulderDash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.View
{
    public class OutputView
    {

        public OutputView()
        {
        }

        public void printLevel(Game Game, int LevelLength)
        {
            Console.Clear();
            Console.WriteLine("Time left: " + LevelLength + " | points: " + Game.AmountOfPoints);

            Tile temp1 = Game.First;
            Tile temp2 = Game.First;

            while (temp1 != Game.Last)
            {
                if (temp1 != null)
                {
                    Console.Write(temp1.StaticObject.DrawChar);
                    temp1 = temp1.Right;
                }
                else if (temp2.Down != null)
                {
                    temp1 = temp2.Down;
                    temp2 = temp2.Down;
                    Console.WriteLine();
                }
            }
            Console.WriteLine(Game.Last.StaticObject.DrawChar);
        }

        public void ShowGameWon(Game Game, bool DidWin)
        {
            if (!DidWin)
            {
                Console.WriteLine("Unfortunately you didn't make it in time.... Press a level number to play again");
            }
            else
            {
                Console.WriteLine("Congratulations, you made it in time. Your final score is " + Game.AmountOfPoints);
                Console.WriteLine("Press a level number to play again");
            }
        }

        public void ShowGameOverScreen()
        {
            Console.WriteLine("Oh dear, you are dead! Press a level number to play again");
        }

        public void ShowStartScreen()
        {
            Console.WriteLine("Welcome to boulder dash, which level do you wish to play? [1 - 4]");
        }
    }
}
