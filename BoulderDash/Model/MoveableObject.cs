using BoulderDash.Model.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model
{
    public abstract class MoveableObject
    {
        Tile Location { get; set; }
        bool IsRound { get; set; }

        public char drawChar;
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }

        public virtual void move(int direction)
        {
        }
    }
}
