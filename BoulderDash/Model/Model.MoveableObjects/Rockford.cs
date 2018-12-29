using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Rockford : MoveableObject
    {
        public bool IsRound { get; set; } 

        public char drawChar = 'R';
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }

        public void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
