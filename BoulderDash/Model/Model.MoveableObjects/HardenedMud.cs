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
        public bool hasMoved;

        public HardenedMud(Game Game) : base(Game)
        {
            DrawChar = '#';
            Destroyable = true;
            Supportive = true;
            IsWalkable = false;
            CanExplode = false;
            hasMoved = false;
            GivesPoints = false;
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

            if (CanKillRockFord(target, hasMoved))
                return true;

            if (FallOnExplosive(target, hasMoved))
                return true;

            if (target.StaticObject.IsEmpty && target.StaticObject.moveableObject == null)
            {
                if (Canfall() || hasMoved)
                {
                    target.StaticObject.moveableObject = this;
                    Location.StaticObject.moveableObject = null;
                    Location = target;
                    hasMoved = true;
                    return true;
                }
            }

            if (hasMoved)
            {
                Game.tempList.Remove(Location.StaticObject.moveableObject);
                Location.StaticObject = new Mud(null);
                Location.StaticObject.moveableObject = null;
                return false;
            }
            
            return false;
        }

        private bool CanKillRockFord(Tile target, bool hasMoved)
        {
            if (target == Game.Rockford?.Location && hasMoved)
            {
                Game.Rockford.Explode();
                return true;
            }

            return false;
        }

        private bool FallOnExplosive(Tile target, bool hasMoved)
        {
            if(target.StaticObject.moveableObject?.CanExplode == true && hasMoved)
            {
                target.StaticObject.moveableObject.Explode();
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
