using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Explosive : MoveableObject
    {
        public Explosive(Tile location, Game game) : base(location, game)
        {
            DrawChar = 'X';
            Location = location;
        }

        public override void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
