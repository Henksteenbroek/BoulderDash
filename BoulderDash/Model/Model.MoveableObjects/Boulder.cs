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
        }

        public override void move()
        {
            Tile target = Location.Down;

            //target.StaticObject.moveableObject = this;
            //Location.StaticObject.moveableObject = null;
            //Location = target;
        }
    }
}
