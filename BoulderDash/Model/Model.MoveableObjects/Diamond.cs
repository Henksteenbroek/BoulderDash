using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Diamond : MoveableObject
    {
        public Diamond(Game game) : base(game)
        {
            DrawChar = '$';
            IsWalkable = true;
        }

        public override bool move()
        {
            return true;
        }
    }
}
