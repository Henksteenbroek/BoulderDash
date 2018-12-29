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

        private OutputView outputView;
        Game game;

        public MainController()
        {
            outputView = new OutputView();
            game = new Game();
            game.ReadLevel(1);

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
    }
}
