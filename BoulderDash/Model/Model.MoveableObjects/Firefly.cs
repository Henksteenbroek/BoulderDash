using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Firefly : MoveableObject
    {
        public Firefly(Game game) : base(game)
        {
            DrawChar = 'F';
        }

        public override void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
