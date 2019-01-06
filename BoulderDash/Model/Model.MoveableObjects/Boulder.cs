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
            DrawChar = 'B';
            IsRound = true;
        }

        public override bool move()
        {
            Tile target = Location;

            //Naar onder vallen (leeg vakje eronder)
            if (target.Down.StaticObject.IsEmpty && target.Down.StaticObject.moveableObject == null)
            {
                target.Down.StaticObject.moveableObject = this;
                Location.StaticObject.moveableObject = null;
                Location = target.Down;
                return true;
            }

            //Rollable object onder boulder
            if (target.Down.StaticObject.moveableObject?.IsRound == true)
            {

                //Naar rechts vallen
                if (target.Right.StaticObject.IsEmpty && target.Right.Down.StaticObject.IsEmpty)
                {
                    if (target.Right.StaticObject.moveableObject == null && target.Right.Down.StaticObject.moveableObject == null)
                    {
                        target.Right.Down.StaticObject.moveableObject = this;
                        Location.StaticObject.moveableObject = null;
                        Location = target.Right.Down;
                        return true;
                    }
                    return false;
                }

                //Naar link vallen
                if (target.Left.StaticObject.IsEmpty && target.Left.Down.StaticObject.IsEmpty)
                {
                    if (target.Left.StaticObject.moveableObject == null && target.Left.Down.StaticObject.moveableObject == null)
                    {
                        target.Left.Down.StaticObject.moveableObject = this;
                        Location.StaticObject.moveableObject = null;
                        Location = target.Left.Down;
                        return true;
                    }
                    return false;
                }

                return false;
            }

            return false;
        }
    }
}
