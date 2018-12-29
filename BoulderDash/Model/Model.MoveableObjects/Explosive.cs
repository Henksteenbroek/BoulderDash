using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Explosive : MoveableObject
    {
        public bool IsRound { get; set; }

        public char drawChar = 'T';
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }

        public Tile Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
