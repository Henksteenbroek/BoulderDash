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
        private bool IsDead;
        private Thread ExplodeTimer;

        public TNT(Game game) : base(game)
        {
            DrawChar = 'X';
            timer = 30;

            IsWalkable = true;
            IsRound = true;
            Destroyable = true;
            CanExplode = true;
            hasMoved = false;
            Supportive = false;
            GivesPoints = false;
            IsDead = false;

            ExplodeTimer = new Thread(AutoExplode);
            ExplodeTimer.Start();
        }

        public override bool move()
        {
            if (IsDead)
                return false;

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

        public override bool Explode()
        {
            IsDead = true;
            return base.Explode();
        }
    }
}
