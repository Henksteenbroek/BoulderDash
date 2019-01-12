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
        private bool hasMoved;

        public Rollable(Game game) : base(game)
        {
            hasMoved = false;
        }

        public override bool move(int direction)
        {
            return false;
        }

        public override bool move()
        {
            Tile target = Location;
            
            if (CanKillRockFord(target, hasMoved))
                return true;

            if (FallOnExplosive(target, hasMoved))
                return true;

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
                    if (target.Right.StaticObject.moveableObject == null
                        && target.Right.Down.StaticObject.moveableObject == null)
                    {
                        return MoveToLocation(target.Right.Down);
                    }
                    hasMoved = false;
                    return false;
                }

                //Naar link vallen
                if (target.Left.StaticObject.IsEmpty && target.Left.Down.StaticObject.IsEmpty)
                {
                    if (target.Left.StaticObject.moveableObject == null
                        && target.Left.Down.StaticObject.moveableObject == null)
                    {

                        return MoveToLocation(target.Left.Down);
                    }
                    hasMoved = false;
                    return false;
                }
                hasMoved = false;
                return false;
            }
            hasMoved = false;
            return false;
        }

        private bool FallOnExplosive(Tile target, bool hasMoved)
        {
            if (!hasMoved)
                return false;

            if (target.Down.StaticObject.moveableObject?.CanExplode == true)
            {
                target.Down.StaticObject.moveableObject.Explode();
                return true;
            }

            if (target.Down.StaticObject.moveableObject?.IsRound == true)
            {
                if (target.Right.StaticObject.IsEmpty && target.Right.StaticObject.moveableObject == null)
                {
                    if (target.Right.Down.StaticObject.moveableObject?.CanExplode == true)
                    {
                        target.Right.Down.StaticObject.moveableObject.Explode();
                        return true;
                    }
                }

                if (target.Left.StaticObject.IsEmpty && target.Left.StaticObject.moveableObject == null)
                {
                    if (target.Left.Down.StaticObject.moveableObject?.CanExplode == true)
                    {
                        target.Left.Down.StaticObject.moveableObject.Explode();
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CanKillRockFord(Tile target, bool hasMoved)
        {
            if (!hasMoved)
                return false;

            if (target.Down == game.Rockford?.Location)
            {
                target.Down.StaticObject.moveableObject.Explode();
                return true;
            }

            if (target.Down.StaticObject.moveableObject?.IsRound == true)
            {
                if (target.Right.StaticObject.IsEmpty && target.Right.StaticObject.moveableObject == null)
                {
                    if (target.Right.Down == game.Rockford?.Location)
                    {
                        target.Right.Down.StaticObject.moveableObject.Explode();
                        return true;
                    }
                }

                if (target.Left.StaticObject.IsEmpty && target.Left.StaticObject.moveableObject == null)
                {
                    if (target.Left.Down == game.Rockford?.Location)
                    {
                        target.Left.Down.StaticObject.moveableObject.Explode();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MoveToLocation(Tile target)
        {
            target.StaticObject.moveableObject = this;
            Location.StaticObject.moveableObject = null;
            Location = target;
            hasMoved = true;
            return true;
        }
    }
}
