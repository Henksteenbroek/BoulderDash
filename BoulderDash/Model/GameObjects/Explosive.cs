﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.GameObjects
{
    public class Explosive : GameObject
    {
        public char drawChar = 'T';
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }
    }
}