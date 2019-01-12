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
        public bool Supportive { get; set; }
        public bool CanExplode { get; set; }
        public bool GivesPoints { get; set; }
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

        public virtual bool Explode()
        {
            Tile temp = Location.Left.Up;
            Tile target = temp;
            while (target != Location.Right.Down)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (target.StaticObject.moveableObject?.Destroyable == true)
                    {
                        if (target == game.Rockford?.Location)
                        {
                            target.StaticObject.moveableObject.Explode();
                        }
                        game.tempList.Remove(target.StaticObject.moveableObject);
                        target.StaticObject.moveableObject = null;
                    }

                    if (target.StaticObject.Destroyable)
                    {
                        target.StaticObject = new Empty(null);
                    }

                    if (target != Location.Right.Down)
                        target = target.Right;
                }

                if (temp != Location.Down.Left)
                {
                    temp = temp.Down;
                    target = temp;
                }
            }
            game.tempList.Remove(this);
            Location.StaticObject.moveableObject = null;
            Location.StaticObject = new Empty(null);
            return true;
        }
    }
}
