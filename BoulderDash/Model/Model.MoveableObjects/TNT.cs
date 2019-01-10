using BoulderDash.Controller;
using BoulderDash.Model.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class TNT : Rollable
    {

        private int timer;
        private bool hasMoved;
        private bool hasExploded;

        public TNT(Game game) : base(game)
        {
            DrawChar = 'X';
            IsWalkable = true;
            IsRound = true;
            timer = 90;
            hasMoved = false;
            hasExploded = false;
            Destroyable = true;
        }

        public override bool move()
        {
            if (!hasExploded)
            {
                AutoExplode();

                if (base.move())
                {
                    hasMoved = true;
                    return true;
                }

                if (hasMoved && !base.move())
                {
                    Explode();
                }
            }

            return false;
        }

        public void AutoExplode()
        {
            timer--;
            if (timer <= 0)
            {
                Explode();
            }
        }

        public void Explode()
        {
            Tile temp = Location.Left.Up;
            Tile target = temp;
            while (target != Location.Right.Down)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (target.StaticObject.moveableObject?.Destroyable == true)
                    {
                        //game.moveableObjects.Remove(target.StaticObject.moveableObject);
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
            hasExploded = true;
            Location.StaticObject = new Empty(null);
        }
    }
}
