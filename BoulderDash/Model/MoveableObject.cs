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
        public bool IsWalkable { get; set; }
        public bool IsPushable { get; set; }
        public bool Destroyable { get; set; }
        public char DrawChar { get; set; }

        public MoveableObject(Game game)
        {
            this.game = game;
        }

        public virtual bool move(int direction)
        {
            return false;
        }

        public virtual bool move()
        {
            return false;
        }
    }
}
