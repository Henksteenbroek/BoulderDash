using BoulderDash.Model.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model
{
    public abstract class MoveableObject
    {
        Tile Location { get; set; }
        bool IsRound { get; set; }
        char DrawChar { get; set; }

        public virtual void move(int direction)
        {
        }
    }
}
