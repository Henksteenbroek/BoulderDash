using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Explosive : Rollable
    {
        public Explosive(Game game) : base(game)
        {
            DrawChar = 'X';
            IsRound = true;
        }
    }
}
