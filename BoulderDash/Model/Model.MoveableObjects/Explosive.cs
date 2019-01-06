using BoulderDash.Controller;
using BoulderDash.Model.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Explosive : Rollable
    {

        private int timer;
        private bool hasMoved;

        public Explosive(Game game) : base(game)
        {
            DrawChar = 'X';
            IsWalkable = true;
            IsRound = true;
            timer = 90;
            hasMoved = false;
        }

        public override bool move()
        {
            AutoExplode();

            if (base.move())
            {
                hasMoved = true;
                return true;
            }

            if(hasMoved && !base.move())
            {
                Explode();
            }

            return false;
        }

        public void AutoExplode()
        {
            timer--;
            if(timer <= 0)
            {
                Explode();
            }
        }

        public void Explode()
        {
            Location.StaticObject = new Empty(null);
        }
    }
}
