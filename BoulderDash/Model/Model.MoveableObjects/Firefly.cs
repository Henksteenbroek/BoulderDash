﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Firefly : MoveableObject
    {
        public Firefly(Tile location) : base(location)
        {
            DrawChar = 'F';
            Location = location;
        }

        public override void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
