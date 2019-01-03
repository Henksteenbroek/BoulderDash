using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Rockford : MoveableObject
    {
        public Rockford(Game game) : base(game)
        {
            DrawChar = 'R';
        }

        public override void move(int direction)
        {
            game.MoveObject(this, direction);
        }
    }
}
