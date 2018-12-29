using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Rockford : MoveableObject
    {
        public Rockford()
        {
            DrawChar = 'R';
        }

        public override void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
