﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Boulder : MoveableObject
    {
        public Boulder()
        {
            DrawChar = 'B';
        }

        public override void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
