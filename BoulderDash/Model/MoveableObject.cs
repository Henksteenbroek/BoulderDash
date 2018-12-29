using BoulderDash.Controller;
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
        public Game game;
        public Tile Location { get; set; }
        public bool IsRound { get; set; }
        public char DrawChar { get; set; }

        public MoveableObject(Tile location, Game game)
        {
            Location = location;
            this.game = game;
        }

        public virtual void move(int direction)
        {
        }
    }
}
