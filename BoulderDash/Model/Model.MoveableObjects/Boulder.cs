using BoulderDash.Controller;
using BoulderDash.Model.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Boulder : Rollable
    {
        public Boulder(Game game) : base(game)
        {
            DrawChar = 'o';
            IsRound = true;
            IsPushable = true;
            Destroyable = true;
            CanExplode = false;
            Supportive = false;
        }

        public override bool move(int direction)
        {
            Tile target = null;

            switch (direction)
            {
                case 1:
                    target = Location.Up;
                    return false;
                case 2:
                    target = Location.Down;
                    return false;
                case 3:
                    target = Location.Left;
                    break;
                case 4:
                    target = Location.Right;
                    break;
                case 0:
                    return false;
            }

            if(target.StaticObject.IsEmpty && target.StaticObject.moveableObject == null)
            {
                target.StaticObject.moveableObject = this;
                Location.StaticObject.moveableObject = null;
                Location.StaticObject = new Empty(null);
                Location = target;
                return true;
            }

            return false;
        }

        public override bool Explode()
        {
            return false;
        }
    }
}
