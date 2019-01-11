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
            Supportive = false;
            CanExplode = true;
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
    }
}
