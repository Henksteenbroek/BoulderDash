using BoulderDash.Controller;
using BoulderDash.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            OutputView outputView = new OutputView();

            game.ReadLevel(1);
            outputView.printLevel(game);

            Console.ReadLine();
        }
    }
}
