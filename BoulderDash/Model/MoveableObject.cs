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
        public Tile Location { get; set; }
        public bool IsRound { get; set; }
        public char DrawChar { get; set; }

        public MoveableObject(Tile location)
        {
            Location = location;
        }

        public virtual void move(int direction)
        {
        }
    }
}
