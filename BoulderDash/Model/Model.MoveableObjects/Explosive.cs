﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Explosive : MoveableObject
    {
        public char drawChar = 'T';
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }

        public override void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
