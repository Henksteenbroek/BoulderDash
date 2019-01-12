using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Diamond : Rollable
    {
        public Diamond(Game game) : base(game)
        {
            DrawChar = '$';
            IsWalkable = true;
            IsRound = true;
            Destroyable = true;
            GivesPoints = true;
            CanExplode = false;
            Supportive = false;
        }

        public override bool Explode()
        {
            return false;
        }
    }
}
