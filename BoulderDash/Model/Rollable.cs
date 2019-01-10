using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Controller;

namespace BoulderDash.Model
{
    public abstract class Rollable : MoveableObject
    {
        public Rollable(Game game) : base(game)
        {
        }

        public override bool move(int direction)
        {
            return false;
        }

        public override bool move()
        {
            Tile target = Location;

            //Naar onder vallen (leeg vakje eronder)
            if (target.Down.StaticObject.IsEmpty && target.Down.StaticObject.moveableObject == null)
            {
                return MoveToLocation(target.Down);
            }

            //Rollable object staat op een ander rollable object
            if (target.Down.StaticObject.moveableObject?.IsRound == true)
            {

                //Naar rechts vallen
                if (target.Right.StaticObject.IsEmpty && target.Right.Down.StaticObject.IsEmpty)
                {
                    if (target.Right.StaticObject.moveableObject == null && target.Right.Down.StaticObject.moveableObject == null)
                    {
                        return MoveToLocation(target.Right.Down);
                    }
                    return false;
                }

                //Naar link vallen
                if (target.Left.StaticObject.IsEmpty && target.Left.Down.StaticObject.IsEmpty)
                {
                    if (target.Left.StaticObject.moveableObject == null && target.Left.Down.StaticObject.moveableObject == null)
                    {
                        return MoveToLocation(target.Left.Down);
                    }
                    return false;
                }

                return false;
            }

            return false;
        }

        public bool MoveToLocation(Tile target)
        {
            if (target.StaticObject.moveableObject?.Destroyable == true)
            {
                game.Rockford = null;
            }
            target.StaticObject.moveableObject = this;
            Location.StaticObject.moveableObject = null;
            Location = target;
            return true;
        }
    }
}
