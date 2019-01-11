using BoulderDash.Controller;
using BoulderDash.Model.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class HardenedMud : MoveableObject
    {
        public int HitPoints = 2;
        public int Supporters;

        public HardenedMud(Game game) : base(game)
        {
            DrawChar = '#';
            IsWalkable = false;
            CanExplode = false;
            Destroyable = true;
            Supportive = true;
        }

        public override bool move(int direction)
        {
            HitPoints--;

            if (HitPoints == 0)
            {
                IsWalkable = true;
                return true;
            }
            return false;
        }

        public override bool move()
        {
            Tile target = Location.Down;

            if (CanKillRockFord(target))
                return true;

            if (target.StaticObject.IsEmpty && target.StaticObject.moveableObject == null)
            {
                if (Canfall())
                {
                    target.StaticObject.moveableObject = this;
                    Location.StaticObject.moveableObject = null;
                    Location = target;
                    return true;
                }
            }
            return false;
        }

        private bool CanKillRockFord(Tile target)
        {
            if (target == game.Rockford?.Location && Canfall())
            {
                game.Rockford = null;
                return true;
            }

            return false;
        }

        public bool Canfall()
        {
            Supporters = 0;

            if (Location.Up.StaticObject.Supportive && Location.Up.StaticObject.moveableObject == null)
                Supporters++;

            if (Location.Up.StaticObject.moveableObject?.Supportive == true)
                Supporters++;

            if (Location.Left.StaticObject.Supportive && Location.Left.StaticObject.moveableObject == null)
                Supporters++;

            if (Location.Left.StaticObject.moveableObject?.Supportive == true)
                Supporters++;

            if (Location.Right.StaticObject.Supportive && Location.Right.StaticObject.moveableObject == null)
                Supporters++;

            if (Location.Right.StaticObject.moveableObject?.Supportive == true)
                Supporters++;

            if (Location.Down.StaticObject.moveableObject?.Supportive == true)
            {
                Supporters++;
            }

            if (Supporters >= 2)
            {
                return false;
            }

            return true;
        }

        public override bool Explode()
        {
            return false;
        }
    }
}
