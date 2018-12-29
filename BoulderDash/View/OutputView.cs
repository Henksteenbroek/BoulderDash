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

        public void printLevel(Game game, int LevelLength)
        {
            Console.Clear();

            Console.WriteLine("Time left: " + LevelLength);

            Tile temp1 = game.First;
            Tile temp2 = game.First;

            while (temp1 != game.Last)
            {
                if (temp1 != null)
                {
                    Console.Write(temp1.GameObject.DrawChar);
                    temp1 = temp1.Right;
                }
                else if (temp2.Down != null)
                {
                    temp1 = temp2.Down;
                    temp2 = temp2.Down;
                    Console.WriteLine();
                }
            }
            Console.WriteLine(game.Last.GameObject.DrawChar);
        }
    }
}
