﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.GameObjects
{
    public class Exit : GameObject
    {
        public char drawChar = 'E';
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }
    }
}