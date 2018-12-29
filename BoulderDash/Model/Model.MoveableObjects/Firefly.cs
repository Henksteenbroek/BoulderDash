using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Firefly : MoveableObject
    {
        public char drawChar = 'F';
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }

        public override void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
