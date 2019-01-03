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
            Tile target = null;

            switch (direction)
            {
                case 1:
                    target = Location.Up;
                    break;
                case 2:
                    target = Location.Down;
                    break;
                case 3:
                    target = Location.Left;
                    break;
                case 4:
                    target = Location.Right;
                    break;
            }

            target.StaticObject.moveableObject = this;
            Location.StaticObject.moveableObject = null;
            Location = target;
        }
    }
}

