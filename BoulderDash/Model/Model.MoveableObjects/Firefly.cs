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
        public int direction;
        
        public Firefly(Game game) : base(game)
        {
            DrawChar = 'F';
            IsWalkable = false;
            direction = 1;
            Destroyable = true;
        }

        public override bool move()
        {
            Tile target = null;

            switch (direction)
            {
                case 1:
                    target = Location.Up;
                    direction++;
                    break;
                case 2:
                    target = Location.Left;
                    direction++;
                    break;
                case 3:
                    target = Location.Down;
                    direction++;
                    break;
                case 4:
                    target = Location.Right;
                    direction = 1;
                    break;
            }

            if (target.StaticObject.moveableObject?.IsWalkable == false)
            {
                return false;
            }
            else if (target.StaticObject.IsWalkable == false)
            {
                return false;
            }
            target.StaticObject.moveableObject = this;
            Location.StaticObject.moveableObject = null;
            Location = target;
            return true;
        }
    }
}
