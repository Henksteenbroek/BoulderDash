using BoulderDash.Controller;
using BoulderDash.Model.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class TNT : Rollable
    {

        private int timer;
        private bool hasMoved;
        private Thread ExplodeTimer;

        public TNT(Game game) : base(game)
        {
            DrawChar = 'X';
            IsWalkable = true;
            IsRound = true;
            timer = 30;
            hasMoved = false;
            Destroyable = true;
            ExplodeTimer = new Thread(AutoExplode);
            ExplodeTimer.Start();
        }

        public override bool move()
        {
            if (base.move())
            {
                hasMoved = true;
                return true;
            }

            if (hasMoved && !base.move())
            {
                Explode();
            }

            return false;
        }

        public void AutoExplode()
        {
            while (timer > 0)
            {
                timer--;
                Thread.Sleep(1000);
            }
            Explode();
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
                        if (target == game.Rockford?.Location)
                        {
                            game.Rockford = null;
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
            Location.StaticObject = new Empty(null);
        }
    }
}
