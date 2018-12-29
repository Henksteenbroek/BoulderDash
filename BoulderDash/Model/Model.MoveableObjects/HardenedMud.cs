using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class HardenedMud : MoveableObject
    {
        public char drawChar = 'H';
        
        public override void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
