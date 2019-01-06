using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Boulder : MoveableObject
    {
        public Boulder(Game game) : base(game)
        {
            DrawChar = 'O';
            IsWalkable = false;
        }

        public override bool move()
        {
            return true;
        }
    }
}
