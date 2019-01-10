using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.View
{
    public class InputView
    {
        private ConsoleKeyInfo key;
        private int returnValue;

        public int readInput()
        {
            key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    returnValue = 1;
                    break;
                case ConsoleKey.DownArrow:
                    returnValue = 2;
                    break;
                case ConsoleKey.LeftArrow:
                    returnValue = 3;
                    break;
                case ConsoleKey.RightArrow:
                    returnValue = 4;
                    break;
                case ConsoleKey.R:
                    returnValue = 5;
                    break;
                default:
                    returnValue = 0;
                    break;
            }
            return returnValue;
        }
    }
}
