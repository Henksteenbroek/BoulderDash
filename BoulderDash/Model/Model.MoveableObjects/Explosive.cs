using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Explosive : MoveableObject
    {
        public Explosive(Game game) : base(game)
        {
            DrawChar = 'X';
            IsRound = true;
        }

        public override bool move()
        {
            //Tile target = Location.Right;

            //target.StaticObject.moveableObject = this;
            //Location.StaticObject.moveableObject = null;
            //Location = target;
            return true;
        }
    }
}
