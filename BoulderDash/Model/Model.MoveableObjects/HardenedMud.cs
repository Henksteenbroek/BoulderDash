using BoulderDash.Controller;
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
       
        public HardenedMud(Game game) : base(game)
        {
            DrawChar = '#';
            IsWalkable = false;
        }

        public override bool move(int direction)
        {
            HitPoints--;

            if (HitPoints == 0) {
                IsWalkable = true;
                return true;
            }
            return false;
        }

        public override bool move()
        {
            return false;
        }
    }
}
