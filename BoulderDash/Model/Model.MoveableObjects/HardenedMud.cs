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
        public HardenedMud(Tile location, Game game) : base(location, game)
        {
            DrawChar = 'H';
            Location = location;
        }

        public override void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
