using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Boulder : Rollable
    {
        public Boulder(Game game) : base(game)
        {
            DrawChar = 'B';
            IsRound = true;
        }

      
    }
}
